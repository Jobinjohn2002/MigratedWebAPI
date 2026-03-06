using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class MLDLoanerSwitcherooHelper
    {
        private readonly static TurnAroundEventTypeIdentifier?[] SPDStartEventTypes = new TurnAroundEventTypeIdentifier?[] {
            TurnAroundEventTypeIdentifier.Inbound,
            TurnAroundEventTypeIdentifier.Wash,
            TurnAroundEventTypeIdentifier.AvailableForCollection,
            TurnAroundEventTypeIdentifier.AssignToBatchTag,
            TurnAroundEventTypeIdentifier.DeconStart,
        };

        /// <summary>
        /// Attempts to execute a "switcheroo" if all conditions are met.
        /// A switcheroo simply archives the current container instance, and unarchives another with the same instance name,
        /// where the other is for a later loaner loan kit request, potentially for a different customer.
        /// This is neccesary to prevent having mulitple active instances sharing the same identifer to prevent the "duplicate barcode" warning.
        /// </summary>
        /// <summary>
        /// CheckAndApplySwitcheroo operation
        /// </summary>
        public static bool CheckAndApplySwitcheroo(Turnaround turnaround, ContainerInstance containerInstance, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (!SPDStartEventTypes.Contains(scanDC.EventTypeId))
            {
                return false;
            }

            if (turnaround == null)
            {
                return false;
            }

            if (containerInstance == null)
            {
                containerInstance = turnaround.ContainerInstance;
            }

            if (!containerInstance.IsALoanerInstance())
            {
                return false;
            }

            var lastEvent = turnaround.TurnaroundEvent.Where(te => te.Workflow != null).OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault();
            var isLastEventEnded = lastEvent?.Workflow.IsEnd == true;
            var hasLoadTrolley = turnaround.TurnaroundEvent.Any(a => a.EventTypeId == (short)TurnAroundEventTypeIdentifier.LoadTrolleyEPOC);

            if (!isLastEventEnded && !hasLoadTrolley)
            {
                return false;
            }

            var pendingArchivedInstance = GetNextLoanerInstanceToProccess(containerInstance.PrimaryId, (short)scanDC.FacilityId, out var missedLinesToEmail);
            if (pendingArchivedInstance == null)
            {
                return false;
            }

            var deliveryPointId = pendingArchivedInstance.DeliveryPointId;
            var containerMasterId = pendingArchivedInstance.ContainerMasterId;
            var itemTypeId = pendingArchivedInstance.ItemTypeId;

            var unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork();

            var workflowRepository = WorkflowRepository.New(unitOfWork);
            var startEventWorkflow = workflowRepository.ReadWorkflow(null, (int)scanDC.EventTypeId, itemTypeId, scanDetails.FacilityId, containerMasterId, deliveryPointId);
            var isStartEvent = startEventWorkflow != null;
            if (!isStartEvent)
            {
                return false;
            }

            if (hasLoadTrolley)
            {
                EndCurrentTurnaround(scanDC, scanDetails, turnaround);
            }
            ArchiveInstance(containerInstance.ContainerInstanceId, scanDC.UserId, unitOfWork);
            UnarchiveInstance(pendingArchivedInstance.ContainerInstanceId, unitOfWork);

            EmailAboutMissedLines((short)scanDC.FacilityId, missedLinesToEmail, pendingArchivedInstance);

            return true;
        }

        private static bool IsALoanerInstance(this IContainerInstance containerInstance)
        {
            using (var repository = InstanceFactory.GetInstance<IPathwayRepository>())
            {
                return repository.Container.LoanSetContents.Any(a =>
                    a.InstanceId == containerInstance.ContainerInstanceId &&
                    a.LoanSet.LoanSetExternalReference.Count > 0 &&
                    a.LoanSet.LoanSetExternalReference.FirstOrDefault().ExternalReferenceTypeId == (short)ExternalReferenceTypeIdentifier.SPM
                );
            }
        }

        private static void ArchiveInstance(int containerInstanceId, int userId, IUnitOfWork unitOfWork)
        {
            var data = DataAdapterFactory.GetContainerInstanceDataAdapter(unitOfWork);
            data.ArchiveContainerInstance(containerInstanceId, userId);

            CheckArchiveCM(containerInstanceId, unitOfWork);
            CheckArchiveLKR(containerInstanceId, unitOfWork);
        }

        private static void UnarchiveInstance(int containerInstanceId, IUnitOfWork unitOfWork)
        {
            var data = DataAdapterFactory.GetContainerInstanceDataAdapter(unitOfWork);
            data.UnarchiveContainerInstance(containerInstanceId);
        }

        private static void EndCurrentTurnaround(ScanAssetDataContract scanDC, ScanDetails scanDetails, Turnaround turnaround)
        {
            const TurnAroundEventTypeIdentifier endEventToApply = TurnAroundEventTypeIdentifier.ReceivedForAnotherLoanKit;

            var previousScanDCTurnaroundEvents = scanDC.TurnaroundEvents;
            var previousAsset = scanDC.Asset;
            var previousLastProccessEventTypeId = scanDC.LastProcessEventTypeId;
            var previousTurnaroundId = scanDC.TurnaroundId;
            var previousDeliveryPointId = scanDC.DeliveryPtId;

            scanDC.TurnaroundEvents = new List<DataContracts.TurnaroundEventDataContract>();
            scanDC.Asset = new AssetDetailsDataContract
            {
                ContainerMasterId = turnaround.ContainerMasterId,
                ItemTypeId = turnaround.ContainerMaster.ItemTypeId
            };
            scanDC.LastProcessEventTypeId = (TurnAroundEventTypeIdentifier?)turnaround.CurrentTurnaroundEvent.EventTypeId;
            scanDC.TurnaroundId = turnaround.TurnaroundId;
            scanDC.DeliveryPtId = turnaround.DeliveryPointId;
            using (var applyEvent = InstanceFactory.GetInstance<IApplyEvent>())
            {
                applyEvent.Setup(null, scanDC.UserId, (short)scanDC.FacilityId, scanDC.StationTypeId, scanDC.StationId);
                var eventToApply = new List<ApplyTurnaroundEventDetails>
                    {
                        new ApplyTurnaroundEventDetails {
                            EventType = endEventToApply
                        }
                    };
                applyEvent.ApplyEvents(eventToApply, new List<ScanAssetDataContract> { scanDC }, scanDetails, true);
            }

            scanDC.TurnaroundEvents = previousScanDCTurnaroundEvents;
            scanDC.Asset = previousAsset;
            scanDC.LastProcessEventTypeId = previousLastProccessEventTypeId;
            scanDC.TurnaroundId = previousTurnaroundId;
            scanDC.DeliveryPtId = previousDeliveryPointId;
        }

        private static MLDDuplicateInstancesModel GetNextLoanerInstanceToProccess(string containerInstanceBarcode, short facilityId, out IEnumerable<MLDDuplicateInstancesModel> missedLinesToEmail)
        {
            var loanKitLines = new List<MLDDuplicateInstancesModel>();
            var ignoredLoanKitStatus = new short[] { (short)LoanSetStatusTypeIdentifier.Archived, (short)LoanSetStatusTypeIdentifier.Cancelled };

            {
                loanKitLines.AddRange(repository.DataManager.ExecuteQuery((row, table, set) =>
                    new MLDDuplicateInstancesModel
                    {
                        IsCurrentlyAtSPD = Convert.ToBoolean(row["IsCurrentlyAtSPD"]),
                        HasBeenToCustomer = Convert.ToBoolean(row["HasBeenToCustomer"]),
                        EarliestProcedureDate = Convert.ToDateTime(row["EarliestProcedureDate"]),
                        ContainerInstanceId = Convert.ToInt32(row["ContainerInstanceId"]),
                        ContainerInstanceExternalId = Convert.ToString(row["ContainerInstanceExternalId"]),
                        ContainerMasterId = Convert.ToInt32(row["ContainerMasterId"]),
                        DeliveryPointId = Convert.ToInt32(row["DeliveryPointId"]),
                        ItemTypeId = Convert.ToInt32(row["ItemTypeId"]),
                        LoanStatusId = Convert.ToInt16(row["LoanStatusId"]),
                        LoanKitExternalId = Convert.ToString(row["LoanKitExternalId"]),
                        MinimumReprocessingTime = Convert.ToString(row["MinimumReprocessingTime"])
                    },
                    "dbo.MLD_GetDuplicateInstances",
                    CommandType.StoredProcedure,
                    new SqlParameter("Barcode", containerInstanceBarcode)
                ));
            }

            loanKitLines = loanKitLines.Where(a => !ignoredLoanKitStatus.Contains(a.LoanStatusId)).ToList();
            var missedLines = FilterMissedLines(loanKitLines, FacilitySettings.LoanSetAPIMinimumTrayReprocessingTimeMinutes(facilityId));
            missedLinesToEmail = missedLines.Where(a => !loanKitLines.Any(b => (b.EarliestProcedureDate > a.EarliestProcedureDate) && (b.HasBeenToCustomer || b.IsCurrentlyAtSPD)));

            return loanKitLines.Except(missedLines).Where(a => !a.HasBeenToCustomer).OrderBy(a => a.EarliestProcedureDate).FirstOrDefault();
        }

        private static IEnumerable<MLDDuplicateInstancesModel> FilterMissedLines(IEnumerable<MLDDuplicateInstancesModel> lines, int facilityMinimumReprocessingTime)
        {
            foreach (var line in lines)
            {
                var earliestPossibleStartDate = DateTime.UtcNow.AddMinutes(line.MinimumReprocessingTimeParsed ?? facilityMinimumReprocessingTime);
                if (line.EarliestProcedureDate < earliestPossibleStartDate)
                {
                    yield return line;
                }
            }
        }

        private static void EmailAboutMissedLines(short facilityId, IEnumerable<MLDDuplicateInstancesModel> missedLinesToEmail, MLDDuplicateInstancesModel nextLineToProccess)
        {
            if (!missedLinesToEmail.Any())
            {
                return;
            }

            string facilityEmailAddress;
            {
                facilityEmailAddress = repository.Container.Facility.FirstOrDefault(a => a.FacilityId == facilityId)?.EmailAddress;
            }

            if (string.IsNullOrEmpty(facilityEmailAddress))
            {
                return;
            }

            foreach (var missedLineToEmail in missedLinesToEmail)
            {
                var subject = $"Missed Loaner Request: Skipped { missedLineToEmail.ContainerInstanceExternalId } on { missedLineToEmail.LoanKitExternalId }";
                var emailModel = new MLDMissedLoanKitLineModel
                {
                    MissedContainerInstanceExternalId = missedLineToEmail.ContainerInstanceExternalId,
                    MissedLoanKitExternalId = missedLineToEmail.LoanKitExternalId,
                    NextLoanKitExternalId = nextLineToProccess?.LoanKitExternalId,
                };
                EmailHelper.SendEmail("MLD_MissedLoanKitLine.cshtml", emailModel, SystemSettings.DefaultFromEmailAddress, facilityEmailAddress, subject, SystemSettings.SMTPHost, SystemSettings.SMTPPort);
            }
        }

        /// <summary>
        /// If the provided turnaroundID is associated to a loaner loan kit request, and it has already
        /// been to the customer, then we archive the CI and CM, and archive the LKR if possible.
        /// </summary>
        /// <summary>
        /// DeliveryNotePrintCleanup operation
        /// </summary>
        public static void DeliveryNotePrintCleanup(int turnaroundId, int userId, IUnitOfWork unitOfWork = null)
        {
            if (unitOfWork == null)
            {
                unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork();
            }

            var turnaroundRepo = TurnaroundRepository.New(unitOfWork);
            var turnaround = turnaroundRepo.Get(turnaroundId);
            if (turnaround.ContainerInstance == null)
                return;

            if (!turnaround.ContainerInstance.IsALoanerInstance())
            {
                return;
            }

            if (turnaround.ContainerInstance.Turnaround.Where(a => a.TurnaroundId != turnaround.TurnaroundId).Any(a => a.TurnaroundEvent.Any(b => b.EventTypeId == (short)TurnAroundEventTypeIdentifier.DeliveryNotePrint)))
            {
                var data = DataAdapterFactory.GetContainerInstanceDataAdapter(unitOfWork);
                data.ArchiveContainerInstance(turnaround.ContainerInstanceId.Value, userId);
                CheckArchiveCM(turnaround.ContainerInstanceId.Value, unitOfWork);
                CheckArchiveLKR(turnaround.ContainerInstanceId.Value, unitOfWork);
            }
        }

        /// <summary>
        /// CheckArchiveCM operation
        /// </summary>
        public static bool CheckArchiveCM(int containerInstanceId,IUnitOfWork workUnit)
        {
            var ciRepo = new ContainerInstanceRepository(workUnit);

            var thisCi = ciRepo.Get(containerInstanceId);
            var thisCM = thisCi.ActiveContainerMaster;

            var thisCIs = ciRepo.GetAllByContainerMasterDefinitionAndFacilityId(thisCM.ContainerMasterDefinitionId, thisCi.FacilityId);
            
            var firstCM = thisCi.ContainerMasters.FirstOrDefault(cm => cm.Revision == 1);
            if (firstCM != null && thisCIs.All(ci => ci.Archived != null))
            {
                thisCM.Archived = DateTime.UtcNow;
                thisCM.ArchivedUserId = firstCM.CreatedUserId;
                CheckArchiveIM(firstCM);
                ciRepo.Save();
                return true ;
            }

            return false;
        }

        /// <summary>
        /// CheckArchiveIM operation
        /// </summary>
        public static bool CheckArchiveIM(ContainerMaster firstRevisionContainerMaster)
        {
            var archived = false;
            foreach(var cc in firstRevisionContainerMaster.ContainerContents)
            {
                var itemMaster = cc.ItemMasterDefinition?.CurrentItemMaster;

                if (itemMaster != null)
                {
                    itemMaster.ItemStatusId = (byte)ItemStatusTypeIdentifier.Archived;
                    archived = true;
                }

            }
            return archived;

        }

        /// <summary>
        /// CheckArchiveLKR operation
        /// </summary>
        public static bool CheckArchiveLKR(int containerInstanceId,IUnitOfWork workUnit)
        {
            var lkcRepo = new LoanSetContentsRepository(workUnit);
            var thisLkc = lkcRepo.GetContentsByInstanceId(containerInstanceId);
            var thisLs = thisLkc.LoanSet;
            var allLkc = thisLs.LoanSetContents;
            if (allLkc.All(lkc => lkc.ContainerInstance.Archived != null))
            {
                thisLkc.LoanSet.LoanStatusId = (short)LoanSetStatusTypeIdentifier.Archived;
                thisLkc.LoanSet.LoanSetAuditHistory.Add(
                    LoanSetAuditHistoryFactory.CreateEntity(
                        workUnit,
                        loanSetId: thisLs.LoanSetId,
                        createdUserId: thisLs.AuditUserId,
                        created: DateTime.UtcNow,
                        loanSetStatusId: thisLs.LoanStatusId
                    )
                );
                lkcRepo.Save();
                return true;
            }

            return false;
        }
    }
}
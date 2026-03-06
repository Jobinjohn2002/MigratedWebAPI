using SynergyApplicationFrameworkApi.Application.DTOs.Data;
using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using SynergyApplicationFrameworkApi.Application.Services.TurnaroundProcessing;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ReportTypeIdentifier = Synergy.LabelPrinting.Enums.ReportTypeIdentifier;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {
        private static void AddWorkflowInfoToScanResult(ScanAssetDataContract dataContract)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var workflowRepository = WorkflowRepository.New(workUnit);
                var workflow = workflowRepository.ReadNextEvents((int?)dataContract.LastProcessEventTypeId, dataContract.Asset.ItemTypeId, dataContract.FacilityId, dataContract.Asset.ContainerMasterId, dataContract.DeliveryPtId).ToList();

                var eventTypes = workflow.Select(workflowEventType => new EventTypeDataContract()
                {
                    EventTypeId = workflowEventType.EventTypeId
                }).ToList();

                dataContract.PossibleNextEvents = eventTypes;
            }
        }

        /// <summary>
        /// Scan operation
        /// </summary>
        public void Scan(ScanDetails scanDetails, ScanAssetDataContract scanDC)
        {
            Log.Info("Start Scan");
            _synergyTrakData.StationTypeId = scanDetails.StationTypeId;
            _synergyTrakData.StationId = scanDetails.StationId;
            _synergyTrakData.FacilityId = scanDetails.FacilityId;
            _synergyTrakData.UserId = scanDetails.UserId;
            _machineTypeId = scanDetails.MachineTypeId;
            _ignoreNotesWarningsAndDecon = scanDetails.IgnoreNotesWarningsAndDecon;
            _synergyTrakData.IsRemoveFromParent = scanDetails.IsRemoveFromParent;
            _synergyTrakData.KeepBatchTagTogetherRequested = scanDetails.IsKeepFailedBatchTogether ?? false;
            _synergyTrakData.FailureTypeId = (byte?)scanDetails.FailureReason;

            if (scanDetails.Events.Count > 0)
            {
                scanDC.EventTypeId = (TurnAroundEventTypeIdentifier)scanDetails.Events.First().EventType;
            }
            if (scanDetails.Events.FirstOrDefault()?.EventType == (int)TurnAroundEventTypeIdentifier.AuditStarted)
            {
                {
                    var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                    Turnaround turnaround;

                    if (scanDetails.InstanceId.HasValue)
                    {
                        turnaround = containerInstanceRepository.GetLastTurnaroundByInstance(scanDetails.InstanceId.Value);
                    }
                    else
                    {
                        turnaround = containerInstanceRepository.GetLastTurnaroundByExternalOrAlternateId(scanDetails.ExternalId);
                    }

                    if (turnaround == null || turnaround.TurnaroundEvent.Any(te => te.Workflow != null && te.Workflow.IsEnd))
                    {
                        scanDetails.Events.Insert(0,
                            new ScanEventDataContract
                            {
                                EventType = (int)TurnAroundEventTypeIdentifier.AutomaticStart
                            });
                    }
                }
            }

            scanDC.ScannedString = scanDetails.ExternalId;
            scanDC.BatchId = scanDetails.BatchId;
            scanDC.FacilityId = scanDetails.FacilityId;
            scanDC.StationTypeId = scanDetails.StationTypeId;
            scanDC.StationTypeCategoryId = scanDetails.StationTypeCategoryId;
            scanDC.UserId = scanDetails.UserId;
            scanDC.Reports = new List<ReportDataContract>();
            scanDC.PinReasonId = scanDetails.PinReason;
            if (scanDetails.DeliveryPointId.HasValue)
            {
                scanDC.DeliveryPtId = scanDetails.DeliveryPointId.Value;
            }

            if (scanDetails.StationId.HasValue)
            {
                scanDC.StationId = scanDetails.StationId.Value;
                scanDC.LocationId = scanDetails.StationLocationId;
                scanDC.ApprovedByUserId = scanDetails.ApprovedByUserId;
                scanDC.ApprovedByUserPinReasonId = scanDetails.ApprovedByUserPinReasonId;

                if (scanDetails.Events.Count > 0 && scanDetails.Events.First().EventType != (int)TurnAroundEventTypeIdentifier.ReprintLabel)
                {
                    _synergyTrakData.EventTypeId = (TurnAroundEventTypeIdentifier)scanDetails.Events.First().EventType;

                    {
                        var eventTypeRepository = EventTypeRepository.New(workUnit);
                        var eventTypeRow = eventTypeRepository.Get((int)_synergyTrakData.EventTypeId);

                        if (eventTypeRow != null)
                        {
                            _isProcessEvent = eventTypeRow.ProcessEvent;

                            if (scanDetails.TurnaroundId.HasValue) // Used on existing turnaround where we know turnaround id.
                            {
                                ScanByTurnaroundId(scanDetails, scanDC);
                            }
                            else if (scanDetails.TurnaroundExternalId.HasValue) // Scanning external turnaround id.
                            {
                                ScanByTurnaroundExternalId(scanDetails, scanDC);
                            }
                            else if (scanDetails.InstanceId.HasValue) // Used when user has picked a container instance >1
                            {
                                ScanByInstanceId(scanDetails, scanDC);
                            }
                            else if (!string.IsNullOrEmpty(scanDetails.ExternalId) || !string.IsNullOrEmpty(scanDetails.ContainerInstancePrimaryId)) // scanning of container external id.
                            {
                                if (!string.IsNullOrEmpty(scanDetails.ContainerInstancePrimaryId))
                                {
                                    scanDetails.ExternalId = scanDetails.ContainerInstancePrimaryId;
                                }
                                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToTransferNote)
                                {
                                    ScanByTurnaroundOrItemExternalId(scanDetails, scanDC);
                                }
                                else
                                {
                                    ScanByInstanceIdentifier(scanDetails, scanDC);
                                }
                            }
                            else if (scanDetails.DeliveryNoteExternalId.HasValue)
                            {
                                ScanByDeliveryNoteId(scanDetails, scanDC);
                            }
                            else
                            {
                                scanDC.ErrorCode = (int)ErrorCodes.InvalidItem;
                            }
                        }
                        else
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.EventDoesNotExist;
                        }
                    }
                }
                else
                {
                    if (scanDetails.Events.Count > 0)
                    {
                        _synergyTrakData.EventTypeId = (TurnAroundEventTypeIdentifier)scanDetails.Events.First().EventType;
                    }
                    if (scanDetails.TurnaroundId.HasValue) // Used on existing turnaround where we know turnaround id.
                    {
                        if ((scanDetails.Events == null || scanDetails.Events.Count == 0) && scanDetails.FulfillsDeconTask && scanDetails.BatchId.HasValue && scanDetails.MachineId.HasValue)
                        {
                            var bh = new BatchHelper();
                            scanDC.TurnaroundId = scanDetails.TurnaroundId;
                            bh.UpdateBatchDecontaminationTasks(scanDetails.BatchId.Value, scanDetails.TurnaroundId.Value, scanDetails.MachineId.Value, _synergyTrakData.UserId);
                        }
                        else
                        {
                            ScanByTurnaroundId(scanDetails, scanDC);

                            if (scanDetails.PrintDetails)
                            {
                                Printing.PrintUtility.PrintItemDetails(scanDetails, scanDC, ReportTypeIdentifier.EnquiryDetails);
                            }
                        }
                    }
                    else if (scanDetails.TurnaroundExternalId.HasValue)
                    {
                        ScanByTurnaroundExternalId(scanDetails, scanDC);
                    }
                    else if (scanDetails.InstanceId.HasValue) // Used when user has picked a container instance >1
                    {
                        ScanByInstanceId(scanDetails, scanDC);
                    }
                    else if (scanDetails.ContainerInstancePrimaryId != null)
                    {
                        scanDetails.ExternalId = scanDetails.ContainerInstancePrimaryId;
                        ScanByInstanceIdentifier(scanDetails, scanDC);
                    }
                    else
                    {
                        int turnaroundExternalId;
                        if (int.TryParse(scanDetails.ExternalId, out turnaroundExternalId))
                        {
                            scanDetails.TurnaroundExternalId = turnaroundExternalId;
                            ScanByTurnaroundExternalId(scanDetails, scanDC);

                            if (scanDC.ErrorCode == (int)ErrorCodes.InvalidTurnaround)
                            {
                                scanDC.ErrorCode = null;
                                ScanByInstanceIdentifier(scanDetails, scanDC);
                                Scanning.FailedScan.Add(scanDC.ScannedString, (short)Pathway.Enums.ScanType.Enquire, scanDC.UserId, scanDC.StationId, scanDC.LocationId, null);
                            }
                        }
                        else if (!string.IsNullOrEmpty(scanDetails.ExternalId))
                        {
                            ScanByInstanceIdentifier(scanDetails, scanDC);
                        }

                        if (scanDetails.PrintDetails)
                        {
                            Printing.PrintUtility.PrintItemDetails(scanDetails, scanDC, ReportTypeIdentifier.EnquiryDetails);
                        }
                    }
                }
                scanDC.RequestedEventType = _synergyTrakData.EventTypeId;

                if (scanDC.Asset != null && (scanDC.NonUniqueAssets == null ||
                            scanDC.NonUniqueAssets.Count == 0))
                {
                    AddWorkflowInfoToScanResult(scanDC); // can only get them if the return result is one single turnaround

                    if (scanDetails.IncludeWeighingInformation
                        && scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BatchTag
                        && scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Carriage
                        && scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Trolley
                        && scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BaseCarriage)
                    {
                        FillInWeighingInformation(scanDC);
                    }
                }
                else
                {
                    scanDC.PossibleNextEvents = new List<EventTypeDataContract>();
                }

                if (scanDC.TurnaroundId.HasValue)
                {
                    scanDC.IsQuarantineAfterWashAvailable = scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Endoscopy
                        && DoesTurnaroundHaveActiveServiceReports(scanDC.TurnaroundId.Value)
                        && IsTurnaroundPreWash(scanDC.TurnaroundId.Value);
                }

                Log.Info("Finish Scan");
                if (scanDC.ErrorCode == null
                    && _synergyTrakData.CanApplyEvent
                    && scanDC.Asset != null
                    && (scanDetails.Events.Any(et => et.EventType == (int)TurnAroundEventTypeIdentifier.AuditStarted)
                        || (scanDetails.Events.Any(et => et.EventType == (int)TurnAroundEventTypeIdentifier.StartPacking && scanDC.AuditRequiredForProccessing)))
                    )
                {
                    scanDC.Audit = new AuditDataContract();
                    Auditing.CreateAudit(scanDetails, scanDC);
                }
                if (scanDC.ErrorCode != null)
                {
                    TurnaroundProcessing.DeniedTurnaroundEvent.Log(scanDC);
                }
            }
        }

        private void FillInWeighingInformation(ScanAssetDataContract scanDc)
        {
            {
                var customerRepository = CustomerRepository.New(workUnit);
                var cmdRepository = ContainerMasterDefinitionRepository.New(workUnit);

                var containerMasterDef = cmdRepository.All()
                    .FirstOrDefault(a => a.ContainerMasterDefinitionId == scanDc.Asset.ContainerMasterDefinitionId);

                var customerOnStop = customerRepository.Repository.Find(i => i.CustomerDefinitionId == containerMasterDef.CustomerDefinitionId).OrderByDescending(j => j.Revision).FirstOrDefault().CustomerStatusId == (int)CustomerStatusTypeIdentifier.Stop;

                if (customerOnStop)
                {
                    scanDc.ErrorCode = (int?)ErrorCodes.CustomerOnStop;
                    return;
                }

                ContainerInstance ci = null;
                if (scanDc.Asset.ContainerInstanceId != null)
                {
                    var cir = ContainerInstanceRepository.New(workUnit);
                    ci = cir.Get((int)scanDc.Asset.ContainerInstanceId);
                }

                if (scanDc.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag ||
                    scanDc.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Carriage ||
                    scanDc.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley ||
                    scanDc.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BaseCarriage)
                {
                    scanDc.ErrorCode = (int)ErrorCodes.InvalidItemType;
                    return;
                }

                var ciwr = ContainerInstanceWeightRepository.New(workUnit);
                var ciw = ciwr.All().FirstOrDefault(a => a.ContainerInstanceId == scanDc.Asset.ContainerInstanceId);

                if (ciw == null)
                {
                    scanDc.Asset.PreWashRefWeightKg = 0M;
                    scanDc.Asset.PostWashRefWeightKg = 0M;
                    scanDc.Asset.WeighingRequiredForPostWash = true;
                    scanDc.Asset.WeighingRequiredForPreWash = true;
                }
                else
                {
                    scanDc.Asset.PreWashRefWeightKg = ciw.PreWashRefWeightKg;
                    scanDc.Asset.PostWashRefWeightKg = ciw.PostWashRefWeightKg;

                    if (ciw.RequiresApproval)
                    {
                        scanDc.Asset.WeighingRequiredForPreWash = (ciw.ApprovedPreWashWeightId.GetValueOrDefault() == 0);
                        scanDc.Asset.WeighingRequiredForPostWash = (ciw.ApprovedPostWashWeightId.GetValueOrDefault() == 0);
                    }
                }

                scanDc.Asset.InstrumentsToWeigh = GetInstrumentsToWeigh(scanDc);

                var tr = TurnaroundRepository.New(workUnit);
                var ter = TurnaroundEventRepository.New(workUnit);
                var tewr = TurnaroundEventWeightRepository.New(workUnit);

                var eventTypes =
                    (from t in tr.All()
                     join te in ter.All() on t.TurnaroundId equals te.TurnaroundId
                     join tew in tewr.All() on te.TurnaroundEventId equals tew.TurnaroundEventId
                     where t.ContainerInstanceId == scanDc.Asset.ContainerInstanceId &&
                             (te.EventTypeId == (short)TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances ||
                             te.EventTypeId == (short)TurnAroundEventTypeIdentifier.WeighedUsingPostWashTolerances)
                             && tew.WeightStatusId != (int)WeightStatus.Cancelled
                     select te.EventTypeId).Distinct();

                if (eventTypes.Any(a => a == (short)TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances))
                {
                    scanDc.Asset.HasBeenPreWashWeighed = true;
                }

                if (eventTypes.Any(a => a == (short)TurnAroundEventTypeIdentifier.WeighedUsingPostWashTolerances))
                {
                    scanDc.Asset.HasBeenPostWashWeighed = true;
                }
                if (!scanDc.Asset.WeighingRequired && ci != null)
                {
                    scanDc.Asset.WeighingRequired = ci.WeighingRequired;
                }
                if (scanDc.TurnaroundEvents != null)
                {
                    var lastWeighingPreWashToleranceEvent = scanDc.TurnaroundEvents.Where(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances).OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault();
                    var lastWeighingPostWashToleranceEvent = scanDc.TurnaroundEvents.Where(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.WeighedUsingPostWashTolerances).OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault();
                    if (lastWeighingPreWashToleranceEvent != null || lastWeighingPostWashToleranceEvent != null)
                    {
                        if (lastWeighingPreWashToleranceEvent != null)
                        {
                            var turnaroundeventWeightPreWashToleranceRecord = ter.Get(lastWeighingPreWashToleranceEvent.TurnaroundEventId).TurnaroundEventWeight;
                            if (turnaroundeventWeightPreWashToleranceRecord.FirstOrDefault().WeightStatusId == (int)WeightStatus.Cancelled)
                            {
                                scanDc.Asset.LastWeighingEventWasCancelledPreWash = lastWeighingPreWashToleranceEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances;
                            }
                        }

                        if (lastWeighingPostWashToleranceEvent != null)
                        {
                            var turnaroundeventWeightPostWashToleranceRecord = ter.Get(lastWeighingPostWashToleranceEvent.TurnaroundEventId).TurnaroundEventWeight;
                            if (turnaroundeventWeightPostWashToleranceRecord.FirstOrDefault().WeightStatusId == (int)WeightStatus.Cancelled)
                            {
                                scanDc.Asset.LastWeighingEventWasCancelledPostWash = lastWeighingPostWashToleranceEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.WeighedUsingPostWashTolerances;
                            }
                        }
                    }
                }
            }
        }

        private static int GetInstrumentsToWeigh(ScanAssetDataContract scanDc)
        {
            try
            {
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("ContainerInstanceId", scanDc.Asset.ContainerInstanceId)
                };

                var items = ComponentItemHelper.GetComponentItems("ReadComponentsListByContainerInstance", parameters);

                    var reusableItems =
                        items.Where(a => BaseTypeIdentifier.GetIdentifier(a.BaseItemTypeName) == BaseTypeIdentifier.Reusable
                            && a.ChildItemTypeName == "Instrument"
                            && a.Category != CategoryIdentifier.Notes.ToString());

                    var reusableItemsCount = reusableItems.Sum(b => b.Quantity);

                var itemExceptionCount =
                    reusableItems.Sum(a => a.ItemExceptions.Where(i => i.ItemExceptionReason.RemovedFromContainer)
                        .Sum(b => b.ItemExceptionQuantity));

                return reusableItemsCount - itemExceptionCount;
            }
            catch
            {
                return 0; // represents unknown
            }
        }

        private void ScanByInstanceIdentifier(ScanDetails scanDetails, ScanAssetDataContract scanDC)
        {
            List<ContainerInstance> containers;

            {
                var containerRepository = ContainerInstanceRepository.New(workUnit);
                Log.Info("Get matching container instances");

                #region Check to see if we are processing a transfer note at inbound or outbound
                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Inbound || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.FacilityTransferOutbound)
                {
                    Log.Info("Check for transfernote scan at inbound/outbound");

                    var transferNoteRepository = TransferNoteRepository.New(workUnit);
                    var tn = transferNoteRepository.All().FirstOrDefault(t => t.ExternalId == scanDetails.ExternalId);

                    if (tn != null)
                    {
                        var facilityRepository = FacilityRepository.New(workUnit);
                        var facility = facilityRepository.Get(_synergyTrakData.FacilityId);
                        if (facility != null)
                        {
                            var trolley = containerRepository.Get(tn.Turnaround.ContainerInstanceId.GetValueOrDefault());

                            if (trolley != null)
                            {
                                scanDetails.ExternalId = null;
                                scanDetails.TurnaroundExternalId = tn.Turnaround.ExternalId;

                                ScanByTurnaroundExternalId(scanDetails, scanDC);
                                scanDC.ScannedString = tn.ExternalId;

                                return;
                            }
                        }
                    }
                }

                #endregion

                containers = containerRepository.PreSearchContainerInstance(scanDetails.ExternalId, scanDetails.FacilityId, ExludeTrolleyFromMFPByEvent(), _synergyTrakData.EventTypeId)
                    .Include(ci => ci.ContainerInstanceIdentifier)
                    .ToList();
            }

            scanDC.ScannedString = scanDetails.ExternalId;
            if (containers.Count > 0)
            {
                if (containers.Count == 1)
                {
                    ProcessContainer(containers[0], scanDetails, scanDC);
                }
                else if (containers.Count > 1)
                {
                    scanDC.NonUniqueAssets = new List<AssetDetailsDataContract>();

                    {
                        foreach (var container in containers)
                        {
                            scanDC.NonUniqueAssets.Add(CreateAssetDataContract(container, null, workUnit));
                        }
                    }
                }
            }
            else if (containers.Count == 0)
            {
                {
                    var containerRepository = ContainerInstanceRepository.New(workUnit);
                    var containerInstance = containerRepository.GetByPrimaryAndFacilityId(scanDetails.ExternalId, scanDetails.FacilityId);

                    if (containerInstance?.Archived != null)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.ArchivedContainerInstance;
                    }
                    else
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.InvalidItem;
                        Scanning.FailedScan.Add(scanDC.ScannedString, (short)Pathway.Enums.ScanType.ContainerInstance, scanDC.UserId, scanDC.StationId, scanDC.LocationId, (short?)scanDC.EventTypeId);

                    }
                }
            }
        }

        private void ScanByDeliveryNoteId(ScanDetails scanDetails, ScanAssetDataContract scanDC)
        {
            try
            {
                {
                    var deliveryNoteRepository = DeliveryNoteRepository.New(workUnit);
                    var turnaroundRepository = TurnaroundRepository.New(workUnit);
                    var deliveryNote = deliveryNoteRepository.ReadDeliveryNoteByExternalId(scanDetails.DeliveryNoteExternalId.Value, scanDetails.FacilityId);
                    if (deliveryNote == null)
                    {
                        var deliveryNoteById = deliveryNoteRepository.ReadDeliveryNoteByExternalId(scanDetails.DeliveryNoteExternalId.Value);
                        if (deliveryNoteById != null)
                        {
                            var turnaround = turnaroundRepository.GetAllTurnaroundsByDeliveryNoteId(deliveryNoteById.DeliveryNoteId).FirstOrDefault();

                            var trolleyTurnaround = turnaround?.ParentTurnaround;

                            if (trolleyTurnaround != null)
                            {
                                using (var trolleyDatabaseHelper = new TrolleyDatabaseHelper())
                                {
                                    if (trolleyDatabaseHelper.GetTrolleySummary(trolleyTurnaround?.ContainerInstance?.PrimaryId, scanDetails.FacilityId).Any(x => x.IsOwner || x.CanProcessForMFPCustomer))
                                    {
                                        deliveryNote = deliveryNoteById;
                                    }
                                }
                            } else
                            {
                                if(turnaround != null)
                                {
                                    deliveryNote = deliveryNoteById;
                                }
                            }

                        }
                    }

                    if (deliveryNote != null)
                    {
                        var turnarounds = turnaroundRepository.GetFromDeliveryNote(deliveryNote.DeliveryNoteId).OrderByDescending(t => t.ContainerInstanceId.HasValue);
                        scanDC.DeliveryNoteExternalId = deliveryNote.ExternalId.ToString();
                       
                        if (PreworkflowValidation(scanDC, scanDetails, false))
                        {
                            if (!HasAutomaticEventBeenApplied(scanDC))
                            {
                                var dt = new DataTable();
                                dt.Columns.Add("ID", typeof(int));
                                foreach (var turnaround in turnarounds)
                                {
                                    if (turnaround.ContainerInstanceId != null)
                                    {
                                        if (turnaround.ContainerInstance.CurrentTurnaround.TurnaroundId != turnaround.TurnaroundId)
                                            continue;
                                    }

                                    var saDc = new ScanAssetDataContract()
                                    {
                                        TurnaroundId = turnaround.TurnaroundId,
                                        Expiry = turnaround.Expiry,
                                        TurnaroundExternalId = turnaround.ExternalId,
                                        ServiceRequirementName = turnaround.ServiceRequirement.Text,
                                        DeliveryPtId = deliveryNote.DeliveryPointId,
                                        FacilityId = turnaround.FacilityId,
                                        LastProcessEventTypeId = (TurnAroundEventTypeIdentifier)turnaround.TurnaroundEvent.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventType.ProcessEvent).EventTypeId,
                                        TurnaroundEvents = new List<DataContracts.TurnaroundEventDataContract>(),
                                        StartTurnaroundEventId = turnaround.StartEventId,
                                        Asset = new AssetDetailsDataContract()
                                        {
                                            ItemTypeId = turnaround.ContainerMaster.ItemTypeId,
                                            BaseItemTypeText = turnaround.ContainerMaster.BaseItemType.Text,
                                            ContainerMasterName = turnaround.ContainerMaster.Text,
                                            ContainerInstancePrimaryId = turnaround.ContainerInstance?.PrimaryId
                                        }
                                    };

                                    foreach (var te in turnaround.TurnaroundEvent)
                                    {
                                        saDc.TurnaroundEvents.Add(new DataContracts.TurnaroundEventDataContract
                                        {
                                            EventTypeId = te.EventTypeId,
                                            TurnaroundEventId = te.TurnaroundEventId,
                                            StationId = te.StationId,
                                            CreatedUserId = te.CreatedUserId
                                        });
                                    }

                                    dt.Rows.Add(turnaround.TurnaroundId);
                                    _synergyTrakData.ScanDcList.Add(saDc);
                                }
                                using (var repository = new PathwayRepository())
                                {

                                    var list = repository.DataManager.ExecuteQuery<int>((row, table, set) =>
                                    {
                                        return Convert.ToInt32(row["TurnaroundId"]);
                                    },
                                    "dbo.Workflow_BulkRead",
                                    CommandType.StoredProcedure,
                                        new SqlParameter
                                        {
                                            ParameterName = "@Data",
                                            Value = dt,
                                            TypeName = "[dbo].[IDTable]",
                                            SqlDbType = SqlDbType.Structured
                                        },
                                        new SqlParameter
                                        {
                                            ParameterName = "@EventTypeToApply",
                                            Value = scanDetails.Events.First().EventType
                                        }
                                        );

                                    if (list.Count < _synergyTrakData.ScanDcList.Count)
                                    {
                                        var newSadcList = new List<ScanAssetDataContract>();
                                        foreach (var value in list)
                                        {
                                            foreach (var sadc in _synergyTrakData.ScanDcList)
                                            {
                                                if (sadc.TurnaroundId == value)
                                                {
                                                    newSadcList.Add(sadc);
                                                }
                                            }
                                        }

                                        _synergyTrakData.ScanDcList = newSadcList;
                                    }
                                }
                                if (_synergyTrakData.ScanDcList.Count > 0)
                                {
                                    List<ApplyTurnaroundEventDetails> eventsToApply = new List<ApplyTurnaroundEventDetails>
                                    {
                                        new ApplyTurnaroundEventDetails
                                        {
                                            EventType = scanDetails.Events?.First()?.EventType != null ? (TurnAroundEventTypeIdentifier)scanDetails.Events.First().EventType : TurnAroundEventTypeIdentifier.Unknown,
                                            DeliveryNoteId = deliveryNote.DeliveryNoteId,
                                            RemoveFromParent = false,
                                            ParentTurnaroundId = scanDetails.ParentTurnaroundId,
                                            LocationId = null,
                                            BatchId = null,
                                            IsEndTurnaround = false,
                                            IsAutomaticEvent = false,
                                        }
                                    };

                                    ApplyEvent(eventsToApply, _synergyTrakData.ScanDcList, scanDetails);

                                    scanDC.ChildItems = _synergyTrakData.ScanDcList;
                                }
                                else
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.AlreadyDelivered;
                                }
                            }
                        }
                        else
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.InvalidItem;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex, "ScanByDeliveryNoteId");
            }
        }

        private void ScanByInstanceId(ScanDetails scanDetails, ScanAssetDataContract scanDC)
        {
            ContainerInstance instance = null;

            if (scanDetails.InstanceId.HasValue)
            {
                {
                    var containerRepository = ContainerInstanceRepository.New(workUnit);
                    instance = containerRepository.Get(scanDetails.InstanceId.Value);
                }

                if (instance != null)
                {
                    ProcessContainer(instance, scanDetails, scanDC);
                }
                else
                {
                    short? eventId = null;
                    if (scanDC.EventTypeId.HasValue)
                    {
                        eventId = (short)scanDC.EventTypeId.Value;
                    }

                    Scanning.FailedScan.Add(scanDC.ScannedString, (short)Pathway.Enums.ScanType.ItemInstance, scanDC.UserId, scanDC.StationId, scanDC.LocationId, eventId);
                }
            }
        }

        private void ScanByTurnaroundExternalId(ScanDetails scanDetails, ScanAssetDataContract scanDC)
        {
            if (scanDetails.TurnaroundExternalId.HasValue)
            {
                scanDC.ScannedString = scanDetails.TurnaroundExternalId.Value.ToString();

                {
                    var turnaroundRepository = TurnaroundRepository.New(workUnit);
                    var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacilityId(scanDetails.TurnaroundExternalId.Value, _synergyTrakData.FacilityId);

                    if (turnaround != null)
                    {
                        ProcessTurnaround(turnaround, scanDC, scanDetails, null);
                    }
                    else
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.InvalidTurnaround;
                        if (scanDC.EventTypeId.HasValue)
                        {
                            Scanning.FailedScan.Add(scanDC.ScannedString, (short)Pathway.Enums.ScanType.Turnaround, scanDC.UserId, scanDC.StationId, scanDC.LocationId, (short)scanDC.EventTypeId.Value);
                        }
                    }
                }
            }
        }

        private void ScanByTurnaroundId(ScanDetails scanDetails, ScanAssetDataContract scanDC)
        {
            Turnaround turnaround = null;

            if (scanDetails.TurnaroundId.HasValue)
            {
                {
                    var turnaroundRepository = TurnaroundRepository.New(workUnit);
                    turnaround = turnaroundRepository.Get(scanDetails.TurnaroundId.Value);

                    if (turnaround != null)
                    {
                        ProcessTurnaround(turnaround, scanDC, scanDetails, null);
                        scanDC.ScannedString = scanDC.Asset.ContainerInstancePrimaryId;
                    }
                    else
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.InvalidTurnaround;
                        short? eventId = null;
                        if (scanDC.EventTypeId.HasValue)
                        {
                            eventId = (short)scanDC.EventTypeId.Value;
                        }

                        Scanning.FailedScan.Add(scanDC.ScannedString, (short)Pathway.Enums.ScanType.ContainerInstance, scanDC.UserId, scanDC.StationId, scanDC.LocationId, eventId);
                    }
                }
            }
        }

        private void ScanByTurnaroundOrItemExternalId(ScanDetails scanDetails, ScanAssetDataContract scanDC)
        {
            var turnaroundMatch = false;

            List<ContainerInstance> containers;
            Turnaround turnaround = null;
            var isExtra = false;

            {
                var containerRepository = ContainerInstanceRepository.New(workUnit);
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                Log.Info("Get matching container instances");
                containers = containerRepository.PreSearchContainerInstance(scanDetails.ExternalId, scanDetails.FacilityId, ExludeTrolleyFromMFPByEvent()).ToList();
                var instanceMatch = containers.Count > 0;
                Log.Info("Get matching turnaround");
                if (long.TryParse(scanDetails.ExternalId, out long turnaroundExternalId))
                {
                    turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacilityId(turnaroundExternalId, _synergyTrakData.FacilityId);

                    if (turnaround?.ContainerInstanceId != null)
                    {
                        var turnaroundContainer = containerRepository.PreSearchContainerInstance(turnaround.ContainerInstanceId.Value, scanDetails.FacilityId);
                        if (turnaroundContainer != null)
                        {
                            var latestTurnaround = containerRepository.GetLastLiveTurnaroundByInstance(turnaroundContainer.ContainerInstanceId);
                            if (latestTurnaround != null
                                && turnaround.TurnaroundId == latestTurnaround.TurnaroundId
                                && turnaround.CurrentTurnaroundEvent?.EventTypeId != (int)TurnAroundEventTypeIdentifier.Archived
                                && !containers.Contains(turnaroundContainer))
                            {
                                containers.Add(turnaroundContainer);
                                turnaroundMatch = true;
                            }
                        }
                    }
                    if (turnaround?.ContainerMasterId != null && turnaround.ContainerMaster.BaseItemType.ItemTypeId == (int)ItemTypeIdentifier.Extra)
                    {
                        turnaroundMatch = true;
                        isExtra = true;
                    }
                }

                scanDC.ScannedString = scanDetails.ExternalId;

                if (containers.Count == 1 || isExtra)
                {
                    if (instanceMatch)
                    {
                        ProcessContainer(containers[0], scanDetails, scanDC);
                    }
                    else if (turnaroundMatch)
                    {
                        ProcessTurnaround(turnaround, scanDC, scanDetails, null);
                    }
                }
            }
            if (containers.Count > 1)
            {
                scanDC.NonUniqueAssets = new List<AssetDetailsDataContract>();

                {
                    foreach (var container in containers)
                    {
                        scanDC.NonUniqueAssets.Add(CreateAssetDataContract(container, null, workUnit));
                    }
                }
            }
            else if (containers.Count == 0 && !isExtra)
            {
                {
                    var containerRepository = ContainerInstanceRepository.New(workUnit);
                    var containerInstance = containerRepository.GetByPrimaryAndFacilityId(scanDetails.ExternalId, scanDetails.FacilityId);

                    if (containerInstance?.Archived != null)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.ArchivedContainerInstance;
                    }
                    else
                    {
                        if (turnaround != null)
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.TurnaroundIsArchived;
                        }
                        else
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.InvalidItemOrTurnaround;
                        }
                        if (scanDC.EventTypeId.HasValue)
                        {
                            Scanning.FailedScan.Add(scanDC.ScannedString, (short)Pathway.Enums.ScanType.ContainerInstance, scanDC.UserId, scanDC.StationId, scanDC.LocationId, (short)scanDC.EventTypeId.Value);
                            Scanning.FailedScan.Add(scanDC.ScannedString, (short)Pathway.Enums.ScanType.Turnaround, scanDC.UserId, scanDC.StationId, scanDC.LocationId, (short)scanDC.EventTypeId.Value);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// BatchScan operation
        /// </summary>
        public void BatchScan(ScanDetails scanDetails, ScanAssetDataContract dataContract)
        {
            _synergyTrakData.StationTypeId = scanDetails.StationTypeId;
            _synergyTrakData.StationId = scanDetails.StationId;
            _synergyTrakData.FacilityId = scanDetails.FacilityId;
            _synergyTrakData.UserId = scanDetails.UserId;
            _ignoreNotesWarningsAndDecon = true;
            _synergyTrakData.StationLocationId = StationHelper.GetStationLocationId(scanDetails) ?? scanDetails.StationId;
            _synergyTrakData.KeepBatchTagTogetherRequested = scanDetails.IsKeepFailedBatchTogether ?? false;

            if (scanDetails.Events.Count > 0 && scanDetails.BatchId.HasValue)
            {
                _synergyTrakData.EventTypeId = (TurnAroundEventTypeIdentifier)scanDetails.Events.First().EventType;

                {
                    var batchRepository = BatchRepository.New(workUnit);
                    var teRepository = TurnaroundEventRepository.New(workUnit);
                    var cteRepository = CurrentTurnaroundEventRepository.New(workUnit);
                    var eventTypeRepository = EventTypeRepository.New(workUnit);

                    var eventTypeRow = eventTypeRepository.Get((int)_synergyTrakData.EventTypeId);
                    var batch = batchRepository.Get(scanDetails.BatchId.GetValueOrDefault());

                    if (eventTypeRow != null && batch != null)
                    {
                        _isProcessEvent = eventTypeRow.ProcessEvent;
                        var turnaroundIds = batch.TurnaroundEvent.Select(te => te.TurnaroundId).Distinct().ToList();
                        List<int> turnaroundIdsToIgnore = new List<int>();

                        foreach (var tId in turnaroundIds)
                        {
                            var v = cteRepository.GetLastProcessEventByTurnaroundId(tId);
                            var allEvents = teRepository.GetAllTurnaroundEventsByTurnaroundId(tId);
                            if (v?.BatchId == null || (scanDetails.BatchId.HasValue && v.BatchId != scanDetails.BatchId.Value || v?.Turnaround.ContainerMaster.ItemTypeId == (int)ItemTypeIdentifier.ChildBatchTag))
                            {
                                turnaroundIdsToIgnore.Add(tId);
                                continue;
                            }

                            var processEventsToIgnore = new List<short>
                            {
                                (short) TurnAroundEventTypeIdentifier.Archived,
                                (short) TurnAroundEventTypeIdentifier.IntoQuarantine
                            };

                            bool turnaroundEndedEarly = allEvents.Any(ev => ev.EventTypeId == (int)TurnAroundEventTypeIdentifier.TurnaroundEndedEarly);

                            if (v.EventTypeId != (int)TurnAroundEventTypeIdentifier.IntoAutoclave && !processEventsToIgnore.Contains(v.EventTypeId) && !turnaroundEndedEarly)
                            {
                                dataContract.ErrorCode = (int)ErrorCodes.BatchTurnaroundEventsInconsistent;
                                return;
                            }

                            if (v.EventTypeId != (int)TurnAroundEventTypeIdentifier.IntoAutoclave)
                            {
                                turnaroundIdsToIgnore.Add(tId);
                            }
                        }

                        if (turnaroundIdsToIgnore.Any())
                        {
                            turnaroundIds.RemoveAll(t => turnaroundIdsToIgnore.Contains(t));
                        }

                        _synergyTrakData.StationTypeId = scanDetails.StationTypeId;
                        _synergyTrakData.StationId = scanDetails.StationId;
                        _synergyTrakData.FacilityId = scanDetails.FacilityId;
                        _synergyTrakData.UserId = scanDetails.UserId;

                        scanDetails.ApplyEvent = false;

                        var listOfDataContracts = new List<ScanAssetDataContract>();

                        Parallel.ForEach(turnaroundIds, t => listOfDataContracts.Add(ProcessBatchTurnaround(t, scanDetails)));

                        if (listOfDataContracts.All(dc => dc.ErrorCode == null))
                        {
                            foreach (var scanDC in listOfDataContracts)
                            {
                                TurnaroundEvents.Create(_synergyTrakData.EventTypeId, CreateTurnaroundEventData(scanDC, scanDetails, _synergyTrakData.EventTypeId));
                            }

                        }

                        GetReportsAndNotification(listOfDataContracts, dataContract);

                        BatchHelper batchHelper = new BatchHelper();

                        switch (_synergyTrakData.EventTypeId)
                        {
                            case TurnAroundEventTypeIdentifier.FailBatchPostSteamInjection:
                                batchHelper.Fail(scanDetails.BatchId.Value, FailureTypeIdentifier.PoststeamFailure, _synergyTrakData.UserId);
                                break;

                            case TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithoutReassign:
                                batchHelper.Fail(scanDetails.BatchId.Value, FailureTypeIdentifier.PresteamFailure, _synergyTrakData.UserId);

                                break;

                            case TurnAroundEventTypeIdentifier.FailBatchPostNonSteamInjection:
                                batchHelper.Fail(scanDetails.BatchId.Value, FailureTypeIdentifier.PostNonSteamFailure, _synergyTrakData.UserId);
                                break;

                            case TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithoutReassign:
                                batchHelper.Fail(scanDetails.BatchId.Value, FailureTypeIdentifier.PreNonSteamFailure, _synergyTrakData.UserId);
                                break;

                            case TurnAroundEventTypeIdentifier.BrokenPack:
                                batchHelper.Fail(scanDetails.BatchId.Value, FailureTypeIdentifier.DamagedWraps, _synergyTrakData.UserId);
                                break;

                            case TurnAroundEventTypeIdentifier.WetPack:
                                batchHelper.Fail(scanDetails.BatchId.Value, FailureTypeIdentifier.WetPackOrTray, _synergyTrakData.UserId);
                                break;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// BatchScanEx operation
        /// </summary>
        public void BatchScanEx(ScanDetails scanDetails, ScanAssetDataContract dataContract)
        {
            var start = DateTime.UtcNow;
            _synergyTrakData.StationTypeId = scanDetails.StationTypeId;
            _synergyTrakData.StationId = scanDetails.StationId;
            _synergyTrakData.FacilityId = scanDetails.FacilityId;
            _synergyTrakData.UserId = scanDetails.UserId;
            _ignoreNotesWarningsAndDecon = true;
            _synergyTrakData.StationLocationId = StationHelper.GetStationLocationId(scanDetails);
            _synergyTrakData.KeepBatchTagTogetherRequested = scanDetails.IsKeepFailedBatchTogether ?? false;

            if ((scanDetails.Events.Count > 0) && (scanDetails.BatchId.HasValue))
            {
                _synergyTrakData.EventTypeId = (TurnAroundEventTypeIdentifier)scanDetails.Events.First().EventType;

                {
                    var eventTypeRepository = EventTypeRepository.New(workUnit);
                    var batchRepository = BatchRepository.New(workUnit);
                    var batch = batchRepository.Get(scanDetails.BatchId.Value);

                    _isProcessEvent = eventTypeRepository.Get((int)_synergyTrakData.EventTypeId).ProcessEvent;

                    if (batch != null)
                    {
                        var teRepository = TurnaroundEventRepository.New(workUnit);
                        List<Turnaround> turnarounds;

                        int eventTypeToValidate;

                        switch (batch.Machine.MachineTypeId)
                        {
                            case (int)MachineTypeIdentifier.Autoclave:
                                eventTypeToValidate = (int)TurnAroundEventTypeIdentifier.IntoAutoclave;
                                break;

                            case (int)MachineTypeIdentifier.Washer:
                                eventTypeToValidate = (int)TurnAroundEventTypeIdentifier.WashRelease;
                                break;

                            case (int)MachineTypeIdentifier.Post1997Washer:
                                eventTypeToValidate = (int)TurnAroundEventTypeIdentifier.WashRelease;
                                break;

                            default:
                                eventTypeToValidate = (int)TurnAroundEventTypeIdentifier.Wash;
                                break;
                        }

                        if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.FailedWash)
                        {
                            turnarounds = batch.CurrentlyAssignedTurnarounds.Where(t => t.ContainerMaster.ItemType.ParentItemTypeId != (int)ItemTypeIdentifier.BaseCarriage).ToList();
                        }
                        else
                        {
                            turnarounds = teRepository.Repository.Find(te => te.BatchId == scanDetails.BatchId && te.EventType.ProcessEvent).GroupBy(te => te.TurnaroundId)
                                                                        .Select(g => g.OrderByDescending(t => t.Created).FirstOrDefault().Turnaround).ToList();
                        }

                        var eventsToIgnore = new List<int>
                        {
                            (int) TurnAroundEventTypeIdentifier.Archived,
                            (int) TurnAroundEventTypeIdentifier.IntoQuarantine
                        };

                        var invalidLastEvent = batch.TurnaroundEvent.Any(te =>
                            te.Turnaround.CurrentTurnaroundEvent.EventTypeId != eventTypeToValidate &&
                            !eventsToIgnore.Contains(te.Turnaround.CurrentTurnaroundEvent.EventTypeId) &&
                            te.Turnaround.TurnaroundEvent.All(ev => ev.EventTypeId != (int)TurnAroundEventTypeIdentifier.TurnaroundEndedEarly)
                        );

                        if (invalidLastEvent)
                        {
                            dataContract.ErrorCode = (int)ErrorCodes.BatchTurnaroundEventsInconsistent;
                        }
                        else
                        {
                            if (!scanDetails.IsKeepFailedBatchTogether.HasValue && batch.TurnaroundEvent.Any(te => te.Turnaround.ContainerMaster.BaseItemType.ItemTypeId == (int)ItemTypeIdentifier.BatchTag))
                            {
                                dataContract.ChildBatchTagCount = batch.TurnaroundEvent.GroupBy(te => te.TurnaroundId).Count(grp => grp.First().Turnaround.ContainerMaster.BaseItemType.ItemTypeId == (int)ItemTypeIdentifier.BatchTag && grp.First().Turnaround.TurnaroundEvent.All(te => te.EventTypeId != (int)TurnAroundEventTypeIdentifier.Archived));
                                dataContract.RequiresKeepBatchTogetherConfirmation = true;
                                return;
                            }

                            var listOfDataContracts = new List<ScanAssetDataContract>();

                            scanDetails.ApplyEvent = false;
                            Parallel.ForEach(turnarounds, turnaround => listOfDataContracts.Add(ProcessBatchTurnaround(turnaround.TurnaroundId, scanDetails)));
                            if (!_synergyTrakData.KeepBatchTagTogetherRequested)
                            {
                                var turnaroundsOnABatchTag = listOfDataContracts.Where(dc => dc.IsParentABatchTag).ToList();
                                ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemoveFromBatchTag, true), turnaroundsOnABatchTag, scanDetails);
                            }

                            ApplyEvent(ApplyTurnaroundEventDetails.Create(_synergyTrakData.EventTypeId, !_synergyTrakData.KeepBatchTagTogetherRequested), listOfDataContracts, scanDetails);
                            _synergyTrakData.ScanDcList.Clear();
                        }
                    }
                }
            }

            dataContract.OperationDurationMs = (long)(DateTime.UtcNow - start).TotalMilliseconds;
        }
    }
}
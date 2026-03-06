using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.Services;
using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Class for all audit related turnaround events.
    /// </summary>
    /// <summary>
    /// Auditing
    /// </summary>
    public class Auditing : BasicTurnaroundEvents
    {
        #region Constructor
        public Auditing(SynergyTrakData data) : base(data)
        {
        }
        #endregion

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AuditStarted)]
        /// <summary>
        /// StartAudit operation
        /// </summary>
        public void StartAudit(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            CheckAutomaticCollection(scanDC, scanDetails);
            ApplyEvent(TurnAroundEventTypeIdentifier.AuditStarted, scanDetails);
            if (scanDC.IsRemoveFromParent)
            {
                RemoveFromParent(scanDC);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AuditFinished)]
        /// <summary>
        /// FinishAudit operation
        /// </summary>
        public void FinishAudit(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(TurnAroundEventTypeIdentifier.AuditFinished, scanDetails);

            if (scanDetails.Audit?.AuditResultTypeId == (int)AuditResultTypeIdentifier.CompletedWithExceptions && (scanDetails.Audit?.AuditLocationCategoryId == (byte)StationTypeCategoryIdentifier.CleanRoom || FacilitySettings.GetDeconAuditImmediateQuarantine((short)scanDC.FacilityId)))
            {
                if (!scanDC.IsInQuarantine)
                {
                    AuditQuarantine(scanDC, scanDetails, TurnAroundEventTypeIdentifier.AuditFinished);
                }
                else
                {
                    scanDC.AuditFailedItemAlreadyQuarantined = true;
                }
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AuditFailed)]
        /// <summary>
        /// FailAudit operation
        /// </summary>
        public void FailAudit(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(TurnAroundEventTypeIdentifier.AuditFailed, scanDetails);

            if (scanDetails.Audit?.AuditLocationCategoryId == (byte)StationTypeCategoryIdentifier.CleanRoom || FacilitySettings.GetDeconAuditImmediateQuarantine((short)scanDC.FacilityId))
            {
                if (!scanDC.IsInQuarantine)
                {
                    AuditQuarantine(scanDC, scanDetails, TurnAroundEventTypeIdentifier.AuditFailed);
                }
                else
                {
                    scanDC.AuditFailedItemAlreadyQuarantined = true;
                }
            }
        }

        /// <summary>
        /// AuditQuarantine operation
        /// </summary>
        public void AuditQuarantine(ScanAssetDataContract scanDC, ScanDetails scanDetails, TurnAroundEventTypeIdentifier eventType)
        {
            var _eventsToApply = new List<ApplyTurnaroundEventDetails>();
            if (scanDC.IsDeconEndRequired)
            {
                _eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.DeconCancel, CanSetTurnaroundExpiryTime = false });
            }

            if (scanDC.IsParentACarriage)
            {
                _eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemovedFromCarriage, RemoveFromParent = true });
            }

            if (scanDC.IsParentABatchTag)
            {
                _eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemoveFromBatchTag, RemoveFromParent = true });
            }

            _data.QuarantineReasonId = (int)QuarantineReasonIdentifier.AuditFailure;
            scanDC.AuditFailedItemQuarantined = true;

            if (_eventsToApply.Any())
            {
                ApplyEvent(_eventsToApply, scanDC, scanDetails);
            }
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.IntoQuarantine, RemoveFromParent = true }, scanDC, scanDetails,true);

            ContainerInstances.SetInstanceQuarantineReason(scanDC.Asset.ContainerInstanceId, (short)eventType, _data.QuarantineReasonId);
        }

        /// <summary>
        /// AuditQuarantine operation
        /// </summary>
        public void AuditQuarantine(List<ScanAssetDataContract> scanDClist, ScanDetails scanDetails, TurnAroundEventTypeIdentifier eventType)
        {
            var RemoveFromBatchTag = new List<ScanAssetDataContract>();
            var ContainerInstanceList = new List<int>();

            foreach (var sadc in scanDClist)
            {
                if (sadc.IsParentABatchTag)
                {
                    RemoveFromBatchTag.Add(sadc);
                }

                if (sadc.Asset.ContainerInstanceId.HasValue)
                {
                    ContainerInstanceList.Add(sadc.Asset.ContainerInstanceId.Value);
                }

                sadc.AuditFailedItemQuarantined = true;
            }

            if (RemoveFromBatchTag.Any())
            {
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemoveFromBatchTag, RemoveFromParent = true }, RemoveFromBatchTag, scanDetails);
            }

            _data.QuarantineReasonId = (int)QuarantineReasonIdentifier.AuditFailure;
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.IntoQuarantine, RemoveFromParent = true }, scanDClist, scanDetails);

            ContainerInstances.SetMultipleInstanceQuarantineReasons(ContainerInstanceList, (short)eventType, _data.QuarantineReasonId);
        }
        /// <summary>
        /// CheckCreateIntoQuarantineNotificationsForAudit operation
        /// </summary>
        public static void CheckCreateIntoQuarantineNotificationsForAudit(ScanDetails scanDetails, ScanAssetDataContract dc)
        {
            if (dc.ErrorCode != null) return;
            InstanceFactory.GetInstance<ILog>().Info($"Audit Fail Into Quarantine: start notifications");

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                ITurnaroundEvent turnaroundEvent = TurnaroundEventFactory.CreateEntity(workUnit);
                var intoQuarantineTurnaroundEventId = dc.TurnaroundEvents?.LastOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoQuarantine)?.TurnaroundEventId;

                var noNotificationTypesFired = (!dc.NotificationTypesFired?.Any()) ?? true;

                if (noNotificationTypesFired && intoQuarantineTurnaroundEventId.HasValue)
                {
                    var notificationEngineHelper = new NotificationEngineHelper();
                    turnaroundEvent.TurnaroundEventId = intoQuarantineTurnaroundEventId.Value;
                    dc.NotificationTypesFired = notificationEngineHelper.ProcessNotifications(dc, scanDetails, turnaroundEvent);
                }
            }

            InstanceFactory.GetInstance<ILog>().Info($"Audit Fail Into Quarantine:end notifications");
        }

        /// <summary>
        /// FindItemInstances operation
        /// </summary>
        public static List<ItemExceptionResponseContract> FindItemInstances(int facilityId, List<string> scannedInputs)
        {
            try
            {
                var resultList = new List<ItemExceptionResponseContract>();
                using (var repository = new PathwayRepository())
                {
                    var dt = new DataTable();
                    dt.Columns.Add("ScannedValue", typeof(string));
                    foreach (var input in scannedInputs)
                    {
                        dt.Rows.Add(input);
                    }
                    var results = repository.DataManager.ExecuteQuery((row, table, set) =>
                    {
                        return new
                        {
                            ScannedValue = Convert.ToString(row["Value"]),
                            Text = Convert.ToString(row["Text"]),
                            ItemInstanceID = Convert.ToInt32(row["ItemInstanceID"]),
                            ItemInstanceIdentifierTypeId = Convert.ToInt16(row["ItemInstanceIdentifierTypeId"]),
                        };
                    },
                    "dbo.GetItemInstanceExceptionResult",
                    CommandType.StoredProcedure,
                    new SqlParameter("@FacilityId", facilityId),
                        new SqlParameter
                        {
                            ParameterName = "@ScannedValues",
                            Value = dt,
                            TypeName = "[dbo].[NVarCharMaxValueTable]",
                            SqlDbType = SqlDbType.Structured
                        }
                    );
                    foreach (var input in scannedInputs)
                    {
                        var result = results.FirstOrDefault(res => string.Compare(res.ScannedValue, input, StringComparison.OrdinalIgnoreCase) == 0);
                        resultList.Add(new ItemExceptionResponseContract
                        {
                            ItemName = result?.Text ?? string.Empty,
                            ItemInstanceId = result?.ItemInstanceID ?? null,
                            ItemInstanceIdentifierTypeId = result?.ItemInstanceIdentifierTypeId ?? 2,
                            ScannedBarcode = input,
                        });
                    }
                }
                return resultList;
            }
            catch (Exception ex)
            {
                InstanceFactory.GetInstance<ILog>().Exception(ex, "Audit Exception");
            }
            return null;
        }

        private static bool IsAuditRequired(short facilityId, int containerMasterDefinitionId, int stationTypeCategory)
        {

            {
                var facilityAuditRuleRepo = FacilityAuditRuleRepository.New(workUnit);
                var facilityAuditRules = facilityAuditRuleRepo.GetAllForFacility(facilityId);

                if (facilityAuditRules.FirstOrDefault(ar => ar.AuditRule.StationTypeCategoryId == stationTypeCategory && ar.AuditRule.IsEnabled) == null)
                {
                    return false;
                }

                var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                var containerMaster = containerMasterRepository.GetActiveOneByContainerMasterDefinitionId(containerMasterDefinitionId);
                if (containerMaster == null)
                {
                    return false;
                }

                var containerMasterAuditRules = containerMaster.ValidContainerMasterDefinitionAuditRules;

                if (containerMasterAuditRules.FirstOrDefault(ar => ar.AuditRule.StationTypeCategoryId == stationTypeCategory && ar.AuditRule.IsEnabled) == null)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// IsCleanRoomAuditRequired operation
        /// </summary>
        public static bool IsCleanRoomAuditRequired(ScanAssetDataContract dataContract)
        {
            if (IsAuditRequired((short)dataContract.FacilityId, dataContract.Asset.ContainerMasterDefinitionId, (int)StationTypeCategoryIdentifier.CleanRoom))
            {
                return true;
            }
            else if (IsAuditRequired((short)dataContract.FacilityId, dataContract.Asset.ContainerMasterDefinitionId, (int)StationTypeCategoryIdentifier.Decontamination))
            {
                if (HasFailedDeconAudit(dataContract))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// IsDeconAuditRequired operation
        /// </summary>
        public static bool IsDeconAuditRequired(ScanAssetDataContract dataContract)
        {
            return IsAuditRequired((short)dataContract.FacilityId, dataContract.Asset.ContainerMasterDefinitionId, (int)StationTypeCategoryIdentifier.Decontamination);
        }

        /// <summary>
        /// SetAuditRequiredFromNextEventTypeId operation
        /// </summary>
        public static void SetAuditRequiredFromNextEventTypeId(ScanAssetDataContract dataContract)
        {
            if (dataContract?.Asset != null)
            {
                {
                    var eventTypeRepository = EventTypeRepository.New(workUnit);

                    int? stationTypeCategoryId = eventTypeRepository.Get(dataContract.NextEventId)
                                                                ?.EventTypeStationTypes.FirstOrDefault(ets => ets.Preferred)
                                                                ?.StationType?.StationTypeCategoryId;

                    if (stationTypeCategoryId.HasValue)
                    {
                        dataContract.AuditRequiredPriorityScreen = IsAuditRequired((short)dataContract.FacilityId, dataContract.Asset.ContainerMasterDefinitionId, stationTypeCategoryId.Value);
                    }
                }

            }
        }

        /// <summary>
        /// SetAuditProgressForScan operation
        /// </summary>
        public static void SetAuditProgressForScan(ScanAssetDataContract ScanDC)
        {
            if (ScanDC?.Asset != null)
            {
                var CleanAuditRequired = IsCleanRoomAuditRequired(ScanDC);
                var CleanAuditCompleted = HasQualifyingAudit(ScanDC);
                var DeconAuditRequired = IsDeconAuditRequired(ScanDC);
                var DeconAuditCompleted = CleanAuditCompleted || HasAuditBeenCompleted(ScanDC, (int)StationTypeCategoryIdentifier.Decontamination);

                ScanDC.AuditCleanOutstanding = CleanAuditRequired && !CleanAuditCompleted;
                ScanDC.AuditDeconOutstanding = DeconAuditRequired && !DeconAuditCompleted;
            }
        }

        /// <summary>
        /// HasAuditBeenCompleted operation
        /// </summary>
        public static bool HasAuditBeenCompleted(ScanAssetDataContract dataContract, int auditLocation)
        {
            {
                var SIAuditRepo = SingleInstrumentAuditRepository.New(workUnit);

                if (dataContract.TurnaroundId != null)
                {
                    var audit = SIAuditRepo.FindLatestForTurnaroundAndStationType(dataContract.TurnaroundId.Value, auditLocation);

                    if (audit != null)
                    {
                        return (audit.AuditLocationCategoryId == (int)StationTypeCategoryIdentifier.CleanRoom && audit.AuditResultTypeId == (short)AuditResultTypeIdentifier.CompletedWithoutExceptions)
                            || (audit.AuditLocationCategoryId == (int)StationTypeCategoryIdentifier.Decontamination);
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// HasQualifyingAudit operation
        /// </summary>
        public static bool HasQualifyingAudit(ScanAssetDataContract dataContract)
        {
            using (var context = new OperativeModelContainer())
            {
                return context.SIT_HasValidAudit(dataContract.TurnaroundId, dataContract.FacilityId).FirstOrDefault().GetValueOrDefault();
            }
        }

        /// <summary>
        /// HasFailedDeconAudit operation
        /// </summary>
        public static bool HasFailedDeconAudit(ScanAssetDataContract dataContract)
        {
            {
                var SIAuditRepo = SingleInstrumentAuditRepository.New(workUnit);

                if (dataContract.TurnaroundId != null)
                {
                    var audit = SIAuditRepo.FindLatestForTurnaround(dataContract.TurnaroundId.Value);

                    if (audit != null)
                    {
                        return ((audit.AuditResultTypeId == (short)AuditResultTypeIdentifier.ManualFail || audit.AuditResultTypeId == (short)AuditResultTypeIdentifier.CompletedWithExceptions) && audit.AuditLocationCategoryId == (int)StationTypeCategoryIdentifier.Decontamination);
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// CreateAudit operation
        /// </summary>
        public static void CreateAudit(ScanDetails sd, ScanAssetDataContract saDc)
        {
            {
                var newAuditInfo = context.SIT_CreateAudit(saDc.LastTurnaroundEventId.Value).FirstOrDefault();
                saDc.Audit.AuditId = newAuditInfo.SingleInstrumentAuditId;
                saDc.Audit.AuditLocationCategoryId = newAuditInfo.AuditLocationCategoryId;
            }
        }

        /// <summary>
        /// UpdateAudit operation
        /// </summary>
        public static AuditDataContract UpdateAudit(ScanDetails sd, int endedTurnaroundEventId)
        {
            try
            {
                {
                    var SIAuditRepo = SingleInstrumentAuditRepository.New(workUnit);
                    var Audit = SIAuditRepo.Get(sd.Audit.AuditId);
                    Audit.EndedTurnaroundEventId = endedTurnaroundEventId;
                    Audit.AuditResultTypeId = sd.Audit.AuditResultTypeId;

                    var processMissing = (sd.Audit.AuditResultTypeId == (int)AuditResultTypeIdentifier.CompletedWithExceptions);

                    foreach (var auditLine in sd.Audit.AuditLines)
                    {
                        if (!auditLine.Processed && (processMissing || auditLine.AuditLineStatusTypeId != (short)AuditLineStatusTypeIdentifier.Missing))
                        {
                            Audit.SingleInstrumentAuditLine.Add(SingleInstrumentAuditLineFactory.CreateEntity(workUnit,
                                singleInstrumentAuditId: Audit.SingleInstrumentAuditId,
                                itemInstanceIdentifierTypeId: auditLine.ItemInstanceIdentifierType,
                                itemInstanceId: auditLine.ItemInstanceId,
                                isRequiredBySpecification: auditLine.IsRequiredBySpecification,
                                auditLineStatusTypeId: auditLine.AuditLineStatusTypeId,
                                auditLineExceptionReasonId: auditLine.AuditLineExceptionReasonId,
                                scannedBarcodeValue: auditLine.ScannedBarcode
                            ));
                            auditLine.Processed = true;
                        }

                    }
                    foreach (var fault in sd.Audit.ProcessFaults)
                    {
                        Audit.SingleInstrumentAuditProcessFault.Add(SingleInstrumentAuditProcessFaultFactory.CreateEntity(workUnit,
                            singleInstrumentAuditId: Audit.SingleInstrumentAuditId,
                            scannedBarcodeValue: fault.ScannedBarcode,
                            auditProcessFaultReasonId: fault.FaultReasonId
                        ));
                        fault.Processed = true;
                    }

                    workUnit.Save();

                    var auditDc = new AuditDataContract
                    {
                        AuditId = Audit.SingleInstrumentAuditId,
                        AuditLocationCategoryId = Audit.AuditLocationCategoryId,
                        AuditResultTypeId = Audit.AuditResultTypeId,
                        AuditLines = sd.Audit.AuditLines,
                        ProcessFaults = sd.Audit.ProcessFaults
                    };

                    return auditDc;
                }
            }
            catch (Exception ex)
            {
                InstanceFactory.GetInstance<ILog>().Exception(ex, "Audit Exception");
            }

            return new AuditDataContract();
        }

        /// <summary>
        /// AuditExceptionsPrint operation
        /// </summary>
        public static void AuditExceptionsPrint(ScanDetails scanDetails, ScanAssetDataContract dataContract, int? turnaroundEventId, string reportPath, int numberOfCopies)
        {
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.Get(scanDetails.TurnaroundId.Value);

                var userRepository = UserRepository.New(workUnit);
                var user = userRepository.Get(scanDetails.UserId);

                if (turnaround != null && scanDetails?.Audit?.AuditId != null)
                {
                    var list = new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("S", user.SystemId.ToString()),
                        new Tuple<string, string>("TurnaroundId", turnaround.TurnaroundId.ToString()),
                        new Tuple<string, string>("AuditId", scanDetails.Audit.AuditId.ToString())
                    };

                    var result = Printing.PrintUtility.CreatePDFReport(reportPath, list.ToArray());
                    if (scanDetails.IsNetworkPrinting)
                    {
                        Printing.PrintUtility.PrintPDFReport(result, scanDetails.LaserPrinter);
                    }
                    else
                    {
                        Printing.PrintUtility.PrintLocalPDFReport(result, dataContract);
                    }
                    var printHistoryHelper = new PrintHistoryHelper();
                    var printHistory = printHistoryHelper.CreatePrintHistory(user.UserId, Enums.Printing.PrintContentTypeIdentifier.AuditException, dataContract.TurnaroundId, turnaroundEventId.Value, dataContract.BatchId, null);
                    if (printHistory != null)
                    {
                        printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, Enums.Printing.PrintHistoryPrinterType.LaserPrinter, new PDFContent { Bytes = result.ReportData });
                    }
                }
            }
        }

        /// <summary>
        /// Validation operation
        /// </summary>
        public static bool Validation(ScanAssetDataContract scanDC, ScanDetails scanDetails, SynergyTrakData synergyTrakData)
        {
            if (synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignToBatchTag && IsDeconAuditRequired(scanDC) && !HasAuditBeenCompleted(scanDC, (int)StationTypeCategoryIdentifier.Decontamination))
            {
                if (scanDetails.ParentTurnaroundId.HasValue)
                {
                    {
                        var turnaroundRepository = TurnaroundRepository.New(workUnit);
                        var turnaround = turnaroundRepository.Get(scanDetails.ParentTurnaroundId.Value);
                        if (turnaround.ParentTurnaround?.ContainerMaster?.BaseItemType?.ItemTypeId == (int)ItemTypeIdentifier.BaseCarriage)
                        {
                            scanDC.AuditRequiredForProccessing = true;
                            scanDC.ErrorCode = (int)ErrorCodes.AuditRequired;
                        }
                    }
                }

                if (scanDC.ErrorCode == null && FacilitySettings.ShowAuditWarningWhenAssigningToBatchTag(scanDetails.FacilityId) && !scanDetails.IgnoreNotesWarningsAndDecon)
                {
                    scanDC.TransientNotes.Add(new NoteDataContract
                    {
                        Id = 0,
                        Text = TranslatorManager.GetText("pathway", "GenericNotes", "AuditBatchTagWarningMessage", culture: scanDetails.Culture),
                        Type = (int)ContainerMasterNoteTypeIdentifier.Operational, //Operational gives Two options
                        ContainerMasterName = scanDC.Asset.ContainerMasterName,
                        ContainerInstancePrimaryId = scanDC.Asset.ContainerInstancePrimaryId,
                        ErrorCode = (int)ErrorCodes.AuditRequired,
                        Activity = TertiaryActivity.TrayAudit
                    });

                    synergyTrakData.CanApplyEvent = false;
                }
            }

            if (synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage || synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Wash)
            {
                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag)
                {
                    if (scanDC.ChildItems != null)
                    {
                        foreach (var child in scanDC.ChildItems)
                        {
                            if (IsDeconAuditRequired(child) && !HasAuditBeenCompleted(child, (int)StationTypeCategoryIdentifier.Decontamination))
                            {
                                child.AuditRequiredForProccessing = true;
                                scanDC.ErrorCode = (int)ErrorCodes.AuditRequired;
                            }
                        }
                    }
                }
                else if (IsDeconAuditRequired(scanDC) && !HasAuditBeenCompleted(scanDC, (int)StationTypeCategoryIdentifier.Decontamination))
                {
                    scanDC.AuditRequiredForProccessing = true;
                    scanDC.ErrorCode = (int)ErrorCodes.AuditRequired;
                }
            }

            if (synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.StartPacking)
            {
                if (IsCleanRoomAuditRequired(scanDC))
                {
                    scanDC.AuditRequiredForProccessing = true;
                    if (!UserHelper.HasAnyPermission(scanDC.UserId, new PermissionIdentifier[] { PermissionIdentifier.TrayAuditUser, PermissionIdentifier.OperativeAdministrator, PermissionIdentifier.Administrator }))
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.AuditRequiredUserHasNoPermission;
                    }
                }
            }

            if (synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.QualityAssurance)
            {
                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag)
                {
                    foreach (var child in scanDC.ChildItems)
                    {
                        if (!HasQualifyingAudit(child))
                        {
                            child.AuditRequiredForProccessing = true;
                            scanDC.ErrorCode = (int)ErrorCodes.AuditRequired;
                        }
                    }
                }
                else if (!HasQualifyingAudit(scanDC))
                {
                    scanDC.ErrorCode = (int)ErrorCodes.AuditRequired;
                }
            }
            if (synergyTrakData .EventTypeId == TurnAroundEventTypeIdentifier.AuditStarted &&
                (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Tray &&
                 scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.LoanTray &&
                 scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Supplementary &&
                 scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Endoscopy
                ))
            {
                scanDC.ErrorCode = (int)ErrorCodes.AuditInvalidItemType;
            }

            return !scanDC.ErrorCode.HasValue;
        }
    }
}
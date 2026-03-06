using SynergyApplicationFrameworkApi.Application.DTOs.Data;
using SynergyApplicationFrameworkApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ReportTypeIdentifier = Synergy.LabelPrinting.Enums.ReportTypeIdentifier;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// For 'happy path' standard processing events. 
    /// </summary>
    /// <summary>
    /// BasicTurnaroundEvents
    /// </summary>
    public class BasicTurnaroundEvents : TurnaroundEvents
    {
        public BasicTurnaroundEvents(SynergyTrakData data) : base(data)
        {
        }

        #region Turnaround Event Methods

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.Inbound)]
        /// <summary>
        /// Inbound operation
        /// </summary>
        public void Inbound(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            try
            {
                Log.Info("Inbound start");
                Log.Info("Inbound create turnaround events start");
                var eventsToApply = new List<ApplyTurnaroundEventDetails>();

                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag)
                {
                    ApplyEvent(TurnAroundEventTypeIdentifier.Inbound, scanDetails);
                }
                else
                {
                    if ((scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.LoadTrolleyEPOC) ||
                    (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AvailableForCollection))
                    {
                        eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AutomaticCollection, IsAutomaticEvent = true });
                    }

                    eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.Inbound, RemoveFromParent = true });
                    ApplyEvent(eventsToApply, _data.ScanDcList, scanDetails);
                }

                Log.Info("Inbound create turnaround events finish");
                if (scanDC != null)
                {
                    if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                    {
                        var list = new List<Tuple<string, string>>
                        {
                            new Tuple<string, string>("TrolleyId", scanDC.Asset.ContainerInstanceId.ToString())
                        };
                        User user;
                        using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                        {
                            var userRepository = UserRepository.New(workUnit);
                            user = userRepository.Get(scanDC.UserId);
                        }

                        list.Add(new Tuple<string, string>("S", user.SystemId.ToString()));

                        Log.Info("Inbound CreateReport start");

                        var result = Printing.PrintUtility.CreatePDFReport(ReportTypeIdentifier.InboundList.ToString(), list.ToArray());
                        if (scanDetails.IsNetworkPrinting)
                        {
                            Printing.PrintUtility.PrintPDFReport(result, scanDetails.LaserPrinter);
                        }
                        else
                        {
                            Printing.PrintUtility.PrintLocalPDFReport(result, scanDC);
                        }
                        var printHistoryHelper = new PrintHistoryHelper();
                        var taList = new List<int>();
                        _data.ScanDcList.ForEach(x => taList.Add(x.TurnaroundId.Value));
                        var printHistory = printHistoryHelper.CreatePrintHistory(user.UserId, Enums.Printing.PrintContentTypeIdentifier.InboundList, taList, null, null, scanDC.BatchId, null);
                        if (printHistory != null)
                        {
                            printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, Enums.Printing.PrintHistoryPrinterType.LaserPrinter, new PDFContent { Bytes = result.ReportData });
                        }

                        Log.Info("Inbound CreateReport finish");
                    }

                    if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Endoscopy && scanDC.Defects.Any())
                    {
                        var quarantine = new Quarantine(_data);
                        quarantine.PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ServiceReportRaised);
                    }

                    MLDQuarantineHelper.CheckAutoQuarantineAfterInbound(_data, scanDC, scanDetails);
                }
                
                Log.Info("Inbound finish");
            }
            catch (Exception ex)
            {
                Log.Exception(ex, "Inbound exception");
                throw;
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.TrayPrioritisation)]
        /// <summary>
        /// TrayPrioritisation operation
        /// </summary>
        public void TrayPrioritisation(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (Printing.PrintUtility.IsLaserPrinterAvailable(scanDetails.LaserPrinter, scanDetails.IsNetworkPrinting))
            {
                Log.Info($"TrayPrioritisation ExternalId: {scanDC.Asset.ContainerInstancePrimaryId}");

                {
                    var turnaroundRepository = TurnaroundRepository.New(workUnit);
                    var turnaround = turnaroundRepository.Get(scanDC.TurnaroundId.Value);
                    if (turnaround.ItemExceptionsApprovalFlag)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.CantTPWithItemExceptions;
                        return;
                    }
                }

                var eventsToApply = new List<ApplyTurnaroundEventDetails>();
                if (_data.IsRemoveFromParent)
                {
                    eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemoveFromBatchTag });
                }

                eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.TrayPrioritisation });
                ApplyEvent(eventsToApply, _data.ScanDcList, scanDetails);

                foreach (var dc in _data.ScanDcList)
                {
                    SterileExpiryHelper.UpdateSterileExpiry(dc);
                }

                if (scanDC != null)
                {
                    foreach (var dc in _data.ScanDcList)
                    {
                        Printing.PrintUtility.PrintTraylist(dc, scanDetails);
                    }
                }
            }
            else
            {
                scanDC.ErrorCode = (int)ErrorCodes.LaserPrinterNotAvailable;
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.QualityAssurance)]
        /// <summary>
        /// QualityAssurance operation
        /// </summary>
        public void QualityAssurance(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (_data.IsRemoveFromParent) // If a container is scanned individually, and it is part of a batchtag.
            {
                ApplyEvent(TurnAroundEventTypeIdentifier.RemoveFromBatchTag, scanDetails);
            }

            List<ScanAssetDataContract> orderedScanDcList = _data.ScanDcList;
            if (_data.ScanDcList.Count > 1)
            {
                {
                    var facilityRespository = FacilityRepository.New(workUnit);
                    var currentFacility = facilityRespository.Get((short)scanDC.FacilityId);
                    var setting = currentFacility?.Owner.Tenancy.TenancySetting.FirstOrDefault(a => a.Name == KnownTenancySetting.PrintQALabelsAlphabetically);
                    bool printQaLabelsAlphabetically = false;
                    if (setting != null)
                    {
                        bool.TryParse(setting.Value, out printQaLabelsAlphabetically);
                    }

                    var container = _data.ScanDcList[0];
                    if (printQaLabelsAlphabetically)
                    {
                        orderedScanDcList = _data.ScanDcList.Where(dc => dc != container).OrderBy(x => x.Asset.ContainerMasterName).ToList();
                        orderedScanDcList.Insert(0, container);
                    }
                }
            }

            _data.ScanDcList = orderedScanDcList;

            var eventsToApply = new List<ApplyTurnaroundEventDetails> { ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.QualityAssurance) };
            ApplyEvent(eventsToApply, orderedScanDcList, scanDetails, false);

            bool isAutoDispatchEnabled = FacilitySettings.IsAutoDispatchEnabled(scanDetails.FacilityId);

            Parallel.ForEach(_data.ScanDcList, dc => IntoStockDispatch(dc, scanDetails, isAutoDispatchEnabled)); // Called on all nodes.

            foreach (var dc in orderedScanDcList)
            {
                Printing.PrintUtility.CreateTurnaroundLabelUpdateSterileExpiry(dc, scanDetails, _data.FacilityId, TurnAroundEventTypeIdentifier.QualityAssurance);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FailedQualityAssurance)]
        /// <summary>
        /// FailedQualityAssurance operation
        /// </summary>
        public void FailedQualityAssurance(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var failedReasonId = scanDetails.Data;
            if (_data.IsRemoveFromParent)
            {
                ApplyEvent(TurnAroundEventTypeIdentifier.RemoveFromBatchTag, scanDetails);
            }
            if (failedReasonId != null)
            {
                ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.FailedQualityAssurance, true), scanDetails);
                Parallel.ForEach(_data.ScanDcList, dc => FailedQa(dc, failedReasonId));
            }
        }

        private static void FailedQa(ScanAssetDataContract scanDC, int? failedReasonId)
        {
            if (scanDC.LastProcessEventTypeId.HasValue && scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.FailedQualityAssurance && failedReasonId.HasValue)
            {
                {
                    var repository = TurnaroundEventFailureTypeRepository.New(workUnit);
                    var t = TurnaroundEventFailureTypeFactory.CreateEntity(workUnit,
                        failureTypeId: (byte)failedReasonId,
                        turnaroundEventId: scanDC.LastTurnaroundEventId.Value
                    );

                    repository.Add(t);
                    repository.Save();
                }
            }
        }

        /// <summary>
        /// This checks whether IntoStock should be applied, before doing so.
        /// </summary>
        /// <param name="scanDC"></param>
        /// <param name="isAutoDispatchEnabled">Whether the automatic dispatch facility setting is on or not</param>
        private void IntoStockDispatch(ScanAssetDataContract scanDC, ScanDetails scanDetails, bool isAutoDispatchEnabled)
        {
            {
                var itemTypeRepository = ItemTypeRepository.New(workUnit);
                var itemType = itemTypeRepository.Get(scanDC.Asset.ItemTypeId);

                if (itemType.IsNonSterileProduct)
                {
                    if (isAutoDispatchEnabled)
                    {
                        var disp = new DispatchEvents(_data);
                        disp.Dispatch(scanDC, scanDetails, false, true);
                    }
                    else
                    {
                        var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                        var deliveryPt = deliveryPointRepository.Get(scanDC.DeliveryPtId);

                        if (deliveryPt.StockLocation)
                        {
                            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.IntoStock, LocationId = deliveryPt.LocationId }, scanDC, scanDetails);
                            UpdateContainerInstanceLocation(scanDC.TurnaroundExternalId, deliveryPt.LocationId);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// GetOrCreateDeliveryNoteId operation
        /// </summary>
        public int GetOrCreateDeliveryNoteId(ScanAssetDataContract scanDC, bool isEndTurnaround = false)
        {
            {
                var deliveryNoteRepository = DeliveryNoteRepository.New(workUnit);
                var lastDn = deliveryNoteRepository.GetLastUnprintedDeliveryNoteByDeliveryPointAndFacility(scanDC.DeliveryPtId, _data.FacilityId);

                int deliveryNoteId;

                if (lastDn != null && !isEndTurnaround)
                {
                    scanDC.DeliveryNoteExternalId = lastDn.ExternalId.ToString();
                    deliveryNoteId = lastDn.DeliveryNoteId;
                }
                else
                {
                    var newDn = DeliveryNoteFactory.CreateEntity(workUnit,
                        printed: DateTime.UtcNow,
                        printedStatus: false,
                        deliveryPointId: scanDC.DeliveryPtId,
                        facilityId: _data.FacilityId,
                        printedUserId: scanDC.UserId,
                        legacyFacilityOrigin: 0
                    );
                    if (isEndTurnaround)
                    {
                        newDn.PrintedStatus = true;
                        newDn.Printed = DateTime.UtcNow;
                    }

                    deliveryNoteRepository.Add(newDn);
                    workUnit.Save();

                    scanDC.DeliveryNoteExternalId = newDn.ExternalId.ToString();
                    deliveryNoteId = newDn.DeliveryNoteId;
                }

                return deliveryNoteId;
            }
        }

        /// <summary>
        /// CheckAutomaticCollection operation
        /// </summary>
        public void CheckAutomaticCollection(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (!scanDC.ParentTurnaroundId.HasValue)
            {
                return;
            }

            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var parentTurnaround = turnaroundRepository.Get(scanDC.ParentTurnaroundId.Value);

                if (parentTurnaround?.ContainerMaster.BaseItemType.ItemTypeId != (int)ItemTypeIdentifier.Trolley)
                {
                    return;
                }

                if (scanDC.TurnaroundEvents.Any(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.LoadTrolleyEPOC))
                {
                    scanDC.IsRemoveFromParent = true;

                    if (!scanDC.TurnaroundEvents.Any(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AutomaticCollection
                                                       || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.Collected))
                    {
                        ApplyEvent(TurnAroundEventTypeIdentifier.AutomaticCollection, scanDC, scanDetails, true);
                    }
                }
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.Archived)]
        /// <summary>
        /// Archived operation
        /// </summary>
        public void Archived(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            foreach (var dc in _data.ScanDcList)
            {
                Archive(dc, scanDetails);
            }
        }

        /// <summary>
        /// Archive operation
        /// </summary>
        public void Archive(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDC.TurnaroundId.HasValue)
            {
                {
                    var turnaroundRepository = TurnaroundRepository.New(workUnit);
                    var turnaround = turnaroundRepository.Get(scanDC.TurnaroundId.Value);

                    if (turnaround != null)
                    {
                        turnaround.ParentTurnaroundId = null;
                        turnaround.DeliveryNoteId = null;
                        turnaroundRepository.Save();
                    }

                    SetInstanceQuarantineReasons(scanDC.Asset.ContainerInstanceId, null, null);
                }
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.Archived, RemoveFromParent = true }, scanDC, scanDetails);
                scanDC.IsTurnaroundLive = false;
            }
        }

        /// <summary>
        /// SetInstanceQuarantineReasons operation
        /// </summary>
        public void SetInstanceQuarantineReasons(int? containerInstanceId, short? eventTypeId, short? quarantineReasonId)
        {
            if (containerInstanceId.HasValue)
            {
                {
                    var containerRepository = ContainerInstanceRepository.New(workUnit);
                    var instance = containerRepository.Get(containerInstanceId.Value);

                    if (instance != null)
                    {
                        instance.QuarantineEventTypeId = eventTypeId;
                        instance.QuarantineReasonId = quarantineReasonId;

                        containerRepository.Save();
                    }
                }
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.ServiceRequirementChange)]
        /// <summary>
        /// ServiceRequirementChange operation
        /// </summary>
        public void ServiceRequirementChange(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var newServiceRequirementId = scanDetails.Data;
            if (newServiceRequirementId.HasValue)
            {
                var serviceRequirementExpiryRepository = new ServiceRequirementExpiryRepository();
                {
                    var turnaroundRepository = TurnaroundRepository.New(workUnit);
                    var turnaround = turnaroundRepository.Get(scanDC.TurnaroundId.Value);

                    if (turnaround != null)
                    {
                        turnaround.ServiceRequirementId = newServiceRequirementId.Value;

                        var firstTurnaroundEventDate = turnaround.TurnaroundEvent.OrderBy(a => a.Created).FirstOrDefault()?.Created;

                        if (turnaround.Expiry > DateTime.UtcNow) //If the turnaround has already expired (or there is no expiry), don't recalculate it 
                        {
                            var newExpiry = serviceRequirementExpiryRepository.ReadExpiryReCalculation(scanDC.TurnaroundId.Value, scanDC.ServiceRequirementId, newServiceRequirementId.Value, scanDC.Expiry);
                            var newExpiryDateTime = DateTime.SpecifyKind(newExpiry.Expiry, DateTimeKind.Utc);

                            if (firstTurnaroundEventDate.HasValue && newExpiryDateTime < firstTurnaroundEventDate)
                            {
                                scanDC.ErrorCode = (int)ErrorCodes.ServiceRequirementExpiryPrecedesCreation;
                                return;
                            }

                            turnaround.Expiry = newExpiryDateTime;
                            scanDC.Expiry = newExpiryDateTime;
                        }

                        turnaroundRepository.Save();

                        var turnaroundWhRepository = TurnaroundWHRepository.New(workUnit);
                        var turnaroundWh = turnaroundWhRepository.GetByTurnaround(turnaround.TurnaroundId);

                        if (turnaroundWh != null)
                        {
                            turnaroundWh.ServiceRequirementId = newServiceRequirementId.Value;

                            var serviceRequirementRepository = ServiceRequirementRepository.New(workUnit);
                            var serviceRequirement = serviceRequirementRepository.Get(newServiceRequirementId.Value);

                            if (serviceRequirement != null)
                            {
                                turnaroundWh.ServiceRequirementName = serviceRequirement.Text;
                            }

                            turnaroundWhRepository.Save();
                        }
                    }
                }
                ApplyEvent(TurnAroundEventTypeIdentifier.ServiceRequirementChange, scanDC, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AcknowledgeNote)]
        /// <summary>
        /// AcknowledgeNote operation
        /// </summary>
        public void AcknowledgeNote(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if ((scanDetails.Data.HasValue) && (scanDetails.Data == (int)QuarantineReasonIdentifier.PlannedMaintenance))
            {
                _data.QuarantineReasonId = (int)QuarantineReasonIdentifier.PlannedMaintenance;
            }

            if (scanDetails.Count.HasValue)
            {
                for (var i = 0; i < scanDetails.Count; i++)
                {
                    var completed = ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AcknowledgeNote, DeliveryNoteId = scanDC.DeliveryNoteId }, scanDC, scanDetails);

                    if (completed.Count > 0 && completed[0].Events.Count > 0)
                        LinkAcknowledgeNoteEventToNote(scanDetails.NoteId, scanDetails.ProcessNoteType, completed[0].Events[0].TurnaroundEvent.TurnaroundEventId, scanDetails.StationId);
                }
            
            }
            else
            {
                var completed = ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AcknowledgeNote, DeliveryNoteId = scanDC.DeliveryNoteId }, scanDC, scanDetails);

                if(completed.Count > 0 && completed[0].Events.Count > 0)
                    LinkAcknowledgeNoteEventToNote(scanDetails.NoteId, scanDetails.ProcessNoteType, completed[0].Events[0].TurnaroundEvent.TurnaroundEventId, scanDetails.StationId);
                
            }
        }

        private void LinkAcknowledgeNoteEventToNote(int? noteId, ProcessNoteType? processNoteType, int turnaroundEventId, int? stationId)
        {
            if (processNoteType != null && noteId != null && stationId != null)
            {
                {
                    var turnaroundEventAcknowledgeNoteRepository = new TurnaroundEventAcknowledgeNoteRepository(workUnit);
                    turnaroundEventAcknowledgeNoteRepository.Add(TurnaroundEventAcknowledgeNoteFactory.CreateEntity(workUnit,
                        turnaroundEventId: turnaroundEventId,
                        processingNoteId: processNoteType == ProcessNoteType.TimeBased ? noteId : (int?)null,
                        containerMasterNoteId: processNoteType == ProcessNoteType.Revision ? noteId : (int?)null,
                        stationId: stationId
                    ));
                    workUnit.Save();
                }
            }
        
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.Delivered)]
        /// <summary>
        /// Delivered operation
        /// </summary>
        public void Delivered(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, UseDeliveryNoteIdFromScanDc = true, ParentTurnaroundId = scanDetails.ParentTurnaroundId }, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AutomaticDelivery)]
        /// <summary>
        /// AutomaticDelivery operation
        /// </summary>
        public void AutomaticDelivery(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            scanDC.LocationId = null;
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, ParentTurnaroundId = scanDetails.ParentTurnaroundId, UseDeliveryNoteIdFromScanDc = true }, scanDC, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AutomaticStart)]
        /// <summary>
        /// AutomaticStart operation
        /// </summary>
        public void AutomaticStart(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            foreach (var turnaroundEvent in scanDetails.Events)
            {
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = (TurnAroundEventTypeIdentifier)turnaroundEvent.EventType, ParentTurnaroundId = scanDetails.ParentTurnaroundId, UseDeliveryNoteIdFromScanDc = true }, scanDetails);
            }
        }

        /// <summary>
        /// CheckIfAlreadyAssigned operation
        /// </summary>
        public static bool CheckIfAlreadyAssigned(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDetails.ParentTurnaroundId.HasValue && scanDetails.ParentItemTypeId.HasValue)
            {
                var parentItemType = (ItemTypeIdentifier)scanDetails.ParentItemTypeId;

                if ((parentItemType == ItemTypeIdentifier.BatchTag) || (parentItemType == ItemTypeIdentifier.BatchTagOriginal))
                {
                    if (!scanDC.ErrorCode.HasValue && scanDC.ParentTurnaroundId.HasValue && scanDC.IsParentABatchTag) // Do even more validation
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.ItemAlreadyAssignedToAnotherBatchTag;
                    }
                }
                else if ((parentItemType == ItemTypeIdentifier.Carriage) || (parentItemType == ItemTypeIdentifier.BaseCarriage))
                {
                    if (!scanDC.ErrorCode.HasValue && scanDC.ParentTurnaroundId.HasValue && scanDC.IsParentACarriage) // Do even more validation
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.ItemAlreadyAssignedToAnotherCarriage;
                    }
                }
            }

            return !scanDC.ErrorCode.HasValue;
        }

        /// <summary>
        /// ValidateForTrolleyWasher operation
        /// </summary>
        public static void ValidateForTrolleyWasher(ScanAssetDataContract scanDC)
        {
            if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Tray)
            {
                scanDC.ErrorCode = (int)ErrorCodes.CantScanTrayOntoTrolleyWasher;
            }
            else if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.LoanTray)
            {
                scanDC.ErrorCode = (int)ErrorCodes.CantScanLoanTrayOntoTrolleyWasher;
            }
            else if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Supplementary)
            {
                scanDC.ErrorCode = (int)ErrorCodes.CantScanSupplementaryTrayOntoTrolleyWasher;
            }
            else if ((scanDC.Asset.MachineTypeId == (int)MachineTypeIdentifier.SuperUltrasound) ||
                     (scanDC.Asset.MachineTypeId == (int)MachineTypeIdentifier.SuperUltraSound2))
            {
                scanDC.ErrorCode = (int)ErrorCodes.CantScanUltrasonicItemsOntoTrolleyWasher;
            }
            else if (scanDC.Asset.MachineTypeId != (int)MachineTypeIdentifier.TrolleyWasher)
            {
                scanDC.ErrorCode = (int)ErrorCodes.OnlyTrolleyWashItemsInATrolleyWasher;
            }
            else if ((scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley) &&
                     ((scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.LoadTrolleyEPOC) ||
                      (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AvailableForCollection) ||
                      (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.Collected)))
            {
                scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
            }
        }

        #endregion
    }
}
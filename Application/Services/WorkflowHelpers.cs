using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {
        private void CheckCustomerWorkflow(ScanAssetDataContract scanDC, short eventToCheck)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                var workflowRepository = WorkflowRepository.New(workUnit);
                var deliverPt = deliveryPointRepository.Get(scanDC.DeliveryPtId);

                if (deliverPt != null)
                {
                    var customerWorkflowRepository = CustomerWorkflowRepository.New(workUnit);

                    var icw = customerWorkflowRepository.ReadCustomerWorkflowByEventTypeIdAndCustomerDefinitionId(eventToCheck, deliverPt.CustomerDefinitionId);
                    if (icw != null)
                    {
                        scanDC.SetExpiryTime = icw.IsStartEvent;
                        scanDC.HasCustomerWorkflow = true;

                        return;
                    }
                    else
                    {
                        scanDC.SetExpiryTime = false;
                        scanDC.HasCustomerWorkflow = false;
                    }
                    var workflow = workflowRepository.ReadWorkflow((int?)scanDC.LastProcessEventTypeId, eventToCheck, scanDC.Asset.ItemTypeId, scanDC.FacilityId, scanDC.Asset.ContainerMasterId, scanDC.DeliveryPtId);
                    if (workflow != null && !workflow.IsBestPractice)
                    {
                        scanDC.SetExpiryTime = true;
                        scanDC.HasCustomerWorkflow = true;
                    }
                    else
                    {
                        scanDC.SetExpiryTime = false;
                        scanDC.HasCustomerWorkflow = false;
                    }
                }
            }
        }

        /// <summary>
        /// Primarily used for checking batch tags and carriages.
        /// </summary>
        /// <param name="scanDC"></param>
        /// <param name="scanDetails"></param>
        /// <returns></returns>        
        private bool PreworkflowValidation(ScanAssetDataContract scanDC, ScanDetails scanDetails, bool isCreatingNewTurnaround)
        {
            if (_isLastEventAnEndEvent && !_isProcessEvent && isCreatingNewTurnaround)
            {

                if ((scanDC.IsArchived) && (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AuditFailed || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AuditFinished || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AuditCancelled))
                {
                    scanDC.ErrorCode = (int)ErrorCodes.TurnaroundIsArchived;
                }
                else
                {
                    scanDC.ErrorCode = (int)ErrorCodes.CantStartTurnaroundWithNonProcessEvent;
                }

                return false;
            }
            if (scanDC.IsInQuarantine && _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoQuarantine)
            {
                scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                return false;
            }

            if (!EpocEpodValidation(scanDC, scanDetails))
            {
                return false;
            }

            if (!WashValidation(scanDC, scanDetails))
            {
                return false;
            }

            if ((scanDetails.ParentTurnaroundId.HasValue) && (scanDetails.ParentItemTypeId.HasValue))
            {
                var parentItemType = (ItemTypeIdentifier)scanDetails.ParentItemTypeId;

                if ((parentItemType == ItemTypeIdentifier.BatchTag) || (parentItemType == ItemTypeIdentifier.BatchTagOriginal))
                {
                    var bt = new BatchTag(CreateTurnaroundEventData(scanDC, scanDetails, _synergyTrakData.EventTypeId));
                    bt.ValidateAssignToBatchTag(scanDC, scanDetails);
                }
                else if ((parentItemType == ItemTypeIdentifier.Carriage) || (parentItemType == ItemTypeIdentifier.BaseCarriage))
                {
                    var car = new Carriage(CreateTurnaroundEventData(scanDC, scanDetails, _synergyTrakData.EventTypeId));
                    car.ValidateAssignToCarriage(scanDC, scanDetails);
                }
            }

            if (!ValidateDeconTaskRules(scanDC, scanDetails))
            {
                return false;
            }

            if (!CustomerStopValidation(scanDC, scanDetails))
            {
                return false;
            }

            if (scanDC.EventTypeId == TurnAroundEventTypeIdentifier.IntoStock &&
                scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.IntoAutoclave)
            {
                OOAStockInValidation(scanDC, scanDetails);
            }

            if (scanDC.EventTypeId == TurnAroundEventTypeIdentifier.AddedToTrolley && (scanDetails.IsDispatchingStock ?? false) && scanDetails.DeliveryPointId.HasValue)
            {
                OOATrolleyDispatchAddStockToTrolley(scanDC, scanDetails);
            }
            if (scanDC.EventTypeId == TurnAroundEventTypeIdentifier.AuditStarted &&
                (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Tray &&
                scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.LoanTray &&
                scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Supplementary &&
                scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Endoscopy
                ))
            {
                scanDC.ErrorCode = (int)ErrorCodes.AuditInvalidItemType;
            }

            if ((scanDC.Asset != null) && ((scanDC.Asset.IsContainerMasterArchived) || (scanDC.Asset.IsContainerInstanceArchived)))
            {
                scanDC.ErrorCode = (int)ErrorCodes.ArchivedContainerMaster;
            }
            else if ((scanDC.IsArchived) && (_isProcessEvent) && (_synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.Archived))
            {
                scanDC.ErrorCode = (int)ErrorCodes.TurnaroundIsArchived;
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.WashRelease)
            {
                if (scanDC.FacilityId != scanDetails.FacilityId)
                {
                    scanDC.ErrorCode = (int)ErrorCodes.WashReleaseSwitchedFacility;
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.OutofAutoclave)
            {
                if (scanDetails.IsWarnForDifferentDeliveryPoints && scanDetails.DeliveryPointId.HasValue &&
                    scanDC.DeliveryPtId != scanDetails.DeliveryPointId)
                {
                    scanDC.ErrorCode = (int)ErrorCodes.DifferentDeliveryPoints;
                    return false;
                }

                {
                    var turnaroundEventRepository = TurnaroundEventRepository.New(workUnit);
                    var lastProcessEvent = turnaroundEventRepository.Get(scanDC.LastProcessEventId.Value);

                    if (scanDC.TurnaroundEvents.FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoAutoclave) == null)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.AddToAutoclaveOutBatch;
                    }
                    else if (scanDC.FacilityId != scanDetails.FacilityId && lastProcessEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoAutoclave)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.OutOfAutoclaveSwitchedFacility;
                    }
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Dispatch && scanDetails.IsDispatchingStock == true && scanDetails.DeliveryPointId != null)
            {
                if (DispatchOutOfStock(scanDC, scanDetails) == false)
                {
                    return false;
                }
            }

            if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.PartWash) &&
                (scanDetails.StationTypeId == (int)StationTypeIdentifier.Wash || scanDetails.StationTypeId == (int)StationTypeIdentifier.Decon))
            {
                CheckAutomaticCollection(scanDC, scanDetails);
            }

            if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.FailedWash) && (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BaseCarriage) && (!scanDetails.ApplyToBatch))
            {
                scanDC.ErrorCode = (int)ErrorCodes.CantFailCarriages;
            }

            if ((scanDC.Asset != null) && ((scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag) || (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTagOriginal)))
            {
                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.StartPacking)
                {
                    scanDC.ErrorCode = (int)ErrorCodes.CantScanBatchTagAtPacking;
                }
                else if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.FailedQualityAssurance)
                {
                    scanDC.ErrorCode = (int)ErrorCodes.CantScanBatchTagAtFailedQualityAssurance;
                }
                else if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.BatchTagCreated) || (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage))
                {
                    if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.ItemAlreadyAssignedToAnotherCarriage;
                    }
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.ReprintLabel)
            {
                if (_isLastEventAnEndEvent || scanDC.TurnaroundId == null)
                {
                    if (scanDetails.TurnaroundExternalId != null)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.TurnaroundIsArchived;
                    }
                    else if (scanDetails.ExternalId != null)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.NoCurrentTurnaround;
                    }
                }
                else if (!scanDC.TurnaroundEvents.Exists(t => t.EventTypeId == (int)TurnAroundEventTypeIdentifier.QualityAssurance))
                {
                    scanDC.ErrorCode = (int)ErrorCodes.ItemMustHaveHadQAToReprint;
                }
            }

            if ((scanDetails.BaseItemTypeId.HasValue) && (scanDC.Asset != null) && (scanDC.Asset.BaseItemTypeId != scanDetails.BaseItemTypeId.Value))
            {
                var trayCompatibleTypes = new[] { (int)ItemTypeIdentifier.Tray, (int)ItemTypeIdentifier.LoanTray };

                if (!trayCompatibleTypes.Contains(scanDC.Asset.BaseItemTypeId) && !trayCompatibleTypes.Contains(scanDetails.BaseItemTypeId.Value))
                {
                    scanDC.ErrorCode = (int)ErrorCodes.ScannedWrongItemType;
                }
            }

            if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.PartWash) && (_synergyTrakData.IsRemoveFromParent == false))
            {
                if ((scanDC.IsParentABatchTag) && (scanDC.LastProcessEventTypeId.HasValue) && (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AssignToBatchTag))
                {
                    return false;
                }

                if ((scanDC.IsParentACarriage) && (scanDC.LastProcessEventTypeId.HasValue) && (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage))
                {
                    return false;
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoAutoclave && scanDetails.BatchId != null)
            {
                ValidateBatchCycle(scanDC, scanDetails.BatchId.Value);
            }

            if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.WashRelease ||
                (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.FailedWash && scanDetails.ApplyToBatch && scanDC.TurnaroundEvents.Any(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.WashRelease)) &&
                    scanDC.TurnaroundEvents.Any(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.WashIn)))
            {
                SetAndValidateBatchId(scanDC, scanDetails);
            }
            else if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.FailedWash && scanDetails.ApplyToBatch &&
                        scanDC.TurnaroundEvents.Any(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.Wash))
            {
                SetAndValidateBatchId(scanDC, scanDetails);
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.FailedWash && scanDetails.ApplyToBatch && scanDC.TurnaroundEvents.All(te => te.EventTypeId != (int)TurnAroundEventTypeIdentifier.WashRelease) &&
                (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage || scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.WashIn))
            {
                scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;

                if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage)
                {
                    scanDC.NextEventId = (int)TurnAroundEventTypeIdentifier.WashIn;
                }
                else
                {
                    scanDC.NextEventId = (int)TurnAroundEventTypeIdentifier.WashRelease;
                }

                {
                    var eventTypeRepository = EventTypeRepository.New(workUnit);
                    var nextEvent = eventTypeRepository.Get(scanDC.NextEventId);
                    scanDC.NextEvent = nextEvent.Text;
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToTransferNote)
            {
                if (ValidateAddedToTransferNote(scanDC, scanDetails) == false)
                {
                    return false;
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.FacilityTransferOutbound)
            {
                if (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Trolley)
                {
                    scanDC.ErrorCode = (int)ErrorCodes.InvalidItem;
                    return false;
                }
                if (scanDetails.TransferNoteId == null || scanDetails.RouteToEventTypeId == null)
                {
                    using (var repository = new PathwayRepository())
                    {
                        var transferNote = repository.Container.TransferNote.FirstOrDefault(tn => tn.TransportTurnaroundId == scanDC.TurnaroundId && tn.DispatchTransferNoteEventId == null);
                        if (transferNote != null)
                        {
                            scanDetails.TransferNoteId = transferNote.TransferNoteId;
                            scanDetails.RouteToEventTypeId = transferNote.RouteToEventTypeId;
                        }
                    }
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.RemovedFromTransferNote)
            {
                {
                    if (GetTransferNoteRerouteEvent(scanDC, scanDetails, workUnit) == false)
                    {
                        return false;
                    }
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Inbound)
            {
                if (TransferNoteInbound(scanDC, scanDetails) == false)
                {
                    return false;
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Archived || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoQuarantine)
            {
                {
                    {
                        var transferNote = repository.Container.TransferNote.FirstOrDefault(tn => tn.TransportTurnaroundId == scanDC.TurnaroundId || tn.TransportTurnaroundId == scanDC.ParentTurnaroundId.Value);
                        if (transferNote != null)
                        {
                            scanDetails.TransferNoteId = transferNote.TransferNoteId;

                            var transferNoteLine = transferNote.TransferNoteLine.FirstOrDefault(tnl => tnl.TurnaroundId == scanDC.TurnaroundId);

                            if (transferNoteLine != null)
                            {
                                scanDetails.TransferNoteLineId = transferNoteLine.TransferNoteLineId;
                            }

                            scanDetails.UseFirstRerouteEvent = true;
                            if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                            {
                                foreach (var dc in _synergyTrakData.ScanDcList.Where(x => x.TurnaroundId != scanDC.TurnaroundId))
                                {
                                    if (_synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.RemovedFromTransferNote)
                                    {
                                        scanDetails.RouteToEventTypeId = null;
                                    }

                                    GetTransferNoteRerouteEvent(dc, scanDetails, workUnit);
                                }
                            }

                            RemoveFromTransferNote(scanDC, scanDetails);
                        }
                        if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.ReviewNeeded)
                        {
                            scanDC.ItemExceptionApprovalFlag = false;
                            ApplyEvent(
                                new List<ApplyTurnaroundEventDetails>
                                {
                                    new ApplyTurnaroundEventDetails {EventType = TurnAroundEventTypeIdentifier.Reviewed},
                                    new ApplyTurnaroundEventDetails {EventType = TurnAroundEventTypeIdentifier.PackingProcessEnded}
                                },
                                scanDC, scanDetails);

                        }
                    }
                }
            }
            if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoPigeonHoleStock || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToOrder))
            {
                var disp = new DispatchEvents(CreateTurnaroundEventData(scanDC, scanDetails, _synergyTrakData.EventTypeId));
                disp.AutomaticDispatch(scanDC, scanDetails);
            }
            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Archived &&
                scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.LoadTrolleyEPOD && scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley && scanDC.ChildItems.Any())
            {
                foreach (var childScanDc in scanDC.ChildItems)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AutomaticDelivery, IsAutomaticEvent = true, RemoveFromParent = true }, childScanDc, scanDetails);
                }

                scanDC.ChildItems.Clear();
            }
            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Archived &&
                scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.TrolleyStarted && scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley && scanDC.ChildItems.Any())
            {
                foreach (var childScanDc in scanDC.ChildItems)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemovedFromTrolley, IsAutomaticEvent = true, RemoveFromParent = true }, childScanDc, scanDetails);
                    _synergyTrakData.ScanDcList.Remove(childScanDc);
                }

                scanDC.ChildItems.Clear();
            }

            if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AddedToTrolley &&
                (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.WetPack || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.BrokenPack))
            {
                _preWorkflowEventId = (int)TurnAroundEventTypeIdentifier.RemovedFromTrolley;
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToOrder && scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.LoadTrolleyEPOD)
            {
                AutomaticDelivery(scanDC, scanDetails);
            }

            return !scanDC.ErrorCode.HasValue;
        }

        private bool DispatchOutOfStock(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var lastEvent = scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.IsProcessEvent);

            if (lastEvent != null && lastEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoStock)
            {
                if (_synergyTrakData.CanApplyEvent || _ignoreNotesWarningsAndDecon)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.OutOfStock }, scanDC, scanDetails);
                }
                var teEvent = scanDC.TurnaroundEvents.OrderByDescending(o => o.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.OutOfStock);

                if (teEvent == null)
                {
                    return false;
                }
            }
            else
            {
                scanDC.ErrorCode = ((scanDC.TurnaroundId.HasValue && scanDC.TurnaroundId > 0) || (scanDC.TurnaroundExternalId > 0)) ?
                            (int)ErrorCodes.TurnaroundInvalidNextEvent :
                            (int)ErrorCodes.InvalidNextEvent;
            }

            return true;
        }

        private void AutomaticDelivery(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                var workflowRepository = WorkflowRepository.New(workUnit);
                var validLoadTrolleyEpodAutomaticDeleveryWorkflow = workflowRepository.ReadWorkflow((int?)scanDC.LastProcessEventTypeId, (int)TurnAroundEventTypeIdentifier.AutomaticDelivery, scanDC.Asset.ItemTypeId, scanDC.FacilityId, scanDC.Asset.ContainerMasterId, scanDC.DeliveryPtId);
                var validAutomaticDeliveryToAddToOrderWorkflow = workflowRepository.ReadWorkflow((int?)TurnAroundEventTypeIdentifier.AutomaticDelivery, (int)_synergyTrakData.EventTypeId, scanDC.Asset.ItemTypeId, scanDC.FacilityId, scanDC.Asset.ContainerMasterId, scanDC.DeliveryPtId);

                if (validLoadTrolleyEpodAutomaticDeleveryWorkflow != null && validAutomaticDeliveryToAddToOrderWorkflow != null)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AutomaticDelivery, IsAutomaticEvent = true }, scanDC, scanDetails);
                }
            }
        }

        private void SetAndValidateBatchId(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                var turnaroundEventRepository = TurnaroundEventRepository.New(workUnit);
                var batchRepository = BatchRepository.New(workUnit);
                var machineRepository = MachineRepository.New(workUnit);

                var lastWashInEvent =
                    scanDC.TurnaroundEvents.OrderByDescending(te => te.Created)
                        .FirstOrDefault(x => x.EventTypeId == (int)TurnAroundEventTypeIdentifier.WashIn);
                var lastChangedBatchEvent =
                    scanDC.TurnaroundEvents.OrderByDescending(te => te.Created)
                        .FirstOrDefault(x => x.EventTypeId == (int)TurnAroundEventTypeIdentifier.ChangedBatch);

                var lastWashEvent =
                    scanDC.TurnaroundEvents.OrderByDescending(te => te.Created)
                        .FirstOrDefault(x => x.EventTypeId == (int)TurnAroundEventTypeIdentifier.Wash);
                if (lastWashInEvent != null)
                {
                    if (scanDetails.BatchId.HasValue)
                    {
                        scanDC.BatchId = scanDetails.BatchId;
                    }
                    else
                    {
                        scanDC.BatchId = lastChangedBatchEvent != null &&
                                         lastChangedBatchEvent.Created > lastWashInEvent.Created
                            ? turnaroundEventRepository.Get(lastChangedBatchEvent.TurnaroundEventId).BatchId
                            : turnaroundEventRepository.Get(lastWashInEvent.TurnaroundEventId).BatchId;
                    }

                    if (scanDC.BatchId.HasValue)
                    {
                        var batch = batchRepository.Get(scanDC.BatchId.Value);

                        scanDC.BatchName = batch.ExternalId;
                        scanDC.WasherName = machineRepository.Get(batch.MachineId.Value).Text;

                        if (string.IsNullOrEmpty(scanDC.BatchName) || string.IsNullOrEmpty(scanDC.WasherName))
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.TurnaroundNotPartOfABatch;
                        }
                    }
                    else
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.BatchDoesNotExist;
                    }
                }
                else if (lastWashEvent != null)
                {
                    scanDC.BatchId = scanDetails.BatchId.HasValue
                        ? scanDetails.BatchId
                        : turnaroundEventRepository.Get(lastWashEvent.TurnaroundEventId).BatchId;

                    if (scanDC.BatchId.HasValue)
                    {
                        var batch = batchRepository.Get(scanDC.BatchId.Value);

                        scanDC.BatchName = batch.ExternalId;
                        scanDC.WasherName = machineRepository.Get(batch.MachineId.Value).Text;

                        if (string.IsNullOrEmpty(scanDC.BatchName) || string.IsNullOrEmpty(scanDC.WasherName))
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.TurnaroundNotPartOfABatch;
                        }
                    }
                    else
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.BatchDoesNotExist;
                    }
                }
            }
        }

        private static bool CustomerStopValidation(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                var customerRepository = CustomerRepository.New(workUnit);
                var customerFacilityId = scanDC.FacilityId;

                if (scanDC.Asset != null)
                {
                    if (scanDC.Asset.FacilityId.HasValue && (scanDC.Asset.FacilityId.Value != scanDetails.FacilityId))
                    {
                        customerFacilityId = scanDC.Asset.FacilityId.Value;
                    }

                    var customer = customerRepository.GetCustomersByFacility((short)customerFacilityId).FirstOrDefault(c => c.Text == scanDC.Asset.CustomerName);

                    if ((customer != null) && (customer.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Stop))
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.CustomerOnStop;
                    }
                }
            }

            return !scanDC.ErrorCode.HasValue;
        }

        private bool GetTransferNoteRerouteEvent(ScanAssetDataContract scanDC, ScanDetails scanDetails, IUnitOfWork workUnit)
        {
            var workflowRepository = WorkflowRepository.New(workUnit);
            List<WorkflowDataContract> nextEventTypes;

            if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag && scanDC.ChildItems != null && scanDC.ChildItems.Any())
            {
                nextEventTypes = workflowRepository.GetTransferNoteRerouteEvents(scanDC.ChildItems.First().TurnaroundId.GetValueOrDefault()).ToList();
            }
            else
            {
                nextEventTypes = workflowRepository.GetTransferNoteRerouteEvents(scanDC.TurnaroundId.GetValueOrDefault()).ToList();
            }

            if (nextEventTypes.Any())
            {
                if (!scanDetails.UseFirstRerouteEvent && nextEventTypes.Count() > 1 && scanDetails.RouteToEventTypeId == null)
                {
                    scanDC.Asset.TransferNoteReRouteEventTypeList = new List<EventTypeListDataContract>();

                    scanDC.Asset.TransferNoteReRouteEventTypeList.AddRange(
                        nextEventTypes.Select(e => new EventTypeListDataContract
                        {
                            EventTypeId = e.NextEventTypeId,
                            EventType = e.NextEvent
                        }));

                    scanDC.Asset.MoreThanOneReRouteEvent = true;
                    return false;
                }
                scanDC.RouteToEventTypeId = (TurnAroundEventTypeIdentifier)(scanDetails.RouteToEventTypeId ?? (nextEventTypes.OrderBy(o => o.Rank).First().NextEventTypeId));
                scanDC.Asset.MoreThanOneReRouteEvent = false;

                if (!scanDetails.RouteToEventTypeId.HasValue)
                {
                    scanDetails.RouteToEventTypeId = (short)nextEventTypes.First().NextEventTypeId;
                }
            }
            else
            {
                scanDC.ErrorCode = (int)ErrorCodes.ApplyTurnaroundEventError;
                scanDC.TransferNote = TransferNoteHelper.GetTransferNote(new TransferNoteRequestDataContract() { TransferNoteId = scanDetails.TransferNoteId.GetValueOrDefault() });
                return false;
            }

            return true;
        }

        private static void GetNextEvent(ScanAssetDataContract scanDC)
        {
            if (scanDC.TurnaroundId.HasValue)
            {
                {
                    var turnaroundWhRepository = TurnaroundWHRepository.New(workUnit);
                    var turnaroundWh = turnaroundWhRepository.GetByTurnaround(scanDC.TurnaroundId.GetValueOrDefault());

                    if (turnaroundWh != null)
                    {
                        if (turnaroundWh.NextEventTypeId.HasValue)
                        {
                            scanDC.NextEventId = turnaroundWh.NextEventTypeId.Value;
                        }

                        scanDC.NextEvent = turnaroundWh.NextEventName;
                    }
                }
            }
        }

        private bool IsWorkflowStepValid(ScanAssetDataContract scanDC, TurnAroundEventTypeIdentifier eventType, int? preWorkflowEventId, bool ignoreLastProcessEvent = false)
        {
            Workflow nextWorkflow = null;

            try
            {
                {
                    var workflowRepository = WorkflowRepository.New(workUnit);

                    int? lastProcessEventTypeId = null;

                    if (!ignoreLastProcessEvent)
                    {
                        lastProcessEventTypeId = preWorkflowEventId ?? (int?)scanDC.LastProcessEventTypeId;
                    }

                    nextWorkflow = workflowRepository.ReadWorkflow(lastProcessEventTypeId, (int)eventType, scanDC.Asset.ItemTypeId, _synergyTrakData.FacilityId, scanDC.Asset.ContainerMasterId, scanDC.DeliveryPtId);

                    if (nextWorkflow != null)
                    {
                        scanDC.IsTurnaroundEnded = nextWorkflow.IsEnd;
                        scanDC.IsBestPracticeWorkflow = nextWorkflow.IsBestPractice;
                    }
                }
            }
            catch (Exception)
            {
                scanDC.ErrorCode = (int)ErrorCodes.MissingWorkflowEntry;
            }

            return (nextWorkflow != null);
        }

        private void GetNextEventViaWorkflow(ScanAssetDataContract scanDC)
        {
            {
                var workflowRepository = WorkflowRepository.New(workUnit);

                var nextEventType = workflowRepository.ReadNextEvent((int?)scanDC.LastProcessEventTypeId,
                    scanDC.Asset.ItemTypeId, _synergyTrakData.FacilityId, scanDC.Asset.ContainerMasterId, scanDC.DeliveryPtId);

                if (nextEventType != null)
                {
                    scanDC.NextEventId = nextEventType.EventTypeId;
                    scanDC.NextEvent = nextEventType.Text;
                }
            }
        }
    }
}
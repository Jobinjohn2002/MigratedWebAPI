using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {
        private bool ParentValidation(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            CheckIfAlreadyAssigned(scanDC, scanDetails);
            if (!_synergyTrakData.IsRemoveFromParent && (_synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.Archived && _synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.WashRelease) && (!scanDC.ErrorCode.HasValue))
            {
                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.FailedWash && scanDetails.ApplyToBatch)
                {
                    return true;
                }
                if ((scanDC.IsParentABatchTag) && ((_isProcessEvent) && (_synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.RemoveFromBatchTag) &&
                    (_synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.RemovedFromCarriage) && (_synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.IntoQuarantine)))
                {
                    return false;
                }

                if ((scanDC.IsParentACarriage) && ((_isProcessEvent) && (_synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.RemovedFromCarriage) &&
                    (_synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.RemoveFromBatchTag) && (_synergyTrakData.EventTypeId != TurnAroundEventTypeIdentifier.IntoQuarantine)))
                {
                    return false;
                }
            }

            return !scanDC.ErrorCode.HasValue;
        }

        private bool WashValidation(ScanAssetDataContract scannedAssetData, ScanDetails scanDetails)
        {
            switch (_synergyTrakData.EventTypeId)
            {
                case TurnAroundEventTypeIdentifier.CarriageCreated:
                    Carriage.ValidateForCarriageCreated(scannedAssetData);
                    break;

                case TurnAroundEventTypeIdentifier.Wash:
                case TurnAroundEventTypeIdentifier.WashIn:
                    ValidateForWash(scannedAssetData, scanDetails);
                    break;

                case TurnAroundEventTypeIdentifier.PartWash:
                    ValidateForPartWash(scannedAssetData, scanDetails);
                    break;

                case TurnAroundEventTypeIdentifier.BatchTagCreated:
                    BatchTag.ValidateForBatchTagCreated(scannedAssetData);
                    break;

                default:
                    break;
            }

            return !scannedAssetData.ErrorCode.HasValue;
        }

        /// <summary>
        /// Makes sure the scanned asset is a BatchTag.
        /// If it is not then the error code on the <see cref="ScanAssetDataContract"/> is set to <see cref="ErrorCodes.ScannedWrongItemType"/>
        /// </summary>
        /// <param name="scannedAssetData">The <see cref="ScanAssetDataContract"/> to check.</param>
        private void ValidateForWash(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (!scanDetails.MachineTypeId.HasValue)
            {
                return;
            }

            if (scanDetails.MachineTypeId.Value == (int)MachineTypeIdentifier.TrolleyWasher)
            {
                BasicTurnaroundEvents.ValidateForTrolleyWasher(scanDC);
            }

            if ((scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley) &&
                (scanDetails.MachineTypeId.Value != (int)MachineTypeIdentifier.TrolleyWasher))
            {
                scanDC.ErrorCode = (int)ErrorCodes.TrolleysMustUseATrolleyWasher;
            }

            if ((scanDC.Asset.MachineTypeId == (int)MachineTypeIdentifier.HandWash) &&
                (scanDetails.MachineTypeId.Value != (int)MachineTypeIdentifier.HandWash))
            {
                scanDC.ErrorCode = (int)ErrorCodes.NoHandWashItemsInAWasher;
            }

            if ((scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Trolley) &&
                (scanDetails.MachineTypeId.Value == (int)MachineTypeIdentifier.TrolleyWasher))
            {
                scanDC.ErrorCode = (int)ErrorCodes.NoNoneTrolleyItemsInATrolleyWasher;
            }

            if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.WashIn) &&
                ((ItemTypeIdentifier)scanDC.Asset.ItemTypeId != ItemTypeIdentifier.Carriage &&
                 (ItemTypeIdentifier)scanDC.Asset.ItemTypeId != ItemTypeIdentifier.BaseCarriage))
            {
                scanDC.ErrorCode = (int)ErrorCodes.CarriagesOnlyForWashRelease;
            }

            if (scanDC.ErrorCode == null && _machineTypeId.HasValue)
            {
                if (scanDC.Asset.MachineTypeId != _machineTypeId)
                {
                    _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.PartWash;
                }

                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.PartWash)
                {
                    scanDC.IsDeconEndRequired = false;
                }
            }
            if (!scanDC.ErrorCode.HasValue)
            {
                switch (scanDC.Asset.BaseItemTypeId)
                {
                    case (int)ItemTypeIdentifier.BaseCarriage:
                        if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.PartWash)
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.NoPartWashingCarriages;
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        private void ValidateForPartWash(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (!_isNewTurnaround)
            {
                return;
            }
            if (scanDetails.Events.FirstOrDefault()?.EventType == (int)TurnAroundEventTypeIdentifier.Wash
                && _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.PartWash
                && scanDC.Asset.MachineTypeId == _machineTypeId)
            {
                _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.Wash;
            }
        }
        /// <summary>
        /// ValidateAssignToBatchTag operation
        /// </summary>
        public bool ValidateAssignToBatchTag(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                var eventTypeRepository = EventTypeRepository.New(workUnit);

                ItemTypeIdentifier itemType = (ItemTypeIdentifier)scanDC.Asset.ItemTypeId;

                if ((itemType == ItemTypeIdentifier.BatchTag) || (itemType == ItemTypeIdentifier.ChildBatchTag) || (itemType == ItemTypeIdentifier.BatchTagOriginal))
                {
                    scanDC.ErrorCode = (int)ErrorCodes.NoBatchTagsOnABatchTag;
                }
                else if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignToBatchTag)
                {
                    CheckIfAlreadyAssigned(scanDC, scanDetails);
                    if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.RemoveFromBatchTag && scanDC.IsDeconEndRequired)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                        scanDC.NextEventId = (int)TurnAroundEventTypeIdentifier.DeconEnd;

                        var nextEventType = eventTypeRepository.Get(scanDC.NextEventId);

                        if (nextEventType != null)
                        {
                            scanDC.NextEvent = nextEventType.Text;
                        }
                    }
                }

                if (!scanDC.ErrorCode.HasValue) // Do some more validation
                {
                    if ((itemType == ItemTypeIdentifier.Carriage) || (itemType == ItemTypeIdentifier.BaseCarriage))
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.NoCarriagesOnABatchTag;
                    }
                    else if (itemType == ItemTypeIdentifier.Trolley)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.NoTrolleysOnABatchTag;
                    }
                }

                if (!scanDC.ErrorCode.HasValue)
                {
                    BatchTag.ValidateAssignToBatchTagForProcessing(scanDC, scanDetails, scanDC.DeliveryPtId, workUnit);
                }

                if (!scanDC.ErrorCode.HasValue)
                {
                    var firstChild = turnaroundRepository.Get(scanDetails.ParentTurnaroundId.Value).ChildTurnaround.FirstOrDefault();

                    if (firstChild != null)
                    {
                        var batchTagAdditionalWashCycles = firstChild.ContainerMaster.ProcessingDecontaminationTasks;
                        var trayAdditionalWashCycles = containerMasterRepository.Get(scanDC.Asset.ContainerMasterId).ProcessingDecontaminationTasks;

                        if (batchTagAdditionalWashCycles != null && batchTagAdditionalWashCycles.Any())
                        {
                            if (batchTagAdditionalWashCycles.Count != trayAdditionalWashCycles.Count)
                            {
                                scanDC.ErrorCode = (int)ErrorCodes.BatchTagDifferentAdditionalWashCycles;
                            }
                            else
                            {
                                foreach (var cycle in batchTagAdditionalWashCycles)
                                {
                                    if (trayAdditionalWashCycles.All(bc => bc.DecontaminationTaskId != cycle.DecontaminationTaskId))
                                    {
                                        scanDC.ErrorCode = (int)ErrorCodes.BatchTagDifferentAdditionalWashCycles;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (trayAdditionalWashCycles != null && trayAdditionalWashCycles.Any())
                            {
                                scanDC.ErrorCode = (int)ErrorCodes.BatchTagDifferentAdditionalWashCycles;
                            }
                        }

                        if (string.IsNullOrEmpty(scanDC.Message))
                        {
                            scanDC.Message = firstChild.ContainerMaster.ItemType.Text;
                        }
                    }
                }
            }

            return !scanDC.ErrorCode.HasValue;
        }

        private bool ValidateDeconTaskRules(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                var eventTypeRepository = EventTypeRepository.New(workUnit);
                var transferNoteLineRepository = TransferNoteLineRepository.New(workUnit);
                if (scanDetails.RetrospectiveProcessStationTypeId > 0)
                {
                    return true;
                }
                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.DeconEnd && _synergyTrakData.ScanDcList.First().Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Endoscopy)
                {
                    return true;
                }

                if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Wash || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.DeconEnd ||
                     _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.DeconStart || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignToBatchTag ||
                     _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage) && (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BaseCarriage))
                {
                    if (scanDC.Asset.DecontaminationTasks != null && scanDC.Asset.DecontaminationTasks.Count > 0)
                    {
                        scanDC.CompletedPartWashes = CompletedPartWashes(scanDC);
                    }

                    if (scanDC.IsDeconEndRequired &&
                        scanDC.Asset.DecontaminationTasks != null && scanDC.Asset.DecontaminationTasks.Count > 0)
                    {
                        _synergyTrakData.CanApplyEvent = false;
                    }
                    else if (!DecontaminationComplete(scanDC) && scanDC.StationTypeId == (int)StationTypeIdentifier.Wash &&
                        scanDC.Asset.DecontaminationTasks != null && scanDC.Asset.DecontaminationTasks.Count > 0 && scanDC.DisplayDeconTasks)
                    {
                        _synergyTrakData.CanApplyEvent = false;
                    }
                }
                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Wash)
                {
                    if (scanDC.IsDeconEndRequired)
                    {
                        if (Auditing.Validation(scanDC, scanDetails, _synergyTrakData))
                        {
                            if (_synergyTrakData.CanApplyEvent)
                            {
                                if (!scanDC.IsParentABatchTag && !scanDC.IsParentACarriage)
                                {
                                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.DeconEnd, CanSetTurnaroundExpiryTime = false }, _synergyTrakData.ScanDcList, scanDetails);
                                    scanDC.IsDeconEndRequired = false;
                                }
                                else
                                {
                                    _synergyTrakData.CanApplyEvent = false;
                                }
                            }
                        }
                    }
                }
                if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignToBatchTag || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage) &&
                    scanDetails.StationTypeId == (int)StationTypeIdentifier.Wash && scanDC.IsDeconEndRequired && !scanDC.IsParentACarriage && !scanDC.IsParentABatchTag)
                {
                    if (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BatchTag ||
                       (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag && _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage))
                    {
                        if (Auditing.Validation(scanDC, scanDetails, _synergyTrakData))
                        {
                            if (_synergyTrakData.CanApplyEvent)
                            {
                                ApplyEvent(
                                    new ApplyTurnaroundEventDetails
                                    {
                                        EventType = TurnAroundEventTypeIdentifier.DeconEnd,
                                        CanSetTurnaroundExpiryTime = false
                                    }, _synergyTrakData.ScanDcList, scanDetails);
                                scanDC.IsDeconEndRequired = Decon.IsDeconEndRequired(scanDC);
                            }
                            else
                            {
                                _preWorkflowEventId = (int)TurnAroundEventTypeIdentifier.DeconEnd;
                            }
                        }
                    }
                }
                bool quarantineForCSR = true;
                if (scanDetails is CustomerDefectDataContract)
                {
                    quarantineForCSR = (scanDetails as CustomerDefectDataContract).Quarantine;
                }

                if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoQuarantine ||
                    (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.CustomerDefectRaised && quarantineForCSR && !scanDetails.ReQuarantineAfterWash))
                    && scanDC.IsDeconEndRequired)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.DeconCancel, CanSetTurnaroundExpiryTime = false }, scanDC, scanDetails);
                    scanDC.IsDeconEndRequired = Decon.IsDeconEndRequired(scanDC);
                }

                if (scanDetails.StationTypeId == (int)StationTypeIdentifier.Wash && !scanDC.IsDeconEndRequired &&
                    _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.DeconEnd)
                {
                    scanDC.ErrorCode = (int)ErrorCodes.CannotApplyDeconEnd;
                }
                if (scanDC.IsDeconEndRequired
                    && scanDC.Asset.DecontaminationTasks != null
                    && scanDC.Asset.DecontaminationTasks.Any()
                    && !scanDetails.IgnoreNotesWarningsAndDecon
                    && (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Wash
                        || (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignToBatchTag && scanDetails.StationTypeId == (int)StationTypeIdentifier.Wash)
                        || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage)
                    )
                {
                    return false;
                }
                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.DeconStart && scanDC.IsDeconEndRequired)
                {
                    return false;
                }

                if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Wash || (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.DeconStart)) &&
                    scanDC.IsDeconEndRequired && !_synergyTrakData.CanApplyEvent)
                {
                    return false;
                }
                if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Wash || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage) && scanDC.Asset.DecontaminationTasks != null && scanDC.Asset.DecontaminationTasks.Any() &&
                     scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag && scanDC.HasChildren)
                {
                    if (transferNoteLineRepository.All().FirstOrDefault(tnl => tnl.TurnaroundId == scanDC.TurnaroundId && tnl.DispatchTransferNoteEventId != null) != null)
                    {
                        _synergyTrakData.CanApplyEvent = false;
                    }
                    else if (scanDC.TurnaroundEvents.All(te => te.EventTypeId != (int)TurnAroundEventTypeIdentifier.DeconStart))
                    {
                        foreach (var child in scanDC.ChildItems)
                        {
                            if (!Decon.CheckIfAllDeconTasksFulfilled(child))
                            {
                                var et = eventTypeRepository.Get((int)TurnAroundEventTypeIdentifier.DeconStart);
                                scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                                scanDC.NextEventId = et.EventTypeId;
                                scanDC.NextEvent = et.Text;

                                return false;
                            }
                        }
                    }
                }

                return true;
            }
        }

        private BatchCycleExtendedError GenerateNonBatchTagExtendedError(ContainerMaster containerMaster)
        {
            var batchCycleExtendedError = new BatchCycleExtendedError()
            {
                IsBatchTag = false,
                IncompatibleTurnarounds = new System.Collections.Generic.List<IncompatibleTurnaroundInfo>()
            };

            var turnaroundInfo = new IncompatibleTurnaroundInfo()
            {
                ExternalId = 0,
                BatchCycleNames = containerMaster.ProcessingBatchCycles.Select(x => x.Text).ToList()
            };

            batchCycleExtendedError.IncompatibleTurnarounds.Add(turnaroundInfo);

            return batchCycleExtendedError;
        }

        private BatchCycleExtendedError GenerateBatchTagExtendedError(Turnaround turnaround, int batchCycleId)
        {
            var batchCycleExtendedError = new BatchCycleExtendedError()
            {
                IsBatchTag = true,
                UsedBatchCycleTypes = new System.Collections.Generic.Dictionary<string, int>(),
                IncompatibleTurnarounds = new System.Collections.Generic.List<IncompatibleTurnaroundInfo>()
            };

            foreach (var child in turnaround.ChildTurnaround)
            {
                child.ContainerMaster.ProcessingBatchCycles.Select(x => x.Text).ToList().ForEach((batchTag) =>
                {
                    if (batchCycleExtendedError.UsedBatchCycleTypes.ContainsKey(batchTag))
                    {
                        batchCycleExtendedError.UsedBatchCycleTypes[batchTag]++;
                    }
                    else
                    {
                        batchCycleExtendedError.UsedBatchCycleTypes.Add(batchTag, 1);
                    }
                });

                if (child.ContainerMaster.ProcessingBatchCycles.All(x => x.BatchCycleId != batchCycleId))
                {
                    var turnaroundInfo = new IncompatibleTurnaroundInfo
                    {
                        ExternalId = child.ExternalId,
                        BatchCycleNames = child.ContainerMaster.ProcessingBatchCycles.Select(x => x.Text).ToList()
                    };

                    batchCycleExtendedError.IncompatibleTurnarounds.Add(turnaroundInfo);
                }
            }

            return batchCycleExtendedError;
        }

        private void ValidateBatchCycle(ScanAssetDataContract scanDC, int batchId)
        {
            {
                var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                var batchCycleRepository = BatchCycleRepository.New(workUnit);
                var batchRepository = BatchRepository.New(workUnit);
                var turnaroundRepository = TurnaroundRepository.New(workUnit);

                var batch = batchRepository.Get(batchId);
                var batchCycle = batchCycleRepository.Get(batch.BatchCycleId.Value);
                var containerMaster = containerMasterRepository.Get(scanDC.Asset.ContainerMasterId);

                if (batchCycle != null)
                {
                    if (containerMaster.ItemType.ParentItemTypeId == (int)ItemTypeIdentifier.BatchTag)
                    {
                        var turnaround = turnaroundRepository.Get(scanDC.TurnaroundId.GetValueOrDefault());

                        if (turnaround?.ChildTurnaround != null && turnaround.ChildTurnaround.Any(c => c.ContainerMaster.ProcessingBatchCycles.All(bc => bc.BatchCycleId != batchCycle.BatchCycleId)))
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.IncompatibleBatchCycles;
                            scanDC.ExtendedErrorInformation = GenerateBatchTagExtendedError(turnaround, batchCycle.BatchCycleId);
                        }
                    }
                }
            }
        }

        private bool ValidateAddedToTransferNote(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToTransferNote && scanDetails.TransferNoteId.HasValue &&
                (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Tray || scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.LoanTray ||
                 scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag || scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Supplementary ||
                 scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra || scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Endoscopy))
            {
                var result = TransferNoteHelper.AddToTransferNoteValidation(scanDC, scanDetails);

                if (result != ValidateTransferResult.Valid)
                {
                    switch (result)
                    {
                        case ValidateTransferResult.InvalidRestrictions:
                            scanDC.ErrorCode = (int)ErrorCodes.ItemScannedTransferNoteRestriction;
                            break;
                        default:
                            scanDC.ErrorCode = (int)ErrorCodes.InvalidItemScannedTransferNote;
                            break;
                    }

                    return false;
                }
            }
            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToTransferNote && scanDetails.TransferNoteId.HasValue &&
                (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Tray || scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.LoanTray ||
                    scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag || scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Supplementary ||
                    scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra || scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Endoscopy))
            {
                {
                    var workflowRepository = WorkflowRepository.New(workUnit);
                    var validWorkflow = workflowRepository.ReadWorkflow((int?)TurnAroundEventTypeIdentifier.FacilityTransferOutbound, (int)scanDetails.RouteToEventTypeId, scanDC.Asset.ItemTypeId, _synergyTrakData.FacilityId, scanDC.Asset.ContainerMasterId, scanDC.DeliveryPtId);

                    if (validWorkflow == null)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.InvalidItemScannedTransferNote;
                        return false;
                    }
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToTransferNote && scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley && scanDetails.TransferNoteId.HasValue)
            {
                using (var repository = new PathwayRepository())
                {
                    var transferNote = repository.Container.TransferNote.FirstOrDefault(tn => tn.TransportTurnaroundId == scanDC.TurnaroundId.Value);
                    if (transferNote != null && transferNote.DispatchTransferNoteEventId == null)
                    {
                        scanDC.TransferNote = TransferNoteHelper.GetTransferNote(new TransferNoteRequestDataContract() { TransferNoteId = transferNote.TransferNoteId });
                        return false;
                    }

                    if (transferNote == null)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.NoMatchingTransferNoteForTrolley;
                        return false;
                    }
                }
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToTransferNote && scanDetails.DestinationFacilityId.HasValue && !scanDetails.TransferNoteId.HasValue)
            {
                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                {
                    {
                        var mfpRelationship = repository.Container.MultiFacilityProcessHandShake.FirstOrDefault(
                            hs => hs.RequestingFacilityId == _synergyTrakData.FacilityId &&
                                    hs.IsEnabled &&
                                    hs.MultiFacilityProcessing.AlternateProcessingFacilityId == scanDetails.DestinationFacilityId.Value &&
                                    hs.MultiFacilityProcessing.IsEnabled);
                        if (mfpRelationship == null)
                        {
                            mfpRelationship = repository.Container.MultiFacilityProcessHandShake.FirstOrDefault(
                                hs => hs.RequestingFacilityId == scanDetails.DestinationFacilityId.Value &&
                                        hs.IsEnabled &&
                                        hs.MultiFacilityProcessing.AlternateProcessingFacilityId == _synergyTrakData.FacilityId &&
                                        hs.MultiFacilityProcessing.IsEnabled);
                            if (mfpRelationship != null)
                            {
                                var trolleyDatabaseHelper = new TrolleyDatabaseHelper();
                                var trolleys = trolleyDatabaseHelper.GetTrolleySummary(scanDetails.ExternalId, scanDetails.DestinationFacilityId ?? 0).Where(x => x.IsOwner || (x.CanProcessForAnyCustomerFacility && x.CanProcessForMFPCustomer)).ToList();
                                if (trolleys.Count > 1)
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.DuplicateExternalId;
                                    return false;
                                }
                                else if (trolleys.Count == 0)
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.InvalidItemScannedTransferNote;
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    scanDC.ErrorCode = (int)ErrorCodes.InvalidItemScannedTransferNote;
                    return false;
                }
            }

            return true;
        }

        private bool TransferNoteInbound(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                {
                    if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                    {
                        var tn = repository.Container.TransferNote.FirstOrDefault(x => x.TransportTurnaroundId == scanDC.TurnaroundId);
                        if (tn?.DispatchTransferNoteEventId != null && tn.InboundEventId == null)
                        {
                            var facilityRepository = FacilityRepository.New(workUnit);
                            var facility = facilityRepository.Get(_synergyTrakData.FacilityId);
                            _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.FacilityTransferInbound;
                            _isProcessEvent = false;

                            scanDC.TransferNote = TransferNoteHelper.GetTransferNote(new TransferNoteRequestDataContract() { TransferNoteId = tn.TransferNoteId });
                            scanDC.SupervisorApprovalRequired = false;

                            if (facility.OwnerId != tn.ToOwnerId && scanDetails.SupervisorAction == SupervisorActions.NoActionTaken)
                            {
                                scanDC.SupervisorApprovalRequired = true;
                                return false;
                            }
                        }
                    }
                    else if (IsReRouteEvent(scanDC.LastProcessEventTypeId))
                    {
                        var tnl = repository.Container.TransferNoteLine.FirstOrDefault(x => x.TurnaroundId == scanDC.TurnaroundId);
                        if (tnl?.DispatchTransferNoteEventId != null && tnl.InboundEventId == null)
                        {
                            var facilityRepository = FacilityRepository.New(workUnit);
                            var facility = facilityRepository.Get(_synergyTrakData.FacilityId);
                            _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.FacilityTransferInbound;
                            _isProcessEvent = false;

                            scanDC.TransferNote = TransferNoteHelper.GetTransferNote(new TransferNoteRequestDataContract() { TransferNoteId = tnl.TransferNote.TransferNoteId });
                            scanDC.SupervisorApprovalRequired = false;

                            if (facility.OwnerId != tnl.TransferNote.ToOwnerId && scanDetails.SupervisorAction == SupervisorActions.NoActionTaken)
                            {
                                scanDC.SupervisorApprovalRequired = true;
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private bool IsReRouteEvent(TurnAroundEventTypeIdentifier? eventType)
        {
            return (eventType == TurnAroundEventTypeIdentifier.RerouteToWash || eventType == TurnAroundEventTypeIdentifier.RerouteToInspectionAssemblyPacking || eventType == TurnAroundEventTypeIdentifier.RerouteToQualityAssurance || eventType == TurnAroundEventTypeIdentifier.RerouteToIntoAutoclave || eventType == TurnAroundEventTypeIdentifier.RerouteToDispatch);
        }

        private bool EpocEpodValidation(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if ((_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AvailableForCollection ||
                _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Collected)
                && scanDetails.ParentItemTypeId == (int)ItemTypeIdentifier.Trolley)
            {
                scanDC.ErrorCode = (int)ErrorCodes.ItemAlreadyAssignedToAnotherCarriage;
                return false;
            }

            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Delivered
                && (scanDC.Asset == null || 
                    (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Trolley && scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Endoscopy))
                && scanDC.DeliveryNoteExternalId == null)
            {
                scanDC.ErrorCode = (int)ErrorCodes.InvalidItemType;
                return false;
            }

            var validateMFPTrolleysStationTypes = new int[] { (int)StationTypeIdentifier.Dispatch, (int) StationTypeIdentifier.OOATrolleyDispatch,
                (int)StationTypeIdentifier.TrolleyDispatch, (int)StationTypeIdentifier.AutoclaveDispatch, (int)StationTypeIdentifier.AutoclaveDispatchPassThro,
                (int)StationTypeIdentifier.AutoclaveOrderDispatch, (int)StationTypeIdentifier.EpodEpoc, (int)StationTypeIdentifier.FacilityTransfer, (int)StationTypeIdentifier.Store};

            if (scanDC.Asset != null
                && scanDetails.ParentTurnaroundId != null
                && validateMFPTrolleysStationTypes.Contains(scanDC.StationTypeId)
                && scanDC.Asset.FacilityId != scanDetails.FacilityId
                && scanDC.Asset.FacilityId != null)
            {
                {
                    var turnaroundRepo = TurnaroundRepository.New(workUnit);
                    var trolley = turnaroundRepo.Get((int)(scanDetails.ParentTurnaroundId));
                    var trolleyDBHelper = new TrolleyDatabaseHelper();
                    var mfpTrolleys = trolleyDBHelper.GetTrolleySummary(trolley.Instance.ExternalId, (int)(scanDC.Asset.FacilityId)).Where(x => x.IsOwner || (x.CanProcessForMFPCustomer && x.CanProcessForAnyCustomerFacility));
                    if (!mfpTrolleys.Any() && scanDC.EventTypeId != TurnAroundEventTypeIdentifier.RemovedFromTransferNote)
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.TurnaroundAndTrolleyFacilityMismatch;
                        return false;
                    }
                }
            }

            if (scanDC.Asset != null
                && validateMFPTrolleysStationTypes.Contains(scanDC.StationTypeId)
                && scanDetails.ParentTurnaroundId == null
                && scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley
                && (scanDC.EventTypeId != null && (int)scanDC.EventTypeId == (int)TurnAroundEventTypeIdentifier.Delivered)
                && scanDC.Asset.FacilityId != scanDetails.FacilityId
                && scanDC.Asset.FacilityId != null
                )
            {
                var trolleyDBHelper = new TrolleyDatabaseHelper();
                var mfpTrolleys = trolleyDBHelper.GetTrolleySummary(scanDetails.ExternalId, scanDetails.FacilityId).Where(x => x.IsOwner || (x.CanProcessForMFPCustomer && x.CanProcessForAnyCustomerFacility));
                if (!mfpTrolleys.Any())
                {
                    scanDC.ErrorCode = (int)ErrorCodes.InvalidTurnaround;
                    return false;
                }
            }
            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.LoadTrolleyEPOC)
            {
                if (scanDetails.ParentTurnaroundId.HasValue)
                {
                    if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                    {
                        scanDetails.ParentTurnaroundId = null;
                    }
                    else
                    {
                        {
                            var userDeliveryPointRepository = UserDeliveryPointRepository.New(workUnit);
                            var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                            var containerInstance = containerInstanceRepository.Get(scanDC.Asset.ContainerInstanceId.Value);

                            if (!userDeliveryPointRepository.HasDeliveryPointAccess(scanDC.UserId, containerInstance.DeliveryPointId))
                            {
                                scanDC.ErrorCode = (int)ErrorCodes.NoDeliveryPointAccess;
                                return false;
                            }
                        }
                    }
                }
                else if (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Trolley)
                {
                    scanDC.ErrorCode = (int)ErrorCodes.NotATrolley;
                }

                if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.LoadTrolleyEPOC && scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                {
                    _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.Unknown;
                    scanDetails.Events.Clear();
                    scanDetails.ApplyEvent = false;
                    return false;
                }
            }

            return true;
        }

        private void OOAStockInValidation(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                var deliveryPoint = deliveryPointRepository.Get(scanDC.DeliveryPtId);
                var turnaround = turnaroundRepository.Get((int)scanDetails.TurnaroundId);
                var batch = turnaround.TurnaroundEvent.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventType.ProcessEvent).Batch;

                if (batch != null && batch.BatchStatusId == (int)BatchStatusIdentifier.InProgress && batch.Machine.MachineType.IsSteriliser)
                {
                    scanDC.ErrorCode = (int)ErrorCodes.BatchInProgress;
                }

                if (!deliveryPoint.StockLocation)
                {
                    scanDC.ErrorCode = (int)ErrorCodes.NonStockIntoStock;
                }

                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.OutofAutoclave }, scanDC, scanDetails);
            }
        }

        private void OOATrolleyDispatchAddStockToTrolley(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToTrolley && scanDetails.DeliveryPointId.HasValue)
            {
                if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.IntoStock)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.OutOfStock }, scanDC, scanDetails);
                }
                else if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.IntoAutoclave)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.OutofAutoclave }, scanDC, scanDetails);
                }
            }
        }
        private bool HasAutomaticEventBeenApplied(ScanAssetDataContract scanDc)
        {
            if (scanDc.AutomaticEventApplied || scanDc.ChildItems != null && scanDc.ChildItems.Any(sdcc => sdcc.AutomaticEventApplied))
                return true;

            return false;
        }
    }
}
using SynergyApplicationFrameworkApi.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// BatchTag
    /// </summary>
    public class BatchTag : BasicTurnaroundEvents
    {
        public BatchTag(SynergyTrakData data) : base(data)
        {
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemoveFromBatchTag)]
        /// <summary>
        /// RemoveFrom operation
        /// </summary>
        public void RemoveFrom(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var eventsToApply = new List<ApplyTurnaroundEventDetails>();
                var turnaroundEventRepository = TurnaroundEventRepository.New(workUnit);
                var turnaroundEvents = turnaroundEventRepository.GetAllTurnaroundEventsByTurnaroundId(scanDC.ParentTurnaroundId.Value).ToList();

                if (turnaroundEvents.Count(c => c.EventTypeId == (int)TurnAroundEventTypeIdentifier.AssignedToCarriage) >
                    turnaroundEvents.Count(c => c.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromCarriage))
                {
                    eventsToApply.Add(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemovedFromCarriage, scanDC.IsRemoveFromParent));
                }

                eventsToApply.Add(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemoveFromBatchTag, true));
                if (scanDetails.Events.Count > 1)
                {
                    eventsToApply.Add(ApplyTurnaroundEventDetails.Create((TurnAroundEventTypeIdentifier)scanDetails.Events[1].EventType, true));
                }
                if (scanDC.OverrideTurnaroundEventFacility)
                {
                    var lastEvent = turnaroundEventRepository.Get(scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).First(te => te.IsProcessEvent).TurnaroundEventId);
                    eventsToApply.FirstOrDefault(aed => aed.EventType == TurnAroundEventTypeIdentifier.RemoveFromBatchTag).LocationId = lastEvent.LocationId;
                }

                ApplyEvent(eventsToApply, scanDC, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AssignToBatchTag)]
        /// <summary>
        /// AssignTo operation
        /// </summary>
        public void AssignTo(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            int? newParentTurnaroundId = scanDetails.ParentTurnaroundId;

            if (newParentTurnaroundId.HasValue && scanDC.TurnaroundId.HasValue)
            {
                CheckAutomaticCollection(scanDC, scanDetails);
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AssignToBatchTag, ParentTurnaroundId = newParentTurnaroundId.Value }, scanDC, scanDetails);

                {
                    CreateTurnaroundAssigned(scanDC.TurnaroundId.Value, newParentTurnaroundId.Value);

                    var turnaroundEventRepository = TurnaroundEventRepository.New(workUnit);
                    var turnaroundEvents = turnaroundEventRepository.GetAllTurnaroundEventsByTurnaroundId(newParentTurnaroundId.Value).ToList();

                    if (turnaroundEvents.Count(c => c.EventTypeId == (int)TurnAroundEventTypeIdentifier.AssignedToCarriage) >
                        turnaroundEvents.Count(c => c.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromCarriage))
                    {
                        ApplyEvent(TurnAroundEventTypeIdentifier.AssignedToCarriage, scanDC, scanDetails);
                    }
                }
            }
            else
            {
                scanDC.ErrorCode = (int)ErrorCodes.NoParentTurnaroundId;
            }

            if (PlannedMaintenance.IsScheduled(scanDC))
            {
                scanDC.ErrorCode = (int)ErrorCodes.PlannedMaintenanceBatchTag;
                ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemoveFromBatchTag, true), scanDC, scanDetails);
            }

            if (scanDC.Defects.Count > 0)
            {
                RemoveFrom(scanDC, scanDetails);

                var quarantine = new Quarantine(_data);
                quarantine.PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ServiceReportRaised);
            }
        }

        /// <summary>
        /// FailValidation operation
        /// </summary>
        public bool FailValidation(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if ((_data.EventTypeId == TurnAroundEventTypeIdentifier.FailedWash ||
                     _data.EventTypeId == TurnAroundEventTypeIdentifier.FailedWashReleaseRequired) && !scanDetails.ApplyToBatch && scanDC.HasChildren && !scanDetails.IsKeepFailedBatchTogether.HasValue)
            {
                scanDC.RequiresKeepBatchTogetherConfirmation = true;
                return false;
            }

            return !scanDC.ErrorCode.HasValue;
        }

        /// <summary>
        /// ValidateAssignToBatchTag operation
        /// </summary>
        public bool ValidateAssignToBatchTag(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                var eventTypeRepository = EventTypeRepository.New(workUnit);

                ItemTypeIdentifier itemType = (ItemTypeIdentifier)scanDC.Asset.ItemTypeId;

                if ((itemType == ItemTypeIdentifier.BatchTag) || (itemType == ItemTypeIdentifier.ChildBatchTag) || (itemType == ItemTypeIdentifier.BatchTagOriginal))
                {
                    scanDC.ErrorCode = (int)ErrorCodes.NoBatchTagsOnABatchTag;
                }
                else if (_data.EventTypeId == TurnAroundEventTypeIdentifier.AssignToBatchTag)
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
                    ValidateAssignToBatchTagForProcessing(scanDC, scanDetails, scanDC.DeliveryPtId, workUnit);
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

        /// <summary>
        /// ValidateAssignToBatchTagForProcessing operation
        /// </summary>
        public static void ValidateAssignToBatchTagForProcessing(ScanAssetDataContract scanDC, ScanDetails scanDetails, int selectedDeliveryPointId, IUnitOfWork workUnit)
        {
            var turnaroundRepository = TurnaroundRepository.New(workUnit);
            var deliveryPointRepository = DeliveryPointRepository.New(workUnit);

            var batchTagTurnaround = scanDetails.ParentTurnaroundId == null
                ? null
                : turnaroundRepository.Get(scanDetails.ParentTurnaroundId.Value);
            if (batchTagTurnaround == null)
            {
                scanDC.ErrorCode = (int)ErrorCodes.BatchTagHasEnded;
                return;
            }

            if (!scanDC.ErrorCode.HasValue)
            {
                ValidateItemTypeMatch(scanDC, batchTagTurnaround);
            }

            if (!scanDC.ErrorCode.HasValue)
            {
                ValidateWashCycleMachineTypesMatch(scanDC, batchTagTurnaround);
            }

            if (!scanDC.ErrorCode.HasValue)
            {
                ValidateSterilityMatch(scanDC, batchTagTurnaround);
            }

            if (!scanDC.ErrorCode.HasValue)
            {
                var deliveryPoint = deliveryPointRepository.Get(selectedDeliveryPointId);
                scanDC.ErrorCode = (int?)ValidateParentAndChildDeliveryPoints(batchTagTurnaround, deliveryPoint, scanDetails.FacilityId);
            }
        }

        private static void ValidateItemTypeMatch(ScanAssetDataContract scanDC, Turnaround batchTagTurnaround)
        {
            var firstItem = batchTagTurnaround.ChildTurnaround.FirstOrDefault();

            if (firstItem == null)
            {
                return;
            }

            if (firstItem.ContainerMaster.ItemType.ParentItemTypeId == scanDC.Asset.BaseItemTypeId)
            {
                return;
            }

            var trayCompatibleTypes = new[] { (int)ItemTypeIdentifier.Tray, (int)ItemTypeIdentifier.LoanTray };
            if (trayCompatibleTypes.Contains(firstItem.ContainerMaster.ItemType.ParentItemTypeId.GetValueOrDefault()) && trayCompatibleTypes.Contains(scanDC.Asset.BaseItemTypeId))
            {
                return;
            }

            scanDC.ErrorCode = (int)ErrorCodes.ItemTypesMustMatchOnABatchTag;
            scanDC.Message = firstItem.ContainerMaster.ItemType?.ParentItemType.Text;
        }
        private static void ValidateWashCycleMachineTypesMatch(ScanAssetDataContract scanDC, Turnaround batchTagTurnaround)
        {
            if (batchTagTurnaround.ContainerMaster.MachineType.MachineTypeId != scanDC.Asset.MachineTypeId)
            {
                scanDC.ErrorCode = (int)ErrorCodes.MachineTypeMismatch;
                scanDC.Message = batchTagTurnaround.ContainerMaster.MachineType.Text;
            }
        }

        private static void ValidateSterilityMatch(ScanAssetDataContract scanDC, Turnaround batchTagTurnaround)
        {
            if (batchTagTurnaround.ContainerMaster.ItemType.IsNonSterileProduct != scanDC.Asset.IsNonSterile)
            {
                scanDC.ErrorCode = batchTagTurnaround.ContainerMaster.ItemType.IsNonSterileProduct
                    ? (int)ErrorCodes.CannotAddSterileToBatchTagWithNonSterileItems
                    : (int)ErrorCodes.CannotAddNonSterileToBatchTagWithSterileItems;
            }
        }

        private static ErrorCodes? ValidateParentAndChildDeliveryPoints(Turnaround batchTagTurnaround, DeliveryPoint newChildDeliveryPoint, short facilityId)
        {
            if (!batchTagTurnaround.ChildTurnaround.Any())
            {
                return null;
            }

            if (batchTagTurnaround.ChildTurnaround.Any(ct => ct.DeliveryPointId == newChildDeliveryPoint.DeliveryPointId))
            {
                return null;
            }

            var setting = FacilityHelper.IsOperativeDifferentDeliveryPointBatchTagWarning(facilityId);

            if (setting == DeliveryPointBatchTagSetting.Off)
            {
                return null; //Setting off so we don't care
            }

            if (setting == DeliveryPointBatchTagSetting.On)
            {
                return ErrorCodes.BatchTagDeliveryPointsDontMatch;
            }

            if (setting == DeliveryPointBatchTagSetting.RestrictedByDeliveryPoint)
            {
                if (batchTagTurnaround.DeliveryPoint.RestrictedForBatchTag)
                {
                    return ErrorCodes.BatchTagDeliveryPointsRestrictedAndDontMatch;
                }

                if (newChildDeliveryPoint.RestrictedForBatchTag)
                {
                    return ErrorCodes.ItemDeliveryPointsRestrictedAndDontMatch;
                }

                if (batchTagTurnaround.ChildTurnaround.Any(ct => ct.DeliveryPoint.RestrictedForBatchTag))
                {
                    return ErrorCodes.ItemDeliveryPointsRestrictedAndDontMatch;
                }
            }

            return null;
        }

        /// <summary>
        /// ValidateForBatchTagCreated operation
        /// </summary>
        public static void ValidateForBatchTagCreated(ScanAssetDataContract scannedAssetData)
        {
            if (scannedAssetData.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BatchTag)
            {
                scannedAssetData.ErrorCode = (int)ErrorCodes.ScannedWrongItemType;
            }
        }
    }
}
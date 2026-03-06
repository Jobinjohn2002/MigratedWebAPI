using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// DispatchEvents
    /// </summary>
    public class DispatchEvents : BasicTurnaroundEvents
    {
        public DispatchEvents(SynergyTrakData data) : base(data)
        {

        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.Dispatch)]
        /// <summary>
        /// Dispatch operation
        /// </summary>
        public void Dispatch(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            Dispatch(scanDC, scanDetails, false, false);
        }

        /// <summary>
        /// Dispatch operation
        /// </summary>
        public void Dispatch(ScanAssetDataContract scanDC, ScanDetails scanDetails, bool isEndTurnaround, bool isAutomaticEvent)
        {
            var deliveryNoteId = GetOrCreateDeliveryNoteId(scanDC, isEndTurnaround);
            scanDC.DeliveryNoteId = deliveryNoteId;
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.Dispatch, DeliveryNoteId = deliveryNoteId, IsEndTurnaround = isEndTurnaround, IsAutomaticEvent = isAutomaticEvent }, scanDC, scanDetails);
        }

        /// <summary>
        /// AutomaticDispatch operation
        /// </summary>
        public void AutomaticDispatch(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (AutomaticCompleteTurnaroundForStockOrderingEnabled(scanDetails.FacilityId))
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var workflowRepository = WorkflowRepository.New(workUnit);
                    var validDispatchWorkflow = workflowRepository.ReadWorkflow((int?)scanDC.LastProcessEventTypeId, (int)TurnAroundEventTypeIdentifier.Dispatch, scanDC.Asset.ItemTypeId, scanDC.FacilityId, scanDC.Asset.ContainerMasterId, scanDC.DeliveryPtId);
                    var currentlyAtDispatch = scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.Dispatch || scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AutomaticDispatch;
                    var validDeliveryNotePrintWorkflow = workflowRepository.ReadWorkflow((int?)TurnAroundEventTypeIdentifier.DeliveryNotePrint, (int)_data.EventTypeId, scanDC.Asset.ItemTypeId, scanDC.FacilityId, scanDC.Asset.ContainerMasterId, scanDC.DeliveryPtId);

                    if ((validDispatchWorkflow != null || currentlyAtDispatch) && validDeliveryNotePrintWorkflow != null)
                    {
                        var originalLocationId = scanDC.LocationId;
                        var stationRepository = StationRepository.New(workUnit);
                        var station = stationRepository.Get(scanDC.StationId);
                        scanDC.LocationId = station.LocationId;

                        if (currentlyAtDispatch)
                        {
                            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemovedFromDeliveryNote, IsAutomaticEvent = true }, scanDC, scanDetails);
                        }
                        Dispatch(scanDC, scanDetails, true, true);
                        ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.DeliveryNotePrint, IsAutomaticEvent = true }, _data.ScanDcList, scanDetails);
                        scanDC.LocationId = originalLocationId;
                    }
                }

            }
        }

        /// <summary>
        /// Validation operation
        /// </summary>
        public static bool Validation(Turnaround turnaround, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var isValid = true;

            if (scanDetails.IsWarnForDifferentDeliveryPoints &&
                scanDetails.DeliveryPointId.HasValue &&
                turnaround.DeliveryPointId != scanDetails.DeliveryPointId)
            {
                scanDC.ErrorCode = (int)ErrorCodes.DifferentDeliveryPoints;
                return false;
            }

            if (scanDC.Asset.IsLoanSetExpired && (scanDC.EventTypeId == TurnAroundEventTypeIdentifier.Dispatch ||
                (scanDC.EventTypeId == TurnAroundEventTypeIdentifier.OutofAutoclave && scanDetails.StationTypeId == (int)StationTypeIdentifier.OutofAutoclaveDispatch) ||
                (scanDC.EventTypeId == TurnAroundEventTypeIdentifier.OutofAutoclave && scanDetails.StationTypeId == (int)StationTypeIdentifier.OOATrolleyDispatch) ||
                (scanDC.EventTypeId == TurnAroundEventTypeIdentifier.AddedToTrolley)
                ))
            {
                scanDC.ErrorCode = (int)ErrorCodes.LoanSetExpired;
                isValid = false;
            }

            return isValid;
        }

        private bool AutomaticCompleteTurnaroundForStockOrderingEnabled(short facilityId)
        {
            {
                var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
                return facilitySettingRepository.ReadFacilitySetting<bool>(facilityId, KnownFacilitySetting.AutomaticCompleteTurnaroundForStockOrderingEnabled);
            }
        }
    }
}
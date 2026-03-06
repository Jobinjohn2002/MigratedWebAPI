using System;
using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.Services;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Orders
    /// </summary>
    public class Orders : BasicTurnaroundEvents
    {
        public Orders(SynergyTrakData data) : base(data)
        {
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AddedToOrder)]
        /// <summary>
        /// AddedToOrder operation
        /// </summary>
        public void AddedToOrder(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, ParentTurnaroundId = scanDetails.ParentTurnaroundId, UseDeliveryNoteIdFromScanDc = true }, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemovedFromOrder)]
        /// <summary>
        /// RemovedFromOrder operation
        /// </summary>
        public void RemovedFromOrder(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, ParentTurnaroundId = scanDetails.ParentTurnaroundId, UseDeliveryNoteIdFromScanDc = true }, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.OrderShipped)]
        /// <summary>
        /// OrderShipped operation
        /// </summary>
        public void OrderShipped(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            List<ApplyTurnaroundEventDetails> eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = TurnAroundEventTypeIdentifier.OrderShipped,
                    ParentTurnaroundId = scanDetails.ParentTurnaroundId,
                    LocationId = scanDC.LocationId,
                    UseDeliveryNoteIdFromScanDc = true,
                }
            };

            ApplyEvent(eventsToApply, _data.ScanDcList, scanDetails);
        }

    }
}
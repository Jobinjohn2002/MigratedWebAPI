using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// LoadTrolley
    /// </summary>
    public class LoadTrolley : BasicTurnaroundEvents
    {
        public LoadTrolley(SynergyTrakData data) : base(data)
        {
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.LoadTrolleyEPOC)]
        /// <summary>
        /// EPOC operation
        /// </summary>
        public void EPOC(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.LoadTrolleyEPOC, ParentTurnaroundId = scanDetails.ParentTurnaroundId }, scanDetails);

            if ((scanDC != null) && (scanDC.TurnaroundId > 0) && (scanDetails.ParentTurnaroundId.HasValue) && (scanDC.TurnaroundId.HasValue))
            {
                CreateTurnaroundAssigned(scanDC.TurnaroundId.Value, scanDetails.ParentTurnaroundId.Value);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.LoadTrolleyEPOD)]
        /// <summary>
        /// EPOD operation
        /// </summary>
        public void EPOD(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { LocationId = scanDetails.StationLocationId, EventType = TurnAroundEventTypeIdentifier.LoadTrolleyEPOD, ParentTurnaroundId = scanDetails.ParentTurnaroundId }, scanDC, scanDetails);

            if ((scanDC != null) && (scanDC.TurnaroundId > 0) && (scanDetails.ParentTurnaroundId.HasValue) && (scanDC.TurnaroundId.HasValue))
            {
                CreateTurnaroundAssigned(scanDC.TurnaroundId.Value, scanDetails.ParentTurnaroundId.Value);
            }
        }
    }
}
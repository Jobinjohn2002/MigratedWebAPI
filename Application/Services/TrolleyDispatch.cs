using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// TrolleyDispatch
    /// </summary>
    public class TrolleyDispatch : BasicTurnaroundEvents
    {
        public TrolleyDispatch(SynergyTrakData data) : base(data) { }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AddedToTrolley)]
        /// <summary>
        /// AddedToTrolley operation
        /// </summary>
        public void AddedToTrolley(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {

            var eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = TurnAroundEventTypeIdentifier.AddedToTrolley,
                    ParentTurnaroundId = scanDetails.ParentTurnaroundId
                }
            };
                                               
            CreateTurnaroundAssigned(scanDC.TurnaroundId.Value, scanDetails.ParentTurnaroundId.Value, forceCreateNew: true);

            ApplyEvent(eventsToApply, scanDC, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemovedFromTrolley)]
        /// <summary>
        /// RemovedFromTrolley operation
        /// </summary>
        public void RemovedFromTrolley(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = TurnAroundEventTypeIdentifier.RemovedFromTrolley,
                    RemoveFromParent = true
                }
            };

            ApplyEvent(eventsToApply, scanDC, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.TrolleyStarted)]
        /// <summary>
        /// TrolleyStarted operation
        /// </summary>
        public void TrolleyStarted(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = TurnAroundEventTypeIdentifier.TrolleyStarted
                }
            };

            ApplyEvent(eventsToApply, scanDC, scanDetails);
        }
    }
}
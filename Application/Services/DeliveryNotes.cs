using System;
using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.Services;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// DeliveryNotes
    /// </summary>
    public class DeliveryNotes : BasicTurnaroundEvents
    {
        public DeliveryNotes(SynergyTrakData data) : base(data)
        {
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.DeliveryNotePrint)]
        /// <summary>
        /// Print operation
        /// </summary>
        public void Print(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            DeliveryNotePrint(scanDC, scanDetails, _data.RequiresProof);

            if (scanDC.TurnaroundId.HasValue && scanDC.ParentTurnaroundId.HasValue)
            {
                CreateTurnaroundAssigned(scanDC.TurnaroundId.Value, scanDC.ParentTurnaroundId.Value);
            }
        }

        private void DeliveryNotePrint(ScanAssetDataContract scanDC, ScanDetails scanDetails, bool requiresProof, bool isEndTurnaround = false, bool isAutomaticEvent = false)
        {
            DeliveryNoteScanDetails dnScanDetails = scanDetails as DeliveryNoteScanDetails;

            List<ApplyTurnaroundEventDetails> eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = TurnAroundEventTypeIdentifier.DeliveryNotePrint,
                    DeliveryNoteId = dnScanDetails?.DeliveryNoteId,
                    RemoveFromParent = false,
                    ParentTurnaroundId = scanDetails.ParentTurnaroundId,
                    LocationId = null,
                    BatchId = null,
                    IsEndTurnaround = isEndTurnaround,
                    IsAutomaticEvent = isAutomaticEvent
                }
            };
            if (requiresProof)
            {
                eventsToApply.Add(new ApplyTurnaroundEventDetails()
                {
                    EventType = TurnAroundEventTypeIdentifier.LoadTrolleyEPOD,
                    DeliveryNoteId = dnScanDetails?.DeliveryNoteId,
                    RemoveFromParent = false,
                    ParentTurnaroundId = scanDetails.ParentTurnaroundId,
                    LocationId = null,
                    BatchId = null,
                    IsAutomaticEvent = isAutomaticEvent
                });
            }

            ApplyEvent(eventsToApply, _data.ScanDcList, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemovedFromDeliveryNote)]
        /// <summary>
        /// RemoveTurnaroundFromDeliveryNote operation
        /// </summary>
        public void RemoveTurnaroundFromDeliveryNote(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(TurnAroundEventTypeIdentifier.RemovedFromDeliveryNote, scanDC, scanDetails);

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.Get(scanDC.TurnaroundId.Value);

                if (turnaround != null)
                {
                    turnaround.DeliveryNoteId = null;
                    turnaround.ParentTurnaroundId = null;

                    var wh = turnaround.TurnaroundWH.FirstOrDefault();

                    if (wh != null)
                    {
                        wh.DeliveryNoteExternalId = null;
                        wh.DeliveryNoteId = null;
                    }
                    turnaroundRepository.Save();
                }
                else
                {
                    scanDC.ErrorCode = (int)ErrorCodes.InvalidTurnaround;
                }
            }
        }

    }
}
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Autoclave
    /// </summary>
    public class Autoclave : DeliveryNotes
    {
        public Autoclave(SynergyTrakData data) : base(data)
        {
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.IntoAutoclave)]
        /// <summary>
        /// IntoAutoclave operation
        /// </summary>
        public void IntoAutoclave(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var isBatchFailed = false;
            var isBatchBiFailed = false;
            var failEventApplied = 0;

            Batch batch = null;

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var containerMasterRepository = ContainerMasterRepository.New(workUnit);
                var containerMaster = containerMasterRepository.Get(scanDC.Asset.ContainerMasterId);

                if ((containerMaster != null) && (scanDetails.BatchId.HasValue))
                {
                    var batchRepository = BatchRepository.New(workUnit);
                    batch = batchRepository.Get(scanDetails.BatchId.Value);

                    #region Check Batch Status
                    if (batch != null)
                    {
                        var biTest = batch.BiologicalIndicatorTest.FirstOrDefault();

                        if (biTest?.TestResult != null)
                        {
                            isBatchBiFailed = !biTest.TestResult.Value;
                        }

                        if (batch.BatchCycleId.HasValue)
                        {
                            if (batch.BatchStatusId == (int)BatchStatusIdentifier.Failed)
                            {
                                isBatchFailed = true;
                                var failEvents = new List<short>
                                {
                                    (short) TurnAroundEventTypeIdentifier.WetPack,
                                    (short) TurnAroundEventTypeIdentifier.BrokenPack,
                                    (short) TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithoutReassign,
                                    (short) TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithReassign,
                                    (short) TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithoutReassign,
                                     (short) TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithReassign,
                                      (short) TurnAroundEventTypeIdentifier.FailBatchPostSteamInjection,
                                      (short) TurnAroundEventTypeIdentifier.FailBatchPostNonSteamInjection,

                                };
                                failEventApplied = batch.TurnaroundEvent.FirstOrDefault(x => failEvents.Contains(x.EventTypeId)).EventTypeId;
                            }
                        }
                    }
                    #endregion
                }
            }

            if (scanDC.ErrorCode != null)
            {
                return;
            }

            if (_data.IsRemoveFromParent)     // If a container is scanned individually, and it is part of a batchtag.
            {
                var removeFromBatchEvent = new ApplyTurnaroundEventDetails
                {
                    EventType = TurnAroundEventTypeIdentifier.RemoveFromBatchTag,
                };
                if (scanDetails.IsRetrospectiveAddToAutoclaveBatch == true)
                {
                    removeFromBatchEvent.RetrospectiveCreatedDate = batch.Started.Value;
                }

                ApplyEvent(removeFromBatchEvent, scanDetails);
            }

            var intoAcEvent = new ApplyTurnaroundEventDetails()
            {
                EventType = TurnAroundEventTypeIdentifier.IntoAutoclave,
                RemoveFromParent = true,
                BatchId = scanDC.BatchId
            };

            if (scanDetails.IsRetrospectiveAddToAutoclaveBatch == true)
            {
                if (batch?.Started != null)
                {
                    intoAcEvent.RetrospectiveCreatedDate = batch.Started.Value;
                }
            }
            ApplyEvent(intoAcEvent, scanDetails);

            if (scanDetails.IsRetrospectiveAddToAutoclaveBatch == true)
            {
                ApplyEvent(new ApplyTurnaroundEventDetails
                {
                    EventType = TurnAroundEventTypeIdentifier.RetrospectiveOutOfAutoclaveApproval,
                    IsProcessEvent = false
                }, scanDetails);

                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra && failEventApplied != 0)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = (TurnAroundEventTypeIdentifier)failEventApplied, RemoveFromParent = true }, scanDetails);
                }

            }
            if (isBatchBiFailed)
            {
                if (scanDC.TurnaroundId.HasValue && scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.Archived, RemoveFromParent = true }, scanDetails);
                }
                else
                {
                    var quar = new Quarantine(_data);
                    quar.PutIntoQuarantine(scanDC, scanDetails, (int)QuarantineReasonIdentifier.BIFailed);
                }
            }
            else if (isBatchFailed)
            {
                if (scanDC.TurnaroundId.HasValue && scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.Archived, RemoveFromParent = true }, scanDetails);
                }
                else
                {
                    var quar = new Quarantine(_data);
                    quar.PutIntoQuarantine(scanDC, scanDetails, (int)QuarantineReasonIdentifier.BatchFailed);
                }
            }
        }

        /// <summary>
        /// Process scanning at Out of Autoclave and Out of Autoclave/Dispatch
        /// </summary>
        /// <param name="scanDC"></param>
        /// <param name="scanDetails"></param>
        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.OutofAutoclave)]
        /// <summary>
        /// OutofAutoclave operation
        /// </summary>
        public void OutofAutoclave(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                var eventsToApply = new List<ApplyTurnaroundEventDetails>
                {
                    new ApplyTurnaroundEventDetails
                    {
                        EventType = TurnAroundEventTypeIdentifier.OutofAutoclave,
                        BatchId = scanDC.BatchId
                    }
                };

                var containerMasterDefinitionRepository = ContainerMasterDefinitionRepository.New(workUnit);
                var cmd = containerMasterDefinitionRepository.Get(scanDC.Asset.ContainerMasterDefinitionId);

                var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                var deliveryPoint = deliveryPointRepository.Get(scanDC.DeliveryPtId);

                if (deliveryPoint.StockLocation && cmd != null && cmd.CustomerDefinition.CurrentCustomer.FacilityId == _data.FacilityId)
                {
                    eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.IntoStock, LocationId = deliveryPoint.LocationId });
                    UpdateContainerInstanceLocation(scanDetails.TurnaroundExternalId, deliveryPoint.LocationId);
                }
                else if ((scanDC.StationTypeId == (int)StationTypeIdentifier.OutofAutoclaveDispatch  || (scanDC.StationTypeId == (int)StationTypeIdentifier.OOATrolleyDispatch && scanDetails.IsTrolleylessDispatch)) && scanDetails.IgnoreDispatch == false)
                {
                    var deliveryNoteId = GetOrCreateDeliveryNoteId(scanDC);

                    eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.Dispatch, DeliveryNoteId = deliveryNoteId });
                }

                ApplyEvent(eventsToApply, _data.ScanDcList, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.WetPack)]
        /// <summary>
        /// WetPack operation
        /// </summary>
        public void WetPack(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.Dispatch)
            {
                RemoveTurnaroundFromDeliveryNote(scanDC, scanDetails);
            }

            var eventsToApply = new List<ApplyTurnaroundEventDetails>();

            if(scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AddedToTrolley)
            {
                eventsToApply.Add(new ApplyTurnaroundEventDetails(TurnAroundEventTypeIdentifier.RemovedFromTrolley) { RemoveFromParent = true });
            }

            eventsToApply.Add(new ApplyTurnaroundEventDetails(TurnAroundEventTypeIdentifier.WetPack) { BatchId = scanDC.BatchId, RemoveFromParent = true });
            ApplyEvent(eventsToApply, scanDC, scanDetails);

            if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra)
            {
                Archive(scanDC, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.BrokenPack)]
        /// <summary>
        /// BrokenPack operation
        /// </summary>
        public void BrokenPack(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.Dispatch)
            {
                RemoveTurnaroundFromDeliveryNote(scanDC, scanDetails);
            }
            var eventsToApply = new List<ApplyTurnaroundEventDetails>();

            if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AddedToTrolley)
            {
                eventsToApply.Add(new ApplyTurnaroundEventDetails(TurnAroundEventTypeIdentifier.RemovedFromTrolley) { RemoveFromParent = true });
            }

            eventsToApply.Add(new ApplyTurnaroundEventDetails(TurnAroundEventTypeIdentifier.BrokenPack) { BatchId = scanDC.BatchId, RemoveFromParent = true });
            ApplyEvent(eventsToApply, scanDC, scanDetails);

            if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra)
            {
                Archive(scanDC, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.BiologicalIndicatorFailed)]
        /// <summary>
        /// FailBiologicalIndicator operation
        /// </summary>
        public void FailBiologicalIndicator(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(TurnAroundEventTypeIdentifier.BiologicalIndicatorFailed, scanDC, scanDetails);

            if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra)
            {
                ApplyEvent(TurnAroundEventTypeIdentifier.Archived, scanDC, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithReassign)]
        /// <summary>
        /// FailBatchPreSteamInjectionWithReassign operation
        /// </summary>
        public void FailBatchPreSteamInjectionWithReassign(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, ParentTurnaroundId = scanDetails.ParentTurnaroundId, BatchId = scanDetails.BatchId.Value }, scanDC, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithoutReassign)]
        /// <summary>
        /// FailBatchPreSteamInjectionWithoutReassign operation
        /// </summary>
        public void FailBatchPreSteamInjectionWithoutReassign(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, ParentTurnaroundId = scanDetails.ParentTurnaroundId, BatchId = scanDetails.BatchId.Value }, scanDC, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithoutReassign)]
        /// <summary>
        /// FailBatchPreNonSteamInjectionWithoutReassign operation
        /// </summary>
        public void FailBatchPreNonSteamInjectionWithoutReassign(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, ParentTurnaroundId = scanDetails.ParentTurnaroundId, BatchId = scanDetails.BatchId.Value }, scanDC, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithReassign)]
        /// <summary>
        /// FailBatchPreNonSteamInjectionWithReassign operation
        /// </summary>
        public void FailBatchPreNonSteamInjectionWithReassign(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, ParentTurnaroundId = scanDetails.ParentTurnaroundId, BatchId = scanDetails.BatchId.Value }, scanDC, scanDetails);
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FailBatchPostSteamInjection)]
        /// <summary>
        /// FailBatchPostSteamInjection operation
        /// </summary>
        public void FailBatchPostSteamInjection(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.FailBatchPostSteamInjection, BatchId = scanDC.BatchId }, scanDC, scanDetails);

            if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra)
            {
                Archive(scanDC, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FailBatchPostNonSteamInjection)]
        /// <summary>
        /// FailBatchPostNonSteamInjection operation
        /// </summary>
        public void FailBatchPostNonSteamInjection(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.FailBatchPostNonSteamInjection, BatchId = scanDC.BatchId }, scanDC, scanDetails);

            if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra)
            {
                Archive(scanDC, scanDetails);
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {
        /// <summary>
        /// ReassignBatch operation
        /// </summary>
        public BatchCreatedDataContract ReassignBatch(ReassignBatchRequestDataContract reassignDc, BatchCreatedDataContract newBatch)
        {
            BatchHelper batchHelper = new BatchHelper();
            _synergyTrakData.StationTypeId = reassignDc.StationTypeId;
            _synergyTrakData.StationId = reassignDc.StationId;
            _synergyTrakData.FacilityId = reassignDc.FacilityId;
            _synergyTrakData.UserId = reassignDc.UserId;
            _ignoreNotesWarningsAndDecon = reassignDc.IsApplyingEvent;
            _isProcessEvent = true;
            var scanDetails = new ScanDetails
            {
                BatchId = reassignDc.BatchId,
                FacilityId = reassignDc.FacilityId,
                StationId = reassignDc.StationId,
                StationTypeId = reassignDc.StationTypeId,
                PinReason = reassignDc.PinReason,
                IgnoreNotesWarningsAndDecon = true,
                NTLogon = reassignDc.NTLogon,
                Events = new List<ScanEventDataContract>()
            };

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var cteRepository = CurrentTurnaroundEventRepository.New(workUnit);
                var teRepository = TurnaroundEventRepository.New(workUnit);
                var batchRepository = BatchRepository.New(workUnit);

                if (scanDetails.BatchId.HasValue && newBatch != null)
                {
                    bool canReassign = true;
                    var batch = batchRepository.Get(scanDetails.BatchId.Value);
                    var turnaroundIds = batch.TurnaroundEvent.Select(te => te.TurnaroundId).Distinct().ToList();

                    _synergyTrakData.ScanDcList = GetAssetsFromTurnaroundIds(scanDetails, turnaroundIds);

                    var processEventsToIgnore = new List<short>
                        {
                            (short) TurnAroundEventTypeIdentifier.Archived,
                            (short) TurnAroundEventTypeIdentifier.IntoQuarantine
                        };

                    foreach (var tId in turnaroundIds)
                    {
                        var v = cteRepository.GetLastProcessEventByTurnaroundId(tId);
                        var allEvents = teRepository.GetAllTurnaroundEventsByTurnaroundId(tId);
                        bool turnaroundEndedEarly = allEvents.Any(ev => ev.EventTypeId == (int)TurnAroundEventTypeIdentifier.TurnaroundEndedEarly);

                        if (processEventsToIgnore.Contains(v.EventTypeId) || turnaroundEndedEarly)
                        {
                            _synergyTrakData.ScanDcList.RemoveAll(dc => dc.TurnaroundId.GetValueOrDefault() == tId);
                        }
                        else if (v.EventTypeId != (int)TurnAroundEventTypeIdentifier.IntoAutoclave)
                        {
                            canReassign = false;
                            newBatch.ErrorCode = (int)ErrorCodes.BatchTurnaroundEventsInconsistent;
                            break;
                        }
                    }

                    if (canReassign)
                    {
                        var nonBTs = _synergyTrakData.ScanDcList.Where(s => s.Asset != null && s.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BatchTag).ToList();
                        var eventsToApply = new List<ApplyTurnaroundEventDetails>();

                        if (reassignDc.IsFailBatch)
                        {
                            bool isSteam = batch.Machine?.IsSteam ?? true;
                            batchHelper.Fail(scanDetails.BatchId.Value, isSteam ? FailureTypeIdentifier.PresteamFailure : FailureTypeIdentifier.PreNonSteamFailure, _synergyTrakData.UserId);
                            eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = isSteam ? TurnAroundEventTypeIdentifier.FailBatchPreSteamInjectionWithReassign : TurnAroundEventTypeIdentifier.FailBatchPreNonSteamInjectionWithReassign, BatchId = reassignDc.BatchId });
                        }
                        else
                        {
                            batchHelper.Archive(reassignDc.BatchId, reassignDc.UserId);
                            eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemovedFromBatch, BatchId = reassignDc.BatchId });

                            if (newBatch.BatchId == reassignDc.BatchId)
                            {
                                newBatch = batchHelper.Create(reassignDc);
                            }
                        }

                        var batchExternalId = batchHelper.GetExternalId(newBatch.BatchId);

                        eventsToApply.Add(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.IntoAutoclave, BatchId = newBatch.BatchId, BatchExternalId = batchExternalId });

                        ApplyEvent(eventsToApply, nonBTs, scanDetails);
                        if (batch.BiologicalIndicatorTest.Any())
                        {
                            var biologicalIndicatorTestRepository = BiologicalIndicatorTestRepository.New(workUnit);

                            foreach (var biologicalIndicatorTest in batch.BiologicalIndicatorTest.ToList())
                            {
                                var biTest = biologicalIndicatorTestRepository.Get(biologicalIndicatorTest.BiologicalIndicatorTestId);
                                biTest.BatchId = newBatch.BatchId;
                            }

                            biologicalIndicatorTestRepository.Save();
                        }

                        GetReportsAndNotification(nonBTs, newBatch);
                    }
                }
            }

            return newBatch;
        }
        /// <summary>
        /// RetrospectiveAddToWashBatch operation
        /// </summary>
        public ScanAssetDataContract RetrospectiveAddToWashBatch(AddToWashBatchDataContract addToWashBatchDC)
        {
            SynergyTrakService synergyTrakService = new SynergyTrakService();
            return synergyTrakService.RetrospectiveAddToWashBatch(addToWashBatchDC);
        }
    }
}
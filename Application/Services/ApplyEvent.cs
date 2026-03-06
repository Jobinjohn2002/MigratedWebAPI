using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Transactions;
using SynergyApplicationFrameworkApi.Application.Services;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public sealed class ApplyEvent
    {

        #region Fields

        private Dictionary<TurnAroundEventTypeIdentifier, TurnaroundEventType> _isProcessEventDictionary;
        private readonly WorkFlowCache _workFlowCache = new WorkFlowCache();
        private readonly FacilityCache _facilityCache = new FacilityCache();

        private ProcessNotificationsDlgt _processNotificationsDlgt;
        private bool _keepBatchTagTogetherRequested;
        private short? _quarantineReasonId;
        private int _stationTypeId;
        private short _facilityId;
        private int? _stationId;
        private int _userId;
        private byte? _failureTypeId;

        #endregion

        #region Constructor

        public ApplyEvent()
        {

        }

        /// <summary>
        /// Setup operation
        /// </summary>
        public void Setup(ProcessNotificationsDlgt processNotificationsDlgt, int userId, short facilityId, int stationTypeId, int? stationId = null,
                          short? quarantineReasonId = null, bool keepBatchTagTogetherRequested = false, byte? failureTypeId = null)
        {
            _processNotificationsDlgt = processNotificationsDlgt;
            _quarantineReasonId = quarantineReasonId;
            _stationTypeId = stationTypeId;
            _facilityId = facilityId;
            _stationId = stationId;
            _userId = userId;
            _keepBatchTagTogetherRequested = keepBatchTagTogetherRequested;
            _failureTypeId = failureTypeId;
        }

        /// <summary>
        /// Setup operation
        /// </summary>
        public void Setup(SynergyTrakData data)
        {
            _processNotificationsDlgt = data.ProcessNotificationsDlgt ?? new NotificationEngineHelper().ProcessNotifications;
            _quarantineReasonId = data.QuarantineReasonId;
            _stationTypeId = data.StationTypeId;
            _facilityId = data.FacilityId;
            _stationId = data.StationId;
            _userId = data.UserId;
            _keepBatchTagTogetherRequested = data.KeepBatchTagTogetherRequested;
            _failureTypeId = data.FailureTypeId;
        }

        #endregion

        private Dictionary<TurnAroundEventTypeIdentifier, TurnaroundEventType> ReadProcessEvents(IEnumerable<TurnaroundEventDetail> eventsToApply)
        {
            var isProcessEventDictionary = new Dictionary<TurnAroundEventTypeIdentifier, TurnaroundEventType>();

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var eventTypeRepository = EventTypeRepository.New(workUnit);

                foreach (var eventDetail in eventsToApply)
                {
                    var eventTypeRow = eventTypeRepository.Get((int)eventDetail.ApplyEvent.EventType);

                    if (!isProcessEventDictionary.ContainsKey(eventDetail.ApplyEvent.EventType))
                    {
                        isProcessEventDictionary.Add(eventDetail.ApplyEvent.EventType, new TurnaroundEventType { Type = eventDetail.ApplyEvent.EventType, IsProcessEvent = eventTypeRow.ProcessEvent, Text = eventTypeRow.Text });
                    }

                    eventDetail.ApplyEvent.IsProcessEvent = isProcessEventDictionary[eventDetail.ApplyEvent.EventType].IsProcessEvent;
                }
                if (eventsToApply.FirstOrDefault(e => e.ApplyEvent.EventType == TurnAroundEventTypeIdentifier.ChangedFacility) == null)
                {
                    var eventTypeRow = eventTypeRepository.Get((int)TurnAroundEventTypeIdentifier.ChangedFacility);

                    isProcessEventDictionary.Add(TurnAroundEventTypeIdentifier.ChangedFacility, new TurnaroundEventType { Type = TurnAroundEventTypeIdentifier.ChangedFacility, IsProcessEvent = eventTypeRow.ProcessEvent, Text = eventTypeRow.Text });
                }
            }

            return isProcessEventDictionary;
        }

        /// <summary>
        /// Map each datacontract with the event to be applied, and the corresponding workflowid.
        /// </summary>
        /// <param name="eventsToApply"></param>
        /// <param name="dataContracts"></param>
        /// <param name="itemTypeOwnWorkflows"></param>
        /// <returns></returns>
        private List<TurnaroundEventComplete> CreateTurnaroundMappingsToApply(List<ApplyTurnaroundEventDetails> eventsToApply, List<ScanAssetDataContract> dataContracts)
        {
            var turnaroundMappings = new List<TurnaroundEventComplete>();

            foreach (var dataContract in dataContracts)
            {
                var tec = new TurnaroundEventComplete { Events = new List<TurnaroundEventDetail>(), DataContract = dataContract, LastProcessEventId = dataContract.LastProcessEventId, LastProcessEventTypeId = dataContract.LastProcessEventTypeId };

                foreach (var applyEvent in eventsToApply)
                {
                    int? nextWorkFlowId = null;

                    if (applyEvent.IsProcessEvent)
                    {
                        nextWorkFlowId = _workFlowCache.GetWorkFlowId((int?)tec.LastProcessEventTypeId, (int)applyEvent.EventType, dataContract.Asset.ItemTypeId, _facilityId, dataContract.Asset.ContainerMasterId, dataContract.DeliveryPtId);

                        tec.LastProcessEventTypeId = applyEvent.EventType;
                    }

                    var ted = new TurnaroundEventDetail { ApplyEvent = applyEvent, NextWorkFlowId = nextWorkFlowId };
                    tec.Events.Add(ted);
                    if (IsAutomaticEventCreated(tec, ted))
                        break;
                }

                turnaroundMappings.Add(tec);

            }

            return turnaroundMappings;
        }

        /// <summary>
        /// ApplyEvents operation
        /// </summary>
        public List<TurnaroundEventComplete> ApplyEvents(List<ApplyTurnaroundEventDetails> eventsToApply, List<ScanAssetDataContract> dataContracts, ScanDetails scanDetails, bool notificationsHandledExternally)
        {
            try
            {

                var turnaroundmappings = CreateTurnaroundMappingsToApply(eventsToApply, dataContracts);
                _isProcessEventDictionary = ReadProcessEvents(turnaroundmappings.SelectMany(tec => tec.Events));

                TurnaroundFacilityHelper turnaroundFacility = new TurnaroundFacilityHelper();

                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                };

                using (var transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    {
                        foreach (var tec in turnaroundmappings)
                        {
                            for (var i = 0; i < tec.Events.Count; i++)
                            {
                                var ted = tec.Events[i];

                                SetTECLocationId(scanDetails, tec, ted);

                                if ((ted.NextWorkFlowId != null) || (!ted.ApplyEvent.IsProcessEvent) || (ted.ApplyEvent.IsEndTurnaround))
                                {
                                    if (tec.DataContract.FacilityId != _facilityId && ted.ApplyEvent == eventsToApply.First() && !tec.DataContract.OverrideTurnaroundEventFacility)
                                    {
                                        tec.Events.Insert(i++, CreateFacilityChangedTED(workUnit, tec, ted));
                                        tec.DataContract.FacilityId = _facilityId;
                                        turnaroundFacility.Update(tec.DataContract.TurnaroundId.Value, _facilityId);
                                    }

                                    ted.TurnaroundEvent = CreateTurnaroundEvent(workUnit, tec.DataContract, ted.ApplyEvent, ted.NextWorkFlowId, tec.LocationId);
                                    tec.DataContract.EventTypeId = ted.ApplyEvent.EventType;

                                    UpdateTECEventWithLatestProcessEvent(tec, ted);
                                }
                            }
                        }

                        CreateTurnaroundEvents(turnaroundmappings);
                        var turnaroundMappingsWithNewEvents = turnaroundmappings.Where(tm => tm.Events.Any(e => e.TurnaroundEvent != null)).ToList();

                        ModifyTurnarounds(workUnit, turnaroundMappingsWithNewEvents);
                        ModifyTurnaroundWhs(workUnit, turnaroundMappingsWithNewEvents);
                        ModifyAutomaticEventRuleList(turnaroundMappingsWithNewEvents);
                    }

                    transaction.Complete();
                }

                _isProcessEventDictionary = ReadProcessEvents(turnaroundmappings.SelectMany(tec => tec.Events));
                GenerateTurnaroundEventDataContracts(turnaroundmappings, scanDetails);
                UpdateContainerInstances(turnaroundmappings);

                if (!notificationsHandledExternally)
                {
                    ProcessNotifications(turnaroundmappings, scanDetails);
                }
                return turnaroundmappings;
            }
            catch
            {
                dataContracts.ForEach(dc => dc.ErrorCode = (int)ErrorCodes.ApplyTurnaroundEventError);
                throw;
            }
        }

        private static void UpdateTECEventWithLatestProcessEvent(TurnaroundEventComplete tec, TurnaroundEventDetail ted)
        {

            if (ted.ApplyEvent.IsProcessEvent)
            {
                tec.DataContract.LastProcessEventId = ted.TurnaroundEvent.TurnaroundEventId;
                tec.DataContract.LastProcessEventTypeId = ted.ApplyEvent.EventType;

                if (ted.NextWorkFlowId != null)
                {
                    tec.DataContract.LastProcessEventWorkflowId = ted.NextWorkFlowId;
                }
            }
        }

        private TurnaroundEventDetail CreateFacilityChangedTED(IUnitOfWork workUnit, TurnaroundEventComplete tec, TurnaroundEventDetail ted)
        {
            var aed = ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.ChangedFacility);
            var facilityChangedTed = new TurnaroundEventDetail
            {
                ApplyEvent = aed,
                TurnaroundEvent = TurnaroundEventFactory.CreateEntity(workUnit,
                    created: DateTime.UtcNow,
                    eventTypeId: (short)TurnAroundEventTypeIdentifier.ChangedFacility,
                    turnaroundId: tec.DataContract.TurnaroundId.Value,
                    stationId: ted.ApplyEvent.RetrospectiveStationId.HasValue ? ted.ApplyEvent.RetrospectiveStationId.Value : _stationId.Value,
                    createdUserId: ted.ApplyEvent.IsAutomaticEvent ? 0 : _userId,
                    processStationTypeId: (byte)_stationTypeId,
                    locationId: tec.LocationId,
                    failureTypeId: _failureTypeId
                )
            };
            return facilityChangedTed;
        }

        private static void SetTECLocationId(ScanDetails scanDetails, TurnaroundEventComplete tec, TurnaroundEventDetail ted)
        {
            int? locationId;
            if (ted.ApplyEvent.RetrospectiveLocationId.HasValue)
            {
                locationId = ted.ApplyEvent.RetrospectiveLocationId.Value;
            }
            else
            {
                if (ted.ApplyEvent.LocationId.HasValue && ted.ApplyEvent.LocationId != 0)
                {
                    locationId = ted.ApplyEvent.LocationId;
                }
                else
                {
                    if (tec.DataContract.LocationId == 0)
                    {
                        locationId = null;
                    }
                    else
                    {
                        locationId = tec.DataContract.LocationId;
                    }
                }
            }

            if (locationId == null && scanDetails.StationLocationId > 0)
            {
                locationId = scanDetails.StationLocationId;
            }
            tec.LocationId = locationId;

        }

        private bool IsAutomaticEventCreated(TurnaroundEventComplete tec, TurnaroundEventDetail ted)
        {
            if (tec.DataContract.Asset?.AutomaticEventDetails is null)
                return false;
            var automaticEventDetail = tec.DataContract.Asset.AutomaticEventDetails
                                          .OrderBy(aed => aed.Created).FirstOrDefault(aed => aed.TriggerEvents
                                          .Any(te => (TurnAroundEventTypeIdentifier)te.EventTypeId == ted.ApplyEvent.EventType || te.Activated));

            if (automaticEventDetail != null)
            {
                if (automaticEventDetail.EventToApplyId == (short)tec.DataContract.EventTypeId)
                    return false;

                automaticEventDetail.IsBeingAssessed = true;
                var triggerEvent = automaticEventDetail.TriggerEvents.FirstOrDefault(te => (TurnAroundEventTypeIdentifier)te.EventTypeId == ted.ApplyEvent.EventType);

                if(triggerEvent is null)
                    triggerEvent = automaticEventDetail.TriggerEvents.FirstOrDefault(te => te.Activated);

                triggerEvent.IsBeingAssessed = true;

                var removeFromParentEvent = AutomaticEventRemoveFromParentEvent(tec, ted, automaticEventDetail);
                ApplyTurnaroundEventDetails automaticCreatedEvent = CreateAutomaticTurnaroundEventDetails(ted, automaticEventDetail, removeFromParentEvent != null);

                if (automaticCreatedEvent.IsProcessEvent)
                {
                    int? autoNextWorkFlowId = _workFlowCache.GetWorkFlowId((int?)tec.LastProcessEventTypeId, (int)automaticCreatedEvent.EventType, tec.DataContract.Asset.ItemTypeId, _facilityId, tec.DataContract.Asset.ContainerMasterId, tec.DataContract.DeliveryPtId);
                    if (autoNextWorkFlowId != null)
                    {
                        if (removeFromParentEvent != null)
                            tec.Events.Add(removeFromParentEvent);
                        ted.ApplyEvent.IsAutomaticTriggerEvent = true;

                        tec.LastProcessEventTypeId = automaticCreatedEvent.EventType;

                        var newTed = new TurnaroundEventDetail { ApplyEvent = automaticCreatedEvent, NextWorkFlowId = autoNextWorkFlowId };
                        tec.Events.Add(newTed);

                        return true;
                    }
                }
            }

            return false;
        }

        private static ApplyTurnaroundEventDetails CreateAutomaticTurnaroundEventDetails(TurnaroundEventDetail ted, AutomaticEventDetailsDataContract automaticEventDetails, bool removeFromParent)
        {
            ApplyTurnaroundEventDetails automaticCreatedEvent = ApplyTurnaroundEventDetails.Copy(ted);
            automaticCreatedEvent.EventType = (TurnAroundEventTypeIdentifier)automaticEventDetails.EventToApplyId;
            automaticCreatedEvent.RemoveFromParent = removeFromParent ? removeFromParent : ted.ApplyEvent.RemoveFromParent;
            automaticCreatedEvent.BatchId = null;
            automaticCreatedEvent.BatchExternalId = null;
            automaticCreatedEvent.IsAutomaticCreatedEvent = true;
            return automaticCreatedEvent;
        }

        private TurnaroundEventDetail AutomaticEventRemoveFromParentEvent(TurnaroundEventComplete tec, TurnaroundEventDetail ted, AutomaticEventDetailsDataContract automaticEventDetail)
        {
            TurnaroundEventDetail removeFromParentEvent = null;

            if ((TurnAroundEventTypeIdentifier)automaticEventDetail.EventToApplyId == TurnAroundEventTypeIdentifier.IntoQuarantine)
            {
                if (tec.DataContract.IsParentACarriage || tec.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage)
                {
                    removeFromParentEvent = CreateRemoveFromParentEvent(tec, ted, TurnAroundEventTypeIdentifier.RemovedFromCarriage, true);
                }

                else if (tec.DataContract.IsParentABatchTag || tec.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AssignToBatchTag)
                {
                    removeFromParentEvent = CreateRemoveFromParentEvent(tec, ted, TurnAroundEventTypeIdentifier.RemoveFromBatchTag, false);
                }
            }

            return removeFromParentEvent;
        }

        private TurnaroundEventDetail CreateRemoveFromParentEvent(TurnaroundEventComplete tec, TurnaroundEventDetail ted, TurnAroundEventTypeIdentifier eventToApply, bool isProcessEvent)
        {
            ApplyTurnaroundEventDetails removeFromParentEvent = ApplyTurnaroundEventDetails.Copy(ted);
            removeFromParentEvent.EventType = eventToApply;
            removeFromParentEvent.RemoveFromParent = true;
            removeFromParentEvent.BatchId = null;
            removeFromParentEvent.BatchExternalId = null;
            removeFromParentEvent.IsProcessEvent = isProcessEvent;

            int? nextWorkflowId = null;

            if (isProcessEvent)
                nextWorkflowId = _workFlowCache.GetWorkFlowId((int)removeFromParentEvent.EventType, (int)TurnAroundEventTypeIdentifier.IntoQuarantine, tec.DataContract.Asset.ItemTypeId, _facilityId, tec.DataContract.Asset.ContainerMasterId, tec.DataContract.DeliveryPtId);

            return new TurnaroundEventDetail { ApplyEvent = removeFromParentEvent, NextWorkFlowId = nextWorkflowId };
        }

        private static void ModifyAutomaticEventRuleList(List<TurnaroundEventComplete> turnaroundmappings)
        {
            var updateAutomaticRuleRequestList = new List<UpdateAutomaticEventRuleRequest> { };

            foreach (var turnaroundMap in turnaroundmappings.Where(tm => tm.DataContract.Asset?.AutomaticEventDetails != null && tm.DataContract.Asset.AutomaticEventDetails.Any(aed => aed.IsBeingAssessed)))
            {
                var automaticEventDetailsList = turnaroundMap.DataContract.Asset.AutomaticEventDetails;
                var automaticEventDetailToAssess = automaticEventDetailsList.FirstOrDefault(aed => aed.IsBeingAssessed);
                var automaticTriggerEventTypeToAssess = automaticEventDetailToAssess.TriggerEvents.FirstOrDefault(te => te.IsBeingAssessed);

                var triggeredAutomaticTurnaroundEvent = turnaroundMap.Events.FirstOrDefault(tm => tm.ApplyEvent.IsAutomaticTriggerEvent);
                var createdAutomaticTurnaroundEvent = turnaroundMap.Events.FirstOrDefault(tm => tm.ApplyEvent.IsAutomaticCreatedEvent);

                if (createdAutomaticTurnaroundEvent != null)
                    turnaroundMap.DataContract.AutomaticEventApplied = true;

                automaticEventDetailToAssess.CreatedTurnaroundEventId = createdAutomaticTurnaroundEvent?.TurnaroundEvent.TurnaroundEventId;
                var matchingAutomaticEventDetailList = automaticEventDetailsList.Where(aed => aed.EventToApplyId == automaticEventDetailToAssess.EventToApplyId &&
                                                               aed.TriggerEvents.Any(te => te.IsBeingAssessed || te.EventTypeId == automaticTriggerEventTypeToAssess.EventTypeId || te.Activated));

                foreach (var automaticEventRule in matchingAutomaticEventDetailList)
                {
                    var triggerEventTypeDetail = automaticEventRule.TriggerEvents.First(te => te.IsBeingAssessed || te.EventTypeId == automaticTriggerEventTypeToAssess.EventTypeId);

                    if(triggerEventTypeDetail is null)
                        triggerEventTypeDetail = automaticEventRule.TriggerEvents.First(te => te.Activated);

                    if (!triggerEventTypeDetail.Activated || triggeredAutomaticTurnaroundEvent != null && createdAutomaticTurnaroundEvent != null)
                    {
                        updateAutomaticRuleRequestList.Add(new UpdateAutomaticEventRuleRequest
                        {
                            ContainerInstanceAutomaticEventId = automaticEventRule.ContainerInstanceAutomaticEventId,
                            EventTypeIdToActivate = triggerEventTypeDetail.EventTypeId,
                            CreatedTurnaroundEventId = createdAutomaticTurnaroundEvent?.TurnaroundEvent.TurnaroundEventId,
                            TriggeredTurnaroundEventId = triggeredAutomaticTurnaroundEvent?.TurnaroundEvent.TurnaroundEventId
                        });
                    }
                }
            }

            if (updateAutomaticRuleRequestList.Count > 0)
            {
                using (var containerInstanceAutoEventService = InstanceFactory.GetInstance<IContainerInstanceAutomaticEventService>())
                using (var repository = InstanceFactory.GetInstance<IPathwayRepository>())
                {
                    containerInstanceAutoEventService.Update(updateAutomaticRuleRequestList, repository);
                }
            }
        }

        private void CreateTurnaroundEvents(List<TurnaroundEventComplete> turnaroundmappings)
        {

            var dt = new DataTable();
            dt.Columns.Add("BatchId", typeof(int));
            dt.Columns.Add("CreatedUserId", typeof(int));
            dt.Columns.Add("EventTypeId", typeof(int));
            dt.Columns.Add("FailureTypeId", typeof(int));
            dt.Columns.Add("ProcessStationTypeId", typeof(int));
            dt.Columns.Add("StationId", typeof(int));
            dt.Columns.Add("TurnaroundId", typeof(int));
            dt.Columns.Add("WorkflowId", typeof(int));
            dt.Columns.Add("RetrospectivelyCreated", typeof(DateTime));
            dt.Columns.Add("PinRequestReasonId", typeof(int));
            dt.Columns.Add("StoragePointId", typeof(int));
            dt.Columns.Add("QuarantineReasonId", typeof(int));
            dt.Columns.Add("LocationId", typeof(int));
            dt.Columns.Add("AbandonReasonId", typeof(int));

            foreach (var tec in turnaroundmappings)
            {
                foreach (var ted in tec.Events)
                {
                    tec.DataContract.ItemExceptionApprovalFlag = ted.ApplyEvent.ItemExceptionsApprovalFlag ?? tec.DataContract.ItemExceptionApprovalFlag;

                    var te = ted.TurnaroundEvent;
                    if (te != null)
                    {
                        var retospectivelyCreated = te.Created == DateTime.MinValue ? (DateTime?)null : te.Created;
                        dt.Rows.Add(te.BatchId, te.CreatedUserId, te.EventTypeId, te.FailureTypeId, te.ProcessStationTypeId, te.StationId, te.TurnaroundId, te.WorkflowId, retospectivelyCreated,
                                    te.PinRequestReasonId, te.StoragePointId, te.QuarantineReasonId, te.LocationId, te.AbandonReasonId);
                    }
                }
            }

            DataSet data;

            {
                data = repository.DataManager.ExecuteQuery("dbo.TurnaroundEvent_BulkInsert_V2", CommandType.StoredProcedure,
                                                            new SqlParameter { ParameterName = "@Data", Value = dt, TypeName = "[dbo].[TurnaroundEventData_V2]", SqlDbType = SqlDbType.Structured });
            }

            if (data == null || data.Tables.Count != 1)
            {
                throw new Exception("Expected data format is 1 table containing turnaround and event types");
            }

            foreach (DataRow dr in data.Tables[0].Rows)
            {
                var turnaroundId = Convert.ToInt32(dr["TurnaroundId"]);
                var eventTypeId = Convert.ToInt16(dr["EventTypeId"]);
                var turnaroundEventId = Convert.ToInt32(dr["TurnaroundEventId"]);
                var tec = turnaroundmappings.FirstOrDefault(tm => tm.DataContract.TurnaroundId == turnaroundId);

                if (tec != null)
                {
                    tec.DataContract.LastTurnaroundEventId = turnaroundEventId;

                    var ted = tec.Events.FirstOrDefault(te => te.TurnaroundEvent != null && te.TurnaroundEvent.TurnaroundEventId == 0 && te.TurnaroundEvent.EventTypeId == eventTypeId);

                    if (ted != null)
                    {
                        ted.TurnaroundEvent.TurnaroundEventId = turnaroundEventId;
                    }
                }
            }
            ////Log.Info("CreateTurnaroundEvents END");
        }

        private class TurnaroundDcPair
        {
            /// <summary>
            /// Gets or sets Dc
            /// </summary>
            public ScanAssetDataContract Dc { get; set; }
            /// <summary>
            /// Gets or sets Turnaround
            /// </summary>
            public Turnaround Turnaround { get; set; }
        }

        private void ModifyTurnarounds(IUnitOfWork workUnit, List<TurnaroundEventComplete> tecList)
        {
            var turnaroundsRequiringExpiryReset = new List<TurnaroundDcPair>();
            var turnarounds = new List<Turnaround>();

            foreach (var tec in tecList)
            {
                var dc = tec.DataContract;
                var lastEventToApply = tec.Events.Last().ApplyEvent;
                var turnaround = TurnaroundFactory.CreateEntity(workUnit,
                    turnaroundId: dc.TurnaroundId.Value,
                    expiry: dc.Expiry,
                    lastEventId: dc.LastTurnaroundEventId,
                    facilityId: dc.OverrideTurnaroundEventFacility ? (short)dc.FacilityId : _facilityId,
                    isPaused: dc.IsTurnaroundPaused,
                    itemExceptionsApprovalFlag: dc.ItemExceptionApprovalFlag
                );

                if (dc.StartTurnaroundEventId == null)
                {
                    turnaround.StartEventId = dc.LastTurnaroundEventId;
                    dc.StartTurnaroundEventId = dc.LastTurnaroundEventId;
                    dc.StartEventTime = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
                }
                else
                {
                    turnaround.StartEventId = dc.StartTurnaroundEventId;
                }

                #region Parent relation
                if (lastEventToApply.RemoveFromParent)
                {
                    turnaround.ParentTurnaroundId = null;
                    dc.ParentTurnaroundId = null;
                    dc.IsParentABatchTag = false;
                    dc.IsParentACarriage = false;
                }
                else
                {
                    if (lastEventToApply.ParentTurnaroundId.HasValue)
                    {
                        turnaround.ParentTurnaroundId = lastEventToApply.ParentTurnaroundId;
                        dc.ParentTurnaroundId = lastEventToApply.ParentTurnaroundId;
                    }
                    else if (dc.ParentTurnaroundId.HasValue)
                    {
                        turnaround.ParentTurnaroundId = dc.ParentTurnaroundId;
                    }
                }
                #endregion

                if (dc.SetExpiryTime && lastEventToApply.CanSetTurnaroundExpiryTime && turnaround.Expiry == new DateTime(1900, 1, 1))
                {
                    turnaroundsRequiringExpiryReset.Add(new TurnaroundDcPair { Dc = dc, Turnaround = turnaround });
                }

                if (lastEventToApply.DeliveryNoteId.HasValue)
                {
                    turnaround.DeliveryNoteId = lastEventToApply.DeliveryNoteId;
                }
                else if (dc.DeliveryNoteId.HasValue && (lastEventToApply.UseDeliveryNoteIdFromScanDc || !lastEventToApply.IsProcessEvent))
                {
                    turnaround.DeliveryNoteId = dc.DeliveryNoteId;
                }

                if (lastEventToApply.ItemExceptionsApprovalFlag.HasValue)
                {
                    turnaround.ItemExceptionsApprovalFlag = lastEventToApply.ItemExceptionsApprovalFlag.Value;
                }

                if (dc.DeliveryPtId > 0)
                {
                    turnaround.DeliveryPointId = dc.DeliveryPtId;
                }

                turnaround.StoragePointId = dc.StoragePointId;
                turnaround.ProcessStationTypeId = dc.StationTypeId;

                turnarounds.Add(turnaround);
            }

            var expiryDt = new DataTable();
            expiryDt.Columns.Add("TurnaroundId", typeof(int));
            expiryDt.Columns.Add("ServiceRequirementId", typeof(int));
            expiryDt.Columns.Add("DeliveryPointId", typeof(int));
            expiryDt.Columns.Add("StartTime", typeof(DateTime));
            expiryDt.Columns.Add("LastEventTime", typeof(DateTime));

            foreach (var t in turnaroundsRequiringExpiryReset)
            {
                expiryDt.Rows.Add(t.Dc.TurnaroundId, t.Dc.ServiceRequirementId, t.Turnaround.DeliveryPointId, t.Turnaround?.StartEvent?.Created ?? t.Dc.StartEventTime, t.Turnaround.CurrentTurnaroundEvent?.TurnaroundEvent?.Created ?? t.Dc.StartEventTime);
            }

            DataSet data;

            {
                data = repository.DataManager.ExecuteQuery("dbo.ServiceRequirementExpiry_BulkCalculate", CommandType.StoredProcedure,
                                                           new SqlParameter { ParameterName = "@FacilityId", Value = _facilityId, SqlDbType = SqlDbType.Int },
                                                           new SqlParameter { ParameterName = "@Data", Value = expiryDt, TypeName = "[dbo].[ExpiryData]", SqlDbType = SqlDbType.Structured });
            }
            foreach (DataRow dr in data.Tables[0].Rows)
            {
                var turnaroundId = Convert.ToInt32(dr["TurnaroundId"]);

                if (dr["Expiry"] != DBNull.Value)
                {
                    var expiry = Convert.ToDateTime(dr["Expiry"]);
                    var dcTurnaround = turnaroundsRequiringExpiryReset.FirstOrDefault(tm => tm.Dc.TurnaroundId == turnaroundId);

                    if (dcTurnaround != null)
                    {
                        dcTurnaround.Dc.Expiry = DateTime.SpecifyKind(expiry, DateTimeKind.Utc);
                        dcTurnaround.Turnaround.Expiry = expiry;

                        dcTurnaround.Dc.StartEventTime = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
                        dcTurnaround.Turnaround.StartEventId = dcTurnaround.Dc.LastTurnaroundEventId;
                    }
                }
            }

            var dt = new DataTable();
            dt.Columns.Add("TurnaroundId", typeof(int));
            dt.Columns.Add("DeliveryNoteId", typeof(int));
            dt.Columns.Add("DeliveryPointId", typeof(int));
            dt.Columns.Add("FacilityId", typeof(int));
            dt.Columns.Add("ParentTurnaroundId", typeof(int));
            dt.Columns.Add("StoragePointId", typeof(int));
            dt.Columns.Add("Expiry", typeof(DateTime));
            dt.Columns.Add("StartEventId", typeof(int));
            dt.Columns.Add("LastEventId", typeof(int));
            dt.Columns.Add("ItemExceptionsApprovalFlag", typeof(bool));
            dt.Columns.Add("IsPaused", typeof(bool));

            foreach (var te in turnarounds)
            {
                dt.Rows.Add(te.TurnaroundId, te.DeliveryNoteId, te.DeliveryPointId, te.FacilityId, te.ParentTurnaroundId, te.StoragePointId, te.Expiry,
                            te.StartEventId, te.LastEventId, te.ItemExceptionsApprovalFlag, te.IsPaused);
            }

            {
                repository.DataManager.ExecuteNonQuery("dbo.Turnaround_BulkUpdate", CommandType.StoredProcedure,
                    new SqlParameter
                    {
                        ParameterName = "@Data",
                        Value = dt,
                        TypeName = "[dbo].[TurnaroundData]",
                        SqlDbType = SqlDbType.Structured
                    });
            }
        }

        private void ModifyTurnaroundWhs(IUnitOfWork workUnit, List<TurnaroundEventComplete> tecList)
        {
            var turnaroundWHs = new List<TurnaroundWH>();

            var turnaroundWhRepository = TurnaroundWHRepository.New(workUnit);

            foreach (var tec in tecList)
            {
                var dc = tec.DataContract;
                var lastEventToApply = tec.Events.Last().ApplyEvent;
                var eventTypeId = (short)lastEventToApply.EventType;

                var turnaroundWh = TurnaroundWHFactory.CreateEntity(workUnit,
                    turnaroundId: dc.TurnaroundId.GetValueOrDefault()
                );

                if (DoesTurnaroundWhRequireCleanup(tec, turnaroundWh))
                {
                    turnaroundWh = turnaroundWhRepository.GetByTurnaround(dc.TurnaroundId.GetValueOrDefault());

                    if (turnaroundWh != null)
                    {
                        turnaroundWhRepository.Delete(turnaroundWh);
                        turnaroundWhRepository.Save();
                    }
                }
                else
                {
                    turnaroundWHs.Add(turnaroundWh);

                    if (lastEventToApply.BatchId.HasValue && string.IsNullOrEmpty(lastEventToApply.BatchExternalId))
                    {
                        BatchHelper bh = new BatchHelper();
                        lastEventToApply.BatchExternalId = bh.GetExternalId(lastEventToApply.BatchId.Value);
                    }

                    turnaroundWh.FacilityId = (short)dc.FacilityId;
                    turnaroundWh.FacilityName = _facilityCache.GetText(dc.FacilityId);
                    turnaroundWh.BatchId = lastEventToApply.BatchId;
                    turnaroundWh.BatchExternalId = lastEventToApply.BatchExternalId ?? string.Empty;
                    turnaroundWh.Expiry = dc.Expiry;
                    turnaroundWh.LastEventId = dc.LastTurnaroundEventId;
                    turnaroundWh.LastEventTypeId = eventTypeId;
                    turnaroundWh.LastEventName = _isProcessEventDictionary[lastEventToApply.EventType].Text;
                    turnaroundWh.LastEventTime = DateTime.UtcNow;
                    turnaroundWh.ParentTurnaroundId = lastEventToApply.RemoveFromParent ? null : dc.ParentTurnaroundId;

                    if (dc.StartEventTime.HasValue)
                    {
                        turnaroundWh.StartEventTime = dc.StartEventTime;
                    }

                    var nextEvent = _workFlowCache.GetNextEventId((int?)dc.LastProcessEventTypeId, dc.Asset.ItemTypeId, _facilityId, dc.Asset.ContainerMasterId, dc.DeliveryPtId);

                    if (nextEvent != null)
                    {
                        dc.NextEventId = nextEvent.ToEventTypeId;
                        dc.NextEvent = nextEvent.ToEventText;

                        turnaroundWh.NextEventTypeId = (short)nextEvent.ToEventTypeId;
                        turnaroundWh.NextEventName = nextEvent.ToEventText;
                    }
                    else
                    {
                        turnaroundWh.NextEventTypeId = null;
                        turnaroundWh.NextEventName = string.Empty;
                    }
                }
            }

            var dt = new DataTable();
            dt.Columns.Add("TurnaroundId", typeof(int));
            dt.Columns.Add("FacilityId", typeof(int));
            dt.Columns.Add("FacilityName", typeof(string));
            dt.Columns.Add("BatchId", typeof(int));
            dt.Columns.Add("BatchExternalId", typeof(string));
            dt.Columns.Add("Expiry", typeof(DateTime));
            dt.Columns.Add("LastEventId", typeof(int));
            dt.Columns.Add("LastEventTypeId", typeof(int));
            dt.Columns.Add("LastEventName", typeof(string));
            dt.Columns.Add("LastEventTime", typeof(DateTime));
            dt.Columns.Add("ParentTurnaroundId", typeof(int));
            dt.Columns.Add("StartEventTime", typeof(DateTime));
            dt.Columns.Add("NextEventTypeId", typeof(int));
            dt.Columns.Add("NextEventName", typeof(string));

            foreach (var te in turnaroundWHs)
            {
                dt.Rows.Add(te.TurnaroundId, te.FacilityId, te.FacilityName, te.BatchId, te.BatchExternalId, te.Expiry, te.LastEventId, te.LastEventTypeId,
                            te.LastEventName, te.LastEventTime, te.ParentTurnaroundId, te.StartEventTime, te.NextEventTypeId, te.NextEventName);
            }

            {
                repository.DataManager.ExecuteNonQuery("dbo.TurnaroundWH_BulkUpdate", CommandType.StoredProcedure,
                    new SqlParameter
                    {
                        ParameterName = "@Data",
                        Value = dt,
                        TypeName = "[dbo].[TurnaroundWHData]",
                        SqlDbType = SqlDbType.Structured
                    });
            }
        }

        private bool DoesTurnaroundWhRequireCleanup(TurnaroundEventComplete tec, TurnaroundWH turnaroundWh)
        {
            var doDelete = false;
            var scanDC = tec.DataContract;

            if (scanDC.TurnaroundId.HasValue)
            {
                if (turnaroundWh != null)
                {
                    if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.LoadTrolleyEPOD)
                    {
                        doDelete = true;
                    }
                    if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.AutomaticDelivery)
                    {
                        doDelete = true;
                    }
                    if (tec.Events.Any(e => e.ApplyEvent.EventType == TurnAroundEventTypeIdentifier.Inbound) && scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                    {
                        doDelete = true;
                    }
                    if ((scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.Wash || scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.PartWash ||
                         scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.WashRelease) &&
                        ((scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley) || (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BaseCarriage) ||
                            (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Carriage)))
                    {
                        doDelete = true;
                    }
                    if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag || scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTagOriginal)
                    {
                        if ((scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.FailedWash && !_keepBatchTagTogetherRequested) || (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.IntoAutoclave))
                        {
                            doDelete = true;
                        }
                    }
                    if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra)
                    {
                        switch (scanDC.LastProcessEventTypeId)
                        {
                            case TurnAroundEventTypeIdentifier.WetPack:
                            case TurnAroundEventTypeIdentifier.BrokenPack:
                            case TurnAroundEventTypeIdentifier.BiologicalIndicatorFailed:
                                doDelete = true;
                                break;
                        }
                    }
                    if (scanDC.LastProcessEventTypeId == TurnAroundEventTypeIdentifier.Archived)
                    {
                        return true;
                    }

                    if (tec.Events.Any(e => e.ApplyEvent.EventType == TurnAroundEventTypeIdentifier.DeliveryNotePrint) &&
                        scanDC.TurnaroundEvents.FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.Dispatch) != null)
                    {
                        return true;
                    }
                }

                if ((turnaroundWh != null) && (scanDC.IsBestPractice && doDelete))
                {
                    return true;
                }
            }
            return false;
        }

        private void GenerateTurnaroundEventDataContracts(List<TurnaroundEventComplete> turnaroundmappings, ScanDetails scanDetails)
        {
            {
                var turnaroundEventRepository = TurnaroundEventRepository.New(workUnit);

                foreach (var tec in turnaroundmappings)
                {
                    foreach (var ted in tec.Events)
                    {
                        if (ted.TurnaroundEvent != null)
                        {
                            var te = new TurnaroundEventDataContract()
                            {
                                TurnaroundEventId = ted.TurnaroundEvent.TurnaroundEventId,
                                EventTypeId = ted.TurnaroundEvent.EventTypeId,
                                Created = DateTime.SpecifyKind(ted.TurnaroundEvent.Created, DateTimeKind.Utc),
                                FacilityId = scanDetails.FacilityId,
                                IsProcessEvent = _isProcessEventDictionary[(TurnAroundEventTypeIdentifier)ted.TurnaroundEvent.EventTypeId].IsProcessEvent
                            };

                            if (scanDetails.FetchFullEventDetailsForAppliedEvent)
                            {
                                var info = turnaroundEventRepository.GetAdditionalInformation(ted.TurnaroundEvent, scanDetails.Culture, scanDetails.UserId);
                                te.AdditionalInfo = info.Text;
                                te.AdditionalInfoFields = info.Fields;
                            }
                            tec.DataContract.TurnaroundEvents.Add(te);
                            tec.DataContract.EventTypeId = (TurnAroundEventTypeIdentifier)ted.TurnaroundEvent.EventTypeId;
                        }
                    }
                }
            }
        }

        private void UpdateContainerInstances(List<TurnaroundEventComplete> turnaroundmappings)
        {
            var dt = new DataTable();
            dt.Columns.Add("ID1", typeof(int));
            dt.Columns.Add("ID2", typeof(int));

            foreach (var ted in turnaroundmappings)
            {
                if (ted.DataContract.Asset.ContainerInstanceId.HasValue && ted.Events.Any(e => e.TurnaroundEvent != null && _isProcessEventDictionary[(TurnAroundEventTypeIdentifier)e.TurnaroundEvent.EventTypeId].IsProcessEvent))
                {
                    dt.Rows.Add(ted.DataContract.Asset.ContainerInstanceId.Value, ted.LocationId);
                }
            }

            {
                repository.DataManager.ExecuteNonQuery("dbo.ContainerInstance_BulkUpdateLocation",
                    CommandType.StoredProcedure,
                    new SqlParameter
                    {
                        ParameterName = "@ContainerInstanceLocationIds",
                        Value = dt,
                        TypeName = "[dbo].[ID_ID_Table]",
                        SqlDbType = SqlDbType.Structured
                    }
                );
            }
        }

        private void ProcessNotifications(List<TurnaroundEventComplete> turnaroundmappings, ScanDetails scanDetails)
        {
            foreach (var ted in turnaroundmappings)
            {
                foreach (var tec in ted.Events)
                {
                    if (tec.TurnaroundEvent != null)
                    {
                        if (ted.DataContract.NotificationTypesFired == null)
                        {
                            ted.DataContract.NotificationTypesFired = _processNotificationsDlgt?.Invoke(ted.DataContract, scanDetails, tec.TurnaroundEvent);
                        }
                        else
                        {
                            ted.DataContract.NotificationTypesFired.AddRange(_processNotificationsDlgt?.Invoke(ted.DataContract, scanDetails, tec.TurnaroundEvent));
                        }
                    }
                }
            }
        }

        private TurnaroundEvent CreateTurnaroundEvent(IUnitOfWork workUnit, ScanAssetDataContract dataContract, ApplyTurnaroundEventDetails applyEvent, int? nextWorkFlowId, int? location)
        {
            var userId = applyEvent.RetrospectiveUserId == null
                ? (_userId == 0 ? dataContract.UserId : _userId)
                : applyEvent.RetrospectiveUserId ?? default(int);

            var newTurnaroundEvent = TurnaroundEventFactory.CreateEntity(workUnit,
                created: applyEvent.RetrospectiveCreatedDate,
                eventTypeId: (short)applyEvent.EventType,
                turnaroundId: dataContract.TurnaroundId.Value,
                stationId: applyEvent.RetrospectiveStationId ?? _stationId.Value,
                createdUserId: applyEvent.IsAutomaticEvent ? 0 : userId,
                batchId: applyEvent.BatchId,
                processStationTypeId: applyEvent.RetrospectiveProcessStationTypeId != default(int) ? (byte)applyEvent.RetrospectiveProcessStationTypeId : (byte)_stationTypeId,
                workflowId: nextWorkFlowId,
                quarantineReasonId: _quarantineReasonId,
                locationId: location,
                storagePointId: dataContract.StoragePointId,
                failureTypeId: _failureTypeId
            );
            var isWeighingEvent = applyEvent.EventType == TurnAroundEventTypeIdentifier.WeighedUsingPostWashTolerances || applyEvent.EventType == TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances;

            if ((dataContract.PinReasonId.HasValue || applyEvent.RetrospectivePinRequestReasonId.HasValue) && ((applyEvent.IsProcessEvent && !applyEvent.IsAutomaticEvent) || isWeighingEvent))
            {
                newTurnaroundEvent.PinRequestReasonId = applyEvent.RetrospectivePinRequestReasonId.HasValue ? applyEvent.RetrospectivePinRequestReasonId : dataContract.PinReasonId;
            }
            if (dataContract.ApprovedByUserId.HasValue)
            {
                newTurnaroundEvent.CreatedUserId = dataContract.ApprovedByUserId.Value;

                if (dataContract.ApprovedByUserPinReasonId.HasValue)
                {
                    newTurnaroundEvent.PinRequestReasonId = dataContract.ApprovedByUserPinReasonId.Value;
                }
                else if (applyEvent.EventType == TurnAroundEventTypeIdentifier.CancelPacking)
                {
                    newTurnaroundEvent.PinRequestReasonId = dataContract.PinReasonId; // to ensure there's a value
                }
                else
                {
                    newTurnaroundEvent.PinRequestReasonId = null;
                }
            }

            if (applyEvent.IsAutomaticCreatedEvent)
            {
                var autoEventDetails = dataContract.Asset.AutomaticEventDetails.FirstOrDefault(aed => aed.IsBeingAssessed);
                PopulateAutoEventProperties(newTurnaroundEvent, autoEventDetails);
            }

            return newTurnaroundEvent;
        }

        private void PopulateAutoEventProperties(TurnaroundEvent te, AutomaticEventDetailsDataContract autoEventDetails)
        {
            if (autoEventDetails.Properties.TryGetValue(AutomaticEventProperties.KnownProperty.QuarantineReasonId, out short quarantineReasonId))
                te.QuarantineReasonId = quarantineReasonId;

            if (autoEventDetails.Properties.TryGetValue(AutomaticEventProperties.KnownProperty.AbandonReasonId, out short abandonReasonId))
                te.AbandonReasonId = abandonReasonId;

            if (autoEventDetails.Properties.TryGetValue(AutomaticEventProperties.KnownProperty.FailureTypeId, out byte failureTypeId))
                te.FailureTypeId = failureTypeId;

            if (autoEventDetails.Properties.TryGetValue(AutomaticEventProperties.KnownProperty.LocationId, out int locationId))
                te.LocationId = locationId;

            if (autoEventDetails.Properties.TryGetValue(AutomaticEventProperties.KnownProperty.StoragePointId, out int storagePointId))
                te.StoragePointId = storagePointId;
        }

        /// <summary>
        /// Dispose operation
        /// </summary>
        public void Dispose()
        {

        }
    }
}
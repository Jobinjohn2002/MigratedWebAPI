using SynergyApplicationFrameworkApi.Application.Services.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {
        private bool _isLastEventAnEndEvent;

        private Turnaround CreateExtraTurnaround(int containerMasterId, int serviceReqId, int deliveryPtId)
        {
            Turnaround turnaround;

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);

                turnaround = TurnaroundFactory.CreateEntity(workUnit,
                    containerMasterId: containerMasterId,
                    serviceRequirementId: serviceReqId,
                    deliveryPointId: deliveryPtId,
                    expiry: new DateTime(1900, 1, 1),
                    containerInstanceId: null,
                    created: DateTime.UtcNow,
                    facilityId: _synergyTrakData.FacilityId,
                    createdUserId: _synergyTrakData.UserId,
                    isBestPractice: true
                );

                turnaroundRepository.Add(turnaround);
                turnaroundRepository.Save();

                var serviceRequirementExpiryRepository = new ServiceRequirementExpiryRepository();
                var expiry = serviceRequirementExpiryRepository.ReadExpiryCalculationWithTurnaround(serviceReqId, turnaround.TurnaroundId);

                turnaround.Expiry = expiry.Expiry;
                turnaroundRepository.Save();
                TurnaroundFacilityHelper turnaroundFacilityHelper = new TurnaroundFacilityHelper();
                turnaroundFacilityHelper.Create(turnaround);
            }

            return turnaround;
        }

        /// <summary>
        /// GetStatusFromTurnaround operation
        /// </summary>
        public void GetStatusFromTurnaround(Turnaround turnaround, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            scanDC.TurnaroundId = turnaround.TurnaroundId;

            var lastprocessEvent = turnaround.TurnaroundEvent.Where(te => te.Workflow != null).OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault();

            if (lastprocessEvent != null)
            {
                _isLastEventAnEndEvent = lastprocessEvent.Workflow.IsEnd;

                scanDC.IsArchived = (lastprocessEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.Archived);
                scanDC.IsInQuarantine = (lastprocessEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoQuarantine);
                scanDC.IsTurnaroundEnded = _isLastEventAnEndEvent;
            }

            Log.Info("ProcessTurnaround GetDetailsFromTurnaround");
            GetDetailsFromTurnaround(turnaround, scanDC, scanDetails);
        }

        /// <summary>
        /// CreateNewTurnaround operation
        /// </summary>
        public void CreateNewTurnaround(ScanAssetDataContract scanDC, ScanDetails scanDetails, ContainerInstance containerInstance)
        {
            Turnaround turnaround = null;
            _isNewTurnaround = true;

            Log.Info("ProcessTurnaround Create new turnaround and put event on that");

            Log.Info($"ProcessTurnaround turnaround == null {(turnaround == null)}, isLastEventAnEndEvent={_isLastEventAnEndEvent}");

            _synergyTrakData.ScanDcList.Clear();
            _synergyTrakData.ScanDcList.Insert(0, scanDC); // Put parent in at front.
            scanDC.TurnaroundId = null;
            scanDC.ErrorCode = null;
            scanDC.LastProcessEventId = null;
            scanDC.LastProcessEventTypeId = null;
            scanDC.LastProcessEventWorkflowId = null;
            _isLastEventAnEndEvent = false;
            scanDC.IsParentABatchTag = false;
            scanDC.IsParentACarriage = false;
            scanDC.IsBestPracticeWorkflow = false;
            scanDC.IsArchived = false; //This was missing.
            scanDC.FacilityId = scanDetails.FacilityId; //Reset this to where we are currently processing

            if (MLDQuarantineHelper.CheckSetScanToAutoQuarantineForDraft(_synergyTrakData, scanDC, scanDetails))
            {
                _ignoreNotesWarningsAndDecon = true;
            }

            {
                if (containerInstance == null)
                {
                    var containerRepository = ContainerInstanceRepository.New(workUnit);
                    var containerInstances = containerRepository.PreSearchContainerInstance(scanDetails.ExternalId, scanDetails.FacilityId, ExludeTrolleyFromMFPByEvent()).ToList();

                    if (containerInstances.Count > 0)
                    {
                        containerInstance = containerInstances[0];
                        scanDC.Asset = CreateAssetDataContract(containerInstance, null, workUnit);
                        scanDC.DeliveryPtId = containerInstance.DeliveryPointId;
                        scanDC.ServiceRequirementDefinitionId = containerInstance.ServiceRequirementDefinitionId;
                    }
                }
                else
                {
                    scanDC.Asset = CreateAssetDataContract(containerInstance, null, workUnit);
                    scanDC.DeliveryPtId = containerInstance.DeliveryPointId;
                    scanDC.ServiceRequirementDefinitionId = containerInstance.ServiceRequirementDefinitionId;

                    if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Wash ||
                        _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.PartWash ||
                        _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.DeconStart ||
                        _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.DeconEnd ||
                        _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.RemoveFromBatchTag ||
                        _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignToBatchTag ||
                        _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AssignedToCarriage)
                    {
                        var helper = new Engine.Helpers.ConfigurableListHelper(workUnit);
                        scanDC.Asset.DecontaminationTasks = helper.GetConfiguredDecontaminationTasksForContainerMaster(scanDC.FacilityId, scanDC.Asset.ContainerMasterId);
                        scanDC.DisplayDeconTasks = !Decon.CheckIfAllDeconTasksFulfilled(scanDC);

                        if (scanDC.Asset.DecontaminationTasks != null && scanDC.Asset.DecontaminationTasks.Count > 0)
                        {
                            scanDC.CompletedPartWashes = CompletedPartWashes(scanDC);
                        }
                    }
                }
            }

            InitialiseScanDcForNewTurnaround(scanDC); // Gets notes and warnings
            scanDC.IsDeconEndRequired = Decon.IsDeconEndRequired(scanDC);

            if (PreworkflowValidation(scanDC, scanDetails, true) && !HasAutomaticEventBeenApplied(scanDC) && CheckValidWorkFlow(scanDC, turnaround, scanDetails, _preWorkflowEventId))
            {
                if ((scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag) && (scanDC.HasChildren))
                {
                    if (scanDetails.ConfirmStartNewTurnaround)
                    {
                        Parallel.ForEach(scanDC.ChildItems, dc => RemoveFromBatchTag(dc, scanDetails));
                    }
                    else
                    {
                        scanDC.RequiresStartNewTurnaroundConfirmation = true;
                        return;
                    }
                }

                if (scanDC.ErrorCode == null)
                {
                    if (!Auditing.Validation(scanDC, scanDetails, SynergyTrakData))
                    {
                        return;
                    }

                    CheckCustomerWorkflow(scanDC, (short)_synergyTrakData.EventTypeId);

                    if (scanDC.HasCustomerWorkflow)
                    {
                        if (SpecialitiesComplexity.Validation(scanDC, _synergyTrakData.ScanDcList, _synergyTrakData.EventTypeId))
                        {
                            scanDC.EventTypeId = _synergyTrakData.EventTypeId;

                            if ((_synergyTrakData.CanApplyEvent || _ignoreNotesWarningsAndDecon) && scanDetails.ApplyEvent)
                            {
                                turnaround = CreateNewTurnaround(scanDC, scanDetails);
                                if ((_synergyTrakData.CanApplyEvent || _ignoreNotesWarningsAndDecon)
                                    && scanDetails.ApplyEvent
                                    && turnaround != null
                                    && scanDC.ErrorCode == null)
                                {
                                    scanDC.TurnaroundId = turnaround.TurnaroundId;

                                    if (scanDC.Warnings != null && scanDC.Warnings.Count > 0)
                                    {
                                        foreach (var w in scanDC.Warnings)
                                        {
                                            w.TurnaroundId = scanDC.TurnaroundId;
                                        }
                                    }

                                    CreateTurnaroundWH(scanDC, turnaround);
                                    ProcessEvent(scanDC, scanDetails);

                                    Log.Info("ProcessTurnaround Call ProcessEvent 2");

                                    GetNextEvent(scanDC);
                                }
                            }
                        }
                    }
                    else
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.NoCustomerWorkflowDefined;
                    }
                }
            }
        }

        /// <summary>
        /// IsTurnaroundPreWash operation
        /// </summary>
        public bool IsTurnaroundPreWash(int turnaroundId)
        {
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var workflowRepository = WorkflowRepository.New(workUnit);

                Turnaround turnaround = turnaroundRepository.Get(turnaroundId);
                var turnaroundData = LazyUtilityHelper.ConvertTurnaroundToTurnaroundData(workUnit, turnaround);

                var fromEventTypeId = turnaround.CurrentTurnaroundEvent.EventTypeId;
                if (fromEventTypeId == (int)TurnAroundEventTypeIdentifier.IntoQuarantine)
                {
                    fromEventTypeId = turnaround.TurnaroundEvent.Where(te =>
                        te.EventType.ProcessEvent &&
                        te.EventType.EventTypeCategoryId == (byte)EventTypeCategoryIdentifier.Normal &&
                        te.EventType.IsArchiveEvent == false).OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).First().EventTypeId;
                }

                return workflowRepository.CheckEventTypeCanBeReached(turnaroundData.ItemTypeId, fromEventTypeId, (int)TurnAroundEventTypeIdentifier.Wash, turnaroundData.FacilityId, turnaroundData.ContainerMasterId, turnaroundData.DeliveryPointId);
            }
        }

        private bool CheckValidWorkFlow(ScanAssetDataContract scanDC, Turnaround turnaround, ScanDetails scanDetails, int? preWorkflowEventId)
        {
            var isValid = true;

            if (_isProcessEvent)
            {
                isValid = IsWorkflowStepValid(scanDC, _synergyTrakData.EventTypeId, preWorkflowEventId);

                if (!isValid)
                {
                    if (turnaround != null)
                    {
                        if ((scanDetails.ParentItemTypeId.HasValue) &&
                           ((scanDetails.ParentItemTypeId.Value == (int)ItemTypeIdentifier.BatchTag) || (scanDetails.ParentItemTypeId.Value == (int)ItemTypeIdentifier.BatchTagOriginal)) &&
                            (scanDC.TurnaroundEvents.Any(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.Wash)))
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEventForAssignToBatchTag;
                        }
                        else
                        {
                            if (_isLastEventAnEndEvent)
                            {
                                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoAutoclave || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.OutofAutoclave ||
                                    _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Dispatch || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AddedToOrder)
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.TurnaroundIsArchived;
                                }
                                else if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoPigeonHoleStock)
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.MissingWorkflowEntry;
                                }
                                else if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.OutOfPigeonHoleStock)
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.ItemNotInStockToRemove;
                                }
                                else if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AvailableForCollection
                                        || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Collected
                                        || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Delivered)
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                                }
                                else
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.NoCurrentTurnaround;
                                }
                            }
                            else
                            {
                                if (StationHelper.IsTurnaroundStation(scanDetails.StationTypeId))
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.TurnaroundInvalidNextEvent;
                                }
                                else
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (scanDC.IsTurnaroundEnded || scanDC.IsArchived)
                        {
                            if (StationHelper.IsTurnaroundStation(scanDetails.StationTypeId))
                            {
                                scanDC.ErrorCode = (int)ErrorCodes.TurnaroundIsArchived;
                            }
                            else
                            {
                                if (scanDC.NextEvent != null &&
                                    (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.VacuumPackedDry
                                    || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.VacuumPackedWet
                                    || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.VacuumPacked
                                    || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoDryingCabinet
                                    || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetDry
                                    || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetExpired
                                    || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetWet
                                    || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoPigeonHoleStock)
                                )
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                                }
                                else
                                {
                                    scanDC.ErrorCode = (int)ErrorCodes.NoCurrentTurnaround;
                                }
                            }
                        }
                        else
                        {
                            scanDC.ErrorCode = (int)ErrorCodes.NoCurrentTurnaround;
                        }
                    }
                }
            }
            else
            {
                if (_synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.PrintLabel
                    && turnaround.TurnaroundEvent.All(te => te.EventTypeId != (short)TurnAroundEventTypeIdentifier.AerPassed))
                {
                    scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                    return false;
                }
            }

            return isValid;
        }

        private static bool CanTurnaroundBeEnded(int turnaroundId)
        {
            {
                var workflowRepository = WorkflowRepository.New(workUnit);
                return workflowRepository.CanTurnaroundBeEnded(turnaroundId);
            }
        }

        /// <summary>
        /// GetTurnaroundDetails operation
        /// </summary>
        public BasicTurnaroundDataContract GetTurnaroundDetails(ScanDetails scanDetails)
        {
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacilityId(scanDetails.TurnaroundExternalId.Value, scanDetails.FacilityId);

                if (turnaround == null)
                {
                    return new BasicTurnaroundDataContract { ErrorCode = (int)ErrorCodes.InvalidTurnaround };
                }

                int? lastProcessEventTypeId = turnaround.TurnaroundEvent.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventType.ProcessEvent).EventTypeId;
                if (lastProcessEventTypeId == (int)TurnAroundEventTypeIdentifier.AddedToTrolley)
                {
                    lastProcessEventTypeId = (int)TurnAroundEventTypeIdentifier.RemovedFromTrolley; //This will be automatically applied
                }

                var workflowRepository = WorkflowRepository.New(workUnit);
                var possibleNextEvents = workflowRepository.ReadNextEvents(lastProcessEventTypeId, turnaround.ContainerMaster.ItemTypeId, scanDetails.FacilityId, turnaround.ContainerMaster.ContainerMasterId, turnaround.DeliveryPoint.DeliveryPointId);
                var possibleEvents = GetEventTypes();

                IEnumerable<EventTypeDataContract> GetEventTypes()
                {
                    foreach (var possibleEventType in possibleNextEvents)
                    {
                        yield return new EventTypeDataContract
                        {
                            EventTypeId = possibleEventType.EventTypeId,
                            Text = possibleEventType.Text,
                        };
                    }
                }

                ErrorCodes? errorCode = null;

                if (!possibleEvents.Any())
                {
                    errorCode = ErrorCodes.TurnaroundIsArchived;
                }

                var batch = turnaround.TurnaroundEvent.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventType.ProcessEvent)?.Batch ??
                            turnaround.TurnaroundEvent.FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoAutoclave)?.Batch;

                var eventType = (TurnAroundEventTypeIdentifier?)scanDetails.Events.FirstOrDefault()?.EventType;

                if (errorCode == null)
                {
                    errorCode = ValidateForEvent(turnaround, eventType);
                }

                if (errorCode == null && batch != null)
                {
                    errorCode = ValidateForEvent(batch, eventType);
                }

                return new BasicTurnaroundDataContract()
                {
                    ErrorCode = (int?)errorCode,
                    TurnaroundExternalId = (int)turnaround.ExternalId,
                    TurnaroundId = turnaround.TurnaroundId,
                    BatchId = batch?.BatchId ?? default(int),
                    BatchName = batch?.ExternalId ?? string.Empty,
                    ContainerInstanceId = turnaround.ContainerInstance?.ContainerInstanceId,
                    ContainerInstancePrimaryId = turnaround.ContainerInstance?.PrimaryId ?? string.Empty,
                    ContainerMasterName = turnaround.ContainerMaster.Text,
                    CustomerName = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Text,
                    DeliveryPointName = turnaround.DeliveryPoint.Text,
                    ServiceRequirementName = turnaround.ServiceRequirement.Text,
                    IsFastTrack = turnaround.ServiceRequirement.IsFastTrack ?? false,
                    Expiry = DateTime.SpecifyKind(turnaround.Expiry, DateTimeKind.Utc),
                    NextEvent = possibleEvents.FirstOrDefault()?.Text ?? string.Empty,
                    PossibleEvents = possibleEvents.ToList()
                };
            }
        }

        /// <summary>
        /// GetTurnaroundNextEvent operation
        /// </summary>
        public BasicTurnaroundDataContract GetTurnaroundNextEvent(ScanDetails scanDetails)
        {
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);

                var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacilityId(scanDetails.TurnaroundExternalId.Value, scanDetails.FacilityId);

                if (turnaround == null)
                {
                    return new BasicTurnaroundDataContract { ErrorCode = (int)ErrorCodes.InvalidTurnaround };
                }

                int? errorCode = null;
                EventType nextEvent = null;
                var workflowRepository = WorkflowRepository.New(workUnit);

                if (scanDetails.Events.Any())
                {
                    nextEvent = workflowRepository.ReadNextEvent(scanDetails.Events.First().EventType, turnaround.ContainerMaster.ItemTypeId, scanDetails.FacilityId, turnaround.ContainerMaster.ContainerMasterId, turnaround.DeliveryPoint.DeliveryPointId);
                    errorCode = nextEvent == null ? (int?)ErrorCodes.TurnaroundIsArchived : null;
                }

                return new BasicTurnaroundDataContract()
                {
                    ErrorCode = errorCode,
                    TurnaroundExternalId = (int)turnaround.ExternalId,
                    TurnaroundId = turnaround.TurnaroundId,
                    ContainerInstanceId = turnaround.ContainerInstance?.ContainerInstanceId,
                    ContainerInstancePrimaryId = turnaround.ContainerInstance?.PrimaryId ?? string.Empty,
                    ContainerMasterName = turnaround.ContainerMaster.Text,
                    CustomerName = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.Text,
                    DeliveryPointName = turnaround.DeliveryPoint.Text,
                    ServiceRequirementName = turnaround.ServiceRequirement.Text,
                    IsFastTrack = turnaround.ServiceRequirement.IsFastTrack ?? false,
                    Expiry = DateTime.SpecifyKind(turnaround.Expiry, DateTimeKind.Utc),
                    NextEvent = GetNextEventDisplayText(nextEvent)
                };
            }
        }

        private string GetNextEventDisplayText(EventType eventType)
        {
            if (eventType == null || eventType.EventTypeId == (short)TurnAroundEventTypeIdentifier.IntoQuarantine || eventType.EventTypeId == (short)TurnAroundEventTypeIdentifier.Archived)
            {
                return string.Empty;
            }

            return eventType.Text;
        }

        private static ErrorCodes? ValidateForEvent(Batch batch, TurnAroundEventTypeIdentifier? eventType)
        {
            if (batch == null)
            {
                throw new ArgumentNullException(nameof(batch));
            }

            switch (eventType)
            {
                case TurnAroundEventTypeIdentifier.OutofAutoclave:
                case TurnAroundEventTypeIdentifier.WetPack:
                case TurnAroundEventTypeIdentifier.BrokenPack:
                case TurnAroundEventTypeIdentifier.OutOfStock:
                case TurnAroundEventTypeIdentifier.IntoStock:

                    if (batch.Machine.MachineType.IsSteriliser)
                    {
                        if (!batch.Started.HasValue)
                        {
                            return ErrorCodes.BatchRequiresStart;
                        }

                        if (batch.BatchStatusId == (int)BatchStatusIdentifier.InProgress)
                        {
                            return ErrorCodes.BatchInProgress;
                        }
                    }
                    if (eventType == TurnAroundEventTypeIdentifier.IntoStock && batch.BiologicalIndicatorTest?.Count > 0)
                    {
                        return CheckBatchBiTest(batch);
                    }

                    break;

                default:
                    return null;
            }

            return null;
        }

        private static ErrorCodes? CheckBatchBiTest(Batch batch)
        {
            {
                var turnaround = batch.CurrentlyAssignedTurnarounds?.FirstOrDefault();
                if (turnaround != null)
                {
                    var facilityRepository = FacilityRepository.New(workUnit);
                    var facility = facilityRepository.Get(turnaround.FacilityId);
                    if (facility?.DelayedBiTestTypeId == (int)DelayedBiTestTypeIdentifier.Off || facility?.DelayedBiTestTypeId == (int)DelayedBiTestTypeIdentifier.AfterSettingIncubation)
                    {
                        var biRepository = BiologicalIndicatorTestRepository.New(workUnit);
                        var biTest = biRepository.GetByBatchId(batch.BatchId);

                        if (facility?.DelayedBiTestTypeId == (int)DelayedBiTestTypeIdentifier.Off && biTest?.BiologicalIndicatorTestStatusId != (int)BiologicalIndicatorTestStatusIdentifier.TestCompleted)
                        {
                            return ErrorCodes.BiTestNotComplete;
                        }

                        else if (facility?.DelayedBiTestTypeId == (int)DelayedBiTestTypeIdentifier.AfterSettingIncubation && biTest?.BiologicalIndicatorTestStatusId == (int)BiologicalIndicatorTestStatusIdentifier.Open)
                        {
                            return ErrorCodes.BiIncubationNotSet;
                        }
                    }

                    return null;
                }

                return null;
            }
        }

        public static ErrorCodes? ValidateForEvent(Turnaround turnaround, TurnAroundEventTypeIdentifier? eventType)
        {
            if (turnaround == null)
            {
                throw new ArgumentNullException(nameof(turnaround));
            }

            switch (eventType)
            {
                case TurnAroundEventTypeIdentifier.OutOfStock:
                    if (!turnaround.DeliveryPoint.StockLocation)
                    {
                        return ErrorCodes.NonStockDeliveryPoint;
                    }

                    var lastProcessEvent = turnaround.TurnaroundEvent?.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventType?.ProcessEvent ?? false);
                    if (lastProcessEvent?.EventTypeId == (int)TurnAroundEventTypeIdentifier.QualityAssurance)
                    {
                        return ErrorCodes.TurnaroundInvalidNextEvent;
                    }

                    break;

                case TurnAroundEventTypeIdentifier.IntoStock:
                    if (!turnaround.DeliveryPoint.StockLocation)
                    {
                        return ErrorCodes.NonStockDeliveryPoint;
                    }

                    if (turnaround.LastEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.QualityAssurance)
                    {
                        return ErrorCodes.AddToAutoclaveOutBatch;
                    }

                    if (turnaround.LastEvent.EventTypeId != (int)TurnAroundEventTypeIdentifier.IntoAutoclave &&
                        turnaround.LastEvent.EventTypeId != (int)TurnAroundEventTypeIdentifier.RetrospectiveOutOfAutoclaveApproval)
                    {
                        return ErrorCodes.TurnaroundInvalidNextEvent;
                    }

                    break;

                default:
                    return null;
            }

            return null;
        }

        private bool DoesTurnaroundHaveActiveServiceReports(int turnaroundId)
        {
            {
                DefectRepository repo = new DefectRepository(workUnit);
                return repo.GetOpenDefects(turnaroundId).Any();
            }
        }

        /// <summary>
        /// HasLoanSetExpiryWarningDisplayed operation
        /// </summary>
        public bool HasLoanSetExpiryWarningDisplayed(Turnaround turnaround, int eventTypeId)
        {
            var turnaroundEvents = turnaround.TurnaroundEvent?.OrderBy(te => te.Created);
            var eventsWhereWarningDisplayed = new List<int>
            {
                (int)TurnAroundEventTypeIdentifier.DeconStart,
                (int)TurnAroundEventTypeIdentifier.Wash,
                (int)TurnAroundEventTypeIdentifier.AssignToBatchTag,
                (int)TurnAroundEventTypeIdentifier.AssignedToCarriage
            };
            if (eventsWhereWarningDisplayed.Any(e => e == eventTypeId) && eventTypeId != (int)TurnAroundEventTypeIdentifier.DeconStart)
            {
                var loansetExpiryDisplayedPreviously = turnaroundEvents?.Any(te => eventsWhereWarningDisplayed.Any(e => e == te.EventTypeId)) ?? false;

                return loansetExpiryDisplayedPreviously;
            }

            return false;
        }
    }
}
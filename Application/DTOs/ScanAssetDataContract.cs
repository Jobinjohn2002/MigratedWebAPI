using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ScanAssetDataContract
    /// </summary>
    public class ScanAssetDataContract : BaseReplyDataContract
    {
        [IgnoreDataMember]
        private DateTime _expiry = new DateTime(1900, 1, 1);
        /// <summary>
        /// Gets or sets IsApplyingEvent
        /// </summary>
        public bool IsApplyingEvent { get; set; }   // Not a datamember though. Just svc side only.
        /// <summary>
        /// Gets or sets ScannedString
        /// </summary>
        public string ScannedString { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeCategoryId
        /// </summary>
        public int StationTypeCategoryId { get; set; }
        /// <summary>
        /// Gets or sets Asset
        /// </summary>
        public AssetDetailsDataContract Asset { get; set; }
        /// <summary>
        /// Gets or sets NonUniqueAssets
        /// </summary>
        public IList<AssetDetailsDataContract> NonUniqueAssets { get; set; }
        public int? TargetTimeSeconds { get; set; }
        public double? PercentageIpohVariance { get; set; }
        public DateTime Expiry
        {
            get
            {
                return _expiry;
            }
            set
            {
                _expiry = value;
                UtcNow = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);
            }
        }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        public int? ServiceRequirementDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }
        /// <summary>
        /// Gets or sets LastMessage
        /// </summary>
        public string LastMessage { get; set; }
        /// <summary>
        /// Gets or sets Packer
        /// </summary>
        public string Packer { get; set; }
        /// <summary>
        /// Gets or sets NextEventId
        /// </summary>
        public int NextEventId { get; set; }
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }
        public int? TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets IsTurnaroundLive
        /// </summary>
        public bool IsTurnaroundLive { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets Warnings
        /// </summary>
        public IList<WarningDataContract> Warnings { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNotes
        /// </summary>
        public IList<NoteDataContract> ContainerMasterNotes { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundNotes
        /// </summary>
        public IList<NoteDataContract> TurnaroundNotes { get; set; }
        /// <summary>
        /// Gets or sets TransientNotes
        /// </summary>
        public IList<NoteDataContract> TransientNotes { get; set; }
        /// <summary>
        /// Gets or sets Defects
        /// </summary>
        public IList<DefectDataContract> Defects { get; set; }
        /// <summary>
        /// Gets or sets IsWorkflowSuccessful
        /// </summary>
        public bool IsWorkflowSuccessful { get; set; }
        /// <summary>
        /// Gets or sets IsTurnaroundEnded
        /// </summary>
        public bool IsTurnaroundEnded { get; set; }
        public int? ParentTurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets Parent
        /// </summary>
        public ScanAssetDataContract Parent { get; set; }
        /// <summary>
        /// Gets or sets IsParentABatchTag
        /// </summary>
        public bool IsParentABatchTag { get; set; }
        /// <summary>
        /// Gets or sets IsParentACarriage
        /// </summary>
        public bool IsParentACarriage { get; set; }
        public int? BatchId { get; set; }
        /// <summary>
        /// Gets or sets BatchName
        /// </summary>
        public string BatchName { get; set; }
        /// <summary>
        /// Gets or sets WasherName
        /// </summary>
        public string WasherName { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEvents
        /// </summary>
        public List<TurnaroundEventDataContract> TurnaroundEvents { get; set; }
        public int? StartTurnaroundEventId { get; set; }
        public int? LastTurnaroundEventId { get; set; }
        public int? LastProcessEventId { get; set; }
        public TurnAroundEventTypeIdentifier? LastProcessEventTypeId { get; set; }
        public int? LastProcessEventWorkflowId { get; set; }
        public TurnAroundEventTypeIdentifier? EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventCreated
        /// </summary>
        public DateTime TurnaroundEventCreated { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        public DateTime? StartEventTime { get; set; }
        /// <summary>
        /// Gets or sets BatchCycleId
        /// </summary>
        public int BatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPtId
        /// </summary>
        public int DeliveryPtId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPtName
        /// </summary>
        public string DeliveryPtName { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets ChildItems
        /// </summary>
        public List<ScanAssetDataContract> ChildItems { get; set; }
        /// <summary>
        /// Gets or sets PmWarned
        /// </summary>
        public List<KeyValueDataContract> PmWarned { get; set; }
        /// <summary>
        /// Gets or sets PmQuarantined
        /// </summary>
        public List<KeyValueDataContract> PmQuarantined { get; set; }
        public int? LocationId { get; set; }
        /// <summary>
        /// Gets or sets SpecialityId
        /// </summary>
        public int SpecialityId { get; set; }
        /// <summary>
        /// Gets or sets ComplexityId
        /// </summary>
        public int ComplexityId { get; set; }
        /// <summary>
        /// Gets or sets IndependentQaCheck
        /// </summary>
        public bool IndependentQaCheck { get; set; }
        /// <summary>
        /// Gets or sets HasChildren
        /// </summary>
        public bool HasChildren { get; set; }
        /// <summary>
        /// Gets or sets IsInQuarantine
        /// </summary>
        public bool IsInQuarantine { get; set; }
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public bool IsArchived { get; set; }
        /// <summary>
        /// Gets or sets IsTurnaroundEndedEarly
        /// </summary>
        public bool IsTurnaroundEndedEarly { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionApprovalFlag
        /// </summary>
        public bool ItemExceptionApprovalFlag { get; set; }
        public int? ApprovedByUserId;
        public int? ApprovedByUserPinReasonId;
        /// <summary>
        /// Gets or sets IsBestPractice
        /// </summary>
        public bool IsBestPractice { get; set; }
        /// <summary>
        /// Gets or sets IsBestPracticeWorkflow
        /// </summary>
        public bool IsBestPracticeWorkflow { get; set; }
        public int? DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteExternalId
        /// </summary>
        public string DeliveryNoteExternalId { get; set; }
        public int? PinReasonId { get; set; }
        /// <summary>
        /// Gets or sets ReferenceNumber
        /// </summary>
        public string ReferenceNumber { get; set; }
        /// <summary>
        /// Gets or sets IsRemoveFromParent
        /// </summary>
        public bool IsRemoveFromParent { get; set; }
        /// <summary>
        /// Gets or sets IsTurnaroundPaused
        /// </summary>
        public bool IsTurnaroundPaused { get; set; }
        /// <summary>
        /// Gets or sets IsDeconEndRequired
        /// </summary>
        public bool IsDeconEndRequired { get; set; }
        /// <summary>
        /// Gets or sets SetExpiryTime
        /// </summary>
        public bool SetExpiryTime { get; set; }
        /// <summary>
        /// Gets or sets HasCustomerWorkflow
        /// </summary>
        public bool HasCustomerWorkflow { get; set; }
        /// <summary>
        /// Gets or sets CompletedPartWashes
        /// </summary>
        public List<CompletedPartWashReplyDataContract> CompletedPartWashes { get; set; }
        /// <summary>
        /// Gets or sets IsStockLocation
        /// </summary>
        public bool IsStockLocation { get; set; }
        /// <summary>
        /// Gets or sets DisplayDeconTasks
        /// </summary>
        public bool DisplayDeconTasks { get; set; }
        /// <summary>
        /// Gets or sets TransferNote
        /// </summary>
        public TransferNoteDataContract TransferNote { get; set; }
        /// <summary>
        /// Gets or sets SupervisorApprovalRequired
        /// </summary>
        public bool SupervisorApprovalRequired { get; set; }
        /// <summary>
        /// Gets or sets RequiresKeepBatchTogetherConfirmation
        /// </summary>
        public bool RequiresKeepBatchTogetherConfirmation { get; set; }
        public int? ChildBatchTagCount { get; set; }
        public TurnAroundEventTypeIdentifier? RouteToEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets RequiresStartNewTurnaroundConfirmation
        /// </summary>
        public bool RequiresStartNewTurnaroundConfirmation { get; set; }
        /// <summary>
        /// Gets or sets IsBatchScan
        /// </summary>
        public bool IsBatchScan { get; set; }
        public bool OverrideTurnaroundEventFacility = false;
        public TurnAroundEventTypeIdentifier RequestedEventType;
        /// <summary>
        /// Gets or sets PreviewOfEvents
        /// </summary>
        public List<EventTypeListDataContract> PreviewOfEvents { get; set; }
        /// <summary>
        /// Gets or sets CanNavigateForEnquiry
        /// </summary>
        public bool CanNavigateForEnquiry { get; set; }
        /// <summary>
        /// Gets or sets PossibleNextEvents
        /// </summary>
        public IList<EventTypeDataContract> PossibleNextEvents { get; set; }
        public int? StoragePointId { get; set; }
        /// <summary>
        /// Gets or sets AuditRequiredForProccessing
        /// </summary>
        public bool AuditRequiredForProccessing { get; set; }
        /// <summary>
        /// Gets or sets AuditRequiredPriorityScreen
        /// </summary>
        public bool AuditRequiredPriorityScreen { get; set; }
        /// <summary>
        /// Gets or sets AuditDeconOutstanding
        /// </summary>
        public bool AuditDeconOutstanding { get; set; }
        /// <summary>
        /// Gets or sets AuditCleanOutstanding
        /// </summary>
        public bool AuditCleanOutstanding { get; set; }
        /// <summary>
        /// Gets or sets AuditFailedItemQuarantined
        /// </summary>
        public bool AuditFailedItemQuarantined { get; set; }
        /// <summary>
        /// Gets or sets AuditFailedItemAlreadyQuarantined
        /// </summary>
        public bool AuditFailedItemAlreadyQuarantined { get; set; }
        /// <summary>
        /// Gets or sets Audit
        /// </summary>
        public AuditDataContract Audit { get; set; }
        /// <summary>
        /// Gets or sets ExtendedErrorInformation
        /// </summary>
        public BatchCycleExtendedError ExtendedErrorInformation { get; set; }
        /// <summary>
        /// Gets or sets BatchCycles
        /// </summary>
        public BatchCyclesDataContract BatchCycles { get; set; }
        public int? ContainerMasterCoolingTime { get; set; }
        public int? RemainingContainerMasterCoolingTime { get; set; }
        /// <summary>
        /// Gets or sets IsQuarantineAfterWashAvailable
        /// </summary>
        public bool IsQuarantineAfterWashAvailable { get; set; }
        /// <summary>
        /// Gets or sets QuarantinedItems
        /// </summary>
        public List<AutomaticQuarantinedItem> QuarantinedItems { get; set; }
        /// <summary>
        /// Gets or sets AutomaticEventApplied
        /// </summary>
        public bool AutomaticEventApplied { get; set; }
    }
}
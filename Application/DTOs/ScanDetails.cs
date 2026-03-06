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
    /// ScanDetails
    /// </summary>
    public class ScanDetails : BaseRequestDataContract
    {
        [IgnoreDataMember]
        /// <summary>
        /// Gets or sets RetrospectiveCreatedDate
        /// </summary>
        public DateTime RetrospectiveCreatedDate { get; set; }
        /// <summary>
        /// Gets or sets RetrospectiveProcessStationTypeId
        /// </summary>
        public int RetrospectiveProcessStationTypeId { get; set; }
        public long? TurnaroundExternalId { get; set; }
        public int? TurnaroundId { get; set; }
        public int? InstanceId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or sets OrderIds
        /// </summary>
        [DataMember] public List<int> OrderIds { get; set; }
        public int? BaseItemTypeId { get; set; }     // Used to make sure that what is about to be created is one of these if set.
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets Events
        /// </summary>
        public List<ScanEventDataContract> Events { get; set; }
        public int? ParentTurnaroundId { get; set; }
        public int? ParentItemTypeId { get; set; }
        public int? ParentDeliveryPtId { get; set; }
        public int? Data { get; set; }
        /// <summary>
        /// Gets or sets StringData
        /// </summary>
        public string StringData { get; set; }
        public int? Count { get; set; }
        public int? PinReason { get; set; }
        /// <summary>
        /// Gets or sets IgnoreNotesWarningsAndDecon
        /// </summary>
        public bool IgnoreNotesWarningsAndDecon { get; set; }
        public int? BatchId { get; set; }
        public int? MachineTypeId { get; set; }
        public int? MachineId { get; set; }
        /// <summary>
        /// Gets or sets IsRemoveFromParent
        /// </summary>
        public bool IsRemoveFromParent { get; set; }
        public int? ApprovedByUserId { get; set; }
        public int? ApprovedByUserPinReasonId { get; set; }
        /// <summary>
        /// Gets or sets IsServerPrinting
        /// </summary>
        public bool IsServerPrinting { get; set; }
        /// <summary>
        /// Gets or sets MultiFacilityIds
        /// </summary>
        public List<short> MultiFacilityIds { get; set; }
        /// <summary>
        /// Gets or sets SupervisorNotAvailable
        /// </summary>
        public bool SupervisorNotAvailable { get; set; }
        public int? QuarantineReasonId { get; set; }
        /// <summary>
        /// Gets or sets ApplyEvent
        /// </summary>
        public bool ApplyEvent { get; set; } = true;
        /// <summary>
        /// Gets or sets IgnoreLoanSetExpriy
        /// </summary>
        public bool IgnoreLoanSetExpriy { get; set; }
        public int? DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets ApplyToBatch
        /// </summary>
        public bool ApplyToBatch { get; set; }
        /// <summary>
        /// Gets or sets IsTurnaroundPaused
        /// </summary>
        public bool IsTurnaroundPaused { get; set; }
        /// <summary>
        /// Gets or sets IgnorePlannedMaintenance
        /// </summary>
        public bool IgnorePlannedMaintenance { get; set; }
        /// <summary>
        /// Gets or sets IgnoreDispatch
        /// </summary>
        public bool IgnoreDispatch { get; set; }
        /// <summary>
        /// Gets or sets FulfillsDeconTask
        /// </summary>
        public bool FulfillsDeconTask { get; set; }
        /// <summary>
        /// Gets or sets StationLocationId
        /// </summary>
        public int StationLocationId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeCategoryId
        /// </summary>
        public int StationTypeCategoryId { get; set; }
        /// <summary>
        /// Gets or sets PrintDetails
        /// </summary>
        public bool PrintDetails { get; set; }
        /// <summary>
        /// Gets or sets TransferNoteLineScan
        /// </summary>
        public TransferNoteLineScan TransferNoteLineScan { get; set; }
        public int? TransferNoteId { get; set; }
        public short? DestinationFacilityId { get; set; }
        public short? RouteToEventTypeId { get; set; }
        public int? TransferNoteLineId { get; set; }
        public bool? IsKeepFailedBatchTogether { get; set; }
        /// <summary>
        /// Gets or sets ConfirmStartNewTurnaround
        /// </summary>
        public bool ConfirmStartNewTurnaround { get; set; }
        /// <summary>
        /// Gets or sets UseFirstRerouteEvent
        /// </summary>
        public bool UseFirstRerouteEvent { get; set; }
        /// <summary>
        /// Gets or sets SupervisorAction
        /// </summary>
        public SupervisorActions SupervisorAction { get; set; }
        public bool? IsRetrospectiveAddToAutoclaveBatch { get; set; }
        /// <summary>
        /// Gets or sets IsWarnForDifferentDeliveryPoints
        /// </summary>
        public bool IsWarnForDifferentDeliveryPoints { get; set; }
        /// <summary>
        /// Gets or sets FetchFullEventDetailsForAppliedEvent
        /// </summary>
        public bool FetchFullEventDetailsForAppliedEvent { get; set; }
        /// <summary>
        /// Gets or sets FetchNotesForAllStations
        /// </summary>
        public bool FetchNotesForAllStations { get; set; }
        public bool? IsDispatchingStock { get; set; }
        /// <summary>
        /// Gets or sets IncludeWeighingInformation
        /// </summary>
        public bool IncludeWeighingInformation { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets Audit
        /// </summary>
        public AuditDataContract Audit { get; set; }
        public bool IncludeAuditInformation {get;set;}
        public int? DeliveryNoteExternalId { get; set; }
        public int? FailureReason { get; set; }
        /// <summary>
        /// Gets or sets AlwaysCheckNotes
        /// </summary>
        public bool AlwaysCheckNotes { get; set; }

        [IgnoreDataMember]
        /// <summary>
        /// Gets or sets OverrideAddToScanHistory
        /// </summary>
        public bool OverrideAddToScanHistory { get; set; }
        /// <summary>
        /// Gets or sets IsTrolleylessDispatch
        /// </summary>
        public bool IsTrolleylessDispatch { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterCoolingTimeApprovedOverride
        /// </summary>
        public bool ContainerMasterCoolingTimeApprovedOverride { get; set; }
        public int? SupervisorApprovalUserId { get; set; }
        /// <summary>
        /// Gets or sets ReQuarantineAfterWash
        /// </summary>
        public bool ReQuarantineAfterWash { get; set; }
        public int? NoteId { get; set; }
        public ProcessNoteType? ProcessNoteType { get; set; }
    }
}
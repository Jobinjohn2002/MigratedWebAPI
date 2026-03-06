using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PackingTurnaroundEventData
    /// </summary>
    public class PackingTurnaroundEventData : StationDataBase
    {
        /// <summary>
        /// Gets or sets TurnaroundID
        /// </summary>
        public int TurnaroundID { get; set; }
        /// <summary>
        /// Gets or sets LastEventTypeId
        /// </summary>
        public int LastEventTypeId { get; set; }
        public int? NextEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ProcessStationTypeId
        /// </summary>
        public int ProcessStationTypeId { get; set; }
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceId
        /// </summary>
        public int ItemInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public new int ServiceRequirementId { get; set; }
        public int? BatchId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public long ExternalId { get; set; }
        /// <summary>
        /// Gets or sets FailureTypeId
        /// </summary>
        public int FailureTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsPackingStartedEvent
        /// </summary>
        public bool IsPackingStartedEvent { get; set; }
        /// <summary>
        /// Gets or sets IsPackingFinishedEvent
        /// </summary>
        public bool IsPackingFinishedEvent { get; set; }
        /// <summary>
        /// Gets or sets IsPackingCanceledEvent
        /// </summary>
        public bool IsPackingCanceledEvent { get; set; }
        /// <summary>
        /// Gets or sets IsPackingFailedEvent
        /// </summary>
        public bool IsPackingFailedEvent { get; set; }
        /// <summary>
        /// Gets or sets IsItemExceptionEvent
        /// </summary>
        public bool IsItemExceptionEvent { get; set; }
        /// <summary>
        /// Gets or sets IsPackingProcessEndedEvent
        /// </summary>
        public bool IsPackingProcessEndedEvent { get; set; }
        /// <summary>
        /// Gets or sets IsSupervisorVerificationRequiredEvent
        /// </summary>
        public bool IsSupervisorVerificationRequiredEvent { get; set; }
        /// <summary>
        /// Gets or sets IsSupervisorVerificationGivenEvent
        /// </summary>
        public bool IsSupervisorVerificationGivenEvent { get; set; }
        /// <summary>
        /// Gets or sets IsSupervisorVerificationCancelledEvent
        /// </summary>
        public bool IsSupervisorVerificationCancelledEvent { get; set; }
        /// <summary>
        /// Gets or sets IsIntoQuarantineEvent
        /// </summary>
        public bool IsIntoQuarantineEvent { get; set; }
        /// <summary>
        /// Gets or sets IsItemExceptionsApprovalFlag
        /// </summary>
        public bool IsItemExceptionsApprovalFlag { get; set; }
        /// <summary>
        /// Gets or sets IsQualityAssuranceEvent
        /// </summary>
        public bool IsQualityAssuranceEvent { get; set; }
        public int? QuarantineReasonId { get; set; }
        public int? SupervisorId { get; set; }
        public bool? IsSupervisorNotAvailable { get; set; }
        public bool? IsReWash { get; set; }  
    }
}

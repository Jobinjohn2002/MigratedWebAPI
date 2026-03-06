using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PriorityItemDataContract
    /// </summary>
    public class PriorityItemDataContract
    {
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public string ServiceRequirement { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets MinutesRemaining
        /// </summary>
        public int MinutesRemaining { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets IsOnABatchTag
        /// </summary>
        public bool IsOnABatchTag { get; set; }
        /// <summary>
        /// Gets or sets IsIdentifiedInstance
        /// </summary>
        public bool IsIdentifiedInstance { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        public int? OrderId { get; set; }
        public int? OrderStatusId { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? ProcedureDate { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        /// <summary>
        /// Gets or sets OrderReference
        /// </summary>
        public string OrderReference { get; set; }
        public int? OrderSourceId { get; set; }
        /// <summary>
        /// Gets or sets OrderStatusText
        /// </summary>
        public string OrderStatusText { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointText
        /// </summary>
        public string DeliveryPointText { get; set; }
        /// <summary>
        /// Gets or sets CustomerText
        /// </summary>
        public string CustomerText { get; set; }
        /// <summary>
        /// Gets or sets OrderLinesTotal
        /// </summary>
        public int OrderLinesTotal { get; set; }
        /// <summary>
        /// Gets or sets OrderLinesPickedTotal
        /// </summary>
        public int OrderLinesPickedTotal { get; set; }
        /// <summary>
        /// Gets or sets OrderNumberDisplay
        /// </summary>
        public string OrderNumberDisplay { get; set; }
        /// <summary>
        /// Gets or sets OrderPickedOutOfTotal
        /// </summary>
        public string OrderPickedOutOfTotal { get; set; }
        /// <summary>
        /// Gets or sets ModifyingUserName
        /// </summary>
        public string ModifyingUserName { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public int? BatchId { get; set; }
        public int? ItemCount { get; set; }
        public int? FailureTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemCountByTotal
        /// </summary>
        public string ItemCountByTotal { get; set; }
        public bool? IsOverDue { get; set; }
        public DateTime? Started { get; set; }
        /// <summary>
        /// Gets or sets BiologicalIndicatorExists
        /// </summary>
        public bool BiologicalIndicatorExists { get; set; }
        /// <summary>
        /// Gets or sets LotNumber
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// Gets or sets WellNumber
        /// </summary>
        public string WellNumber { get; set; }
        public DateTime? CompletionTime { get; set; }
        public int? MinsRemaining { get; set; }
        public BiologicalIndicatorTestStatusIdentifier? Status { get; set; }
        public int? SurgeonId { get; set; }
        /// <summary>
        /// Gets or sets SurgeonName
        /// </summary>
        public string SurgeonName { get; set; }
        public int? SurgicalProcedureTypeId { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureTypeName
        /// </summary>
        public string SurgicalProcedureTypeName { get; set; }
        /// <summary>
        /// Gets or sets CaseCartNumber
        /// </summary>
        public string CaseCartNumber { get; set; }
        /// <summary>
        /// Gets or sets TrayAuditRequired
        /// </summary>
        public bool TrayAuditRequired { get; set; }
        public bool? HasFastTrackItem { get; set; }
        /// <summary>
        /// Gets or sets FastTrackCount
        /// </summary>
        public int FastTrackCount { get; set; }
    }
}

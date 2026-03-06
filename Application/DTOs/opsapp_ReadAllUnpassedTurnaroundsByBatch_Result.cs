using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class opsapp_ReadAllUnpassedTurnaroundsByBatch_Result
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public Nullable<int> ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public Nullable<int> DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets InvoiceLineId
        /// </summary>
        public Nullable<int> InvoiceLineId { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceId
        /// </summary>
        public Nullable<int> ItemInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ParentTurnaroundId
        /// </summary>
        public Nullable<int> ParentTurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets StoragePointId
        /// </summary>
        public Nullable<int> StoragePointId { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets LegacyId
        /// </summary>
        public Nullable<int> LegacyId { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
        /// <summary>
        /// Gets or sets StartEventId
        /// </summary>
        public Nullable<int> StartEventId { get; set; }
        /// <summary>
        /// Gets or sets LastEventId
        /// </summary>
        public Nullable<int> LastEventId { get; set; }
        public Nullable<System.DateTime> SterileExpiryDate { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionsApprovalFlag
        /// </summary>
        public bool ItemExceptionsApprovalFlag { get; set; }
        /// <summary>
        /// Gets or sets IsBestPractice
        /// </summary>
        public bool IsBestPractice { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public Nullable<long> ExternalId { get; set; }
        /// <summary>
        /// Gets or sets IsPaused
        /// </summary>
        public bool IsPaused { get; set; }
        /// <summary>
        /// Gets or sets DisableTrolleyCustomerRestriction
        /// </summary>
        public bool DisableTrolleyCustomerRestriction { get; set; }
    }
}

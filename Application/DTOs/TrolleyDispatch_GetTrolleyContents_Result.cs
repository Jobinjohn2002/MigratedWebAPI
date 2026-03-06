using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class TrolleyDispatch_GetTrolleyContents_Result
    {
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public Nullable<int> ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public Nullable<long> TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets IsSupplementary
        /// </summary>
        public bool IsSupplementary { get; set; }
        /// <summary>
        /// Gets or sets IsTray
        /// </summary>
        public bool IsTray { get; set; }
        /// <summary>
        /// Gets or sets IsExtra
        /// </summary>
        public bool IsExtra { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public string ServiceRequirement { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public bool IsFastTrack { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public Nullable<int> DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public Nullable<int> DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets RestrictedForTrolleys
        /// </summary>
        public bool RestrictedForTrolleys { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public Nullable<int> CustomerId { get; set; }
        public System.DateTime LastEventDateTime { get; set; }
        /// <summary>
        /// Gets or sets LastEventTypeId
        /// </summary>
        public Nullable<int> LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }
        /// <summary>
        /// Gets or sets IsExpiringSoon
        /// </summary>
        public bool IsExpiringSoon { get; set; }
        /// <summary>
        /// Gets or sets DisableTrolleyCustomerRestriction
        /// </summary>
        public bool DisableTrolleyCustomerRestriction { get; set; }
    }
}

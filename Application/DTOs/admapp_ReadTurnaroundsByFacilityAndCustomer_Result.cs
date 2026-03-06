using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadTurnaroundsByFacilityAndCustomer_Result
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets TotalRows
        /// </summary>
        public Nullable<int> TotalRows { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets LastEventEventTypeText
        /// </summary>
        public string LastEventEventTypeText { get; set; }
        /// <summary>
        /// Gets or sets LastEventTypeId
        /// </summary>
        public short LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementDefinitionId
        /// </summary>
        public int ServiceRequirementDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public short DisplayOrder { get; set; }
        /// <summary>
        /// Gets or sets ProcessEvent
        /// </summary>
        public bool ProcessEvent { get; set; }
        /// <summary>
        /// Gets or sets PriorityOrder
        /// </summary>
        public int PriorityOrder { get; set; }
        /// <summary>
        /// Gets or sets ExpiredItemsCount
        /// </summary>
        public Nullable<int> ExpiredItemsCount { get; set; }
        /// <summary>
        /// Gets or sets NearExpiryItemsCount
        /// </summary>
        public Nullable<int> NearExpiryItemsCount { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryID
        /// </summary>
        public string ContainerInstancePrimaryID { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets ExpiryCountDown
        /// </summary>
        public string ExpiryCountDown { get; set; }
        /// <summary>
        /// Gets or sets QuarantineReason
        /// </summary>
        public string QuarantineReason { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public Nullable<bool> IsFastTrack { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets IsIdentifiable
        /// </summary>
        public bool IsIdentifiable { get; set; }
        /// <summary>
        /// Gets or sets RowNumber
        /// </summary>
        public Nullable<int> RowNumber { get; set; }
    }
}

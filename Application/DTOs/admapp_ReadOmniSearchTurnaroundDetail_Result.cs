using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchTurnaroundDetail_Result
    {
        /// <summary>
        /// Gets or sets Turnaroundid
        /// </summary>
        public int Turnaroundid { get; set; }
        public System.DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementid
        /// </summary>
        public int ServiceRequirementid { get; set; }
        /// <summary>
        /// Gets or sets ServicerequirementName
        /// </summary>
        public string ServicerequirementName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteid
        /// </summary>
        public Nullable<int> DeliveryNoteid { get; set; }
        public System.DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets LegacyInternalId
        /// </summary>
        public int LegacyInternalId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public Nullable<long> ExternalId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointid
        /// </summary>
        public int DeliveryPointid { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets Customerid
        /// </summary>
        public int Customerid { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public byte CustomerStatusId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public short EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public int IsArchived { get; set; }
    }
}

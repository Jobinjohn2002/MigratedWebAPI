using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadOmniSearchInstanceDetail_Result
    {
        /// <summary>
        /// Gets or sets Instanceid
        /// </summary>
        public int Instanceid { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public byte CustomerStatusId { get; set; }
        /// <summary>
        /// Gets or sets LegacyId
        /// </summary>
        public int LegacyId { get; set; }
        /// <summary>
        /// Gets or sets LegacyExternalId
        /// </summary>
        public string LegacyExternalId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets SuperType
        /// </summary>
        public string SuperType { get; set; }
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public int IsArchived { get; set; }
    }
}

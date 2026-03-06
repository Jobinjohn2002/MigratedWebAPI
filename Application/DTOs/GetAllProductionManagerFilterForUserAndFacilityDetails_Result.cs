using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class GetAllProductionManagerFilterForUserAndFacilityDetails_Result
    {
        /// <summary>
        /// Gets or sets UserProductionManagerFilterId
        /// </summary>
        public int UserProductionManagerFilterId { get; set; }
        /// <summary>
        /// Gets or sets FilterType
        /// </summary>
        public string FilterType { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public string ServiceRequirement { get; set; }
        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }
        /// <summary>
        /// Gets or sets SubType
        /// </summary>
        public string SubType { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets GroupEvents
        /// </summary>
        public string GroupEvents { get; set; }
        /// <summary>
        /// Gets or sets GroupServiceRequiremts
        /// </summary>
        public string GroupServiceRequiremts { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadTurnaroundsForGraphByFacilityAndCustomer_Result
    {
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public Nullable<int> TurnaroundCount { get; set; }
        /// <summary>
        /// Gets or sets HighPriorityCount
        /// </summary>
        public Nullable<int> HighPriorityCount { get; set; }
        /// <summary>
        /// Gets or sets MediumPriorityCount
        /// </summary>
        public Nullable<int> MediumPriorityCount { get; set; }
        /// <summary>
        /// Gets or sets LastEventEventTypeText
        /// </summary>
        public string LastEventEventTypeText { get; set; }
        /// <summary>
        /// Gets or sets LastEventTypeId
        /// </summary>
        public short LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets EventDisplayOrder
        /// </summary>
        public short EventDisplayOrder { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ServiceRequirementContractedHour
    {
        /// <summary>
        /// Gets or sets ServiceRequirementContractedHoursId
        /// </summary>
        public int ServiceRequirementContractedHoursId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets DayOfWeek
        /// </summary>
        public short DayOfWeek { get; set; }
        public System.TimeSpan Opening { get; set; }
        public System.TimeSpan Closing { get; set; }
        /// <summary>
        /// Gets or sets Closed
        /// </summary>
        public bool Closed { get; set; }
    
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public virtual ServiceRequirement ServiceRequirement { get; set; }
    }
}

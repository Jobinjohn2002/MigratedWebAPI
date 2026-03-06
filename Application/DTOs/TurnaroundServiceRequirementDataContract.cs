using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundServiceRequirementDataContract
    /// </summary>
    public class TurnaroundServiceRequirementDataContract 
    {
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public ServiceRequirementDataContract ServiceRequirement { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }        

    }
    
}
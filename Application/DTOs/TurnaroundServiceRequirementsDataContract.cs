using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundServiceRequirementsDataContract
    /// </summary>
    public class TurnaroundServiceRequirementsDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets TurnaroundServiceRequirements
        /// </summary>
        public List<TurnaroundServiceRequirementDataContract> TurnaroundServiceRequirements { get; set; } = new List<TurnaroundServiceRequirementDataContract>();

    }
    
}
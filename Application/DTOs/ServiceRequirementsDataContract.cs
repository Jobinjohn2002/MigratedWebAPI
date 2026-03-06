using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ServiceRequirementsDataContract
    /// </summary>
    public class ServiceRequirementsDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets ServiceRequirements
        /// </summary>
        public List<ServiceRequirementDataContract> ServiceRequirements { get; set; }
    }
}
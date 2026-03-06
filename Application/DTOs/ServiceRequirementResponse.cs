using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ServiceRequirementReponse
    /// </summary>
    public class ServiceRequirementReponse
    {
        /// <summary>
        /// Gets or sets ServiceRequirements
        /// </summary>
        public List<ServiceRequirementInfo> ServiceRequirements { get; set;}
    }
}

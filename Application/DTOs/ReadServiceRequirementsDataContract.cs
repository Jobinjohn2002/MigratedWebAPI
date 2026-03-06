using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ReadServiceRequirementsDataContract
    /// </summary>
    public class ReadServiceRequirementsDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets ServiceRequirementDefintion
        /// </summary>
        public int ServiceRequirementDefintion { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        public int? TurnaroundId{ get; set; }
    }
}
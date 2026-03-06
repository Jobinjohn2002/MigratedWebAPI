using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
        /// <summary>
        /// CustomerFacilityDefinition
        /// </summary>
        public class CustomerFacilityDefinition : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
    }
}

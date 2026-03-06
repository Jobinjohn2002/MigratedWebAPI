using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class admapp_ReadProductionOverviewByServiceRequirement_Result
    {
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public Nullable<int> TurnaroundCount { get; set; }
        /// <summary>
        /// Gets or sets LastEventEventTypeText
        /// </summary>
        public string LastEventEventTypeText { get; set; }
        /// <summary>
        /// Gets or sets LastEventTypeId
        /// </summary>
        public short LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementText
        /// </summary>
        public string ServiceRequirementText { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementDefinitionId
        /// </summary>
        public int ServiceRequirementDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets CustomerText
        /// </summary>
        public string CustomerText { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public short DisplayOrder { get; set; }
    }
}

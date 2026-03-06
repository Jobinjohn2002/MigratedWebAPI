using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// AuditRuleContract
    /// </summary>
    public class AuditRuleContract
    {
        /// <summary>
        /// Gets or sets AuditType
        /// </summary>
        public AuditTypeIdentifier AuditType { get; set; }
        /// <summary>
        /// Gets or sets AuditStationCategoryRequirement
        /// </summary>
        public StationTypeCategoryIdentifier AuditStationCategoryRequirement { get; set; }
        /// <summary>
        /// Gets or sets IsEnabled
        /// </summary>
        public bool IsEnabled { get;set; }
    }
}

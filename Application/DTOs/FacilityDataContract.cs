using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityDataContract
    /// </summary>
    public class FacilityDataContract
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets DateTimeFormats
        /// </summary>
        public DateTimeFormatDataContract DateTimeFormats { get; set; }
        public bool? BiologicalIndicatorEnabled { get; set; }
        /// <summary>
        /// Gets or sets AllowProcessBeforeBiCompleteType
        /// </summary>
        public int AllowProcessBeforeBiCompleteType { get; set; }
        /// <summary>
        /// Gets or sets RetrospectiveAutoclaveApprovalEnabled
        /// </summary>
        public bool RetrospectiveAutoclaveApprovalEnabled { get; set; }
        /// <summary>
        /// Gets or sets RetrospectiveAutoclaveApprovalCancelEnabled
        /// </summary>
        public bool RetrospectiveAutoclaveApprovalCancelEnabled { get; set; }
        /// <summary>
        /// Gets or sets IsPrimary
        /// </summary>
        public bool IsPrimary { get; set; }
        /// <summary>
        /// Gets or sets PostWashTolerance
        /// </summary>
        public decimal PostWashTolerance { get; set; }
        /// <summary>
        /// Gets or sets PreWashTolerance
        /// </summary>
        public decimal PreWashTolerance { get; set; }
        /// <summary>
        /// Gets or sets ScanAllIdenifiedItemsMarksAsPacked
        /// </summary>
        public bool ScanAllIdenifiedItemsMarksAsPacked { get; set; }
        /// <summary>
        /// Gets or sets FacilityAuditRules
        /// </summary>
        public List<AuditRuleContract> FacilityAuditRules { get; set; }
        /// <summary>
        /// Gets or sets IsFda
        /// </summary>
        public bool IsFda { get; set; }
        /// <summary>
        /// Gets or sets IsWashRelease
        /// </summary>
        public bool IsWashRelease { get; set; }
        /// <summary>
        /// Gets or sets ProcessingMode
        /// </summary>
        public ProcessingModeIdentifier ProcessingMode { get; set; }
        /// <summary>
        /// Gets or sets IsPerformancePauseEnabled
        /// </summary>
        public bool IsPerformancePauseEnabled { get; set; }
        /// <summary>
        /// Gets or sets IsClockingEnabled
        /// </summary>
        public bool IsClockingEnabled { get; set; }
        /// <summary>
        /// Gets or sets OverrideCooldownContainer
        /// </summary>
        public bool OverrideCooldownContainer { get; set; }
    }
}
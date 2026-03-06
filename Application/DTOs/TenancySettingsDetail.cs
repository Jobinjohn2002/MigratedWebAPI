using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TenancySettingsDetail
    /// </summary>
    public class TenancySettingsDetail
    {
        /// <summary>
        /// Gets or sets TenancyId
        /// </summary>
        public int TenancyId { get; set; }
        /// <summary>
        /// Gets or sets Tenancy
        /// </summary>
        public string Tenancy { get; set; }
        /// <summary>
        /// Gets or sets Settings
        /// </summary>
        public TableModel Settings { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public SettingsConfirmation Confirmation { get; set; }
    }
}
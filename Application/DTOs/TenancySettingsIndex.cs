using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TenancySettingsIndex
    /// </summary>
    public class TenancySettingsIndex
    {
        /// <summary>
        /// Gets or sets Switched
        /// </summary>
        public bool Switched { get; set; }
        /// <summary>
        /// Gets or sets Tenancies
        /// </summary>
        public List<TenancySettingInfo> Tenancies { get; set; }
    }
}
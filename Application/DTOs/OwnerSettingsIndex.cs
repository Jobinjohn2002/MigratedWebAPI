using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OwnerSettingsIndex
    /// </summary>
    public class OwnerSettingsIndex
    {
        /// <summary>
        /// Gets or sets Owners
        /// </summary>
        public List<OwnerSettingInfo> Owners { get; set; }
    }
}
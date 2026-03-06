using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SettingsRequestDataContract
    /// </summary>
    public class SettingsRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets Settings
        /// </summary>
        public List<SettingKeyValueDataContract> Settings { get; set; }
    }
}
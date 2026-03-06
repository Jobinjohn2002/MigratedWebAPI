using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SettingsResponseDataContract
    /// </summary>
    public class SettingsResponseDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Settings
        /// </summary>
        public List<SettingDataContract> Settings { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DeliveryPointSettingsIndex
    /// </summary>
    public class DeliveryPointSettingsIndex
    {
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public List<DeliveryPointSettingInfo> DeliveryPoints { get; set; }
    }
}
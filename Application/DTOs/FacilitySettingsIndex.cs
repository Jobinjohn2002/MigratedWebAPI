using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilitySettingsIndex
    /// </summary>
    public class FacilitySettingsIndex
    {
        /// <summary>
        /// Gets or sets Facilities
        /// </summary>
        public List<FacilitySettingInfo> Facilities { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacSetting
    /// </summary>
    public class FacSetting : Setting
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
    }
}
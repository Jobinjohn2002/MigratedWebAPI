using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TenSetting
    /// </summary>
    public class TenSetting : Setting
    {
        /// <summary>
        /// Gets or sets TenancyId
        /// </summary>
        public int TenancyId { get; set; }
    }
}
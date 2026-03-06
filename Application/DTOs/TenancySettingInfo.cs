using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TenancySettingInfo
    /// </summary>
    public class TenancySettingInfo
    {
        /// <summary>
        /// Gets or sets TenancyId
        /// </summary>
        public int TenancyId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
    }
}
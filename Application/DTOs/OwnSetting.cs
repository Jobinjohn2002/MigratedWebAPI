using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OwnSetting
    /// </summary>
    public class OwnSetting : Setting
    {
        /// <summary>
        /// Gets or sets OwnerId
        /// </summary>
        public int OwnerId { get; set; }
    }
}
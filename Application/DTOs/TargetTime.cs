using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TargetTime
    /// </summary>
    public class TargetTime
    {
        /// <summary>
        /// Gets or sets TargetTimeinSeconds
        /// </summary>
        public int TargetTimeinSeconds { get; set; }
        /// <summary>
        /// Gets or sets TargetTimeIncreaseinSeconds
        /// </summary>
        public decimal TargetTimeIncreaseinSeconds { get; set; }
    }
}

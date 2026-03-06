using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserPerformanceData
    /// </summary>
    public class UserPerformanceData
    {
        public decimal? PercentageIPOHVariance { get; set; }
        /// <summary>
        /// Gets or sets IsDefault
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
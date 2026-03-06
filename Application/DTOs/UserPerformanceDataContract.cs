using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserPerformanceDataContract
    /// </summary>
    public class UserPerformanceDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public int StationType { get; set; }
    }
}

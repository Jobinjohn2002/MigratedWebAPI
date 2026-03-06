using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemUsageData
    /// </summary>
    public class ItemUsageData
    {
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets ContainerCount
        /// </summary>
        public int ContainerCount { get; set; }
    }
}

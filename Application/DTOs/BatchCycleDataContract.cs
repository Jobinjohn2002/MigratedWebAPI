using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchCycleDataContract
    /// </summary>
    public class BatchCycleDataContract
    {
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets CycleTypeId
        /// </summary>
        public int CycleTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsChargeable
        /// </summary>
        public bool IsChargeable { get; set; }
        /// <summary>
        /// Gets or sets IsBiologicalIndicatorEnabled
        /// </summary>
        public bool IsBiologicalIndicatorEnabled { get; set; }
        /// <summary>
        /// Gets or sets BatchName
        /// </summary>
        public string BatchName { get; set; }
    }
}
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchCyclesDataContract
    /// </summary>
    public class BatchCyclesDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets BatchCycles
        /// </summary>
        public List<BatchCycleDataContract> BatchCycles { get; set; }
        /// <summary>
        /// Gets or sets IsBiologicalIndicatorEnabled
        /// </summary>
        public bool IsBiologicalIndicatorEnabled { get; set; }
    }
}
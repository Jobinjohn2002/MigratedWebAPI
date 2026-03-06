using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// BatchCycleExtendedError
    /// </summary>
    public class BatchCycleExtendedError : ExtendedError
    {
        /// <summary>
        /// Gets or sets IsBatchTag
        /// </summary>
        public bool IsBatchTag { get; set; }
        /// <summary>
        /// Gets or sets UsedBatchCycleTypes
        /// </summary>
        public Dictionary<string, int> UsedBatchCycleTypes { get; set; }
        /// <summary>
        /// Gets or sets IncompatibleTurnarounds
        /// </summary>
        public List<IncompatibleTurnaroundInfo> IncompatibleTurnarounds { get; set; }
    }

    [Serializable]
    /// <summary>
    /// IncompatibleTurnaroundInfo
    /// </summary>
    public class IncompatibleTurnaroundInfo
    {
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public long ExternalId { get; set; }
        /// <summary>
        /// Gets or sets BatchCycleNames
        /// </summary>
        public List<string> BatchCycleNames { get; set; }
    }
}

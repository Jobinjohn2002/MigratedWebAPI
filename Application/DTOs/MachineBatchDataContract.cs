using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MachineBatchDataContract
    /// </summary>
    public class MachineBatchDataContract
    {
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// Gets or sets BatchName
        /// </summary>
        public string BatchName { get; set; }
        public int? CycleTypeId { get; set; }
        /// <summary>
        /// Gets or sets CycleTypeName
        /// </summary>
        public string CycleTypeName { get; set; }
        /// <summary>
        /// Gets or sets RunningTime
        /// </summary>
        public string RunningTime { get; set; }
        /// <summary>
        /// Gets or sets IsStarted
        /// </summary>
        public bool IsStarted { get; set; }
        /// <summary>
        /// Gets or sets IsTestBatch
        /// </summary>
        public bool IsTestBatch { get; set; }
        public int? BatchStatusId { get; set; }
        /// <summary>
        /// Gets or sets HasBiologicalIndicator
        /// </summary>
        public bool HasBiologicalIndicator { get; set; }
        public bool? HasBiologicalIndicatorPassed { get; set; }
        /// <summary>
        /// Gets or sets NumberOfTurnarounds
        /// </summary>
        public int NumberOfTurnarounds { get; set; }
    }
}
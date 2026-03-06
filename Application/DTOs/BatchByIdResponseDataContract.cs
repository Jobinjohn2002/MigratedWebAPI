using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchByIdResponseDataContract
    /// </summary>
    public class BatchByIdResponseDataContract : BaseReplyDataContract
    {
        public int? BatchId;
        public string ExternalId;
        public int RunningTime;
        public DateTime? Started;
        public int CycleId;
        public string CycleName;
        public int MachineId;
        /// <summary>
        /// Gets or sets IsTestBatch
        /// </summary>
        public bool IsTestBatch { get; set; }
        /// <summary>
        /// Gets or sets DoesBiExist
        /// </summary>
        public bool DoesBiExist { get; set; }
        public bool? HasBiPassed { get; set; }
        /// <summary>
        /// Gets or sets IsBiRequiredForTurnaround
        /// </summary>
        public bool IsBiRequiredForTurnaround { get; set; }
        public int? BatchStatusId;
        /// <summary>
        /// Gets or sets BiStatus
        /// </summary>
        public BiologicalIndicatorTestStatusIdentifier BiStatus { get; set; }
        public DateTime? BiEndDate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed class MachineBatchData 
    {
        /// <summary>
        /// Gets or sets RunningTime
        /// </summary>
        public short RunningTime { get; set; }
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        public int? BatchCycleId { get; set; }
        public byte? BatchFailureReasonId { get; set; }
        public int? BatchStatusId { get; set; }
        public int? BatchReleasedUserId { get; set; }
        public int? ArchivedUserId { get; set; }
        public byte? BatchArchiveReasonId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        public int? FailedUserId { get; set; }
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        public DateTime? Started { get; set; }
        public DateTime? Failed { get; set; }
        public DateTime? Archived { get; set; }
        /// <summary>
        /// Gets or sets CycleTypeText
        /// </summary>
        public string CycleTypeText { get; set; }
        /// <summary>
        /// Gets or sets IsBiologicalIndicatorExist
        /// </summary>
        public bool IsBiologicalIndicatorExist { get; set; }
        public bool? IsBiologicalIndicatorPassed { get; set; }
        /// <summary>
        /// Gets or sets IsBiologicalIndicatorRequiredForTurnaround
        /// </summary>
        public bool IsBiologicalIndicatorRequiredForTurnaround { get; set; }
        public int? NextEventTypeId { get; set; } 
        /// <summary>
        /// Gets or sets NextEventName
        /// </summary>
        public string NextEventName { get; set; }
        public DateTime? DateChecked { get; set; }
    }
}

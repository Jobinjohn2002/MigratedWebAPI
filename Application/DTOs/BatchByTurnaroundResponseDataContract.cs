using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchByTurnaroundResponseDataContract
    /// </summary>
    public class BatchByTurnaroundResponseDataContract : BaseReplyDataContract
    {
        public int? BatchId;
        public string ExternalId;
        public int RunningTime;
        public DateTime? Started;
        public int CycleId;
        public string CycleName;
        public int MachineId;
        public int? TurnaroundId { get; set; }
        public int? TurnaroundLastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundInstanceName
        /// </summary>
        public string TurnaroundInstanceName { get; set; }
        public int? BatchStatusId;
        /// <summary>
        /// Gets or sets ItemHasBeenScannedOffBatch
        /// </summary>
        public bool ItemHasBeenScannedOffBatch { get; set; }
        public int? NextEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets NextEventName
        /// </summary>
        public string NextEventName { get; set; }
        public int? LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets LastEventName
        /// </summary>
        public string LastEventName { get; set; }
        public int? LastProcessEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets LastProcessEventName
        /// </summary>
        public string LastProcessEventName { get; set; }
        /// <summary>
        /// Gets or sets LastProcessEventDateTime
        /// </summary>
        public DateTime LastProcessEventDateTime { get; set; }
        /// <summary>
        /// Gets or sets CanItemBeScannedOffBatch
        /// </summary>
        public bool CanItemBeScannedOffBatch { get; set; }
        /// <summary>
        /// Gets or sets IsEndEvent
        /// </summary>
        public bool IsEndEvent { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundProcessCycleTypes
        /// </summary>
        public List<TurnaroundProcessingCycleTypesDataContract> TurnaroundProcessCycleTypes { get; set; }
        /// <summary>
        /// Gets or sets HasParentTurnaround
        /// </summary>
        public bool HasParentTurnaround { get; set; }
        /// <summary>
        /// Gets or sets StationLocationId
        /// </summary>
        public int StationLocationId { get; set; }
        public int? LastProcessEventStationTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsTestBatch
        /// </summary>
        public bool IsTestBatch { get; set; }
        /// <summary>
        /// Gets or sets IsStockLocation
        /// </summary>
        public bool IsStockLocation { get; set; }

        #region BI
        /// <summary>
        /// Gets or sets IsBiRequiredForTurnaround
        /// </summary>
        public bool IsBiRequiredForTurnaround { get; set; }
        /// <summary>
        /// Gets or sets DoesBiExist
        /// </summary>
        public bool DoesBiExist { get; set; }
        public bool? HasBiPassed { get; set; }
        /// <summary>
        /// Gets or sets BiStatus
        /// </summary>
        public BiologicalIndicatorTestStatusIdentifier BiStatus { get; set; }
        public DateTime? BiEndDate { get; set; }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AerDataContract
    /// </summary>
    public class AerDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets BatchPrefix
        /// </summary>
        public string BatchPrefix { get; set; }
        public int? BatchId { get; set; }
        /// <summary>
        /// Gets or sets CycleNumber
        /// </summary>
        public string CycleNumber { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets RunningTime
        /// </summary>
        public short RunningTime { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public AerStatus Status { get; set; }
        public DateTime? Started { get; set; }
        /// <summary>
        /// Gets or sets Shelves
        /// </summary>
        public List<AerShelfLocationDataContract> Shelves { get; set; }
        /// <summary>
        /// Gets or sets FailureTypes
        /// </summary>
        public List<DataValueDataContract> FailureTypes { get; set; }
        /// <summary>
        /// Gets or sets ReadOnly
        /// </summary>
        public bool ReadOnly { get; set; }
        /// <summary>
        /// Gets or sets DisinfectionCycleOverdue
        /// </summary>
        public bool DisinfectionCycleOverdue { get; set; }
    }
}

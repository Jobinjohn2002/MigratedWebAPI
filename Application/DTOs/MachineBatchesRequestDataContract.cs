using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MachineBatchesRequestDataContract
    /// </summary>
    public class MachineBatchesRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        public DateTime? StartDate { get; set; }
        public int? CycleTypeId { get; set; }
        /// <summary>
        /// Gets or sets TestBatchesOnly
        /// </summary>
        public bool TestBatchesOnly { get; set; }
        /// <summary>
        /// Gets or sets NoTestBatches
        /// </summary>
        public bool NoTestBatches { get; set; }
        /// <summary>
        /// Gets or sets UseBatchStartDate
        /// </summary>
        public bool UseBatchStartDate { get; set; }
    }
}
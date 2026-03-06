using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CreateBatchRequestDataContract
    /// </summary>
    public class CreateBatchRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        public int? BatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets BatchName
        /// </summary>
        public string BatchName { get; set; }
        /// <summary>
        /// Gets or sets IsStartBatch
        /// </summary>
        public bool IsStartBatch { get; set; }
        public int? PinReason;
        /// <summary>
        /// Gets or sets BiLotNumber
        /// </summary>
        public string BiLotNumber { get; set; }
        public DateTime? CreateBatchTime { get; set; }
        public DateTime? StartBatchDate { get; set; }
        /// <summary>
        /// Gets or sets BatchMuchNotExist
        /// </summary>
        public bool BatchMuchNotExist { get; set; }
        /// <summary>
        /// Gets or sets AllowSameBatch
        /// </summary>
        public bool AllowSameBatch { get; set; }
    }
}
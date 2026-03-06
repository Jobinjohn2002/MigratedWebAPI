using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LastBatchRequestDataContract
    /// </summary>
    public class LastBatchRequestDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        public int? BatchId { get; set; }
        /// <summary>
        /// Gets or sets LastMachineBatchDate
        /// </summary>
        public DateTime LastMachineBatchDate { get; set; }
    }
}
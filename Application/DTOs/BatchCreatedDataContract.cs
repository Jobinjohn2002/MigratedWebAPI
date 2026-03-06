using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchCreatedDataContract
    /// </summary>
    public class BatchCreatedDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets BatchCycleId
        /// </summary>
        public int BatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets CycleName
        /// </summary>
        public string CycleName { get; set; }
    }
}
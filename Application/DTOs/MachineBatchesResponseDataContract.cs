using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MachineBatchesResponseDataContract
    /// </summary>
    public class MachineBatchesResponseDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets Batches
        /// </summary>
        public List<MachineBatchDataContract> Batches { get; set; }
    }
}
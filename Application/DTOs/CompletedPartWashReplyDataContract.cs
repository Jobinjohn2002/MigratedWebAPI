using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// CompletedPartWashReplyDataContract
    /// </summary>
    public class CompletedPartWashReplyDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public int MachineTypeId { get; set; }
        /// <summary>
        /// Gets or sets MachineTypeName
        /// </summary>
        public string MachineTypeName { get; set; }
        public int? MachineId { get; set; }
        /// <summary>
        /// Gets or sets MachineName
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// Gets or sets DateOfBatch
        /// </summary>
        public DateTime DateOfBatch { get; set; }
        /// <summary>
        /// Gets or sets UserFullname
        /// </summary>
        public string UserFullname { get; set; }
        /// <summary>
        /// Gets or sets PartWashCheck
        /// </summary>
        public bool PartWashCheck { get; set; }
        public int? DeconTaskId { get; set; }
        public int? BatchId { get; set; }
    }
}
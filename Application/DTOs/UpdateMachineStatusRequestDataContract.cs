using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UpdateMachineStatusRequestDataContract
    /// </summary>
    public class UpdateMachineStatusRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        public int? MachineEventReasonId { get; set; }
        /// <summary>
        /// Gets or sets IsAvailable
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
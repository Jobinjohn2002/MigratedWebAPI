using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MachineStatusDataContract
    /// </summary>
    public class MachineStatusDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        public int? MachineEventTypeId { get; set; }
        public int? MachineEventReasonId { get; set; }
    }
}
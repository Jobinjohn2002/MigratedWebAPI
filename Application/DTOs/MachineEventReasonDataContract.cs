using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MachineEventReasonDataContract
    /// </summary>
    public class MachineEventReasonDataContract
    {
        /// <summary>
        /// Gets or sets ReasonId
        /// </summary>
        public int ReasonId { get; set; }
        /// <summary>
        /// Gets or sets MachineType
        /// </summary>
        public int MachineType { get; set; }
        /// <summary>
        /// Gets or sets Reason
        /// </summary>
        public string Reason { get; set; }
    }
}
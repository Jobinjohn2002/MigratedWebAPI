using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AerDetergentDetails
    /// </summary>
    public class AerDetergentDetails : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets MachineGroupName
        /// </summary>
        public string MachineGroupName { get; set; }
        /// <summary>
        /// Gets or sets DetergentDetails
        /// </summary>
        public List<MachineDetergentDataContract> DetergentDetails { get; set; } = new List<MachineDetergentDataContract>();
    }
}
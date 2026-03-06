using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StatusDataContract
    /// </summary>
    public class StatusDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Command
        /// </summary>
        public int Command { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// Gets or sets CurrentVersionNumber
        /// </summary>
        public string CurrentVersionNumber { get; set; }
        /// <summary>
        /// Gets or sets ForceUpdate
        /// </summary>
        public bool ForceUpdate { get; set; }
        /// <summary>
        /// Gets or sets MachinesStatus
        /// </summary>
        public List<MachineStatusDataContract> MachinesStatus { get; set; }
        /// <summary>
        /// Gets or sets PrimaryFacilityIds
        /// </summary>
        public List<short> PrimaryFacilityIds { get; set; }
    }
}
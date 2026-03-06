using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ChangeCycleNumberRequestDataContract
    /// </summary>
    public class ChangeCycleNumberRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets NewCycleNumber
        /// </summary>
        public string NewCycleNumber { get; set; }
        /// <summary>
        /// Gets or sets BatchIsStarted
        /// </summary>
        public bool BatchIsStarted { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
    }
}

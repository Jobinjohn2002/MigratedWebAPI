using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Describes a machine, e.g. its name and its serial number.
    /// </summary>
    /// <summary>
    /// MachineInfo
    /// </summary>
    public class MachineInfo
    {
        /// <summary>
        /// The machines name
        /// </summary>
        /// <summary>
        /// Gets or sets MachineName
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// The machines name
        /// </summary>
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }

        /// <summary>
        /// The machines serial number
        /// </summary>
        /// <summary>
        /// Gets or sets SerialNumber
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// The filename of the last file processed, stored so that we don't download duplicates
        /// </summary>
        /// <summary>
        /// Gets or sets LastFileProcessed
        /// </summary>
        public string LastFileProcessed { get; set; }
    }
}

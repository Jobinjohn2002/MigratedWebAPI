using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HistoryDataContract
    /// </summary>
    public class HistoryDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets Logs
        /// </summary>
        public List<LogDataContract> Logs { get; set; }
        /// <summary>
        /// Gets or sets MachineIds
        /// </summary>
        public List<int> MachineIds { get; set; }
        /// <summary>
        /// Gets or sets StationType
        /// </summary>
        public StationTypeIdentifier StationType { get; set; }
    }
}
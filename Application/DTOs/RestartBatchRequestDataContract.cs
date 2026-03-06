using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// RestartBatchRequestDataContract
    /// </summary>
    public class RestartBatchRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets BatchName
        /// </summary>
        public string BatchName { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets RestartImmediately
        /// </summary>
        public bool RestartImmediately { get; set; }
        
    }
}

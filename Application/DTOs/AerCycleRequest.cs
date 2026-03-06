using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AerCycleRequest
    /// </summary>
    public class AerCycleRequest : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets BatchExternalId
        /// </summary>
        public string BatchExternalId { get; set; }
        /// <summary>
        /// Gets or sets Failed
        /// </summary>
        public bool Failed { get; set; }
        /// <summary>
        /// Gets or sets FailText
        /// </summary>
        public string FailText { get; set; }
        /// <summary>
        /// Gets or sets CycleType
        /// </summary>
        public BatchCycleTypeIdentifier CycleType { get; set; }

    }
}

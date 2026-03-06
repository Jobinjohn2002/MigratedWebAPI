using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityBatchRequestDataContract
    /// </summary>
    public class FacilityBatchRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets IsFailedCycles
        /// </summary>
        public bool IsFailedCycles { get; set; }
        /// <summary>
        /// Gets or sets IsOutOfAutoclave
        /// </summary>
        public bool IsOutOfAutoclave { get; set; }
        public DateTime? Start { get; set; }

    }
}
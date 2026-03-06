using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FailedScansDataContract
    /// </summary>
    public class FailedScansDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets FailedScans
        /// </summary>
        public List<FailedScanDataContract> FailedScans { get; set; }
    }
}

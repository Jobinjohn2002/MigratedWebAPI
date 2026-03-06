using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopyDeconTaskRequest
    /// </summary>
    public class EndoscopyDeconTaskRequest : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets EndoscopyDeconTaskResults
        /// </summary>
        public List<EndoscopyDeconTaskResult> EndoscopyDeconTaskResults { get; set; }
        /// <summary>
        /// Gets or sets ClientUTCDateTime
        /// </summary>
        public DateTime ClientUTCDateTime { get; set; }
        public int? StationLocationId { get; set; }
        public int? PinReasonId { get; set; }
    }
}
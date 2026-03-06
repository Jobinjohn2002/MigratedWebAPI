using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundEventComplete
    /// </summary>
    public class TurnaroundEventComplete
    {
        /// <summary>
        /// Gets or sets DataContract
        /// </summary>
        public ScanAssetDataContract DataContract { get; set; }

        /// <summary>
        /// Gets or sets Events
        /// </summary>
        public List<TurnaroundEventDetail> Events { get; set; }

        public int? LastProcessEventId { get; set; }

        public TurnAroundEventTypeIdentifier? LastProcessEventTypeId { get; set; }

        public int? LocationId { get; set; }
    }
}
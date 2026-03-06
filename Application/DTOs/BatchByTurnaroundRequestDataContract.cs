using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BatchByTurnaroundRequestDataContract
    /// </summary>
    public class BatchByTurnaroundRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        public int? TurnaroundEventTypeId { get; set; }
        public int? BatchEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets FailPassItem
        /// </summary>
        public bool FailPassItem { get; set; }
        public int? TurnaroundEventTypeIdForStation { get; set; }
        /// <summary>
        /// Gets or sets FailBatch
        /// </summary>
        public bool FailBatch { get; set; }
        /// <summary>
        /// Gets or sets ReassignBatch
        /// </summary>
        public bool ReassignBatch { get; set; }
        /// <summary>
        /// Gets or sets StationLocationId
        /// </summary>
        public int StationLocationId { get; set; }
        public int? StationTypeIdentifier { get; set; }
    }
}
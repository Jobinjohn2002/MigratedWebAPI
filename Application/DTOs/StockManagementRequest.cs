using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StockManagementRequest
    /// </summary>
    public class StockManagementRequest : BaseRequestDataContract
    {
        public int? LocationId { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public short EventType { get; set; }
        /// <summary>
        /// Gets or sets Scans
        /// </summary>
        public List<long> Scans { get; set; }
        /// <summary>
        /// Gets or sets FailedScannedIds
        /// </summary>
        public List<FailedScanDataContract> FailedScannedIds { get; set; }
        /// <summary>
        /// Gets or sets TrolliesScanned
        /// </summary>
        public List<int> TrolliesScanned { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets CheckNotes
        /// </summary>
        public bool CheckNotes { get; set; }
    }
}
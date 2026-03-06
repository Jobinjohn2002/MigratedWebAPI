using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ServiceReportRequest
    /// </summary>
    public class ServiceReportRequest
    {
        /// <summary>
        /// Gets or sets IncidentDate
        /// </summary>
        public DateTime IncidentDate { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets ReportedBy
        /// </summary>
        public string ReportedBy { get; set; }
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets Classification
        /// </summary>
        public string Classification { get; set; }
        /// <summary>
        /// Gets or sets Severity
        /// </summary>
        public int Severity { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        [MaxLength(4000)]
        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public string Details { get; set; }
    }
}

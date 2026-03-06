using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// AuditDataContract
    /// </summary>
    public class AuditDataContract
    {
        /// <summary>
        /// Gets or sets AuditId
        /// </summary>
        public int AuditId { get; set; }
        public short? AuditResultTypeId { get; set; }
        /// <summary>
        /// Gets or sets AuditLocationCategoryId
        /// </summary>
        public byte AuditLocationCategoryId { get; set; }
        /// <summary>
        /// Gets or sets AuditLines
        /// </summary>
        public List<AuditLineDataContract> AuditLines { get; set; }
        /// <summary>
        /// Gets or sets PrintAuditReport
        /// </summary>
        public bool PrintAuditReport { get; set; }
        /// <summary>
        /// Gets or sets AdditionalScans
        /// </summary>
        public List<string> AdditionalScans { get; set; }
        /// <summary>
        /// Gets or sets ProcessFaults
        /// </summary>
        public List<AuditProcessFaultContract> ProcessFaults { get; set; }
    }
}

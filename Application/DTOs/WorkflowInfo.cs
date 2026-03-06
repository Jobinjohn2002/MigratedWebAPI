using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// WorkflowInfo
    /// </summary>
    public class WorkflowInfo
    {
        bool IsEnd { get; set; }
        /// <summary>
        /// Gets or sets IsBestPractive
        /// </summary>
        public bool IsBestPractive { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets RequiresProof
        /// </summary>
        public bool RequiresProof { get; set; }
        /// <summary>
        /// Gets or sets ReleaseRequired
        /// </summary>
        public bool ReleaseRequired { get; set; }
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public short EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// Gets or sets WorkflowId
        /// </summary>
        public int WorkflowId { get; set; }
        /// <summary>
        /// Gets or sets IsStockLocation
        /// </summary>
        public bool IsStockLocation { get; set; }
    }
}

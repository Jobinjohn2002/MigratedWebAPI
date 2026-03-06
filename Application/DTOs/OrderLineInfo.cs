using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Order Line Info.
    /// </summary>
    /// <summary>
    /// OrderLineInfo
    /// </summary>
    public class OrderLineInfo
    {
        /// <summary>
        /// The unique identifier for this resource.
        /// </summary>
        /// <summary>
        /// Gets or sets ProductNumber
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// The product name.
        /// </summary>
        /// <summary>
        /// Gets or sets ProductName
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// The order line status.
        /// </summary>
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// The turnaround serial number (if picked) for the order line.
        /// </summary>
        public long? Turnaround { get; set; }
        /// <summary>
        /// Indicates if the order line is required
        /// </summary>
        /// <summary>
        /// Gets or sets Required
        /// </summary>
        public bool Required { get; set; }
    }
}
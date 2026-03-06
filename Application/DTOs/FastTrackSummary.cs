using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FastTrackSummary
    /// </summary>
    public class FastTrackSummary
    {
        /// <summary>
        /// Gets or sets FastTrackId
        /// </summary>
        public int FastTrackId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternal
        /// </summary>
        public string TurnaroundExternal { get; set; }
    }
}

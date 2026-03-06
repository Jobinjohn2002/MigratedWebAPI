using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundSummary
    /// </summary>
    public class TurnaroundSummary
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        public long? ExternalId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public string Facility { get; set; }
        public int? DeliveryNote { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternal
        /// </summary>
        public string ContainerMasterExternal { get; set; }
    }
}

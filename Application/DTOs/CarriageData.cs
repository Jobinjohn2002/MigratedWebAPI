using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CarriageData
    /// </summary>
    public class CarriageData
    {
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
    }
}

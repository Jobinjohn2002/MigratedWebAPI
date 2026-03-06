using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ServiceRequirementRequest
    /// </summary>
    public class ServiceRequirementRequest : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets ContainerInfo
        /// </summary>
        public ContainerMasterInfo ContainerInfo { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
    }
}
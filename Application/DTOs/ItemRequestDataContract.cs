using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemRequestDataContract
    /// </summary>
    public class ItemRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public int ItemType { get; set; }
    }
}
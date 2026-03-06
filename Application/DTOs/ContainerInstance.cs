using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerInstanceInfo
    /// </summary>
    public class ContainerInstanceInfo
    {
        /// <summary>
        /// The externalId of the ConatinerMaster of the user that applied this event.
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        /// <summary>
        /// The PrimaryId of the Container instance.
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// The externalId of the ConatinerMaster of the user that applied this event.
        /// </summary>
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
    }
}

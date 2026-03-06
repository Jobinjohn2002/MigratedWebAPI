using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerMasterinfo
    /// </summary>
    public class ContainerMasterinfo
    {
        /// <summary>
        /// The externalId of the ConatinerMaster of the user that applied this event.
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }

        /// <summary>
        /// The name of the ConatinerMaster of the user that applied this event.
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The externalId of the ConatinerMaster of the user that applied this event.
        /// </summary>
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// The externalId of the ConatinerMaster of the user that applied this event.
        /// </summary>
        /// <summary>
        /// Gets or sets SubItemType
        /// </summary>
        public string SubItemType { get; set; }
    }
}

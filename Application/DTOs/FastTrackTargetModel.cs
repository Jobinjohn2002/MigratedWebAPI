using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FastTrackTargetModel
    /// </summary>
    public class FastTrackTargetModel
    {
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }

        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }

        /// <summary>
        /// Gets or sets ContainerInstanceValue
        /// </summary>
        public string ContainerInstanceValue { get; set; }

        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
    }
}
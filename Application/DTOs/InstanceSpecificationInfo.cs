using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerInstance Specification Info.
    /// </summary>
    /// <summary>
    /// InstanceSpecificationInfo
    /// </summary>
    public class InstanceSpecificationInfo
    {
        /// <summary>
        /// The unique Id of the ContainerInstance
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        /// <summary>
        /// The ContainerInstance ExternalId
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerInstanceExternalId
        /// </summary>
        public string ContainerInstanceExternalId { get; set; }
        
        /// <summary>
        /// The ContainerMasterDefinitionId of the container instance
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        
        /// <summary>
        /// The Location this Container instance is to be delivered to
        /// </summary>
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

        /// <summary>
        /// The processing service requirement used for this container instance.
        /// </summary>
        /// <summary>
        /// Gets or sets ServiceRequirementDefinitionId
        /// </summary>
        public int ServiceRequirementDefinitionId { get; set; }
        
        /// <summary>
        /// The facility this container instance belongs to
        /// </summary>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }

    }
}

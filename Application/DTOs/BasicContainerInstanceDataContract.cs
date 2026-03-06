//using SynergyApplicationFrameworkApi.Application.DTOs.ContainerInstanceIdentifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{

    [Serializable]
    /// <summary>
    /// BasicContainerInstanceDataContract
    /// </summary>
    public class BasicContainerInstanceDataContract
    {
        public int? ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifiers
        /// </summary>
        public List<ContainerInstanceIdentifierDataContract> ContainerInstanceIdentifiers { get; set; }
    }
}

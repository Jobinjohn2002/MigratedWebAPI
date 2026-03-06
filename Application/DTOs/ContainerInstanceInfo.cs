using SynergyApplicationFrameworkApi.Application.DTOs.ContainerInstanceIdentifiers;
using System.Collections.Generic;
using System;
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
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets PrimaryId
        /// </summary>
        public string PrimaryId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifiers
        /// </summary>
        public List<ContainerInstanceIdentifierDataContract> ContainerInstanceIdentifiers { get; set; }
    }
}
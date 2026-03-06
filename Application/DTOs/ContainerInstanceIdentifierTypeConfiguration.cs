using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerInstanceIdentifierTypeConfiguration
    /// </summary>
    public class ContainerInstanceIdentifierTypeConfiguration
    {
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifierTypes
        /// </summary>
        public List<ContainerInstanceIdentifierType> ContainerInstanceIdentifierTypes { get; set; } = new List<ContainerInstanceIdentifierType>();
        /// <summary>
        /// Gets or sets NewIdentifierType
        /// </summary>
        public ContainerInstanceIdentifierType NewIdentifierType { get; set; } = new ContainerInstanceIdentifierType();
    }
}
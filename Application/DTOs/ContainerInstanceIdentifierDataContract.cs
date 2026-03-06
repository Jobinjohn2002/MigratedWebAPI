using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerInstanceIdentifierDataContract
    /// </summary>
    public class ContainerInstanceIdentifierDataContract
    {
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifierId
        /// </summary>
        public int ContainerInstanceIdentifierId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifierType
        /// </summary>
        public ContainerInstanceIdentifierTypeDataContract ContainerInstanceIdentifierType { get; set; }
        /// <summary>
        /// Gets or sets IsPrimary
        /// </summary>
        public bool IsPrimary { get; set; }
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerInstanceIdTypeInfoDataContract
    /// </summary>
    public class ContainerInstanceIdTypeInfoDataContract
    {
        /// <summary>
        /// Gets or sets InstanceCount
        /// </summary>
        public int InstanceCount { get; set; }
        /// <summary>
        /// Gets or sets TypeId
        /// </summary>
        public int TypeId { get; set; }
        /// <summary>
        /// Gets or sets TypeName
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Gets or sets IsUnique
        /// </summary>
        public bool IsUnique { get; set; }
    }
}

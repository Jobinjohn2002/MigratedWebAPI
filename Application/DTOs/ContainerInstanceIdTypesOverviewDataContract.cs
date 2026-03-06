using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerInstanceIdTypesOverviewDataContract
    /// </summary>
    public class ContainerInstanceIdTypesOverviewDataContract
    {
        /// <summary>
        /// Gets or sets TypeInfo
        /// </summary>
        public List<ContainerInstanceIdTypeInfoDataContract> TypeInfo { get; set; }
        /// <summary>
        /// Gets or sets TotalInstances
        /// </summary>
        public int TotalInstances { get; set; }
    }
}

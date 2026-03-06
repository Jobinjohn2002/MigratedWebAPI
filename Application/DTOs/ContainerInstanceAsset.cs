using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ContainerInstanceAsset
    /// </summary>
    public class ContainerInstanceAsset
    {
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstance ContainerInstance { get; set; }
        /// <summary>
        /// Gets or sets Product
        /// </summary>
        public InventoryCaseProduct Product { get; set; }
    }
}

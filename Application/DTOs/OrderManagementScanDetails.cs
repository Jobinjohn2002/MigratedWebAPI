using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OrderManagementScanDetails
    /// </summary>
    public class OrderManagementScanDetails : ScanDetails
    {
        /// <summary>
        /// Gets or sets CopyUncompleteLinesToNewOrder
        /// </summary>
        public bool CopyUncompleteLinesToNewOrder { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Order Template Line Info.
    /// </summary>
    /// <summary>
    /// OrderTemplateLineInfo
    /// </summary>
    public class OrderTemplateLineInfo
    {
        /// <summary>
        /// The product name.
        /// </summary>
        /// <summary>
        /// Gets or sets ProductName
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// The product number.
        /// </summary>
        /// <summary>
        /// Gets or sets ProductNumber
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// The quantity required.
        /// </summary>
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}
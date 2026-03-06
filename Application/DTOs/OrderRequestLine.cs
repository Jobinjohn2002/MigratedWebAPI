using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Order Request Line
    /// </summary>
    /// <summary>
    /// OrderRequestLine
    /// </summary>
    public class OrderRequestLine
    {
        /// <summary>
        /// The product number.
        /// </summary>
        [Required]
        [MaxLength(11)]
        [MinLength(11)]
        /// <summary>
        /// Gets or sets ProductNumber
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// The quantity required.
        /// </summary>
        [Required]
        [Range(0, int.MaxValue)]
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}
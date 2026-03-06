using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HISOrderRequestLine
    /// </summary>
    public class HISOrderRequestLine
    {
        public const int MAX_CODE_LENGTH = 50;
        public const int MAX_NAME_LENGTH = 100;
        public const int MAX_QUANTITY = 10000;

        /// <summary>
        /// The product number.
        /// </summary>
        [Required]
        [MaxLength(MAX_CODE_LENGTH)]
        /// <summary>
        /// Gets or sets Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The product name.
        /// </summary>
        [Required]
        [MaxLength(MAX_NAME_LENGTH)]
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The quantity required.
        /// </summary>
        [Required]
        [Range(1, MAX_QUANTITY)]
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}

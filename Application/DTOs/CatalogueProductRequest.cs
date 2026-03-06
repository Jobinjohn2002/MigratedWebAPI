using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueProductRequest
    /// </summary>
    public class CatalogueProductRequest
    {
        [Required]
        /// <summary>
        /// Gets or sets VendorId
        /// </summary>
        public int VendorId { get; set; }
        [Required]
        [MaxLength(100)]
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        [MaxLength(30)]
        /// <summary>
        /// Gets or sets CompanyProductCode
        /// </summary>
        public string CompanyProductCode { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueLoansetVendorRep
    /// </summary>
    public class CatalogueLoansetVendorRep
    {
        /// <summary>
        /// Gets or sets RepId
        /// </summary>
        public int RepId { get; set; }
        /// <summary>
        /// Gets or sets RepName
        /// </summary>
        public string RepName { get; set; }
        [Required]
        /// <summary>
        /// Gets or sets VendorCompanyId
        /// </summary>
        public int VendorCompanyId { get; set; }
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets VendorCompanyName
        /// </summary>
        public string VendorCompanyName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueLoansetRequest
    /// </summary>
    public class CatalogueLoansetRequest
    {
        [Required]
        /// <summary>
        /// Gets or sets Case
        /// </summary>
        public CatalogueLoansetCase Case { get; set; }
        [Required]
        /// <summary>
        /// Gets or sets VendorRep
        /// </summary>
        public CatalogueLoansetVendorRep VendorRep { get; set; }
        /// <summary>
        /// Gets or sets Loaners
        /// </summary>
        public List<CatalogueLoansetProduct> Loaners { get; set; }
    }
}


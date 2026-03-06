using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueLoansetPhysician
    /// </summary>
    public class CatalogueLoansetPhysician
    {
        [Required]
        [MaxLength(44)]
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }
        [MaxLength(42)]
        /// <summary>
        /// Gets or sets MiddleName
        /// </summary>
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(42)]
        /// <summary>
        /// Gets or sets LastName
        /// </summary>
        public string LastName { get; set; }
    }
}
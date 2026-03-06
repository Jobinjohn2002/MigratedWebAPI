using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Represents information about a surgeon who performs a surgical procedure
    /// </summary>
    /// <summary>
    /// SurgicalProcedureSurgeon
    /// </summary>
    public class SurgicalProcedureSurgeon
    {
        /// <summary>
        /// A unique reference to identify the surgeon who performed the surgical procedure
        /// </summary>
        [Required]
        [MaxLength(64)]
        [Display(Name = "Surgeon Reference")]
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// The name of the surgeon who performed the surgical procedure
        /// </summary>
        [Required]
        [MaxLength(64)]
        [Display(Name = "Surgeon Name")]
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
    }
}
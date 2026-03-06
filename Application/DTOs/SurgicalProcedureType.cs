using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Represents information about a type of surgical procedure
    /// </summary>
    /// <summary>
    /// SurgicalProcedureType
    /// </summary>
    public class SurgicalProcedureType
    {
        /// <summary>
        /// A unique reference to identify the type of surgical procedure
        /// </summary>
        [Required]
        [MaxLength(64)]
        [Display(Name = "Surgical Procedure Reference")]
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// The name of the type of surgical procedure
        /// </summary>
        [Required]
        [MaxLength(128)]
        [Display(Name="Surgical Procedure Name")]
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
    }
}
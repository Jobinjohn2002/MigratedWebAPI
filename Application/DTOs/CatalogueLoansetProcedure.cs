using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CatalogueLoansetProcedure
    /// </summary>
    public class CatalogueLoansetProcedure
    {
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets Notes
        /// </summary>
        public string Notes { get; set; }
        [Required]
        /// <summary>
        /// Gets or sets Physician
        /// </summary>
        public CatalogueLoansetPhysician Physician { get; set; }
        /// <summary>
        /// Gets or sets Laterality
        /// </summary>
        public string Laterality { get; set; }
        /// <summary>
        /// Gets or sets IsPrimary
        /// </summary>
        public bool IsPrimary { get; set; }

    }
}
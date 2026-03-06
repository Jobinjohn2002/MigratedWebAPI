using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomisableListSaveResult
    /// </summary>
    public class CustomisableListSaveResult
    {
        /// <summary>
        /// Gets or sets ConfigurableList
        /// </summary>
        public ConfigurableListDataContract ConfigurableList { get; set; }

        /// <summary>
        /// Gets or sets ValidationResult
        /// </summary>
        public ConfigurableListValidationResult ValidationResult { get; set; }
    }
}
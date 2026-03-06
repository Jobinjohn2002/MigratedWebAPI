using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomisableList
    /// </summary>
    public class CustomisableList
    {
        /// <summary>
        /// Gets or sets TableTypeId
        /// </summary>
        public int TableTypeId { get; set; }

        public int? EventTypeId { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets TranslatedName
        /// </summary>
        public string TranslatedName { get; set; }

        /// <summary>
        /// Gets or sets SelectedValues
        /// </summary>
        public List<CustomisableValue> SelectedValues { get; set; }
    }
}
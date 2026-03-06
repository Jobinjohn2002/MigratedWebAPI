using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ConfigurableListDataContract
    /// </summary>
    public class ConfigurableListDataContract
    {
        /// <summary>
        /// Gets or sets ConfigurableListTypeId
        /// </summary>
        public int ConfigurableListTypeId { get; set; }
        public int? EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets ConfigurableListValues
        /// </summary>
        public List<ConfigurableListValueDataContract> ConfigurableListValues { get; set; }
        /// <summary>
        /// Gets or sets AllowCustomValues
        /// </summary>
        public bool AllowCustomValues { get; set; }
        /// <summary>
        /// Gets or sets AllowAlphabeticalSorting
        /// </summary>
        public bool AllowAlphabeticalSorting { get; set; }
    }
}
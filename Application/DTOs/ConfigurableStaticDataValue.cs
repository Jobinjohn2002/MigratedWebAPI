using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ConfigurableStaticDataValue
    /// </summary>
    public class ConfigurableStaticDataValue<T>
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public T Id { get; set; }
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets IsSelected
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
    }
}

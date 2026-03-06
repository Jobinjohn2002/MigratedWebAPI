using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// InvalidCustomisableListValue
    /// </summary>
    public class InvalidCustomisableListValue
    {
        /// <summary>
        /// Gets or sets InvalidValue
        /// </summary>
        public ConfigurableListValueDataContract InvalidValue { get; set; }

        /// <summary>
        /// Gets or sets InvalidReferences
        /// </summary>
        public List<InvalidReference> InvalidReferences { get; set; } = new List<InvalidReference>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EnumValueDescription
    /// </summary>
    public class EnumValueDescription
    {
        /// <summary>
        /// Gets or sets Documentation
        /// </summary>
        public string Documentation { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
    }
}
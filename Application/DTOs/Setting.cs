using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Setting
    /// </summary>
    public class Setting
    {
        public int? ID { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public KnownSettingType Type { get; set; }
    }
}
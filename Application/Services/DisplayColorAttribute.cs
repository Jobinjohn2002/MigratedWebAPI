using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// DisplayColorAttribute
    /// </summary>
    public class DisplayColorAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets DisplayColor
        /// </summary>
        public string DisplayColor { get; private set; }

        public DisplayColorAttribute(string color)
        {
            DisplayColor = color;
        }
    }
}

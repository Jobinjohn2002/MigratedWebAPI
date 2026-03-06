using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// TooltipAttribute
    /// </summary>
    public class TooltipAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets Tooltip
        /// </summary>
        public string Tooltip { get; private set; }

        public TooltipAttribute(string toolTip)
        {
            Tooltip = toolTip;
        }
    }
}

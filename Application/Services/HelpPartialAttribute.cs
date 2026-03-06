using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// HelpPartialAttribute
    /// </summary>
    public class HelpPartialAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets PartialView
        /// </summary>
        public string PartialView { get; private set; }
        /// <summary>
        /// Gets or sets Option
        /// </summary>
        public DisplayOption Option { get; private set; }
        /// <summary>
        /// Gets or sets Index
        /// </summary>
        public int Index { get; private set; }

        public HelpPartialAttribute(string partialView, DisplayOption displayOption, int displayIndex)
        {
            PartialView = partialView;
            Option = displayOption;
            Index = displayIndex; 
        }
    }
}
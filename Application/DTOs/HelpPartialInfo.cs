using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Display options.
    /// </summary>
    public enum DisplayOption
    {
        /// <summary>
        /// Display before the main details.
        /// </summary>
        BeforeDetails = 0,
        /// <summary>
        /// Display after the main details.
        /// </summary>
        AfterDetails = 1
    }

    /// <summary>
    /// Describes an additional help partial view.
    /// </summary>
    /// <summary>
    /// HelpPartialInfo
    /// </summary>
    public class HelpPartialInfo
    {
        /// <summary>
        /// The view to render.
        /// </summary>
        /// <summary>
        /// Gets or sets PartialView
        /// </summary>
        public string PartialView { get; set; }

        /// <summary>
        /// Display the partial view before or after the main details.
        /// </summary>
        /// <summary>
        /// Gets or sets Display
        /// </summary>
        public DisplayOption Display { get; set; }

        /// <summary>
        /// The display index.
        /// </summary>
        /// <summary>
        /// Gets or sets Index
        /// </summary>
        public int Index { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Component Specification Info.
    /// </summary>
    [HelpPartial(@"~\Areas\Customer\Views\Specification\_ComponentPositionNotes.cshtml", DisplayOption.AfterDetails, 1)]
    /// <summary>
    /// SpecificationComponentInfo
    /// </summary>
    public class SpecificationComponentInfo : ComponentInfo
    {
        /// <summary>
        /// The position of the component within the overall specification.
        /// </summary>
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// The quantity.
        /// </summary>
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Complexity level.
        /// </summary>
        /// <summary>
        /// Gets or sets Complexity
        /// </summary>
        public string Complexity { get; set; }
        /// <summary>
        /// The speciality.
        /// </summary>
        /// <summary>
        /// Gets or sets Speciality
        /// </summary>
        public string Speciality { get; set; }
        /// <summary>
        /// The item type.
        /// </summary>
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }
    }
}
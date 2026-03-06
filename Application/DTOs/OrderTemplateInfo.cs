using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Order Template Info.
    /// </summary>
    /// <summary>
    /// OrderTemplateInfo
    /// </summary>
    public class OrderTemplateInfo
    {
        /// <summary>
        /// The unique identifier for this resource.
        /// </summary>
        /// <summary>
        /// Gets or sets OrderTemplateNumber
        /// </summary>
        public string OrderTemplateNumber { get; set; }
        /// <summary>
        /// Your reference number, e.g. your internal system reference number to link to this record.
        /// </summary>
        /// <summary>
        /// Gets or sets YourReference
        /// </summary>
        public string YourReference { get; set; }
        /// <summary>
        /// The hospital.
        /// </summary>
        /// <summary>
        /// Gets or sets Hospital
        /// </summary>
        public string Hospital { get; set; }
        /// <summary>
        /// The template lines.
        /// </summary>
        /// <summary>
        /// Gets or sets TemplateLines
        /// </summary>
        public IList<OrderTemplateLineInfo> TemplateLines { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundLabelDataContract
    /// </summary>
    public class TurnaroundLabelDataContract
    {
        /// <summary>
        /// Gets or sets BaseItemTypeId
        /// </summary>
        public int BaseItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets Template
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// Gets or sets Content
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Gets or sets IsPrintSecondaryLabel
        /// </summary>
        public bool IsPrintSecondaryLabel { get; set; }
    }
}
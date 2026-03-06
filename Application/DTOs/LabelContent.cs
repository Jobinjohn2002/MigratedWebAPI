using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LabelContent
    /// </summary>
    public class LabelContent
    {
        /// <summary>
        /// Gets or sets Template
        /// </summary>
        public string Template { get; set; }
        /// <summary>
        /// Gets or sets Content
        /// </summary>
        public string Content { get; set; }
    }
}

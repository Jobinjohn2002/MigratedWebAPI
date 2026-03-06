using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// IndexModel
    /// </summary>
    public class IndexModel
    {
        /// <summary>
        /// Gets or sets Translator
        /// </summary>
        public ITranslator Translator { get; set; }
        /// <summary>
        /// Gets or sets UKLink
        /// </summary>
        public string UKLink { get; set; }
        /// <summary>
        /// Gets or sets USLink
        /// </summary>
        public string USLink { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SearchLogsModel
    /// </summary>
    public class SearchLogsModel
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        /// <summary>
        /// Gets or sets ShowDebug
        /// </summary>
        public bool ShowDebug { get; set; } = true;
        /// <summary>
        /// Gets or sets ShowInfo
        /// </summary>
        public bool ShowInfo { get; set; } = true;
        /// <summary>
        /// Gets or sets ShowWarnings
        /// </summary>
        public bool ShowWarnings { get; set; } = true;
        /// <summary>
        /// Gets or sets ShowErrors
        /// </summary>
        public bool ShowErrors { get; set; } = true;

        /// <summary>
        /// Gets or sets FilterText
        /// </summary>
        public string FilterText { get; set; }

        /// <summary>
        /// Gets or sets Result
        /// </summary>
        public SearchLogsResult Result { get; set; } = SearchLogsResult.Empty;
    }
}
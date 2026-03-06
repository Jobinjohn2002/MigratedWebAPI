using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TableSummary
    /// </summary>
    public class TableSummary
    {
        /// <summary>
        /// Gets or sets TableName
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// Gets or sets Indexing
        /// </summary>
        public IndexingSummary Indexing { get; set; }
    }
}
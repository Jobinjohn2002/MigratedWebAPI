using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// IndexingSummary
    /// </summary>
    public class IndexingSummary
    {
        /// <summary>
        /// Gets or sets TableRows
        /// </summary>
        public int TableRows { get; set; }
        /// <summary>
        /// Gets or sets Indexes
        /// </summary>
        public List<IndexInfo> Indexes { get; set; }
        /// <summary>
        /// Gets or sets MissingIndexes
        /// </summary>
        public List<MissingIndexInfo> MissingIndexes { get; set; }
    }
}

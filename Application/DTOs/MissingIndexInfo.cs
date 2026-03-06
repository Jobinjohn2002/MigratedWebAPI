using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MissingIndexInfo
    /// </summary>
    public class MissingIndexInfo
    {
        /// <summary>
        /// Gets or sets EqualityColumns
        /// </summary>
        public string EqualityColumns { get; set; }
        /// <summary>
        /// Gets or sets InequalityColumns
        /// </summary>
        public string InequalityColumns { get; set; }
        /// <summary>
        /// Gets or sets IncludeColumns
        /// </summary>
        public string IncludeColumns { get; set; }
        /// <summary>
        /// Gets or sets Impact
        /// </summary>
        public float Impact { get; set; }
        /// <summary>
        /// Gets or sets Cost
        /// </summary>
        public float Cost { get; set; }
        /// <summary>
        /// Gets or sets Seeks
        /// </summary>
        public int Seeks { get; set; }
        /// <summary>
        /// Gets or sets Scans
        /// </summary>
        public int Scans { get; set; }
        /// <summary>
        /// Gets or sets Script
        /// </summary>
        public string Script { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// IndexInfo
    /// </summary>
    public class IndexInfo
    {
        /// <summary>
        /// Gets or sets IndexId
        /// </summary>
        public int IndexId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets IsPrimaryKey
        /// </summary>
        public bool IsPrimaryKey { get; set; }
        /// <summary>
        /// Gets or sets IsUniqueConstraint
        /// </summary>
        public bool IsUniqueConstraint { get; set; }
        /// <summary>
        /// Gets or sets Fragmentation
        /// </summary>
        public float Fragmentation { get; set; }
        /// <summary>
        /// Gets or sets TotalReads
        /// </summary>
        public int TotalReads { get; set; }
        /// <summary>
        /// Gets or sets TotalUpdates
        /// </summary>
        public int TotalUpdates { get; set; }
        /// <summary>
        /// Gets or sets IsUsed
        /// </summary>
        public bool IsUsed { get; set; }

        /// <summary>
        /// Gets or sets DropScript
        /// </summary>
        public string DropScript { get; set; }
    }
}

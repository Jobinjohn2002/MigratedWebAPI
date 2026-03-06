using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum RunResult
    {
        Failed = 0,
        Success = 1,
        Retry = 2,
        Cancelled = 3
    }

    /// <summary>
    /// JobInfo
    /// </summary>
    public class JobInfo
    {
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public Guid ID { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets Enabled
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// Gets or sets Steps
        /// </summary>
        public int Steps { get; set; }
        public DateTime? LastRunOn { get; set; }
        public TimeSpan? LastRunDuration { get; set; }
        public RunResult? LastRunResult { get; set; }
        public DateTime? NextRunOn { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LogDataContract
    /// </summary>
    public class LogDataContract
    {
        /// <summary>
        /// Gets or sets DateTime
        /// </summary>
        public string DateTime { get; set; }
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }
    }
}
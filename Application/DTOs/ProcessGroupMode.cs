using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProcessGroupMode
    /// </summary>
    public class ProcessGroupMode
    {
        /// <summary>
        /// Gets or sets ProcessGroupId
        /// </summary>
        public int ProcessGroupId { get; set; }
        /// <summary>
        /// Gets or sets Overridden
        /// </summary>
        public bool Overridden { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
    }
}

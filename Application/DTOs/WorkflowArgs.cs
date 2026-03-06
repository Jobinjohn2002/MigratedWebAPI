using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// WorkflowArgs
    /// </summary>
    public class WorkflowArgs : WorkflowBaseArgs
    {
        /// <summary>
        /// Gets or sets ToEventTypeId
        /// </summary>
        public int ToEventTypeId { get; set; }
    }
}

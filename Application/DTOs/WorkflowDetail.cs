using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// WorkflowDetail
    /// </summary>
    public class WorkflowDetail
    {
        /// <summary>
        /// Gets or sets IsEnd
        /// </summary>
        public bool IsEnd { get; set; }
        public int? FromEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets NextEventTypeId
        /// </summary>
        public int NextEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets NextEventTypeCategoryId
        /// </summary>
        public int NextEventTypeCategoryId { get; set; }
        /// <summary>
        /// Gets or sets WorkflowId
        /// </summary>
        public int WorkflowId { get; set; }
    }
}

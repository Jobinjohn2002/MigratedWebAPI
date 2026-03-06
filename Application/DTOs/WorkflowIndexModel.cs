using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum WorkflowIndexConfirmation
    {
        None = 0,
        WorkflowDeleted = 1
    }

    /// <summary>
    /// WorkflowIndexModel
    /// </summary>
    public class WorkflowIndexModel
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets ProcessingMode
        /// </summary>
        public KnownProcessingMode ProcessingMode { get; set; }
        /// <summary>
        /// Gets or sets Table
        /// </summary>
        public TableModel Table { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public WorkflowIndexConfirmation Confirmation { get; set; }
    }
}
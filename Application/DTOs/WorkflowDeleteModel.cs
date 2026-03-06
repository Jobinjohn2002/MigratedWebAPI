using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// WorkflowDeleteModel
    /// </summary>
    public class WorkflowDeleteModel
    {
        /// <summary>
        /// Gets or sets PageTitle
        /// </summary>
        public string PageTitle { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public Facility Facility { get; set; }
        /// <summary>
        /// Gets or sets WorkflowId
        /// </summary>
        public int WorkflowId { get; set; }
        /// <summary>
        /// Gets or sets Workflow
        /// </summary>
        public Workflow Workflow { get; set; }
        public KnownProcessingMode? ProcessingMode { get; set; }
        /// <summary>
        /// Gets or sets Data
        /// </summary>
        public DataSet Data { get; set; }
    }
}
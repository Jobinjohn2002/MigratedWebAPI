using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityWorkflowModel
    /// </summary>
    public class FacilityWorkflowModel
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
    }
}
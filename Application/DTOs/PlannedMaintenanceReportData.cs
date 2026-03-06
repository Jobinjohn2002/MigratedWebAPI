using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PlannedMaintenanceReportData
    /// </summary>
    public class PlannedMaintenanceReportData
    {
        /// <summary>
        /// Gets or sets MaintenanceReportId
        /// </summary>
        public int MaintenanceReportId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets HasBeenPlanned
        /// </summary>
        public bool HasBeenPlanned { get; set; } 
        /// <summary>
        /// Gets or sets HasBeenWarned
        /// </summary>
        public bool HasBeenWarned { get; set; }
        /// <summary>
        /// Gets or sets HasBeenQuarantined
        /// </summary>
        public bool HasBeenQuarantined { get; set; }
        /// <summary>
        /// Gets or sets PlannedMaintenanceSettingFlag
        /// </summary>
        public int PlannedMaintenanceSettingFlag { get; set; }  
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceAlternateExternalId
        /// </summary>
        public string ContainerInstanceAlternateExternalId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets NextEventTypeId
        /// </summary>
        public int NextEventTypeId { get; set; }  
        
    }
}

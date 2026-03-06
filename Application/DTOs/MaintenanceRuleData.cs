using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MaintenanceRuleData
    /// </summary>
    public class MaintenanceRuleData
    {
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
        /// Gets or sets plannedMaintenanceReportData
        /// </summary>
        public List<PlannedMaintenanceReportData> plannedMaintenanceReportData { get; set; }
        /// <summary>
        /// Gets or sets PlannedMaintenanceSettingFlag
        /// </summary>
        public int PlannedMaintenanceSettingFlag { get; set; }  
        
    }
}

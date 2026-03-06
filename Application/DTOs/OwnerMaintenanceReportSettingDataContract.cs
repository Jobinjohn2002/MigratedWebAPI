using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OwnerMaintenanceReportSettingDataContract
    /// </summary>
    public class OwnerMaintenanceReportSettingDataContract
    {
        public int? OwnerMaintenanceReportSettingId { get; set; }
        /// <summary>
        /// Gets or sets OwnerId
        /// </summary>
        public int OwnerId { get; set; }
        public int? MaintenanceTypeId { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceTypeText
        /// </summary>
        public string MaintenanceTypeText { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceReportSettingId
        /// </summary>
        public MaintenanceReportSetting MaintenanceReportSettingId { get; set; }
    }
}

using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PlannedMaintenanceDataContract
    /// </summary>
    public class PlannedMaintenanceDataContract
    {
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets MaintenanceActivity
        /// </summary>
        public string MaintenanceActivity { get; set; }
        /// <summary>
        /// Gets or sets InstrumentStatus
        /// </summary>
        public MaintenanceInstrumentStatusTypeIdentifier InstrumentStatus { get; set; }
        /// <summary>
        /// Gets or sets PlannedMaintenanceRuleExternalId
        /// </summary>
        public string PlannedMaintenanceRuleExternalId { get; set; }
        /// <summary>
        /// Gets or sets VendorName
        /// </summary>
        public string VendorName { get; set; }
        public int? TurnaroundCount { get; set; }
        public DateTime? DueDate { get; set; }
        public int? DueInTurnarounds { get; set; }
        public int? DueInTime { get; set; }
        /// <summary>
        /// Gets or sets RepeatEvery
        /// </summary>
        public int RepeatEvery { get; set; }
        /// <summary>
        /// Gets or sets RepeatType
        /// </summary>
        public ScheduleRepeatType RepeatType { get; set; }
        /// <summary>
        /// Gets or sets Schedule
        /// </summary>
        public string Schedule { get; set; }
        /// <summary>
        /// Gets or sets Progress
        /// </summary>
        public string Progress { get; set; }
        /// <summary>
        /// Gets or sets NoPreviousTurnarounds
        /// </summary>
        public bool NoPreviousTurnarounds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CostRollup
    /// </summary>
    public class CostRollup
    {
        [DateOnly(AssumeDateOnlyTimeComponent.AssumeLocalMidnight)]
        public DateTime? From { get; set; }
        [DateOnly(AssumeDateOnlyTimeComponent.AssumeLocalMidnight)]
        public DateTime? To { get; set; }

        /// <summary>
        /// Gets or sets Reports
        /// </summary>
        public List<MaintenanceReport> Reports { get; set; }

        /// <summary>
        /// Gets or sets Mode
        /// </summary>
        public CostDisplayMode Mode { get; set; } = CostDisplayMode.Help;

        /// <summary>
        /// Gets or sets LineStatuses
        /// </summary>
        public List<FilterOption> LineStatuses { get; set; } = new List<FilterOption>();

        /// <summary>
        /// Gets or sets CustomerLocations
        /// </summary>
        public List<FilterOptionGroup> CustomerLocations { get; set; } = new List<FilterOptionGroup>();

        /// <summary>
        /// Gets or sets ShowCustomerLocations
        /// </summary>
        public bool ShowCustomerLocations { get; set; }
        /// <summary>
        /// Gets or sets HideReportsWithZeroCost
        /// </summary>
        public bool HideReportsWithZeroCost { get; set; }
        /// <summary>
        /// Gets or sets GeneratePrintCaption
        /// </summary>
        public bool GeneratePrintCaption { get; set; }
    }
}
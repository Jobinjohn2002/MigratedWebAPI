using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ClockingOverviewData
    /// </summary>
    public class ClockingOverviewData
    {
        /// <summary>
        /// Gets or sets UserClockingDataList
        /// </summary>
        public List<UserClockingData> UserClockingDataList { get; set; }
        /// <summary>
        /// Gets or sets LocationClockingDataList
        /// </summary>
        public List<LocationClockingData> LocationClockingDataList { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class PlannedMaintenanceFlagSettingsData 
	{
        /// <summary>
        /// Gets or sets StationTypeText
        /// </summary>
        public string StationTypeText { get; set; }
        /// <summary>
        /// Gets or sets EventTypeText
        /// </summary>
        public string EventTypeText { get; set; }

        public PlannedMaintenanceFlagSettingsData()
        {
        }
    }
}
		
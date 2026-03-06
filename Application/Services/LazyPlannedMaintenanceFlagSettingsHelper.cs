using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPlannedMaintenanceFlagSettingsHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PlannedMaintenanceFlagSettings concretePlannedMaintenanceFlagSettings, IPlannedMaintenanceFlagSettings genericPlannedMaintenanceFlagSettings)
        {		
			concretePlannedMaintenanceFlagSettings.FacilityId = genericPlannedMaintenanceFlagSettings.FacilityId;			
			concretePlannedMaintenanceFlagSettings.StationTypeId = genericPlannedMaintenanceFlagSettings.StationTypeId;			
			concretePlannedMaintenanceFlagSettings.PlannedMaintenanceFlags = genericPlannedMaintenanceFlagSettings.PlannedMaintenanceFlags;
            concretePlannedMaintenanceFlagSettings.EventTypeId = genericPlannedMaintenanceFlagSettings.EventTypeId;
        }
	}
}
		
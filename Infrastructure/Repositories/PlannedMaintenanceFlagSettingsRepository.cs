using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class PlannedMaintenanceFlagSettingsRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public PlannedMaintenanceFlagSettings Get(int plannedMaintenanceFlagSettingsId)
        {
            return Repository.Find(plannedMaintenanceFlagSettings => plannedMaintenanceFlagSettings.PlannedMaintenanceFlagSettingsId == plannedMaintenanceFlagSettingsId).FirstOrDefault();
        }
	}
}
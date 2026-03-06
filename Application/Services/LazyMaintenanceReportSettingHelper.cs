using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMaintenanceReportSettingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MaintenanceReportSetting concreteMaintenanceReportSetting, MaintenanceReportSetting genericMaintenanceReportSetting)
        {
					
			concreteMaintenanceReportSetting.MaintenanceReportSettingId = genericMaintenanceReportSetting.MaintenanceReportSettingId;			
			concreteMaintenanceReportSetting.Text = genericMaintenanceReportSetting.Text;
		}
	}
}
		
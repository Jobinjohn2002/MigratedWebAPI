using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOwnerMaintenanceReportSettingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OwnerMaintenanceReportSetting concreteOwnerMaintenanceReportSetting, OwnerMaintenanceReportSetting genericOwnerMaintenanceReportSetting)
        {

            concreteOwnerMaintenanceReportSetting.OwnerMaintenanceReportSettingId = genericOwnerMaintenanceReportSetting.OwnerMaintenanceReportSettingId;
            concreteOwnerMaintenanceReportSetting.OwnerId = genericOwnerMaintenanceReportSetting.OwnerId;			
            concreteOwnerMaintenanceReportSetting.MaintenanceTypeId = genericOwnerMaintenanceReportSetting.MaintenanceTypeId;			
            concreteOwnerMaintenanceReportSetting.MaintenanceReportSettingId = genericOwnerMaintenanceReportSetting.MaintenanceReportSettingId;			
            concreteOwnerMaintenanceReportSetting.ModifiedByUserId = genericOwnerMaintenanceReportSetting.ModifiedByUserId;			
        }
    }
}
		
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMaintenanceReportStatusHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MaintenanceReportStatus concreteMaintenanceReportStatus, MaintenanceReportStatus genericMaintenanceReportStatus)
        {
					
			concreteMaintenanceReportStatus.MaintenanceReportStatusId = genericMaintenanceReportStatus.MaintenanceReportStatusId;			
			concreteMaintenanceReportStatus.MaintenanceTypeId = genericMaintenanceReportStatus.MaintenanceTypeId;			
			concreteMaintenanceReportStatus.Text = genericMaintenanceReportStatus.Text;
		}
	}
}
		
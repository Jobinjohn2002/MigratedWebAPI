using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMaintenanceReportInstrumentDetailHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MaintenanceReportInstrumentDetail concreteMaintenanceReportInstrumentDetail, MaintenanceReportInstrumentDetail genericMaintenanceReportInstrumentDetail)
        {
					
			concreteMaintenanceReportInstrumentDetail.MaintenanceReportInstrumentId = genericMaintenanceReportInstrumentDetail.MaintenanceReportInstrumentId;			
			concreteMaintenanceReportInstrumentDetail.MaintenanceReportId = genericMaintenanceReportInstrumentDetail.MaintenanceReportId;			
			concreteMaintenanceReportInstrumentDetail.ItemMasterId = genericMaintenanceReportInstrumentDetail.ItemMasterId;			
			concreteMaintenanceReportInstrumentDetail.RepairCategoryId = genericMaintenanceReportInstrumentDetail.RepairCategoryId;			
			concreteMaintenanceReportInstrumentDetail.RepairCost = genericMaintenanceReportInstrumentDetail.RepairCost;			
			concreteMaintenanceReportInstrumentDetail.Created = genericMaintenanceReportInstrumentDetail.Created;			
			concreteMaintenanceReportInstrumentDetail.CreatedUserId = genericMaintenanceReportInstrumentDetail.CreatedUserId;
		}
	}
}
		
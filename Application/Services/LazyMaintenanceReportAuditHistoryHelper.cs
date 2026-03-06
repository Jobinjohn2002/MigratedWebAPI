using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMaintenanceReportAuditHistoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MaintenanceReportAuditHistory concreteMaintenanceReportAuditHistory, IMaintenanceReportAuditHistory genericMaintenanceReportAuditHistory)
        {		
			concreteMaintenanceReportAuditHistory.MaintenanceReportAuditHistoryId = genericMaintenanceReportAuditHistory.MaintenanceReportAuditHistoryId;			
			concreteMaintenanceReportAuditHistory.MaintenanceReportId = genericMaintenanceReportAuditHistory.MaintenanceReportId;			
			concreteMaintenanceReportAuditHistory.MaintenanceReportStatusId = genericMaintenanceReportAuditHistory.MaintenanceReportStatusId;			
			concreteMaintenanceReportAuditHistory.TotalCost = genericMaintenanceReportAuditHistory.TotalCost;			
			concreteMaintenanceReportAuditHistory.Created = genericMaintenanceReportAuditHistory.Created;			
			concreteMaintenanceReportAuditHistory.CreatedUserId = genericMaintenanceReportAuditHistory.CreatedUserId;			
			concreteMaintenanceReportAuditHistory.Notes = genericMaintenanceReportAuditHistory.Notes;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyMaintenanceReportHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(MaintenanceReport concreteMaintenanceReport, IMaintenanceReport genericMaintenanceReport)
        {		
			concreteMaintenanceReport.MaintenanceReportId = genericMaintenanceReport.MaintenanceReportId;			
			concreteMaintenanceReport.TurnaroundId = genericMaintenanceReport.TurnaroundId;			
			concreteMaintenanceReport.MaintenanceTypeId = genericMaintenanceReport.MaintenanceTypeId;			
			concreteMaintenanceReport.MaintenanceReportStatusId = genericMaintenanceReport.MaintenanceReportStatusId;			
			concreteMaintenanceReport.VendorId = genericMaintenanceReport.VendorId;			
			concreteMaintenanceReport.CourierId = genericMaintenanceReport.CourierId;			
			concreteMaintenanceReport.VendorRef = genericMaintenanceReport.VendorRef;			
			concreteMaintenanceReport.CourierRef = genericMaintenanceReport.CourierRef;			
			concreteMaintenanceReport.Created = genericMaintenanceReport.Created;
			concreteMaintenanceReport.CreatedUserId = genericMaintenanceReport.CreatedUserId;			
			concreteMaintenanceReport.Modified = genericMaintenanceReport.Modified;			
			concreteMaintenanceReport.ModifiedUserId = genericMaintenanceReport.ModifiedUserId;			
			concreteMaintenanceReport.EstimatedCompletion = genericMaintenanceReport.EstimatedCompletion;			
			concreteMaintenanceReport.PlannedMaintenanceJobId = genericMaintenanceReport.PlannedMaintenanceJobId;			
			concreteMaintenanceReport.PlannedMaintenanceJobRef = genericMaintenanceReport.PlannedMaintenanceJobRef;			
			concreteMaintenanceReport.TotalCost = genericMaintenanceReport.TotalCost;			
			concreteMaintenanceReport.PurchaseRequisitionRef = genericMaintenanceReport.PurchaseRequisitionRef;			
			concreteMaintenanceReport.PurchaseOrderRef = genericMaintenanceReport.PurchaseOrderRef;			
			concreteMaintenanceReport.InvoiceRef = genericMaintenanceReport.InvoiceRef;			
			concreteMaintenanceReport.Notes = genericMaintenanceReport.Notes;			
			concreteMaintenanceReport.UserDefinedRef = genericMaintenanceReport.UserDefinedRef;			
			concreteMaintenanceReport.QuoteRef = genericMaintenanceReport.QuoteRef;			
			concreteMaintenanceReport.RequesterName = genericMaintenanceReport.RequesterName;			
			concreteMaintenanceReport.RequesterPosition = genericMaintenanceReport.RequesterPosition;
		}
	}
}
		
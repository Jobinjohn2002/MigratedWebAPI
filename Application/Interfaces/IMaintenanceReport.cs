using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IMaintenanceReport : IEntityData
	{		
		int MaintenanceReportId { get; set; }
			
		int TurnaroundId { get; set; }
			
		int? MaintenanceTypeId { get; set; }
			
		int MaintenanceReportStatusId { get; set; }
			
		int? VendorId { get; set; }
			
		int? CourierId { get; set; }
			
		string VendorRef { get; set; }
			
		string CourierRef { get; set; }
			
		DateTime Created { get; set; }
			
		int CreatedUserId { get; set; }
			
		DateTime? Modified { get; set; }
			
		int? ModifiedUserId { get; set; }
			
		DateTime? EstimatedCompletion { get; set; }
			
		int? PlannedMaintenanceJobId { get; set; }
			
		string PlannedMaintenanceJobRef { get; set; }
			
		decimal? TotalCost { get; set; }
			
		string PurchaseRequisitionRef { get; set; }
			
		string PurchaseOrderRef { get; set; }
			
		string InvoiceRef { get; set; }
			
		string Notes { get; set; }
			
		string UserDefinedRef { get; set; }
			
		string QuoteRef { get; set; }
			
		string RequesterName { get; set; }
			
		string RequesterPosition { get; set; }
			
		string ExternalId { get; set; }
	}
}
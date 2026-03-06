using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ITurnaround : IEntityData
	{		
		int TurnaroundId { get; set; }
			
		int? ContainerInstanceId { get; set; }
			
		int ContainerMasterId { get; set; }
			
		int CreatedUserId { get; set; }
			
		int? DeliveryNoteId { get; set; }
			
		int DeliveryPointId { get; set; }
			
		short FacilityId { get; set; }
			
		int? InvoiceLineId { get; set; }
			
		int? ItemInstanceId { get; set; }
			
		int? ParentTurnaroundId { get; set; }
			
		int ServiceRequirementId { get; set; }
			
		int? StoragePointId { get; set; }
			
		long ExternalId { get; set; }
			
		DateTime Created { get; set; }
			
		DateTime Expiry { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		int? StartEventId { get; set; }
			
		int? LastEventId { get; set; }
			
		DateTime? SterileExpiryDate { get; set; }
			
		bool IsBestPractice { get; set; }
			
		bool IsPaused { get; set; }
			
		bool DisableTrolleyCustomerRestriction { get; set; }
			
		bool ItemExceptionsApprovalFlag { get; set; }
	}
}
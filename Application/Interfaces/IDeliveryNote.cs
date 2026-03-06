using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IDeliveryNote : IEntityData
	{		
		int DeliveryNoteId { get; set; }
			
		int DeliveryPointId { get; set; }
			
		short FacilityId { get; set; }
			
		int PrintedUserId { get; set; }
			
		int ExternalId { get; set; }
			
		DateTime Printed { get; set; }
			
		bool PrintedStatus { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		int? LegacyId { get; set; }
			
		bool? PhysicalCopyCreated { get; set; }
			
		DateTime? ExpectedDelivery { get; set; }
	}
}
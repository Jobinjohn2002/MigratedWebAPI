using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IDeliveryPoint : IEntityData
	{		
		int DeliveryPointId { get; set; }
			
		int AddressId { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		int CustomerDefinitionId { get; set; }
			
		byte DeliveryTypeId { get; set; }
			
		int? DirectorateId { get; set; }
			
		string Text { get; set; }
			
		DateTime? Archived { get; set; }
			
		bool StockLocation { get; set; }
			
		bool? RequiresProof { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		int? LocationId { get; set; }
			
		bool RestrictedForBatchTag { get; set; }
			
		bool CreatePhysicalDeliveryNote { get; set; }
			
		bool RestrictedForTrolleys { get; set; }
	}
}
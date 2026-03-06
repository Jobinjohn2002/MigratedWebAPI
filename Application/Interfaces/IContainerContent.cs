using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IContainerContent : IEntityData
	{		
		int ContainerContentId { get; set; }
			
		int? ContainerContentNoteId { get; set; }
			
		int ContainerMasterId { get; set; }
			
		int? ItemMasterDefinitionId { get; set; }
			
		int Quantity { get; set; }
			
		int Position { get; set; }
			
		bool ComponentListPrint { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyCustomerId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IProcessingNote : IEntityData
	{		
		int ProcessingNoteId { get; set; }
			
		byte ProcessingNoteTypeId { get; set; }
			
		int? ContainerMasterDefinitionId { get; set; }
			
		string Text { get; set; }
			
		DateTime? Expiry { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? ItemMasterId { get; set; }
			
		DateTime ActiveFrom { get; set; }
			
		int? PreviousNoteId { get; set; }
			
		int CreatedBy { get; set; }
	}
}
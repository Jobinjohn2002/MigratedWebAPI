using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ILocation : IEntityData
	{		
		int LocationId { get; set; }
			
		byte LocationTypeId { get; set; }
			
		string Text { get; set; }
			
		string ExternalId { get; set; }
			
		string Description { get; set; }
			
		int? MaximumCapacity { get; set; }
			
		int? LeafId { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		DateTime Modified { get; set; }
			
		int ModifiedUserId { get; set; }
			
		string LocationCode { get; set; }
			
		bool IsMandatoryForClockingProcess { get; set; }
			
		bool IsUsagePoint { get; set; }
	}
}
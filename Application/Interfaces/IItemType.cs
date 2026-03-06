using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IItemType : IEntityData
	{		
		short ItemTypeId { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		byte LabelTypeId { get; set; }
			
		short? ParentItemTypeId { get; set; }
			
		string Text { get; set; }
			
		DateTime? Archived { get; set; }
			
		byte ItemTypeFeatures { get; set; }
			
		bool Trackable { get; set; }
			
		bool OwnWorkflow { get; set; }
			
		bool AllowFinancialSetup { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		bool IsNonSterileProduct { get; set; }
			
		bool IsComponent { get; set; }
	}
}
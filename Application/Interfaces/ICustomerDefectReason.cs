using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ICustomerDefectReason : IEntityData
	{		
		byte CustomerDefectReasonId { get; set; }
			
		string Text { get; set; }
			
		bool CausesIntoQuarantine { get; set; }
			
		byte DisplayOrder { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IWorkflow : IEntityData
	{		
		int WorkflowId { get; set; }
			
		short ItemTypeId { get; set; }
			
		short? FromEventTypeId { get; set; }
			
		short ToEventTypeId { get; set; }
			
		bool IsEnd { get; set; }
			
		bool IsStockLocation { get; set; }
			
		bool ForIndividualInstrumentTracking { get; set; }
			
		bool IsRequiredProof { get; set; }
			
		bool IsReleaseRequired { get; set; }
			
		bool IsBestPractice { get; set; }
			
		int CreatedByUserId { get; set; }
			
		DateTime CreatedDate { get; set; }
			
		int? OwnerId { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? ArchivedUserId { get; set; }
	}
}

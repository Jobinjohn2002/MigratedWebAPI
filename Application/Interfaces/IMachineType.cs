using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IMachineType : IEntityData
	{		
		byte MachineTypeId { get; set; }
			
		string Text { get; set; }
			
		string Handler { get; set; }
			
		bool HasBatches { get; set; }
			
		bool IsSteriliser { get; set; }
			
		bool IsCarriageWasher { get; set; }
			
		int? DecontaminationTaskId { get; set; }
	}
}
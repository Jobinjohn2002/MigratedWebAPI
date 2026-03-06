using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IDecontaminationTask : IEntityData
	{		
		int DecontaminationTaskId { get; set; }
			
		int TaskId { get; set; }
			
		string Text { get; set; }
			
		bool UseLabourLevel { get; set; }
			
		DateTime? Archived { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IMaintenanceActivity : IEntityData
	{		
		int MaintenanceActivityId { get; set; }
			
		string Text { get; set; }
			
		DateTime Created { get; set; }
			
		string Code { get; set; }
			
		string ExternalId { get; set; }
			
		bool? Replacement { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? ArchivedUserId { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IQuarantineReason : IEntityData
	{		
		short QuarantineReasonId { get; set; }
			
		string Text { get; set; }
			
		bool IsUserSelectable { get; set; }
	}
}
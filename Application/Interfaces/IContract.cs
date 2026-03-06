using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IContract : IEntityData
	{		
		int ContractId { get; set; }
			
		int VendorId { get; set; }
			
		string Text { get; set; }
			
		DateTime Created { get; set; }
			
		DateTime? StartDate { get; set; }
			
		DateTime? EndDate { get; set; }
			
		int CreatedUserId { get; set; }
			
		DateTime? ModifiedDate { get; set; }
			
		int? CustomerDefinitionId { get; set; }
			
		string VendorContractId { get; set; }
	}
}
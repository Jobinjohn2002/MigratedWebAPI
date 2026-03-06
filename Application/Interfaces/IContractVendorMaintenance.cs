using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IContractVendorMaintenance : IEntityData
	{		
		int Id { get; set; }
			
		int ContractId { get; set; }
			
		int VendorMaintenanceActivityId { get; set; }
			
		decimal? Cost { get; set; }
			
		DateTime? Created { get; set; }
			
		int? CreatedUserId { get; set; }
	}
}
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IServiceRequirementContractedHoursDataAdapter
	{

        IQueryable<ServiceRequirementContractedHours> GetByServiceRequirementId(int serviceRequirementId);
			
	}
}
		
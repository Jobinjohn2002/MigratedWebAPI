using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ICustomerDefect : IEntityData
	{		
		int CustomerDefectId { get; set; }
			
		int CreatedUserId { get; set; }
			
		byte CustomerDefectStatusId { get; set; }
			
		int TurnaroundId { get; set; }
			
		string ExternalId { get; set; }
			
		DateTime Created { get; set; }
			
		string MissingInformation { get; set; }
			
		string DetailsInformation { get; set; }
			
		string InternalDetailsInformation { get; set; }
			
		string ResponseInformation { get; set; }
			
		bool EmailCustomer { get; set; }
			
		bool RespondedDirectly { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		bool QuarantineAfterWash { get; set; }
			
		short FacilityId { get; set; }
	}
}
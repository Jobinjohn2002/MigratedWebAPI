using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IServiceReports : IEntityData
	{		
		int DefectId { get; set; }
			
		string ExternalId { get; set; }
			
		string DefectType { get; set; }
			
		DateTime Raised { get; set; }
			
		string DeliveryPointName { get; set; }
			
		string CustomerName { get; set; }
			
		string SerialNumber { get; set; }
			
		string ClassificationName { get; set; }
			
		string DefectStatusName { get; set; }
			
		short FacilityId { get; set; }
			
		byte DefectStatusId { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IContainerMasterNoteStationType : IEntityData
	{		
		int ContainerMasterNoteId { get; set; }
			
		byte StationTypeId { get; set; }
			
		short? EventTypeId { get; set; }
			
		int ContainerMasterNoteStationTypeId { get; set; }
	}
}
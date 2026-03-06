using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyContainerMasterNoteStationTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ContainerMasterNoteStationType concreteContainerMasterNoteStationType, ContainerMasterNoteStationType genericContainerMasterNoteStationType)
        {
					
			concreteContainerMasterNoteStationType.ContainerMasterNoteId = genericContainerMasterNoteStationType.ContainerMasterNoteId;			
			concreteContainerMasterNoteStationType.ContainerMasterNoteId = genericContainerMasterNoteStationType.ContainerMasterNoteId;			
			concreteContainerMasterNoteStationType.StationTypeId = genericContainerMasterNoteStationType.StationTypeId;			
			concreteContainerMasterNoteStationType.StationTypeId = genericContainerMasterNoteStationType.StationTypeId;			
			concreteContainerMasterNoteStationType.EventTypeId = genericContainerMasterNoteStationType.EventTypeId;			
			concreteContainerMasterNoteStationType.EventTypeId = genericContainerMasterNoteStationType.EventTypeId;
		}
	}
}
		
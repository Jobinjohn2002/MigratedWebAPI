using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyProcessingNoteStationTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ProcessingNoteStationType concreteProcessingNoteStationType, ProcessingNoteStationType genericProcessingNoteStationType)
        {
					
			concreteProcessingNoteStationType.ProcessingNoteId = genericProcessingNoteStationType.ProcessingNoteId;			
			concreteProcessingNoteStationType.StationTypeId = genericProcessingNoteStationType.StationTypeId;			
			concreteProcessingNoteStationType.EventTypeId = genericProcessingNoteStationType.EventTypeId;			
			concreteProcessingNoteStationType.ProcessingNoteStationTypeId = genericProcessingNoteStationType.ProcessingNoteStationTypeId;
		}
	}
}
		
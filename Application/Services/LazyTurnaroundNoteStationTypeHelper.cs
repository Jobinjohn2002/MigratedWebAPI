using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTurnaroundNoteStationTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TurnaroundNoteStationType concreteTurnaroundNoteStationType, TurnaroundNoteStationType genericTurnaroundNoteStationType)
        {
					
			concreteTurnaroundNoteStationType.TurnaroundNoteId = genericTurnaroundNoteStationType.TurnaroundNoteId;				
			concreteTurnaroundNoteStationType.StationTypeId = genericTurnaroundNoteStationType.StationTypeId;			
			concreteTurnaroundNoteStationType.EventTypeId = genericTurnaroundNoteStationType.EventTypeId;	
		}
	}
}
		
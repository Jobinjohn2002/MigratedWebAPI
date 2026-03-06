using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTurnaroundEventAcknowledgeNoteHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TurnaroundEventAcknowledgeNote concreteTurnaroundEventAcknowledgeNote, TurnaroundEventAcknowledgeNote genericTurnaroundEventAcknowledgeNote)
        {
					
			concreteTurnaroundEventAcknowledgeNote.TurnaroundEventId = genericTurnaroundEventAcknowledgeNote.TurnaroundEventId;			
			concreteTurnaroundEventAcknowledgeNote.ContainerMasterNoteId = genericTurnaroundEventAcknowledgeNote.ContainerMasterNoteId;			
			concreteTurnaroundEventAcknowledgeNote.ProcessingNoteId = genericTurnaroundEventAcknowledgeNote.ProcessingNoteId;			
			concreteTurnaroundEventAcknowledgeNote.StationId = genericTurnaroundEventAcknowledgeNote.StationId;
		}
	}
}
		
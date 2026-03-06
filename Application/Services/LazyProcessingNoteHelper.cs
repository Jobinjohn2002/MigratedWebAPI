using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyProcessingNoteHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ProcessingNote concreteProcessingNote, ProcessingNote genericProcessingNote)
        {
					
			concreteProcessingNote.ProcessingNoteId = genericProcessingNote.ProcessingNoteId;			
			concreteProcessingNote.ProcessingNoteTypeId = genericProcessingNote.ProcessingNoteTypeId;			
			concreteProcessingNote.ContainerMasterDefinitionId = genericProcessingNote.ContainerMasterDefinitionId;			
			concreteProcessingNote.Text = genericProcessingNote.Text;					
			concreteProcessingNote.Expiry = genericProcessingNote.Expiry;			
			concreteProcessingNote.Archived = genericProcessingNote.Archived;
		}
	}
}
		
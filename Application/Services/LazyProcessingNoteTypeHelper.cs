using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyProcessingNoteTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ProcessingNoteType concreteProcessingNoteType, ProcessingNoteType genericProcessingNoteType)
        {
					
			concreteProcessingNoteType.ProcessingNoteTypeId = genericProcessingNoteType.ProcessingNoteTypeId;			
			concreteProcessingNoteType.Text = genericProcessingNoteType.Text;
		}
	}
}
		
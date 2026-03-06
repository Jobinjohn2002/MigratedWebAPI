using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class TurnaroundEventAcknowledgeNoteRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public TurnaroundEventAcknowledgeNote Get(int turnaroundEventAcknowledgeNoteId)
        {
            return Repository.Find(turnaroundEventAcknowledgeNote => turnaroundEventAcknowledgeNote.TurnaroundEventId == turnaroundEventAcknowledgeNoteId).FirstOrDefault();
        }
	}
}
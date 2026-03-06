using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTransferNoteHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TransferNote concreteTransferNote, TransferNote genericTransferNote)
        {
					
			concreteTransferNote.TransferNoteId = genericTransferNote.TransferNoteId;			
			concreteTransferNote.FromOwnerId = genericTransferNote.FromOwnerId;			
			concreteTransferNote.ToOwnerId = genericTransferNote.ToOwnerId;			
			concreteTransferNote.ExternalId = genericTransferNote.ExternalId;			
			concreteTransferNote.RouteToEventTypeId = genericTransferNote.RouteToEventTypeId;			
			concreteTransferNote.TransportTurnaroundId = genericTransferNote.TransportTurnaroundId;						
			concreteTransferNote.DispatchTransferNoteEventId = genericTransferNote.DispatchTransferNoteEventId;
		}
	}
}
		
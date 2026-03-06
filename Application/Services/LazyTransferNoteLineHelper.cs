using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTransferNoteLineHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TransferNoteLine concreteTransferNoteLine, TransferNoteLine genericTransferNoteLine)
        {
					
			concreteTransferNoteLine.TransferNoteLineId = genericTransferNoteLine.TransferNoteLineId;			
			concreteTransferNoteLine.TransferNoteId = genericTransferNoteLine.TransferNoteId;			
			concreteTransferNoteLine.TurnaroundId = genericTransferNoteLine.TurnaroundId;
            concreteTransferNoteLine.AddToTransferNoteEventId = genericTransferNoteLine.AddToTransferNoteEventId;
            concreteTransferNoteLine.BeforeTransferProcessEventId = genericTransferNoteLine.BeforeTransferProcessEventId;
            concreteTransferNoteLine.DispatchTransferNoteEventId = genericTransferNoteLine.DispatchTransferNoteEventId;
            concreteTransferNoteLine.BeforeTransferProcessEventId = genericTransferNoteLine.BeforeTransferProcessEventId;
		}
	}
}
		
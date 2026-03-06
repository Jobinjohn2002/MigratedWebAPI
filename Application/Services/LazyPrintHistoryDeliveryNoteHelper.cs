using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyPrintHistoryDeliveryNoteHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PrintHistoryDeliveryNote concretePrintHistoryDeliveryNote, PrintHistoryDeliveryNote genericPrintHistoryDeliveryNote)
        {
					
			concretePrintHistoryDeliveryNote.PrintHistoryDeliveryNoteId = genericPrintHistoryDeliveryNote.PrintHistoryDeliveryNoteId;			
			concretePrintHistoryDeliveryNote.PrintHistoryId = genericPrintHistoryDeliveryNote.PrintHistoryId;			
			concretePrintHistoryDeliveryNote.DeliveryNoteId = genericPrintHistoryDeliveryNote.DeliveryNoteId;
		}
	}
}
		
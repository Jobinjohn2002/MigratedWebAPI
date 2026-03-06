using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyHisOrderNoteHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(HisOrderNote concreteHisOrderNote, HisOrderNote genericHisOrderNote)
        {
					
			concreteHisOrderNote.HisOrderNoteId = genericHisOrderNote.HisOrderNoteId;			
			concreteHisOrderNote.HisOrderId = genericHisOrderNote.HisOrderId;			
			concreteHisOrderNote.Sequence = genericHisOrderNote.Sequence;			
			concreteHisOrderNote.Text = genericHisOrderNote.Text;
		}
	}
}
		
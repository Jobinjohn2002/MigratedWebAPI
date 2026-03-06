using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOrderNoteHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OrderNote concreteOrderNote, OrderNote genericOrderNote)
        {
					
			concreteOrderNote.OrderNoteId = genericOrderNote.OrderNoteId;			
			concreteOrderNote.OrderId = genericOrderNote.OrderId;			
			concreteOrderNote.Sequence = genericOrderNote.Sequence;			
			concreteOrderNote.Text = genericOrderNote.Text;			
			concreteOrderNote.Hash = genericOrderNote.Hash;
		}
	}
}
		
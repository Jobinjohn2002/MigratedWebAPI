using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyAbandonReasonHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(AbandonReason concreteAbandonReason, AbandonReason genericAbandonReason)
        {
					
			concreteAbandonReason.AbandonReasonId = genericAbandonReason.AbandonReasonId;			
			concreteAbandonReason.Text = genericAbandonReason.Text;			
			concreteAbandonReason.IsVisible = genericAbandonReason.IsVisible;	
		}
	}
}
		
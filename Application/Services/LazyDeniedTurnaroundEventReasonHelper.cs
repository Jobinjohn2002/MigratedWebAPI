using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyDeniedTurnaroundEventReasonHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(DeniedTurnaroundEventReason concreteDeniedTurnaroundEventReason, DeniedTurnaroundEventReason genericDeniedTurnaroundEventReason)
        {
					
			concreteDeniedTurnaroundEventReason.DeniedTurnaroundEventReasonId = genericDeniedTurnaroundEventReason.DeniedTurnaroundEventReasonId;			
			concreteDeniedTurnaroundEventReason.Text = genericDeniedTurnaroundEventReason.Text;
		}
	}
}
		
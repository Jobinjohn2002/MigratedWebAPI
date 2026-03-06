using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class LazyPinRequestReasonHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(PinRequestReason concretePinRequestReason, PinRequestReason genericPinRequestReason)
        {
					
			concretePinRequestReason.PinRequestReasonId = genericPinRequestReason.PinRequestReasonId;			
			concretePinRequestReason.Text = genericPinRequestReason.Text;			
			concretePinRequestReason.Description = genericPinRequestReason.Description;
		}
	}
}
		
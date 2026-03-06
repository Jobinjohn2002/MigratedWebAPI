using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyRecipientTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(RecipientType concreteRecipientType, RecipientType genericRecipientType)
        {
					
			concreteRecipientType.RecipientTypeId = genericRecipientType.RecipientTypeId;			
			concreteRecipientType.Text = genericRecipientType.Text;
		}
	}
}
		
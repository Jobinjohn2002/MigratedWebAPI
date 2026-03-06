using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyOwnerConfigurableListValueHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(OwnerConfigurableListValue concreteOwnerConfigurableListValue, OwnerConfigurableListValue genericOwnerConfigurableListValue)
        {
					
			concreteOwnerConfigurableListValue.OwnerId = genericOwnerConfigurableListValue.OwnerId;				
			concreteOwnerConfigurableListValue.ConfigurableListValueId = genericOwnerConfigurableListValue.ConfigurableListValueId;			
			concreteOwnerConfigurableListValue.OrderId = genericOwnerConfigurableListValue.OrderId;			
		}
	}
}
		
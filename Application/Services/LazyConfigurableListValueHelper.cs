using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyConfigurableListValueHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ConfigurableListValue concreteConfigurableListValue, ConfigurableListValue genericConfigurableListValue)
        {
					
			concreteConfigurableListValue.ConfigurableListValueId = genericConfigurableListValue.ConfigurableListValueId;			
			concreteConfigurableListValue.ConfigurableListTypeId = genericConfigurableListValue.ConfigurableListTypeId;			
			concreteConfigurableListValue.CustomValueId = genericConfigurableListValue.CustomValueId;			
			concreteConfigurableListValue.IsSystem = genericConfigurableListValue.IsSystem;
		}
	}
}
		
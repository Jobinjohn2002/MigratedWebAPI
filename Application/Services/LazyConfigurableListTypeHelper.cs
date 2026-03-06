using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyConfigurableListTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ConfigurableListType concreteConfigurableListType, ConfigurableListType genericConfigurableListType)
        {
					
			concreteConfigurableListType.ConfigurableListTypeId = genericConfigurableListType.ConfigurableListTypeId;			
			concreteConfigurableListType.TableName = genericConfigurableListType.TableName;			
			concreteConfigurableListType.AllowCustomValues = genericConfigurableListType.AllowCustomValues;
		}
	}
}
		
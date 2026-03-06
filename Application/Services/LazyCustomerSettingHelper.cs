using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyCustomerSettingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(CustomerSetting concreteCustomerSetting, CustomerSetting genericCustomerSetting)
        {
					
			concreteCustomerSetting.CustomerSettingId = genericCustomerSetting.CustomerSettingId;			
			concreteCustomerSetting.CustomerDefinitionId = genericCustomerSetting.CustomerDefinitionId;			
			concreteCustomerSetting.Name = genericCustomerSetting.Name;			
			concreteCustomerSetting.Type = genericCustomerSetting.Type;			
			concreteCustomerSetting.Value = genericCustomerSetting.Value;
		}
	}
}
		
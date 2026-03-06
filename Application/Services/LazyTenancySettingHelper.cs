using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyTenancySettingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(TenancySetting concreteTenancySetting, TenancySetting genericTenancySetting)
        {
					
			concreteTenancySetting.TenancySettingId = genericTenancySetting.TenancySettingId;			
			concreteTenancySetting.TenancyId = genericTenancySetting.TenancyId;			
			concreteTenancySetting.Name = genericTenancySetting.Name;			
			concreteTenancySetting.Type = genericTenancySetting.Type;			
			concreteTenancySetting.Value = genericTenancySetting.Value;
		}
	}
}
		
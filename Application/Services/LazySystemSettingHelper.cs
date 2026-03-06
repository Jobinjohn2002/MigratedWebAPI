using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazySystemSettingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(SystemSetting concreteSystemSetting, SystemSetting genericSystemSetting)
        {
					
			concreteSystemSetting.SystemSettingId = genericSystemSetting.SystemSettingId;			
			concreteSystemSetting.Name = genericSystemSetting.Name;			
			concreteSystemSetting.Type = genericSystemSetting.Type;			
			concreteSystemSetting.Value = genericSystemSetting.Value;
		}
	}
}
		
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFacilitySettingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FacilitySetting concreteFacilitySetting, FacilitySetting genericFacilitySetting)
        {
					
			concreteFacilitySetting.FacilitySettingId = genericFacilitySetting.FacilitySettingId;			
			concreteFacilitySetting.FacilityId = genericFacilitySetting.FacilityId;			
			concreteFacilitySetting.Name = genericFacilitySetting.Name;			
			concreteFacilitySetting.Type = genericFacilitySetting.Type;			
			concreteFacilitySetting.Value = genericFacilitySetting.Value;
		}
	}
}
		
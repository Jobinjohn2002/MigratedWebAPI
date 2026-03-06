using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class FacilitySettingRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public FacilitySetting Get(int facilitySettingId)
        {
            return Repository.Find(facilitySetting => facilitySetting.FacilitySettingId == facilitySettingId).FirstOrDefault();
        }

        /// <summary>
        /// Reads a facility setting for and returns the value as the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="facilityId">The Id of the facility to look for settings.</param>
        /// <param name="setting">The name of the setting to look for.</param>
        /// <returns>The value recovered for the specified setting.</returns>
        public T ReadFacilitySetting<T>(short facilityId, string settingName)
        {
            return Settings.ReadGenericSetting<T, FacilitySetting>(Repository.Find(fs => fs.FacilityId == facilityId && fs.Name == settingName).FirstOrDefault());
        }
    }
}
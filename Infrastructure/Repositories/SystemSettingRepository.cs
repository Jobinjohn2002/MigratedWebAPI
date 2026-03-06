using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class SystemSettingRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public SystemSetting Get(int systemSettingId)
        {
            return Repository.Find(systemSetting => systemSetting.SystemSettingId == systemSettingId).FirstOrDefault();
        }
        
        /// <summary>
        /// GetAllSettings operation
        /// </summary>
        public IEnumerable<SystemSetting> GetAllSettings(int systemSettingId)
        {
            return Repository.All();
        }

	    /// <summary>
	    /// GetSetting operation
	    /// </summary>
	    public SystemSetting GetSetting(string key)
	    {
	        return Repository.Find(setting => setting.Name == key).FirstOrDefault();
	    }

	}
}
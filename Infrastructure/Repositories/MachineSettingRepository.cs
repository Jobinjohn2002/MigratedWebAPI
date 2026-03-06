using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class MachineSettingRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public MachineSetting Get(int machineSettingId)
        {
            return Repository.Find(machineSetting => machineSetting.MachineSettingId == machineSettingId).FirstOrDefault();
        }

        public T ReadMachineSetting<T>(int machineId, string settingName)
        {
            return Settings.ReadGenericSetting<T, MachineSetting>(Repository.Find(ms => ms.MachineId == machineId && ms.Name == settingName).FirstOrDefault());
        }
    }
}
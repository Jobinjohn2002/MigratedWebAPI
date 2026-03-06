using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class MachineSettings
    {
        public const int DEFAULT_MAX_DRYING_TIME_MINS = 10080;//7 days

        public static int? EndoscopeSterileExpiryVacuumPackedDryMinutes(int machineId)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var machineSettingRepository = MachineSettingRepository.New(workUnit);

                return machineSettingRepository.ReadMachineSetting<int?>(machineId, KnownMachineSetting.EndoscopeSterileExpiryVacuumPackedDryMinutes);
            }
        }

        public static int? EndoscopeSterileExpiryVacuumPackedWetMinutes(int machineId)
        {
            {
                var machineSettingRepository = MachineSettingRepository.New(workUnit);
                return machineSettingRepository.ReadMachineSetting<int?>(machineId, KnownMachineSetting.EndoscopeSterileExpiryVacuumPackedWetMinutes);
            }
        }

        /// <summary>
        /// EndoscopeMaxDryingTimeOrDefault operation
        /// </summary>
        public static int EndoscopeMaxDryingTimeOrDefault(int machineId)
        {
            {
                var machineSettingRepository = MachineSettingRepository.New(workUnit);
                return machineSettingRepository.ReadMachineSetting<int?>(machineId, KnownMachineSetting.MaxDryingTime)
                        ?? DEFAULT_MAX_DRYING_TIME_MINS;
            }
        }
    }
}

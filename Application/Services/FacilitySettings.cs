using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class FacilitySettings
    {
        private const int CacheExpirationSeconds = 5;

        public static int DefaultSecurityTokenLifespanSeconds => 2100;//35mins

        /// <summary>
        /// Gets or sets CacheEnabled
        /// </summary>
        public static bool CacheEnabled { get; set; } = true;

        /// <summary>
        /// SecurityTokenLifespanSeconds operation
        /// </summary>
        public static int SecurityTokenLifespanSeconds(short facilityId)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
                return facilitySettingRepository.ReadFacilitySetting<int?>(facilityId, KnownFacilitySetting.SecurityTokenLifespanSeconds)
                        ?? DefaultSecurityTokenLifespanSeconds;
            }
        }

        /// <summary>
        /// ShowAuditWarningWhenAssigningToBatchTag operation
        /// </summary>
        public static bool ShowAuditWarningWhenAssigningToBatchTag(short facilityId)
        {
            {
                var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
                var facilitySetting = facilitySettingRepository.ReadFacilitySetting<bool?>(facilityId, KnownFacilitySetting.ShowAuditWarningAssigningToBatchTag);

                return facilitySetting ?? true;
            }
        }

        /// <summary>
        /// GetDeconAuditImmediateQuarantine operation
        /// </summary>
        public static bool GetDeconAuditImmediateQuarantine(short facilityId)
        {
            {
                var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
                var facilitySetting = facilitySettingRepository.ReadFacilitySetting<bool?>(facilityId, KnownFacilitySetting.DeconAuditImmediateQuarantine);

                return facilitySetting ?? false;
            }
        }

        /// <summary>
        /// IsAutoDispatchEnabled operation
        /// </summary>
        public static bool IsAutoDispatchEnabled(short facilityId)
        {
            {
                var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
                return facilitySettingRepository.ReadFacilitySetting<bool>(facilityId, KnownFacilitySetting.AutomaticDispatchEnabled);
            }
        }

        /// <summary>
        /// EndoscopeSterileExpiryAerPassedMinutes operation
        /// </summary>
        public static int EndoscopeSterileExpiryAerPassedMinutes(short facilityId)
        {
            return GetSettingOrDefault(KnownFacilitySetting.EndoscopeSterileExpiryAerPassedMinutes, 180, facilityId);
        }

        /// <summary>
        /// EndoscopeSterileExpiryRemovedFromDryingCabinetWetMinutes operation
        /// </summary>
        public static int EndoscopeSterileExpiryRemovedFromDryingCabinetWetMinutes(short facilityId)
        {
            return GetSettingOrDefault(KnownFacilitySetting.EndoscopeSterileExpiryRemovedFromDryingCabinetWetMinutes, 180, facilityId);
        }

        /// <summary>
        /// EndoscopeSterileExpiryRemovedFromDryingCabinetDryMinutes operation
        /// </summary>
        public static int EndoscopeSterileExpiryRemovedFromDryingCabinetDryMinutes(short facilityId)
        {
            return GetSettingOrDefault(KnownFacilitySetting.EndoscopeSterileExpiryRemovedFromDryingCabinetDryMinutes, 180, facilityId);
        }

        /// <summary>
        /// EndoscopeAboutToExpireWarningMinutes operation
        /// </summary>
        public static int EndoscopeAboutToExpireWarningMinutes(short facilityId)
        {
            return GetSettingOrDefault(KnownFacilitySetting.EndoscopeAboutToExpireWarningMinutes, 120, facilityId);
        }

        /// <summary>
        /// EndoscopeRemovedWetRelaxedExpiryRules operation
        /// </summary>
        public static bool EndoscopeRemovedWetRelaxedExpiryRules(short facilityId)
        {
            return GetSettingOrDefault(KnownFacilitySetting.EndoscopeRemovedWetRelaxedExpiryRules, false, facilityId);
        }

        /// <summary>
        /// IsSterileExpiryColumnEnabled operation
        /// </summary>
        public static bool IsSterileExpiryColumnEnabled(short facilityId)
        {
            return GetSettingOrDefault(KnownFacilitySetting.IsSterileExpiryColumnEnabled, false, facilityId);
        }

        /// <summary>
        /// RewashSupervisorApprovalRequired operation
        /// </summary>
        public static bool RewashSupervisorApprovalRequired(short facilityId) => GetSettingOrDefault(KnownFacilitySetting.RewashSupervisorApprovalRequired, false, facilityId);

        /// <summary>
        /// TrolleyDispatchAboutToExpireWarningMinutes operation
        /// </summary>
        public static int TrolleyDispatchAboutToExpireWarningMinutes(short facilityId)
        {
            return GetSettingOrDefault(KnownFacilitySetting.TrolleyDispatchAboutToExpireWarningMinutes, 120, facilityId);
        }

        /// <summary>
        /// AutoUpdateInstallerEnabled operation
        /// </summary>
        public static bool AutoUpdateInstallerEnabled(short facilityId) => GetSettingOrDefault(KnownFacilitySetting.AutoUpdateInstaller, SystemSettings.AutoUpdateInstaller, facilityId);

        /// <summary>
        /// ProductionManagerShowContractuallyEnded operation
        /// </summary>
        public static bool ProductionManagerShowContractuallyEnded(short facilityId) => GetSettingOrDefault(KnownFacilitySetting.ProductionManagerShowContractuallyEnded, false, facilityId);

        /// <summary>
        /// LoanSetAPIMinimumTrayReprocessingTimeMinutes operation
        /// </summary>
        public static int LoanSetAPIMinimumTrayReprocessingTimeMinutes(short facilityId) => GetSettingOrDefault(KnownFacilitySetting.LoanSetAPIMinimumTrayReprocessingTimeMinutes, 0, facilityId);

        /// <summary>
        /// AuditStationExceptions operation
        /// </summary>
        public static bool AuditStationExceptions(short facilityId) => GetSettingOrDefault(KnownFacilitySetting.AuditStationExceptions, false, facilityId);

        private static T GetSettingOrDefault<T>(string name, T defaultValue, short facilityId) where T : struct
        {
            if (CacheEnabled && CacheHelper.Get($"{facilityId.ToString()}{name}", out T cachedValue))
            {
                return cachedValue;
            }

            {
                var facilitySettingRepository = FacilitySettingRepository.New(workUnit);
                var result = facilitySettingRepository.ReadFacilitySetting<T?>(facilityId, name);
                if (result != null)
                {
                    defaultValue = (T)Convert.ChangeType(result, typeof(T));
                }
                if (CacheEnabled)
                {
                    CacheHelper.Add($"{facilityId.ToString()}{name}", defaultValue, CacheExpirationSeconds);
                }

                return defaultValue;
            }
        }
    }
}
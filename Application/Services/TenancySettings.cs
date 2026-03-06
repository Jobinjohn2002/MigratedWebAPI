using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class TenancySettings
    {
        /// <summary>
        /// GetPasswordAttemptsLimit operation
        /// </summary>
        public static int GetPasswordAttemptsLimit(int tenancyId)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<int?>(tenancyId, KnownTenancySetting.PasswordAttemptsLimit);

                return tenancySetting ?? 10;
            }
        }

        /// <summary>
        /// GetPasswordExpirationDays operation
        /// </summary>
        public static int GetPasswordExpirationDays(int tenancyId)
        {
            {
                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<int?>(tenancyId, KnownTenancySetting.PasswordExpirationTimeDays);

                return tenancySetting ?? 90;
            }
        }

        /// <summary>
        /// GetPasswordPreviousToCheck operation
        /// </summary>
        public static int GetPasswordPreviousToCheck(int tenancyId)
        {
            {
                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<int?>(tenancyId, KnownTenancySetting.PasswordPreviousToCheck);

                return tenancySetting ?? 3;
            }
        }

        /// <summary>
        /// GetPasswordResetEmailTokenExpiryMinutes operation
        /// </summary>
        public static int GetPasswordResetEmailTokenExpiryMinutes(int tenancyId)
        {
            {
                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<int?>(tenancyId, KnownTenancySetting.Reset_Password_Email_Token_Expiry);

                return tenancySetting ?? 1440;
            }
        }

        /// <summary>
        /// GetForgotPasswordEmailExpiryMinutes operation
        /// </summary>
        public static int GetForgotPasswordEmailExpiryMinutes(int tenancyId)
        {
            {
                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<int?>(tenancyId, KnownTenancySetting.Forgotten_Password_Email_Token_Expiry);

                return tenancySetting ?? 15;
            }
        }

        /// <summary>
        /// GetStockTransferCustomerGroupEnabled operation
        /// </summary>
        public static bool GetStockTransferCustomerGroupEnabled(int tenancyId)
        {
            {
                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<bool?>(tenancyId, KnownTenancySetting.EPODStockTransferCustomerGroupEnabled);

                return tenancySetting ?? true;
            }
        }

        /// <summary>
        /// HaveIBeenPwnedCheck operation
        /// </summary>
        public static int HaveIBeenPwnedCheck(int tenancyId)
        {
            {
                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<int?>(tenancyId, KnownTenancySetting.HaveIBeenPwnedCheck);

                return tenancySetting ?? 0;
            }
        }

        /// <summary>
        /// HaveIBeenPwnedBreachCountTolerance operation
        /// </summary>
        public static int HaveIBeenPwnedBreachCountTolerance(int tenancyId)
        {
            {
                var tenancySettingRepository = TenancySettingRepository.New(workUnit);
                var tenancySetting = tenancySettingRepository.ReadTenancySetting<int?>(tenancyId, KnownTenancySetting.HaveIBeenPwnedCheckBreachCountTolerance);

                return tenancySetting ?? 1;
            }
        }
    }
}

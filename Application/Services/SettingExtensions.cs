using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class SettingExtensions
    {
        /// <summary>
        /// Tries to convert the SystemSetting value to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert the value to</typeparam>
        /// <param name="setting">The setting to convert the value of</param>
        /// <param name="value">The output value parameter</param>
        /// <returns>True if successfully converted, otherwise false.</returns>
        public static bool TryGetValue<T>(this SystemSetting setting, out T value)
        {
            return DoTryGetValue<T>(setting == null ? null : setting.Value, (KnownSettingType)setting?.Type, out value);
        }

        /// <summary>
        /// Tries to convert the CustomerSetting value to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert the value to</typeparam>
        /// <param name="setting">The setting to convert the value of</param>
        /// <param name="value">The output value parameter</param>
        /// <returns>True if successfully converted, otherwise false.</returns>
        public static bool TryGetValue<T>(this CustomerSetting setting, out T value)
        {
            return DoTryGetValue<T>(setting == null ? null : setting.Value, (KnownSettingType)setting?.Type, out value);
        }

        /// <summary>
        /// Tries to convert the DeliveryPointSetting value to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert the value to</typeparam>
        /// <param name="setting">The setting to convert the value of</param>
        /// <param name="value">The output value parameter</param>
        /// <returns>True if successfully converted, otherwise false.</returns>
        public static bool TryGetValue<T>(this DeliveryPointSetting setting, out T value)
        {
            return DoTryGetValue<T>(setting == null ? null : setting.Value, (KnownSettingType)setting?.Type, out value);
        }

        /// <summary>
        /// Tries to convert the TenancySetting value to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert the value to</typeparam>
        /// <param name="setting">The setting to convert the value of</param>
        /// <param name="value">The output value parameter</param>
        /// <returns>True if successfully converted, otherwise false.</returns>
        public static bool TryGetValue<T>(this TenancySetting setting, out T value)
        {
            return DoTryGetValue<T>(setting == null ? null : setting.Value, (KnownSettingType)setting?.Type, out value);
        }

        /// <summary>
        /// Tries to convert the FacilitySetting value to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert the value to</typeparam>
        /// <param name="setting">The setting to convert the value of</param>
        /// <param name="value">The output value parameter</param>
        /// <returns>True if successfully converted, otherwise false.</returns>
        public static bool TryGetValue<T>(this FacilitySetting setting, out T value)
        {
            return DoTryGetValue<T>(setting == null ? null : setting.Value, (KnownSettingType)setting?.Type, out value);
        }

        /// <summary>
        /// Tries to convert the OwnerSetting value to the specified type
        /// </summary>
        /// <typeparam name="T">The type to convert the value to</typeparam>
        /// <param name="setting">The setting to convert the value of</param>
        /// <param name="value">The output value parameter</param>
        /// <returns>True if successfully converted, otherwise false.</returns>
        public static bool TryGetValue<T>(this OwnerSetting setting, out T value)
        {
            return DoTryGetValue<T>(setting == null ? null : setting.Value, (KnownSettingType)setting?.Type, out value);
        }

        private static bool DoTryGetValue<T>(string str, KnownSettingType type, out T value)
        {
            value = default(T);

            if (str == null)
                return false;

            try
            {
                value = (T)Convert.ChangeType(str, typeof(T));

                return true;
            }
            catch (Exception ex)
            {
                var e = new InvalidOperationException("Unable to convert value {0} to type {1}, setting type is {2}".FormatWith(str ?? "(null)", typeof(T).Name, type), ex);

                Kernel.Log(e);

                return false;
            }
        }
    }
}

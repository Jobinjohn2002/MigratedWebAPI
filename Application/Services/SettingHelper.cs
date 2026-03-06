using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class SettingHelper
    {
        private static T GetSetting<T>(string key)
        {
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[Key.AppSetting + key], typeof(T));
        }

        private static T GetSettingOrDefault<T>(string key)
        {
            var value = ConfigurationManager.AppSettings[Key.AppSetting + key];
            if (value == null)
            {
                return default(T);
            }
            else
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
        }

        public static bool ErrorLogging => GetSetting<bool>("ErrorLogging");

        public static string ErrorPath => GetSetting<string>("ErrorPath");

        public static string ErrorApplicationName => GetSetting<string>("ErrorApplicationName");

        public static string SmtpHost => GetSetting<string>("SmtpHost");

        public static int SmtpPort => GetSetting<int>("SmtpPort");

        public static string LoginUrl => GetSetting<string>("LoginUrl");

        public static string AccessDeniedUrl => GetSetting<string>("AccessDeniedUrl");

        public static bool Impersonate => GetSettingOrDefault<bool>("Impersonate");

        public static string ImpersonateUsername => GetSettingOrDefault<string>("ImpersonateUsername");

        public static string ImpersonatePassword => GetSettingOrDefault<string>("ImpersonatePassword");

        public static string ReportServerUsername => GetSettingOrDefault<string>("ReportServerUsername");

        public static string ReportServerPassword => GetSettingOrDefault<string>("ReportServerPassword");

        public static int BuildVersion => GetSettingOrDefault<int>("BuildVersion");

        /// <summary>
        /// PermissionId
        /// </summary>
        public class PermissionId
        {
            public static int GlobalAdministrator => GetSetting<int>("PermissionId.GlobalAdministrator");

            public static int ApplicationAdministrator => GetSetting<int>("PermissionId.ApplicationAdministrator");

            public static int VendorCatalogueApplicationAdministrator => GetSetting<int>("PermissionId.VendorCatalogueApplicationAdministrator");

            public static int VendorApplicationUser => GetSetting<int>("PermissionId.VendorApplicationUser");
            public static int ApplicationUser => GetSetting<int>("PermissionId.ApplicationUser");
        }

        /// <summary>
        /// Gets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public static string ItemImageUrl => GetSettingOrDefault<string>("ItemImageUrl");

        /// <summary>
        /// Gets the UploadFileSize.
        /// </summary>
        /// <value>
        /// The UploadFileSize.
        /// </value>
        public static string MaxAlowedFileNameLength => GetSettingOrDefault<string>("MaxAlowedFileNameLength");

        /// <summary>
        /// Gets the UploadFileSize.
        /// </summary>
        /// <value>
        /// The UploadFileSize.
        /// </value>
        public static int ImagePageCount => GetSettingOrDefault<int>("ImagePageCount");

        /// <summary>
        /// Gets the UploadFileSize.
        /// </summary>
        /// <value>
        /// The UploadFileSize.
        /// </value>
        public static string MaxUploadAllowedFileSize => GetSettingOrDefault<string>("UploadFileSize");

        /// <summary>
        /// Gets the Upload File Max Count.
        /// </summary>
        /// <value>
        /// The UploadFileSize.
        /// </value>
        public static string MaxUploadAllowedFileCount => GetSettingOrDefault<string>("UploadFileCount");

        /// <summary>
        /// Gets the Upload File Max Count.
        /// </summary>
        /// <value>
        /// The UploadFileSize.
        /// </value>
        public static string UploadFileInvalidCharacters => GetSettingOrDefault<string>("UploadFileInvalidCharacters");

        public static string SupportedFileTypes => GetSettingOrDefault<string>("SupportedFileTypes");

        public static string MaintenanceSupportedFileTypes => GetSettingOrDefault<string>("MaintenanceSupportedFileTypes");

        public static bool IsSterileLinen => GetSettingOrDefault<bool>("SterileLinen");

        public static string ReportStaticUrl => GetSetting<string>("ReportStaticUrl");

        public static int LogoutTimeout => GetSettingOrDefault<int>("LogoutTimeout");

        public static string PressureUnits => GetSetting<string>("PressureUnits");

        public static string TemperatureUnits => GetSetting<string>("TemperatureUnits");

        public static string SmallWeightUnits => GetSetting<string>("SmallWeightUnits");

        public static string LargeWeightUnits => GetSetting<string>("LargeWeightUnits");

        public static bool IsDemoFunctionalityEnabled => GetSettingOrDefault<bool>("IsDemoFunctionalityEnabled");

        public static string FinanceUrl => GetSettingOrDefault<string>("FinanceUrl");

        public static string ReportsUsername => GetSettingOrDefault<string>("ReportsUsername");

        public static string ReportsPassword => GetSettingOrDefault<string>("ReportsPassword");
    }
}

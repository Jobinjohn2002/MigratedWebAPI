using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class SystemSettings
    {
        /// <summary>
        /// Gets or sets SystemSettingName
        /// </summary>
        public static string SystemSettingName { get; set; }

        private static SystemSetting LoadSetting(string systemSettingName)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                return new SystemSettingRepository(workUnit).GetSetting(systemSettingName);
            }

        }

        public static void SetSystemSetting<T>(string name, T value)
        {
            {
                var repository = new SystemSettingRepository(workUnit);

                var systemSetting = repository.GetSetting(name);
                if (systemSetting != null)
                {
                    systemSetting.Value = value.ToString();
                    repository.Save();
                }
            }
        }

        public static T GetSettingOrDefault<T>(string name, T defaultValue)
        {
            if (CacheHelper.Get(name, out T cachedValue))
            {
                return cachedValue;
            }
            else
            {
                var expiration = LoadSetting(KnownSystemSetting.SlidingCacheExpirationSeconds);
                var expirationSeconds = int.Parse(expiration?.Value ?? "60");

                var setting = LoadSetting(name);

                if (setting != null)
                {
                    var typeConverter = TypeDescriptor.GetConverter(typeof(T));
                    if (typeConverter != null && typeConverter.CanConvertFrom(typeof(string)))
                    {
                        try
                        {
                            T databaseValue = (T)typeConverter.ConvertFrom(setting.Value);
                            CacheHelper.Add(name, databaseValue, expirationSeconds);
                            return databaseValue;
                        }
                        catch
                        {
                            Synergy.Core.Kernel.Log($"Exception converting value {setting.Value} to Type {typeConverter.GetType().Name} for setting {name}");
                        }
                    }
                }

                CacheHelper.Add(name, defaultValue, expirationSeconds);
                return defaultValue;
            }
        }

        #region System Settings

        public static int CurrentScriptRevision
        {
            get { return GetSettingOrDefault<int>(KnownSystemSetting.ScriptVersion, 0); }
        }

        public static int CurrentStyleRevision
        {
            get { return GetSettingOrDefault<int>(KnownSystemSetting.StyleVersion, 0); }
        }

        public static string PortalSite
        {
            get { return GetSettingOrDefault(KnownSystemSetting.PortalSite, ""); }
        }

        public static string PortalPrefix
        {
            get { return GetSettingOrDefault(KnownSystemSetting.PortalPrefix, ""); }
        }

        public static string ContainerInstanceShortIdentifierPrefix
        {
            get { return GetSettingOrDefault(KnownSystemSetting.ContainerInstanceShortIdentifierPrefix, ""); }
        }

        #endregion

        #region Reporting Settings

        public static string ReportServiceLogonDomain
        {
            get { return GetSettingOrDefault(KnownSystemSetting.SSRSLogonDomain, "sts-synergy.co.uk"); }
        }

        public static string ReportServiceDomain
        {
            get { return GetSettingOrDefault(KnownSystemSetting.SSRSDomain, "sts-synergy"); }
        }

        public static string ReportServiceLogonUser
        {
            get { return GetSettingOrDefault(KnownSystemSetting.SSRSLogonUser, "svc_tsv5reporting"); }
        }

        public static string ReportServerPassword
        {
            get { return GetSettingOrDefault(KnownSystemSetting.ReportServerPassword, "Tr@K$t4rV5"); }
        }

        public static string ReportsUsername
        {
            get { return GetSettingOrDefault(KnownSystemSetting.SSRSReportUserName, @"sts-synergy.co.uk\svc_tsv5reporting"); }
        }

        public static string ReportBaseUrl
        {
            get { return GetSettingOrDefault<string>(KnownSystemSetting.SSRSBaseUrl, ""); }
        }

        public static string ReportApplicationBaseUrl
        {
            get { return GetSettingOrDefault<string>(KnownSystemSetting.SSRSApplicationBaseUrl, ""); }
        }

        public static string SystemReportPath
        {
            get { return GetSettingOrDefault<string>(KnownSystemSetting.SSRSReportPath, ""); }
        }

        public static string ReportFromEmail
        {
            get { return GetSettingOrDefault<string>(KnownSystemSetting.SSRSReportFromEmail, "no-reply@synergytrak.com"); }
        }

        public static string TableauServerTrustedUrl
        {
            get { return GetSettingOrDefault(KnownSystemSetting.TableauServerTrustedUrl, ""); }
        }

        public static bool TableauJavascriptReports
        {
            get { return GetSettingOrDefault(KnownSystemSetting.TableauJavascriptReports, false); }
        }

        public static string TableauConnectionString
        {
            get { return GetSettingOrDefault(KnownSystemSetting.TableauConnectionString, (string)null); }
        }

        #endregion

        #region File System Settings

        public static string DocumentFileStore
        {
            get { return GetSettingOrDefault<string>(KnownSystemSetting.DocumentFileStore, ""); }
        }

        public static string LogsDirectory
        {
            get { return GetSettingOrDefault<string>(KnownSystemSetting.SynergyTrakLogsDirectory, ""); }
        }

        public static int SynergyTrakLogsRetentionDays
        {
            get { return GetSettingOrDefault<int>(KnownSystemSetting.SynergyTrakLogsRetentionDays, 365); }
        }

        public static string PrintHistoryFileStore
        {
            get { return $"{DocumentFileStore}\\Print"; }
        }

        #endregion

        #region Email Settings

        public static int SMTPPort
        {
            get { return GetSettingOrDefault(KnownSystemSetting.SMTPPort, 25); }
        }

        public static string SMTPHost
        {
            get { return GetSettingOrDefault(KnownSystemSetting.SMTPHost, "smtp.sts-synergy.co.uk"); }
        }

        public static string DefaultFromEmailAddress
        {
            get
            {
                return GetSettingOrDefault(KnownSystemSetting.DefaultFromEmailAddress, "noreply@synergytrak.com");
            }
        }
        #endregion

        #region PasswordAudit Settings

        public static int GetPasswordLockoutRetryMins
        {
            get { return GetSettingOrDefault(KnownSystemSetting.PasswordLockoutRetryMins, 15); }

        }

        #endregion

        #region SynergyTrak Settings

        public static int DynamicDataRefreshSeconds => GetSettingOrDefault(KnownSystemSetting.DynamicDataRefreshSeconds, 300);

        public static int StaticDataRefreshSeconds => GetSettingOrDefault(KnownSystemSetting.StaticDataRefreshSeconds, 3600);

        public static int UserPermissionRefreshSeconds => GetSettingOrDefault(KnownSystemSetting.UserPermissionRefreshSeconds, 300);

        public static int UserFacilityRefreshSeconds => GetSettingOrDefault(KnownSystemSetting.UserFacilityRefreshSeconds, 300);

        public static bool AutoUpdateInstaller => GetSettingOrDefault(KnownSystemSetting.AutoUpdateInstaller, false);

        public static bool AutoUpdateOperative => GetSettingOrDefault(KnownSystemSetting.AutoUpdateOperative, true);

        public static bool ValidateRequestHmac => GetSettingOrDefault(KnownSystemSetting.ValidateRequestHmac, true);

        #endregion
    }
}

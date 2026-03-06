using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class DateTimeExtensions
    {
        #region Properties

        private static readonly DateTime JavascriptEpoc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly IAccountService AccountService = InstanceFactory.GetInstance<IAccountService>();

        #endregion

        #region User TimeZone Functions

        private static User GetUserInfo()
        {
            return AccountService.RetrieveUser();
        }

        /// <summary>
        /// GetLocalDateTime operation
        /// </summary>
        public static DateTime GetLocalDateTime(this DateTime date, Synergy.Data.TimeZone timeZone)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone.Text);
            return TimeZoneInfo.ConvertTimeFromUtc(new DateTime(date.Ticks, DateTimeKind.Utc), timeZoneInfo);
        }

        public static DateTime? GetLocalDateTime(this DateTime? date, Synergy.Data.TimeZone timeZone)
        {
            return date == null ? (DateTime?)null : GetLocalDateTime(date.Value, timeZone);
        }

        /// <summary>
        /// GetLocalDateTime operation
        /// </summary>
        public static DateTime GetLocalDateTime(this DateTime date, User user)
        {
            return GetLocalDateTime(date, user.TimeZone);
        }

        public static DateTime? GetLocalDateTime(this DateTime? date, User user)
        {
            return date == null ? (DateTime?)null : GetLocalDateTime(date.Value, user);
        }

        #endregion

        #region Short DateTime Functions

        /// <summary>
        /// ToLocalShortDate operation
        /// </summary>
        public static string ToLocalShortDate(this DateTime date)
        {
            var user = GetUserInfo();
            var localDateTime = date.GetLocalDateTime(user);
            var format = user.DateTimeFormat.ShortDateFormat.Text;

            return localDateTime.ToString(format);
        }

        /// <summary>
        /// ToLocalShortDate operation
        /// </summary>
        public static string ToLocalShortDate(this DateTime date, User user)
        {
            var localDateTime = date.GetLocalDateTime(user);
            var format = user.DateTimeFormat.ShortDateFormat.Text;

            return localDateTime.ToString(format);
        }

        /// <summary>
        /// ToLocalShortDate operation
        /// </summary>
        public static string ToLocalShortDate(this DateTime? date)
        {
            return date == null ? string.Empty : ToLocalShortDate(date.Value);
        }

        /// <summary>
        /// ToLocalShortTime operation
        /// </summary>
        public static string ToLocalShortTime(this DateTime date)
        {
            var user = GetUserInfo();
            var localDateTime = date.GetLocalDateTime(user);
            var format = user.DateTimeFormat.ShortTimeFormat.Text;

            return localDateTime.ToString(format);
        }

        /// <summary>
        /// ToLocalShortTime operation
        /// </summary>
        public static string ToLocalShortTime(this DateTime? date)
        {
            return date == null ? string.Empty : ToLocalShortTime(date.Value);
        }

        /// <summary>
        /// ToLocalShortDateTime operation
        /// </summary>
        public static string ToLocalShortDateTime(this DateTime date)
        {
            var user = GetUserInfo();
            var localDateTime = date.GetLocalDateTime(user);
            var timeFormat = user.DateTimeFormat.ShortTimeFormat.Text;
            var dateFormat = user.DateTimeFormat.ShortDateFormat.Text;

            return localDateTime.ToString("{0} {1}".FormatWith(dateFormat, timeFormat));
        }

        /// <summary>
        /// ToLocalShortDateTime operation
        /// </summary>
        public static string ToLocalShortDateTime(this DateTime date, User user)
        {
            var localDateTime = date.GetLocalDateTime(user);
            var timeFormat = user.DateTimeFormat.ShortTimeFormat.Text;
            var dateFormat = user.DateTimeFormat.ShortDateFormat.Text;

            return localDateTime.ToString("{0} {1}".FormatWith(dateFormat, timeFormat));
        }

        /// <summary>
        /// ToLocalShortDateTime operation
        /// </summary>
        public static string ToLocalShortDateTime(this DateTime? date)
        {
            return date == null ? string.Empty : ToLocalShortDateTime(date.Value);
        }

        /// <summary>
        /// ToShortDateNoTimeshift operation
        /// </summary>
        public static string ToShortDateNoTimeshift(this DateTime date)
        {
            var user = GetUserInfo();
            var dateFormat = user.DateTimeFormat.ShortDateFormat.Text;

            return date.ToString("{0}".FormatWith(dateFormat));
        }

        /// <summary>
        /// ToLongDateNoTimeshift operation
        /// </summary>
        public static string ToLongDateNoTimeshift(this DateTime date)
        {
            var user = GetUserInfo();
            var dateFormat = user.DateTimeFormat.LongDateFormat.Text;

            return date.ToString("{0}".FormatWith(dateFormat));
        }

        /// <summary>
        /// ToShortDateTimeNoTimeshift operation
        /// </summary>
        public static string ToShortDateTimeNoTimeshift(this DateTime date)
        {
            var user = GetUserInfo();

            var timeFormat = user.DateTimeFormat.ShortTimeFormat.Text;
            var dateFormat = user.DateTimeFormat.ShortDateFormat.Text;

            return date.ToString("{0} {1}".FormatWith(dateFormat, timeFormat));

        }

        #endregion

        #region Long DateTime Functions

        /// <summary>
        /// ToLocalLongDate operation
        /// </summary>
        public static string ToLocalLongDate(this DateTime date)
        {
            var user = GetUserInfo();
            var localDateTime = date.GetLocalDateTime(user);
            var format = user.DateTimeFormat.LongDateFormat.Text;

            return localDateTime.ToString(format);
        }

        /// <summary>
        /// ToLocalLongDate operation
        /// </summary>
        public static string ToLocalLongDate(this DateTime? date)
        {
            return date == null ? string.Empty : ToLocalLongDate(date.Value);
        }

        /// <summary>
        /// ToLocalLongTime operation
        /// </summary>
        public static string ToLocalLongTime(this DateTime date)
        {
            var user = GetUserInfo();
            var localDateTime = date.GetLocalDateTime(user);
            var format = user.DateTimeFormat.LongTimeFormat.Text;

            return localDateTime.ToString(format);
        }

        /// <summary>
        /// ToLocalLongTime operation
        /// </summary>
        public static string ToLocalLongTime(this DateTime? date)
        {
            return date == null ? string.Empty : ToLocalLongTime(date.Value);
        }

        /// <summary>
        /// ToLocalLongDateTime operation
        /// </summary>
        public static string ToLocalLongDateTime(this DateTime date)
        {
            var user = GetUserInfo();
            var localDateTime = date.GetLocalDateTime(user);
            var timeFormat = user.DateTimeFormat.LongTimeFormat.Text;
            var dateFormat = user.DateTimeFormat.LongDateFormat.Text;

            return localDateTime.ToString("{0} {1}".FormatWith(dateFormat, timeFormat));
        }

        /// <summary>
        /// ToLocalLongDateTime operation
        /// </summary>
        public static string ToLocalLongDateTime(this DateTime? date)
        {
            return date == null ? string.Empty : ToLocalLongDateTime(date.Value);
        }

        #endregion

        #region Other Functions

        /// <summary>
        /// Next operation
        /// </summary>
        public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
        {
            var start = (int)from.DayOfWeek;
            var target = (int)dayOfWeek;
            if (target <= start)
                target += 7;
            return from.AddDays(target - start);
        }

        /// <summary>
        /// Previous operation
        /// </summary>
        public static DateTime Previous(this DateTime from, DayOfWeek dayOfWeek)
        {
            var start = (int)from.DayOfWeek;
            var target = (int)dayOfWeek;
            if (target >= start)
                target -= 7;
            return from.AddDays(target - start);
        }

        public static long? ToJavascriptTicks(this DateTime? date)
        {
            if (date == null)
                return null;

            return ToJavascriptTicks(date.Value);
        }

        /// <summary>
        /// ToJavascriptTicks operation
        /// </summary>
        public static long ToJavascriptTicks(this DateTime date)
        {
            var user = GetUserInfo();
            return (date.GetLocalDateTime(user).Ticks - JavascriptEpoc.Ticks) / 10000;
        }

        /// <summary>
        /// ToJavascriptDateNoTimeshiftTicks operation
        /// </summary>
        public static long ToJavascriptDateNoTimeshiftTicks(this DateTime date)
        {
            return (date.Ticks - JavascriptEpoc.Ticks) / 10000;
        }

        #endregion
    }
}

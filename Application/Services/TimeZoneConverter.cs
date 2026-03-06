using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class TimeZoneConverter
    {
        /// <summary>
        /// GetDateTime operation
        /// </summary>
        public static DateTime GetDateTime(object propValue, SynergyDateTimeDisplayFormat type, DateTime dateTime, IDateFormater setting)
        {
            if (propValue != null)
            {
                switch (type)
                {
                    case SynergyDateTimeDisplayFormat.LongDate:
                    case SynergyDateTimeDisplayFormat.ShortDate:

                        DateTime.TryParseExact(propValue.ToString().Trim(), setting.GetFormat(type), CultureInfo.CurrentUICulture,
                                               DateTimeStyles.None, out dateTime);
                        break;
                    case SynergyDateTimeDisplayFormat.LongTime:
                    case SynergyDateTimeDisplayFormat.ShortTime:

                        if (DateTime.TryParseExact(propValue.ToString(), setting.GetFormat(type), CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
                        {
                            dateTime = dateTime.Add(time - time.Date);
                        }

                        break;
                }
            }
            return dateTime;
        }

        /// <summary>
        /// ToLocalTime operation
        /// </summary>
        public static DateTime ToLocalTime(this DateTime dateTime, string timeZone)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeFromUtc(new DateTime(dateTime.Ticks, DateTimeKind.Utc), timeZoneInfo);
        }

        /// <summary>
        /// ToUniversalTime operation
        /// </summary>
        public static DateTime ToUniversalTime(this DateTime dateTime, string timeZone)
        {
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZoneInfo);
        }

        /// <summary>
        /// GetTimeDifference operation
        /// </summary>
        public static string GetTimeDifference(string timeZoneId)
        {
            var now = DateTimeOffset.UtcNow;
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var userTimeZone = timeZoneInfo.GetUtcOffset(now);
            return string.Format("{0}:{1}", userTimeZone.Hours, userTimeZone.Minutes);
        }

        /// <summary>
        /// GetTimeSpan operation
        /// </summary>
        public static short GetTimeSpan(string timeZoneId)
        {
            var now = DateTimeOffset.UtcNow;
            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            var userTimeZone = timeZoneInfo.GetUtcOffset(now);
            return (short)((userTimeZone.Hours * 60) + userTimeZone.Minutes);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class DateTimeConversionHelper
    {
        /// <summary>
        /// Convert UTC to Prefered Datetime.
        /// </summary>
        /// <param name="utcDateTime"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        /// <summary>
        /// ConvertUTCtoPreferedDate operation
        /// </summary>
        public static DateTime ConvertUTCtoPreferedDate(this DateTime utcDateTime, string timeZone)
        {
            TimeZoneInfo userTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            DateTime utcStart = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Unspecified);
            return TimeZoneInfo.ConvertTimeFromUtc(utcStart, userTimeZoneInfo);
        }

        /// <summary>
        /// Convert Prefered to UTC Datetime.
        /// </summary>
        /// <param name="preferedDateTime"></param>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        /// <summary>
        /// ConvertPreferedtoUTCDate operation
        /// </summary>
        public static DateTime ConvertPreferedtoUTCDate(this DateTime preferedDateTime, string timeZone)
        {
            TimeZoneInfo userTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
            return TimeZoneInfo.ConvertTimeToUtc(preferedDateTime, userTimeZoneInfo);
        }

        /// <summary>
        /// Get Prefered DateTime Format.
        /// </summary>
        /// <param name="preferedDateTime"></param>
        /// <param name="preferedFormat"></param>
        /// <returns></returns>
        /// <summary>
        /// PreferedDateTimeFormat operation
        /// </summary>
        public static string PreferedDateTimeFormat(this DateTime preferedDateTime, string preferedFormat)
        {            
            var validatedFormat = preferedFormat.Replace("/", "'/'");
            return preferedDateTime.ToString(validatedFormat);
        }

    }
}

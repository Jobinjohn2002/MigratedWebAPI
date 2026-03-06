using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class BootstrapExtensions
    {
        /// <summary>
        /// ToBootstrapDate operation
        /// </summary>
        public static string ToBootstrapDate(this DateTime date)
        {
            return date.ToString(GetBootstrapDateFormat(date));
        }

        /// <summary>
        /// GetBootstrapDateFormat operation
        /// </summary>
        public static string GetBootstrapDateFormat(this DateTime date)
        {
            return CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;
        }

        /// <summary>
        /// GetBootstrapTimeFormat operation
        /// </summary>
        public static string GetBootstrapTimeFormat(this DateTime date)
        {
            return CultureInfo.CurrentUICulture.DateTimeFormat.ShortTimePattern;
        }

        /// <summary>
        /// GetBootstrapFullDateTimeFormat operation
        /// </summary>
        public static string GetBootstrapFullDateTimeFormat(this DateTime date)
        {
            return CultureInfo.CurrentUICulture.DateTimeFormat.FullDateTimePattern;
        }
    }
}
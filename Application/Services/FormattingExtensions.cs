using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class FormattingExtensions
    {
        /// <summary>
        /// Truncate operation
        /// </summary>
        public static string Truncate(this string value, int maxChars)
        {
            return value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
        }

        /// <summary>
        /// ToBase64 operation
        /// </summary>
        public static string ToBase64(this string textToConvert)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(textToConvert));
        }

        /// <summary>
        /// FromBase64 operation
        /// </summary>
        public static string FromBase64(this string textToConvert)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(textToConvert));
        }
    }
}
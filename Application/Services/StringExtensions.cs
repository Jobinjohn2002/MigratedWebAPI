using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class StringExtensions
    {
        /// <summary>
        /// JsEncode operation
        /// </summary>
        public static string JsEncode(this string str, bool encloseInDoubleQuotes = false)
        {
            return HttpUtility.JavaScriptStringEncode(str, encloseInDoubleQuotes);
        }

        /// <summary>
        /// XmlEscape operation
        /// </summary>
        public static string XmlEscape(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return SecurityElement.Escape(str);
        }
    }
}

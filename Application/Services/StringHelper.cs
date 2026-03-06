using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class StringHelper
    {
        /// <summary>
        /// Pluralise operation
        /// </summary>
        public static string Pluralise(string value)
        {
            if (value.EndsWith("s") || value.EndsWith("x") || value.EndsWith("ch") || value.EndsWith("sh")) // sibilants
            {
                return value + "es";
            }
            else if (value.EndsWith("y")) // y after consonant
            {
                return value.Substring(0, value.Length - 1) + "ies";
            }
            else
            {
                return value + "s";
            }
        }

        /// <summary>
        /// CamelCase operation
        /// </summary>
        public static string CamelCase(string value)
        {
            if (value == null)
            {
                return null;
            }
            else if (value.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return value[0].ToString().ToLower() + value.Substring(1);
            }
        }

        /// <summary>
        /// TitleCase operation
        /// </summary>
        public static string TitleCase(string value)
        {
            if (value == null)
            {
                return null;
            }
            else if (value.Length == 0)
            {
                return string.Empty;
            }
            else
            {
                return value[0].ToString().ToUpper() + value.Substring(1);
            }
        }

        /// <summary>
        /// ToSimpleFormatString operation
        /// </summary>
        public static string ToSimpleFormatString(string formatString)
        {
            return ToSimpleFormatString(formatString, false);
        }

        /// <summary>
        /// ToSimpleFormatString operation
        /// </summary>
        public static string ToSimpleFormatString(string formatString, bool removeSlashes)
        {
            if (formatString != null)
            {
                var simpleFormat = Regex.Match(formatString, @"{0:(.*)}").Groups[1].Value;
                if (removeSlashes)
                {
                    simpleFormat = simpleFormat.Replace("\\", null);
                }
                return simpleFormat;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Xml 
        /// </summary>
        /// <param name="str"></param>
        /// <summary>
        /// XmlEscape operation
        /// </summary>
        public static string XmlEscape(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            return SecurityElement.Escape(str);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class HmacWrapper
    {
        private static readonly string Secret = ConfigurationManager.AppSettings["HmacSecret"];

        /// <summary>
        /// Encode operation
        /// </summary>
        public static string Encode(string clearText, TimeSpan expiry)
        {
            return Hmac.Encode(clearText, expiry, Secret);
        }

        /// <summary>
        /// Verify operation
        /// </summary>
        public static HmacResult Verify(string clearText, string encodedText)
        {
            return Hmac.Verify(clearText, encodedText, Secret);
        }
    }
}
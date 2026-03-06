using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class LegacyEncryptionHelper
    {
        /// <summary>
        /// LegacyEncrypt operation
        /// </summary>
        public static string LegacyEncrypt(string input)
        {
            if (input == null)
            {
                return null;
            }
            else
            {
                var cryptoServiceProvider = new MD5CryptoServiceProvider();
                var hashData = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(input));
                var result = new StringBuilder();
                foreach (var data in hashData)
                {
                    result.Append(data.ToString("x2").ToLower());
                }
                return result.ToString();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ConversionHelper
    {
        /// <summary>
        /// Convert ToBase N.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nbase"></param>
        /// <returns></returns>
        /// <summary>
        /// ConvertToBaseN operation
        /// </summary>
        public static string ConvertToBaseN(int id, int nbase)
        {
            string chars = "0123456789BCDFGHJKLMNPQRSTVWXYZ";
            if (nbase < 2 || nbase > chars.Length)
                return "";

            int r;
            string baseId = "";

            while (id >= nbase)
            {
                r = id % nbase;
                baseId = chars[r] + baseId;
                id = id / nbase;
            }

            baseId = chars[id] + baseId;

            return baseId;
        }
    }
}

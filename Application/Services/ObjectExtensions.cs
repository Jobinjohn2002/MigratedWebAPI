using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// ToJson operation
        /// </summary>
        public static string ToJson(this object obj)
        {
            return Json.Encode(obj);
        }
    }
}

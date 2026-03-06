using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// PrintLog
    /// </summary>
    public class PrintLog
    {
        /// <summary>
        /// Log operation
        /// </summary>
        public static void Log(string method, string message)
        {
            Debug.WriteLine(string.Format("{0:00}:{1:00}:{2:00}:{3:000}[PrintUtility.{4}] {5}", DateTime.UtcNow.Hour, DateTime.UtcNow.Minute, DateTime.UtcNow.Second, DateTime.UtcNow.Millisecond, method, message));
        }
    }
}

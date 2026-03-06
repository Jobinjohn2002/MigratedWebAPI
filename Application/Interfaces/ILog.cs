using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ILog
    /// </summary>
    public interface ILog
    {
        void Info(string data);

        void Exception(Exception ex, string data);

        void WriteLog(string logon, List<LogDataContract> logs);
        void WriteLog(string logon, bool backgroundSvcCall = false);
    }
}

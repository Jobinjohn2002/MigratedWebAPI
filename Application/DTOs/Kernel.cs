using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Log Level enumeration
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Debug information
        /// </summary>
        Debug,
        /// <summary>
        /// Trace information
        /// </summary>
        Information,
        /// <summary>
        /// Warning
        /// </summary>
        Warning,
        /// <summary>
        /// Error
        /// </summary>
        Error
    }

    public static class Kernel
    {
        private static readonly TraceSource Source = new TraceSource("Pathway");

        /// <summary>
        /// Records a log entry
        /// </summary>
        /// <param name="message">The log message</param>
        /// <param name="level">The log level</param>
        /// <summary>
        /// Log operation
        /// </summary>
        public static void Log(string message, LogLevel level = LogLevel.Debug)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    Source.TraceEvent(TraceEventType.Verbose, 4, message);
                    break;

                case LogLevel.Error:
                    Source.TraceEvent(TraceEventType.Error, 1, message);
                    break;

                case LogLevel.Information:
                    Source.TraceEvent(TraceEventType.Information, 3, message);
                    break;

                case LogLevel.Warning:
                    Source.TraceEvent(TraceEventType.Warning, 2, message);
                    break;
            }

            Source.Flush();
        }

        /// <summary>
        /// Logs an entry
        /// </summary>
        /// <param name="ex">The exception to log</param>
        /// <param name="data">Any data related to the exception</param>
        /// <summary>
        /// Log operation
        /// </summary>
        public static void Log(Exception ex, IDictionary<string, object> data = null)
        {
            var str = new StringBuilder();

            var e = ex;
            var indent = 0;
            var dataLogged = (data == null);
            while (e != null)
            {
                str.AppendLine(("{0," + indent + "}").FormatWith("Exception"));

                if (data != null && !dataLogged)
                {
                    data.Keys.ToList().ForEach(key =>
                        str.AppendLine(("{0," + indent + "}").FormatWith("{0} : {1}".FormatWith(key, data[key] == null ? "NULL" : data[key].ToString())))
                    );
                    dataLogged = true;
                }

                str.AppendLine(("{0," + indent + "}").FormatWith("Message : {0}".FormatWith(e.Message)));

                if (!string.IsNullOrEmpty(e.Source))
                    str.AppendLine(("{0," + indent + "}").FormatWith("Source  : {0}".FormatWith(e.Source)));

                if (!string.IsNullOrEmpty(e.StackTrace))
                    str.AppendLine(("{0," + indent + "}").FormatWith("Stack   : {0}".FormatWith(e.StackTrace.Replace(Environment.NewLine, ("{0," + indent + "}").FormatWith(Environment.NewLine)))));

                e = e.InnerException;

                indent += 4;
            }

            Source.TraceEvent(TraceEventType.Error, 1, str.ToString());

            Source.Flush();
        }
    }
}

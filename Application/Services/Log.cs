using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Log
    /// </summary>
    public class Log
    {
        private DateTime _serviceCallStart;
        
        public Log()
        {
            _serviceCallStart = DateTime.UtcNow;
        }

        private ConcurrentQueue<SectorTimeDataContract> Logs { get; } = new ConcurrentQueue<SectorTimeDataContract>();

        #region Capture Log
        /// <summary>
        /// Info operation
        /// </summary>
        public void Info(string value)
        {
            try
            {
                AddLog(value);
            }
            catch
            {
            }
        }

        /// <summary>
        /// Exception operation
        /// </summary>
        public void Exception(Exception ex, string value)
        {
            try
            {
                AddLog(ex, value);
            }
            catch
            {
            }
        }

        private void AddLog(string value)
        {
            var currentTimeMs = (long)(DateTime.UtcNow - _serviceCallStart).TotalMilliseconds;
            Logs.Enqueue(new SectorTimeDataContract() { Tag = value, TimeMs = currentTimeMs });
            Debug.WriteLine($"{currentTimeMs}:{value}");

        }

        private void AddLog(Exception ex, string value)
        {
            var currentTimeMs = (long)(DateTime.UtcNow - _serviceCallStart).TotalMilliseconds;
            Logs.Enqueue(new SectorTimeDataContract() { Tag = value, TimeMs = currentTimeMs });
            Logs.Enqueue(new SectorTimeDataContract() { Tag = "Exception stack trace: " + ex?.StackTrace, TimeMs = currentTimeMs });
            Logs.Enqueue(new SectorTimeDataContract() { Tag = "Inner Exception message: " + ex?.InnerException?.Message, TimeMs = currentTimeMs });
            Logs.Enqueue(new SectorTimeDataContract() { Tag = "Inner Exception stack trace: " + ex?.InnerException?.StackTrace, TimeMs = currentTimeMs });
            Debug.WriteLine($"{currentTimeMs}:{value}");
        }

        #endregion

        #region Write to File
        /// <summary>
        /// WriteLog operation
        /// </summary>
        public void WriteLog(string logon, List<LogDataContract> logs)
        {
            WriteLogFile(logon, logs, true);
        }

        /// <summary>
        /// WriteLog operation
        /// </summary>
        public void WriteLog(string logon, bool backgroundSvcCall = false)
        {
            WriteLogFile(logon, null, backgroundSvcCall);
        }

        private void WriteLogFile(string logon, List<LogDataContract> clientLogs, bool backgroundSvcCall)
        {
            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    if (string.IsNullOrEmpty(SystemSettings.LogsDirectory))
                        return;

                    string fullLogPath = CleanAndGetLogDirectory(logon);

                    var preFix = backgroundSvcCall ? "Background-" : string.Empty;
                    var fileName = clientLogs == null ? $"{preFix}Services.log" : "SynergyTrak.log";
                    var logFile = Path.Combine(fullLogPath, fileName);

                    using (var newTask = new StreamWriter(logFile, true))
                    {
                        if (clientLogs != null)
                        {
                            foreach (var log in clientLogs)
                            {
                                newTask.WriteLine($"{log.DateTime}|{log.Category}|{log.Title}|{log.Message}");
                            }
                        }

                        if (Logs != null)
                        {
                            foreach (var log in Logs)
                            {
                                newTask.WriteLine($"{DateTime.UtcNow}|SERVICE|{log.TimeMs}|{log.Tag}");
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            });
        }

        private static string CleanAndGetLogDirectory(string logon)
        {
            string directory = SystemSettings.LogsDirectory;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            var userPath = Path.Combine(directory, logon);

            try
            {
                var logRetentionDays = SystemSettings.SynergyTrakLogsRetentionDays;
                foreach (var logDirectory in Directory.GetDirectories(userPath))
                {
                    if (DateTime.UtcNow.AddDays(-(logRetentionDays)) > Directory.GetCreationTime(logDirectory))
                    {
                        Directory.Delete(logDirectory, true);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            var now = DateTime.UtcNow;
            var fullLogPath = Path.Combine(userPath, $"{now.Day.ToString("00")}-{now.Month.ToString("00")}-{now.Year}");
            if (!Directory.Exists(fullLogPath))
            {
                Directory.CreateDirectory(fullLogPath);
            }

            return fullLogPath;
        }

        #endregion
    }
}
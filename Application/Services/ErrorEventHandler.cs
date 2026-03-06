using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ErrorEventHandler
    /// </summary>
    public class ErrorEventHandler
    {
        private const string LogFilePath = @"C:\log\";
        private const string ApplicationName = "Trakstar";

        #region CreateErrorDirectory
        /// <summary>
        /// Check if directory exists, if not creates it
        /// </summary>
        /// <param name="logfilePath">full path for log file to be saved (e.g.: C:\\log\\ )</param>
        /// <summary>
        /// CreateErrorDirectory operation
        /// </summary>
        public void CreateErrorDirectory(string logfilePath)
        {
            if (string.IsNullOrEmpty(logfilePath))
                logfilePath = LogFilePath;
            if (!Directory.Exists(logfilePath))
                Directory.CreateDirectory(logfilePath);
        }
        #endregion

        #region ErrorLog
        /// <summary>
        /// Basic error logging
        /// </summary>
        /// <param name="applicationName">Name of the application, error occurred</param>
        /// <param name="errorMessage">Error message to log</param>
        /// <param name="logFilePath">Full directory path for log file (e.g.: C:\\log\\ )</param>
        /// <param name="methodName">Name of method, error occurred</param>
        /// <param name="logMessages">Log message to file?</param>
        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string applicationName, string errorMessage, string logFilePath, string methodName, bool logMessages)
        {
            try
            {
                if (!string.IsNullOrEmpty(errorMessage) && logMessages)
                {
                    CreateErrorDirectory(logFilePath);

                    var utc = DateTime.UtcNow;

                    var date = $"{utc.Day}-{utc.Month}-{utc.Year}";
                    if (string.IsNullOrEmpty(applicationName))
                    {
                        applicationName = ApplicationName;
                    }
                    var header = applicationName + ": " + utc.ToShortDateString() + " " + utc.ToLongTimeString() + " ==> ";

                    using (var sw = new StreamWriter(logFilePath + applicationName + "_" + date + ".txt", true))
                    {
                        sw.WriteLine(header);
                        if (!string.IsNullOrEmpty(methodName))
                            sw.WriteLine(methodName);

                        sw.WriteLine(errorMessage);
                        sw.WriteLine(" ");
                        sw.Flush();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLog(ApplicationName, ex.ToString(), SettingHelper.ErrorLogging);
            }
        }
        /// <summary>
        /// Basic error logging, uses setting in web.config
        /// </summary>
        /// <param name="errorMessage">Error message to log</param>
        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string errorMessage)
        {
            ErrorLog(ApplicationName, errorMessage, LogFilePath, null, SettingHelper.ErrorLogging);
        }

        /// <summary>
        /// Basic error logging
        /// </summary>
        /// <param name="errorMessage">Error message to log</param>
        /// <param name="logMessages">Log message to file?</param>
        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string errorMessage, bool logMessages)
        {
            ErrorLog(ApplicationName, errorMessage, LogFilePath, null, logMessages);
        }

        /// <summary>
        /// Basic error logging, uses setting in web.config
        /// </summary>
        /// <param name="applicationName">Name of the application, error occurred</param>
        /// <param name="errorMessage">Error message to log</param>
        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string applicationName, string errorMessage)
        {
            ErrorLog(applicationName, errorMessage, LogFilePath, null, SettingHelper.ErrorLogging);
        }

        /// <summary>
        /// Basic error logging
        /// </summary>
        /// <param name="applicationName">Name of the application, error occurred</param>
        /// <param name="errorMessage">Error message to log</param>
        /// <param name="logMessages">Log message to file?</param>
        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string applicationName, string errorMessage, bool logMessages)
        {
            ErrorLog(applicationName, errorMessage, LogFilePath, null, logMessages);
        }

        /// <summary>
        /// Basic error logging, uses setting in web.config
        /// </summary>
        /// <param name="applicationName">Name of the application, error occurred</param>
        /// <param name="errorMessage">Error message to log</param>
        /// <param name="logFilePath">Full directory path for log file (e.g.: C:\\log\\ )</param>
        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string applicationName, string errorMessage, string logFilePath)
        {
            ErrorLog(applicationName, errorMessage, logFilePath, null, SettingHelper.ErrorLogging);
        }

        /// <summary>
        /// Basic error logging
        /// </summary>
        /// <param name="applicationName">Name of the application, error occurred</param>
        /// <param name="errorMessage">Error message to log</param>
        /// <param name="logFilePath">Full directory path for log file (e.g.: C:\\log\\ )</param>
        /// <param name="logMessages">Log message to file?</param>
        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string applicationName, string errorMessage, string logFilePath, bool logMessages)
        {
            ErrorLog(applicationName, errorMessage, logFilePath, null, logMessages);
        }

        /// <summary>
        /// Basic error logging, uses setting in web.config
        /// </summary>
        /// <param name="applicationName">Name of the application, error occurred</param>
        /// <param name="errorMessage">Error message to log</param>
        /// <param name="logFilePath">Full directory path for log file (e.g.: C:\\log\\ )</param>
        /// <param name="methodName">Name of method, error occurred</param>
        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string applicationName, string errorMessage, string logFilePath, string methodName)
        {
            ErrorLog(applicationName, errorMessage, logFilePath, methodName, SettingHelper.ErrorLogging);
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Reports print handler
    /// </summary>
    /// <summary>
    /// ReportPrintHandler
    /// </summary>
    public class ReportPrintHandler : PrintHandlerBase
    {
        #region error/message logging

        private void WriteToEventLog(string message, EventLogEntryType eventLogType)
        {
            EventLog elog = new EventLog
            {
                Source = "Application"
            };
            elog.WriteEntry(message, eventLogType);
        }

        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string message, EventLogEntryType eventLogType)
        {
            try
            {
                string sLogFormat = DateTime.UtcNow.ToShortDateString() + " " + DateTime.UtcNow.ToLongTimeString() + " ==> ";
                const string sPathName = @"C:\log\";
                var eventHandler = new Synergy.ErrorHandling.EventHandlers.ErrorEventHandler();
                eventHandler.CreateErrorDirectory(sPathName);

                var dtm = DateTime.UtcNow;

                var sErrorTime = $"{dtm.Day} - {dtm.Month} - {dtm.Year}";

                try
                {
                    using (var sw = new StreamWriter(sPathName + "SMSapplication_ErrorLog_" + sErrorTime + ".txt", true))
                    {
                        sw.WriteLine(sLogFormat + message);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception ex)
                {
                    WriteToEventLog(sLogFormat + ex.ToString(), eventLogType);
                }

                WriteToEventLog(sLogFormat + message, eventLogType);
            }
            catch
            {
            }
        }

        #endregion

        /// <summary>
        /// Prints this instance.
        /// </summary>
        /// <summary>
        /// Print operation
        /// </summary>
        public override List<PrintDetailsDataContract> Print(bool localPrintingEnabled = false)
        {
            try
            {
                if (PrintDetails == null)
                {
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                if (string.IsNullOrEmpty(PrintDetails.PrinterName))
                {
                    throw new Exception(PrintingResources.Display_PrintMessagePrinterNameText);
                }

                var reportData = PrintDetails.PrintableObject as ServerReportData;

                if (reportData == null)
                {
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                var report = new ServerReport();

                report.ReportServerCredentials.NetworkCredentials = new NetworkCredential(
                    SystemSettings.ReportServiceLogonUser,
                    SystemSettings.ReportServerPassword,
                    SystemSettings.ReportServiceLogonDomain
                );

                report.ReportServerUrl = new Uri(SystemSettings.ReportApplicationBaseUrl, UriKind.Absolute);
                report.ReportPath = SystemSettings.SystemReportPath + reportData.ReportName;
                if (reportData.ReportPath != null)
                {
                    report.ReportPath = SystemSettings.SystemReportPath + reportData.ReportPath;
                }

                report.SetParameters(reportData.Parameters);
                report.Refresh();

                var bytes = report.Render("PDF", null, out string mimeType, out string encoding, out string extension, out string[] streamids, out Warning[] warnings);
                if (!localPrintingEnabled)
                {
                    var filename = @"C:\Windows\Temp\" + Guid.NewGuid() + ".pdf";
                    using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                    }

                    var helper = new PrintPdfHelper();
                    helper.PrintPDF(PrintDetails.PrinterName, filename);
                    File.Delete(filename);
                }
                printJobs.Add(new PrintDetailsDataContract { ByteData = bytes, PrinterName = PrintDetails.PrinterName, PrinterTypeId = (int)PrintDetails.PrintType });
            }
            catch (Exception ex)
            {
                ErrorLog(PrintingResources.Display_PrintMessageReportPrintHandlerText + ex, EventLogEntryType.Error);
                OnPrintCompleted(new RunWorkerCompletedEventArgs(0, ex, false));
            }

            return printJobs;
        }

        /// <summary>
        /// PrintToImage operation
        /// </summary>
        public override Image PrintToImage()
        {
            throw new NotImplementedException();
        }
    }
}
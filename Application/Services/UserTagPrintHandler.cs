using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.Services.Resources;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// UserTagPrintHandler
    /// </summary>
    public class UserTagPrintHandler : PrintHandlerBase
    {
        #region ErrorLog

        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string message)
        {
            Synergy.ErrorHandling.EventHandlers.ErrorEventHandler eventHandlers;

            try
            {
                var sLogFormat = DateTime.UtcNow.ToShortDateString() + " " + DateTime.UtcNow.ToLongTimeString() + " ==> ";
                const string sPathName = @"C:\log\";
                eventHandlers = new Synergy.ErrorHandling.EventHandlers.ErrorEventHandler();
                eventHandlers.CreateErrorDirectory(sPathName);

                var dtm = DateTime.UtcNow;

                var sErrorTime = $"{dtm.Day} - {dtm.Month} - {dtm.Year}";

                using (var sw = new StreamWriter(sPathName + "SMSapplication_ErrorLog_" + sErrorTime + ".txt", true))
                {
                    sw.WriteLine(sLogFormat + message);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch
            {
            }
        }

        #endregion

        #region Print

        /// <summary>
        /// Prints the user tag.
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
                    ErrorLog(PrintingResources.Display_PrintMessageUserTagConvertFailedText + " - " + DateTime.UtcNow);
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                if (string.IsNullOrEmpty(PrintDetails.PrinterName))
                {
                    ErrorLog(PrintingResources.Display_PrintMessageUserTagPrinterNameText + " - " + DateTime.UtcNow);
                    throw new Exception(PrintingResources.Display_PrintMessagePrinterNameText);
                }

                var userTag = PrintDetails.PrintableObject as UserTagData;
                if (userTag == null)
                {
                    ErrorLog(PrintingResources.Display_PrintMessageUserTagConvertFailedText + " - " + DateTime.UtcNow);
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                var tag = new UserTag(PrintDetails.PrinterName, userTag);
                if (localPrintingEnabled && PrintDetails.ReturnPdfData)
                {
                    var bytes = tag.PrintToPdf(Properties.Resources.GhostScriptInstallPath);

                    if (bytes != null)
                    {
                        printJobs.Add(new PrintDetailsDataContract()
                        {
                            ByteData = bytes,
                            PrinterName = PrintDetails.PrinterName,
                            PrinterTypeId = (int)PrintDetails.PrintType
                        });
                    }
                }
                else
                {
                    tag.Print();
                }

                ErrorLog(PrintingResources.Display_PrintMessageUserTagPrintText + DateTime.UtcNow);

                OnPrintCompleted(new RunWorkerCompletedEventArgs(PrintDetails.Quantity, null, false));
            }
            catch (Exception ex)
            {
                ErrorLog(PrintingResources.Display_PrintMessageUserTagPrintHandlerText + ex + " - " + DateTime.UtcNow);
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

        #endregion

    }
}
using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.Services.Resources;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Instance label print handler
    /// </summary>
    /// <summary>
    /// StationLabelPrintHandler
    /// </summary>
    public class StationLabelPrintHandler : PrintHandlerBase
    {
        #region ErrorLog
        /// <summary>
        /// ErrorLog operation
        /// </summary>
        public void ErrorLog(string Message)
        {
            Synergy.ErrorHandling.EventHandlers.ErrorEventHandler _eventHandlers; 

            try
            {
                string sLogFormat = DateTime.UtcNow.ToShortDateString().ToString() + " " + DateTime.UtcNow.ToLongTimeString().ToString() + " ==> ";
                const string sPathName = @"C:\log\";
                _eventHandlers = new Synergy.ErrorHandling.EventHandlers.ErrorEventHandler();
                _eventHandlers.CreateErrorDirectory(sPathName);

                var dtm = DateTime.UtcNow;

                var sErrorTime = $"{dtm.Day} - {dtm.Month} - {dtm.Year}";

                using (var sw = new StreamWriter(sPathName + "SMSapplication_ErrorLog_" + sErrorTime + ".txt", true))
                {
                    sw.WriteLine(sLogFormat + Message);
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
        /// Prints this instance label.
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
                    ErrorLog(PrintingResources.Display_PrintMessageStationLabelPrintHandlerText + "" + PrintingResources.Display_PrintMessageConvertFailedText + " - " + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                if (string.IsNullOrEmpty(PrintDetails.PrinterName))
                {
                    ErrorLog(PrintingResources.Display_PrintMessageStationLabelPrintHandlerText + PrintingResources.Display_PrintMessagePrinterNameText + " - " + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                    throw new Exception(PrintingResources.Display_PrintMessagePrinterNameText);
                }

                var station = PrintDetails.PrintableObject as StationLabelData;
                if (station == null)
                {
                    ErrorLog(PrintingResources.Display_PrintMessageStationLabelPrintHandlerText + PrintingResources.Display_PrintMessageConvertFailedText + " - " + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                var labelForm = new StationLabel(PrintDetails.PrinterName, station);
                if (localPrintingEnabled && PrintDetails.ReturnPdfData)
                {
                    var bytes = labelForm.PrintToPdf(Properties.Resources.GhostScriptInstallPath);

                    if (bytes != null)
                    {
                        printJobs.Add(new PrintDetailsDataContract
                                          {
                                              ByteData = bytes, 
                                              PrinterName = PrintDetails.PrinterName, 
                                              PrinterTypeId = (int)PrintDetails.PrintType
                                          });
                    }
                }
                else
                {
                    labelForm.Print();
                }

                OnPrintCompleted(new RunWorkerCompletedEventArgs(PrintDetails.Quantity, null, false));
            }
            catch (Exception ex)
            {
                ErrorLog(PrintingResources.Display_PrintMessageStationLabelPrintHandlerText + "" + ex.ToString() + " - " + DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
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
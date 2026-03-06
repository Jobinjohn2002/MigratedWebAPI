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
    /// InstanceLabelPrintHandler
    /// </summary>
    public class InstanceLabelPrintHandler : PrintHandlerBase
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
                var sLogFormat = DateTime.UtcNow.ToShortDateString().ToString() + " " + DateTime.UtcNow.ToLongTimeString().ToString() + " ==> ";
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
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                if (string.IsNullOrEmpty(PrintDetails.PrinterName))
                {
                    throw new Exception(PrintingResources.Display_PrintMessagePrinterNameText);
                }

                var instance = PrintDetails.PrintableObject as InstanceLabelData;

                if (instance == null)
                {
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                InstanceLabelPrint labelForm  = new InstanceLabelPrint(PrintDetails.PrinterName, instance);
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
                    if (localPrintingEnabled)
                    {
                        printJobs.Add(new PrintDetailsDataContract
                        {
                            PrintableInstance = new PrintableInstance
                            {
                                CustomerName = instance.CustomerName,
                                DeliveryPointName = instance.DeliveryPointName,
                                ContainerInstancePrimaryId = instance.InstanceExternalId,
                                ItemName = instance.ItemName
                            },
                            PrinterName = PrintDetails.PrinterName,
                            PrinterTypeId = (int)PrintDetails.PrintType
                        });
                    }
                    else
                    {
                        labelForm.Print();
                    }
                }

                OnPrintCompleted(new RunWorkerCompletedEventArgs(PrintDetails.Quantity, null, false));
            }
            catch (Exception ex)
            {
                OnPrintCompleted(new RunWorkerCompletedEventArgs(0, ex, false));
            }

            return printJobs;
        }

        /// <summary>
        /// PrintToImage operation
        /// </summary>
        public override Image PrintToImage()
        {
            var instance = PrintDetails.PrintableObject as InstanceLabelData;

            if (instance == null)
            {
                throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
            }

            InstanceLabelPrint labelForm = new InstanceLabelPrint(PrintDetails.PrinterName, instance);

            return labelForm.PrintToImg();
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.Services.Resources;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Plain tag print handler
    /// </summary>
    /// <summary>
    /// PlainTagPrintHandler
    /// </summary>
    public class PlainTagPrintHandler : PrintHandlerBase
    {
        /// <summary>
        /// Prints the plain tag.
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

                var tag = PrintDetails.PrintableObject as string;
                if (tag == null)
                {
                    throw new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                }

                var plainTag = new PlainTag(PrintDetails.PrinterName, tag);
                if (localPrintingEnabled && PrintDetails.ReturnPdfData)
                {
                    var bytes = plainTag.PrintToPdf(Properties.Resources.GhostScriptInstallPath);

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
                else // else is this a "classic" server side print
                {
                    plainTag.Print();
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
            throw new NotImplementedException();
        }
    }
}
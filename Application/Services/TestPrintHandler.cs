using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// Test print handler
    /// </summary>
    /// <summary>
    /// TestPrintHandler
    /// </summary>
    public class TestPrintHandler : PrintHandlerBase
    {
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
                    var ex = new Exception(PrintingResources.Display_PrintMessageConvertFailedText);
                    throw ex;
                }
                Thread.Sleep(int.Parse(PrintDetails.PrintableObject.ToString())*1000);
                if (DateTime.UtcNow.Second%2 == 1)
                {
                    throw new Exception(PrintingResources.Display_PrintMessageRandomErrorText);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public abstract class PrintHandlerBase
    {
        protected List<PrintDetailsDataContract> printJobs = new List<PrintDetailsDataContract>();

        #region IPrintHandler Members

        /// <summary>
        /// Gets the print details
        /// </summary>
        /// <summary>
        /// Gets or sets PrintDetails
        /// </summary>
        public IPrintDetails PrintDetails { get; set; }

        /// <summary>
        /// Occurs when [print completed].
        /// </summary>
        public event EventHandler<RunWorkerCompletedEventArgs> PrintCompleted;

        /// <summary>
        /// Print a single printable object to the named printer
        /// </summary>
        /// <summary>
        /// Print operation
        /// </summary>
        public abstract List<PrintDetailsDataContract> Print(bool localPrintingEnabled = false);

        /// <summary>
        /// PrintToImage operation
        /// </summary>
        public abstract Image PrintToImage();

        #endregion

        /// <summary>
        /// Raises the PrintCompleted event.
        /// </summary>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPrintCompleted(RunWorkerCompletedEventArgs e)
        {
            EventHandler<RunWorkerCompletedEventArgs> handler = PrintCompleted;

            if (handler != null)
            {
                PrintCompleted(this, e);
            }
        }
    }
}
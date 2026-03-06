using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Print Handler
    /// </summary>
    /// <summary>
    /// IPrintHandler
    /// </summary>
    public interface IPrintHandler
    {
        /// <summary>
        /// Gets or sets the print details.
        /// </summary>
        /// <value>The print details.</value>
        IPrintDetails PrintDetails { get; set; }

        /// <summary>
        /// Occurs when [print completed].
        /// </summary>
        event EventHandler<RunWorkerCompletedEventArgs> PrintCompleted;

        /// <summary>
        /// Prints this instance.
        /// </summary>
        List<PrintDetailsDataContract> Print(bool localPrintingEnabled = false);

        Image PrintToImage();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Contains the data required to print an order pick list.
    /// </summary>
    /// <summary>
    /// OrderPickListPrintDataContract
    /// </summary>
    public class OrderPickListPrintDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets the Id of the order to be printed.
        /// </summary>
        /// <summary>
        /// Gets or sets OrderId
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the data to be printed.
        /// </summary>
        public byte[] PrintData { get; set; }

        /// <summary>
        /// Gets or sets the name of the printer to be used.
        /// </summary>
        /// <summary>
        /// Gets or sets PrinterName
        /// </summary>
        public string PrinterName { get; set; }
    }
}

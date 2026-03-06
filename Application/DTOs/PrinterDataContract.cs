using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PrinterDataContract
    /// </summary>
    public class PrinterDataContract
    {
        public int? PrinterId { get; set; }
        /// <summary>
        /// Gets or sets PrinterName
        /// </summary>
        public string PrinterName { get; set; }
        /// <summary>
        /// Gets or sets PrinterTypeId
        /// </summary>
        public int PrinterTypeId { get; set; }
    }
}
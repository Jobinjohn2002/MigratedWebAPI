using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ReprintListDataContract
    /// </summary>
    public class ReprintListDataContract
    {
        /// <summary>
        /// Gets or sets PrintHistoryId
        /// </summary>
        public int PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets LastPrintedBy
        /// </summary>
        public string LastPrintedBy { get; set; }
        /// <summary>
        /// Gets or sets ContentType
        /// </summary>
        public PrintContentTypeIdentifier ContentType { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets ContentRemoved
        /// </summary>
        public bool ContentRemoved { get; set; }
    }
}

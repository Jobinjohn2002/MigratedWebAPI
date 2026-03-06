using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PrintHistoryContentDataContract
    /// </summary>
    public class PrintHistoryContentDataContract
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets PrintHistoryId
        /// </summary>
        public int PrintHistoryId { get; set; }
        /// <summary>
        /// Gets or sets PrinterType
        /// </summary>
        public PrintHistoryPrinterType PrinterType { get; set; }
        /// <summary>
        /// Gets or sets ContentId
        /// </summary>
        public Guid ContentId { get; set; }
        /// <summary>
        /// Gets or sets Ordinal
        /// </summary>
        public DateTime Ordinal { get; set; }
        /// <summary>
        /// Gets or sets PdfContent
        /// </summary>
        public PDFContent PdfContent { get; set; }
        /// <summary>
        /// Gets or sets LabelContent
        /// </summary>
        public LabelContent LabelContent { get; set; }
    }
}

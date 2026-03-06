using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// BasicInvoiceStatusData
    /// </summary>
    public class BasicInvoiceStatusData
    {
        public BasicInvoiceStatusData(int invoiceId, int invoiceStatusId, string text)
        {
            InvoiceId = invoiceId;
            InvoiceStatusId = invoiceStatusId;
            Text = text;
        }
        /// <summary>
        /// Gets or sets InvoiceId
        /// </summary>
        public int InvoiceId { get; set; }
        /// <summary>
        /// Gets or sets InvoiceStatusId
        /// </summary>
        public int InvoiceStatusId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    }
}
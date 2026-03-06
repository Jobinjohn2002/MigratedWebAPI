using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// InvoiceSummary
    /// </summary>
    public class InvoiceSummary
    {
		/// <summary>
		/// Gets or sets CurrentCustomerInvoiceCount
		/// </summary>
		public int CurrentCustomerInvoiceCount { get; set; }
		/// <summary>
		/// Gets or sets CurrentCustomerGroupInvoiceCount
		/// </summary>
		public int CurrentCustomerGroupInvoiceCount { get; set; }
		/// <summary>
		/// Gets or sets CurrentDirectorateInvoiceCount
		/// </summary>
		public int CurrentDirectorateInvoiceCount { get; set; }
    }
}

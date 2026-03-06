using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class InvoiceData 
	{
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerGroupName
        /// </summary>
        public string CustomerGroupName { get; set; }
        /// <summary>
        /// Gets or sets DirectorateName
        /// </summary>
        public string DirectorateName { get; set; }
		/// <summary>
		/// Gets or sets Name
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets FacilityName
		/// </summary>
		public string FacilityName { get; set; }
		/// <summary>
		/// Gets or sets InvoiceStatus
		/// </summary>
		public string InvoiceStatus { get; set; }
		/// <summary>
		/// Gets or sets InvoiceStatusId
		/// </summary>
		public int InvoiceStatusId { get; set; }
		public decimal? Value { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets DebtorId
        /// </summary>
        public string DebtorId { get; set; }
        public int? CustomerId { get; set; }

    }
}
		
using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public partial class Invoice 
	{
		/// <summary>
		/// Gets or sets InvoiceStatusId
		/// </summary>
		public int InvoiceStatusId { get; set; }
		/// <summary>
		/// Gets or sets InvoiceStatus
		/// </summary>
		public string InvoiceStatus { get; set; }
		/// <summary>
		/// Gets or sets Name
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Gets or sets FacilityName
		/// </summary>
		public string FacilityName { get; set; }
		public decimal? Value { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets DebtorId
        /// </summary>
        public string DebtorId { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// CreateAuditHistory operation
        /// </summary>
        public InvoiceStatusAuditHistory CreateAuditHistory(InvoiceStatusIdentifier status, int createdUserId)
        {
            var audit = new InvoiceStatusAuditHistory
            {
                CreatedUserId = createdUserId,
                Invoice = this,
                InvoiceStatusId = (byte)status,
                Created = DateTime.UtcNow,
            };
            return audit;
        }
        /// <summary>
        /// RegenerateProvisionalInvoice operation
        /// </summary>
        public Invoice RegenerateProvisionalInvoice()
        {
            var invoice = new Invoice
            {
                CustomerDefinitionId = CustomerDefinitionId,
                CustomerGroupId = CustomerGroupId,
                DirectorateId = DirectorateId,
                From = From,
                To = To,
            };
            return invoice;
        }
	}
}
		
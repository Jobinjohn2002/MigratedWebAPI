using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class InvoiceContract
	{
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
	}
}
		
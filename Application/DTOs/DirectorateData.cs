using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class DirectorateData 
	{
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public AddressData Address { get; set; }
		/// <summary>
		/// Gets or sets FacilityName
		/// </summary>
		public string FacilityName { get; set; }
		/// <summary>
		/// Gets or sets InvoicePeriod
		/// </summary>
		public byte InvoicePeriod { get; set; }
	}
}
		
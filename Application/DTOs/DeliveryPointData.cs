using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class DeliveryPointData
	{
		public DeliveryPointData()
		{
		}
		/// <summary>
		/// Gets or sets DeliveryPointName
		/// </summary>
		public string DeliveryPointName { get; set; }
		/// <summary>
		/// Gets or sets CustomerName
		/// </summary>
		public string CustomerName { get; set; }
		/// <summary>
		/// Gets or sets CustomerId
		/// </summary>
		public int CustomerId { get; set; }
		/// <summary>
		/// Gets or sets Selected
		/// </summary>
		public bool Selected { get; set; }
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public AddressData Address { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets InstanceCount
        /// </summary>
        public int InstanceCount { get; set; }
        /// <summary>
        /// Gets or sets IsSelected
        /// </summary>
        public bool IsSelected { get; set; }
        /// <summary>
        /// Gets or sets IsPrimary
        /// </summary>
        public bool IsPrimary { get; set; }
    }
}
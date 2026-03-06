using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class Customer 
	{
        /// <summary>
        /// Shortcut to CustomerDefinition.DeliveryPoint
        /// </summary>
        public ICollection<DeliveryPoint> DeliveryPoints
        {
            get
            {
                return CustomerDefinition.DeliveryPoint;
            }
        }

        /// <summary>
        /// Gets or sets InvoicePeriod
        /// </summary>
        public byte InvoicePeriod { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets CustomerGroupName
        /// </summary>
        public string CustomerGroupName { get; set; }

        public int? ExpiryDays { get; set; }
	}
}
		
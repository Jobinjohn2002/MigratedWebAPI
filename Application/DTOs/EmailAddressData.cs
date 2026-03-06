using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EmailAddressData
    /// </summary>
    public class EmailAddressData
    {
        /// <summary>
        /// Gets or sets CustomerData
        /// </summary>
        public IList<AddressData> CustomerData { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointData
        /// </summary>
        public IList<AddressData> DeliveryPointData { get; set; } 
        /// <summary>
        /// Gets or sets UserFacilitiesData
        /// </summary>
        public IList<UserFacilityData> UserFacilitiesData { get; set; } 

    }
}

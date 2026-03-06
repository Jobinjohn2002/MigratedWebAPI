using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class FacilityData 
	{
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public AddressData Address { get; set; }
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public IList<CustomerData> Customers { get; set; }
        public int? ExpiryDays { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets DateTimeFormatId
        /// </summary>
        public int DateTimeFormatId { get; set; }
        /// <summary>
        /// Gets or sets TimeZoneId
        /// </summary>
        public short TimeZoneId { get; set; }
        /// <summary>
        /// Gets or sets DateTimeFormatData
        /// </summary>
        public DateTimeFormatData DateTimeFormatData { get; set; }

        public FacilityData()
        {
        }

        /// <summary>
        /// Gets or sets the Tenancy Setting.
        /// </summary>
        /// <value>The Tenancy Setting.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TenancySetting
        /// </summary>
        public IEnumerable<TenancySettingData> TenancySetting { get; set; }
        /// <summary>
        /// Gets or sets LongTimeFormatId
        /// </summary>
        public int LongTimeFormatId { get; set; }
        /// <summary>
        /// Gets or sets LongDateFormatId
        /// </summary>
        public int LongDateFormatId { get; set; }
        /// <summary>
        /// Gets or sets ShortDateFormatId
        /// </summary>
        public int ShortDateFormatId { get; set; }
        /// <summary>
        /// Gets or sets ShortTimeFormatId
        /// </summary>
        public int ShortTimeFormatId { get; set; }
        /// <summary>
        /// Gets or sets LongTimeFormat
        /// </summary>
        public string LongTimeFormat { get; set; }
        /// <summary>
        /// Gets or sets LongDateFormat
        /// </summary>
        public string LongDateFormat { get; set; }
        /// <summary>
        /// Gets or sets ShortDateFormat
        /// </summary>
        public string ShortDateFormat { get; set; }
        /// <summary>
        /// Gets or sets ShortTimeFormat
        /// </summary>
        public string ShortTimeFormat { get; set; }
        /// <summary>
        /// Gets or sets TimeZone
        /// </summary>
        public string TimeZone { get; set; }
        /// <summary>
        /// Gets or sets IsPrintersCountZero
        /// </summary>
        public bool IsPrintersCountZero { get; set; }
        /// <summary>
        /// Gets or sets IsNotesCountZero
        /// </summary>
        public bool IsNotesCountZero { get; set; }
        /// <summary>
        /// Gets or sets DelayedBiTestType
        /// </summary>
        public int DelayedBiTestType { get; set; }
    }
}
		
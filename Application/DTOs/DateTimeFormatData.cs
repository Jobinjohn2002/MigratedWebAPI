using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{   
	public sealed partial class DateTimeFormatData 
	{
	    public DateTimeFormatData()
	    {
	        
	    }
        /// <summary>
        /// Gets or sets TimeZoneId
        /// </summary>
        public short TimeZoneId { get; set; }
        /// <summary>
        /// Gets or sets TimeZone
        /// </summary>
        public string TimeZone { get; set; }
        /// <summary>
        /// Gets or sets ShortDateFormat
        /// </summary>
        public string ShortDateFormat { get; set; }
        /// <summary>
        /// Gets or sets LongDateFormat
        /// </summary>
        public string LongDateFormat { get; set; }
        /// <summary>
        /// Gets or sets ShortTimeFormat
        /// </summary>
        public string ShortTimeFormat { get; set; }
        /// <summary>
        /// Gets or sets LongTimeFormat
        /// </summary>
        public string LongTimeFormat { get; set; }

	}
}
		
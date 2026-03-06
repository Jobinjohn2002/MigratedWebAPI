using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Format strings and timezone id information to be used for all UTC date/time conversions
    /// </summary>
    /// <summary>
    /// DateTimeFormatDataContract
    /// </summary>
    public class DateTimeFormatDataContract
    {
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
        /// <summary>
        /// Gets or sets ShortDateTimeFormat
        /// </summary>
        public string ShortDateTimeFormat { get; set; }
        /// <summary>
        /// Gets or sets LongDateTimeFormat
        /// </summary>
        public string LongDateTimeFormat { get; set; }
        /// <summary>
        /// Gets or sets TimeZone
        /// </summary>
        public string TimeZone { get; set; }
    }
}


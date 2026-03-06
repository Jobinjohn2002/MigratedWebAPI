using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IDateFormater
    /// </summary>
    public interface IDateFormater : IDateTimeFormatModel
    {
        /// <summary>
        /// Gets and Sets the ShortDateFormat
        /// </summary>
        string ShortDateFormat { get; set; }

        /// <summary>
        /// Gets and Sets the LongDateFormat
        /// </summary>
        string LongDateFormat { get; set; }

        /// <summary>
        /// Gets and Sets the ShortTimeFormat
        /// </summary>
        string ShortTimeFormat { get; set; }

        /// <summary>
        /// Gets and Sets the LongTimeFormat
        /// </summary>
        string LongTimeFormat { get; set; }

        /// <summary>
        /// Gets and Sets the TimeZone
        /// </summary>
        string TimeZone { get; set; }

        /// <param name="dateTimeDisplayFormat"></param>
        string GetFormat(SynergyDateTimeDisplayFormat dateTimeDisplayFormat);

        /// <param name="dateTimeDisplayFormat"></param>
        string GetStringFormat(SynergyDateTimeDisplayFormat dateTimeDisplayFormat);
    }
}

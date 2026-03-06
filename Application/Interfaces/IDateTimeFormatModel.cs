using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IDateTimeFormatModel
    /// </summary>
    public interface IDateTimeFormatModel
    {

        /// <summary>
        /// Gets and Sets the DateTimeFormatId
        /// </summary>
        int DateTimeFormatId { get; set; }

        /// <summary>
        /// Gets and Sets the ShortDateFormatId
        /// </summary>
        [Display(Name = "Display_ShortDateFormatText", ResourceType = typeof(DateTimeFormatResources))]
        int ShortDateFormatId { get; set; }

        /// <summary>
        /// Gets and Sets the LongDateFormatId
        /// </summary>
        [Display(Name = "Display_LongDateFormatText", ResourceType = typeof(DateTimeFormatResources))]
        int LongDateFormatId { get; set; }

        /// <summary>
        /// Gets and Sets the ShortTimeFormatId
        /// </summary>
        [Display(Name = "Display_ShortTimeFormatText", ResourceType = typeof(DateTimeFormatResources))]
        int ShortTimeFormatId { get; set; }

        /// <summary>
        /// Gets and Sets the LongTimeFormatId
        /// </summary>
        [Display(Name = "Display_LongTimeFormatText", ResourceType = typeof(DateTimeFormatResources))]
        int LongTimeFormatId { get; set; }

        /// <summary>
        /// Gets and Sets the TimeZoneId
        /// </summary>
        [Display(Name = "Display_TimeZoneText", ResourceType = typeof(DateTimeFormatResources))]
        short TimeZoneId { get; set; }
    }
}
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserLocaleModel
    /// </summary>
    public class UserLocaleModel
    {
        public UserLocaleModel()
        {
            TimeZones = new List<SelectListItem>();
            LongDates = new List<SelectListItem>();
            ShortDates = new List<SelectListItem>();
            LongTimes = new List<SelectListItem>();
            ShortTimes = new List<SelectListItem>();
        }

        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        public int? TimeZoneId { get; set; }
        public int? LongDateFormatId { get; set; }
        public int? ShortDateFormatId { get; set; }
        public int? LongTimeFormatId { get; set; }
        public int? ShortTimeFormatId { get; set; }

        /// <summary>
        /// Gets or sets TimeZones
        /// </summary>
        public List<SelectListItem> TimeZones { get; set; }
        /// <summary>
        /// Gets or sets LongDates
        /// </summary>
        public List<SelectListItem> LongDates { get; set; }
        /// <summary>
        /// Gets or sets ShortDates
        /// </summary>
        public List<SelectListItem> ShortDates { get; set; }
        /// <summary>
        /// Gets or sets LongTimes
        /// </summary>
        public List<SelectListItem> LongTimes { get; set; }
        /// <summary>
        /// Gets or sets ShortTimes
        /// </summary>
        public List<SelectListItem> ShortTimes { get; set; }
    }
}
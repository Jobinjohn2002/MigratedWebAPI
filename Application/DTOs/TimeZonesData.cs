using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// TimeZonesData
    /// </summary>
    public class TimeZonesData
    {
        public TimeZonesData(TimeZoneInfo timeZoneInfo)
        {
            BaseUtcOffset = timeZoneInfo.BaseUtcOffset;
            DaylightName = timeZoneInfo.DaylightName;
            DisplayName = timeZoneInfo.DisplayName;
            Id = timeZoneInfo.Id;
            StandardName = timeZoneInfo.StandardName;
            SupportsDaylightSavingTime = timeZoneInfo.SupportsDaylightSavingTime;
        }

        #region IUserPermissionRights Members
        /// <summary>
        /// Gets or sets BaseUtcOffset
        /// </summary>
        public TimeSpan BaseUtcOffset { get; set; }
        /// <summary>
        /// Gets or sets DaylightName
        /// </summary>
        public string DaylightName { get; set; }
        /// <summary>
        /// Gets or sets DisplayName
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets StandardName
        /// </summary>
        public string StandardName { get; set; }
        /// <summary>
        /// Gets or sets SupportsDaylightSavingTime
        /// </summary>
        public bool SupportsDaylightSavingTime { get; set; }

        #endregion
    }
}
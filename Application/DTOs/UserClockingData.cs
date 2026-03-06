using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed class UserClockingData : DataContractBase, IUserClockingData
    {
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets IsClockedIn
        /// </summary>
        public bool IsClockedIn { get; set; }
        /// <summary>
        /// Gets or sets ShiftDuration
        /// </summary>
        public TimeSpan ShiftDuration { get; set; }
        /// <summary>
        /// Gets or sets AreaDuration
        /// </summary>
        public TimeSpan AreaDuration { get; set; }
        /// <summary>
        /// Gets or sets LastActivityDuration
        /// </summary>
        public TimeSpan LastActivityDuration { get; set; }
        /// <summary>
        /// Gets or sets LastClockingEventTime
        /// </summary>
        public DateTime LastClockingEventTime { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets LocationName
        /// </summary>
        public string LocationName { get; set; }
    }
}

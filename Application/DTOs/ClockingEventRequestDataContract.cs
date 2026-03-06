using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ClockingEventRequestDataContract
    /// </summary>
    public class ClockingEventRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets ClockingTime
        /// </summary>
        public DateTime ClockingTime { get; set; }
        /// <summary>
        /// Gets or sets LocationPath
        /// </summary>
        public string LocationPath { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets ClockingEventType
        /// </summary>
        public ClockingEventTypeIdentifier ClockingEventType { get; set; }
        /// <summary>
        /// Gets or sets IsAutomatic
        /// </summary>
        public bool IsAutomatic { get; set; }
        public int? AutomaticEventLocationId { get; set; }
        public int? ClockedOutByUserId { get; set; }
        /// <summary>
        /// Gets or sets UserExternalId
        /// </summary>
        public string UserExternalId { get; set; }
        /// <summary>
        /// Gets or sets Username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets Pwd
        /// </summary>
        public string Pwd { get; set; }
    }
}
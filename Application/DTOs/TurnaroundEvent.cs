using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundEventInfo
    /// </summary>
    public class TurnaroundEventInfo
    {
        /// <summary>
        /// The id of the turnaroundEvent.
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundEventId
        /// </summary>
        public int TurnaroundEventId { get; set; }

        /// <summary>
        /// The created DateTime of the turnaroundEvent.
        /// </summary>
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The name of the event that occurred.
        /// </summary>
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public string EventType { get; set; }

        /// <summary>
        /// The stationId of the station where this event occurred.
        /// </summary>
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }

        /// <summary>
        /// The UserId of the user that created the event.
        /// </summary>
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
    }
}

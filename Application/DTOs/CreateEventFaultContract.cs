using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CreateEventFaultContract
    /// </summary>
    public class CreateEventFaultContract : BasicFaultContract
    {
        public CreateEventFaultContract(string faultId, string faultMessage, bool started, int nextEventTypeId, string nextEvent, int nextEventPreferredStationTypeId, string nextEventPreferredStationType)
            : base(faultId, faultMessage)
        {
            Started = started;
            NextEventTypeId = nextEventTypeId;
            NextEvent = nextEvent;
            NextEventPreferredStationTypeId = nextEventPreferredStationTypeId;
            NextEventPreferredStationType = nextEventPreferredStationType;
        }
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }
        /// <summary>
        /// Gets or sets NextEventTypeId
        /// </summary>
        public int NextEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets NextEventPreferredStationType
        /// </summary>
        public string NextEventPreferredStationType { get; set; }
        /// <summary>
        /// Gets or sets NextEventPreferredStationTypeId
        /// </summary>
        public int NextEventPreferredStationTypeId { get; set; }
        /// <summary>
        /// Gets or sets Started
        /// </summary>
        public bool Started { get; set; }
    }
}
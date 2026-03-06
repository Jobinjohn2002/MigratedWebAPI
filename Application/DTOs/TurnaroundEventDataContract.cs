using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// TurnaroundEventDataContract
    /// </summary>
    public class TurnaroundEventDataContract
    {
        /// <summary>
        /// Event Id
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundEventId
        /// </summary>
        public int TurnaroundEventId { get; set; }
        /// <summary>
        /// Gets or sets EventName
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        /// Event Type Id
        /// </summary>
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public int EventTypeId { get; set; }

        /// <summary>
        /// Created date time
        /// </summary>
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Is a process event
        /// </summary>
        /// <summary>
        /// Gets or sets IsProcessEvent
        /// </summary>
        public bool IsProcessEvent { get; set; }

        /// <summary>
        /// Customer facility Id
        /// </summary>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }

        /// <summary>
        /// MachineId
        /// </summary>
        public int? MachineId { get; set; }
        /// <summary>
        /// Gets or sets MachineName
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// BarchId
        /// </summary>
        public int? BatchId { get; set; }
        /// <summary>
        /// Gets or sets BatchExternalId
        /// </summary>
        public string BatchExternalId { get; set; }

        /// <summary>
        /// Process Station Type Id
        /// </summary>
        /// <summary>
        /// Gets or sets ProcessStationTypeId
        /// </summary>
        public int ProcessStationTypeId { get; set; }

        /// <summary>
        /// Process Station Type Cateogry Id
        /// </summary>
        public StationTypeCategoryIdentifier? StationTypeCategoryId { get; set; }

        /// <summary>
        /// Process Station Type Cateogry Id
        /// </summary>
        /// <summary>
        /// Gets or sets IsEventCurrentProcessEvent
        /// </summary>
        public bool IsEventCurrentProcessEvent { get; set; }

        /// <summary>
        /// Created User id
        /// </summary>
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }

        /// <summary>
        /// Location id
        /// </summary>
        public int? LocationId { get; set; }

        /// <summary>
        /// Pin Request ReasonId id
        /// </summary>
        public int? PinRequestReasonId { get; set; }
        
        /// <summary>
        /// Station id
        /// </summary>
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }

        /// <summary>
        /// Additional Information about the turnaround event
        /// </summary>
        /// <summary>
        /// Gets or sets AdditionalInfo
        /// </summary>
        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Extendend Additional Information about the turnaround event
        /// </summary>
        /// <summary>
        /// Gets or sets AdditionalInfoExtended
        /// </summary>
        public string AdditionalInfoExtended { get; set; }
        /// <summary>
        /// Gets or sets AdditionalInfoFields
        /// </summary>
        public Dictionary<string, string> AdditionalInfoFields { get; set; }
    }
}

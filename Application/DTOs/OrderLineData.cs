using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OrderLineData
    /// </summary>
    public class OrderLineData
    {
        public int OrderLineId;
        public int OrderId;
        public int ContainerMasterDefinitionId;
        public int ContainerMasterId;
        public int? TurnaroundId;
        public string ItemName;
        public string ExternalId;
        public long TurnaroundExternalId;
        public int OrderLineStatusId;
        public int OrderLineSourceId;
        /// <summary>
        /// Gets or sets LineStatus
        /// </summary>
        public OrderLineStatusData LineStatus { get; set; }
        public string OrderLineStatusName;
        public int StationId;
        public byte StationTypeId;
        public int CreatedUserId;
        public DateTime Created;
        public bool RemoveTurnaround;
        public bool InStockDefaultLocation;
        public int LastTurnaroundEventId;
        public int LastTurnaroundEventTypeId;
        public bool HasDeliveryNotePrint;
        public bool IntoStock;
        public bool IntoQuarantine;
        public bool IsOrderLineRequired;
        public int? QuarantineReasonId;
        public bool HasDispatchEvent;
        public string Location;
        public int? LocationId;
    }

    /// <summary>
    /// ContainerOrderMasterData
    /// </summary>
    public class ContainerOrderMasterData
    {
        public string ExternalId;
        public string Description;
        public string TurnaroundExternal;
        public string InstanceRef;
    }

}
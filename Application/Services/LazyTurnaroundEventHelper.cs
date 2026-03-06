using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyTurnaroundEventHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(TurnaroundEvent concreteTurnaroundEvent,
                                     TurnaroundEvent genericTurnaroundEvent)
        {
            concreteTurnaroundEvent.TurnaroundEventId = genericTurnaroundEvent.TurnaroundEventId;
            concreteTurnaroundEvent.BatchId = genericTurnaroundEvent.BatchId;
            concreteTurnaroundEvent.CreatedUserId = genericTurnaroundEvent.CreatedUserId;
            concreteTurnaroundEvent.EventTypeId = genericTurnaroundEvent.EventTypeId;
            concreteTurnaroundEvent.FailureTypeId = genericTurnaroundEvent.FailureTypeId;
            concreteTurnaroundEvent.ProcessStationTypeId = genericTurnaroundEvent.ProcessStationTypeId;
            concreteTurnaroundEvent.StationId = genericTurnaroundEvent.StationId;
            concreteTurnaroundEvent.TurnaroundId = genericTurnaroundEvent.TurnaroundId;
            concreteTurnaroundEvent.WorkflowId = genericTurnaroundEvent.WorkflowId;
            concreteTurnaroundEvent.Created = genericTurnaroundEvent.Created;
            concreteTurnaroundEvent.LegacyId = genericTurnaroundEvent.LegacyId;
            concreteTurnaroundEvent.LegacyFacilityOrigin = genericTurnaroundEvent.LegacyFacilityOrigin;
            concreteTurnaroundEvent.LegacyImported = genericTurnaroundEvent.LegacyImported;
            concreteTurnaroundEvent.PinRequestReasonId = genericTurnaroundEvent.PinRequestReasonId;
            concreteTurnaroundEvent.QuarantineReasonId = genericTurnaroundEvent.QuarantineReasonId;
            concreteTurnaroundEvent.LocationId = genericTurnaroundEvent.LocationId;
        }
    }
}
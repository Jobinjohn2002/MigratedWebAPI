using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyMachineEventHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(MachineEvent concreteMachineEvent, MachineEvent genericMachineEvent)
        {
            concreteMachineEvent.MachineEventId = genericMachineEvent.MachineEventId;
            concreteMachineEvent.CreatedUserId = genericMachineEvent.CreatedUserId;
            concreteMachineEvent.MachineEventReasonId = genericMachineEvent.MachineEventReasonId;
            concreteMachineEvent.MachineEventTypeId = genericMachineEvent.MachineEventTypeId;
            concreteMachineEvent.MachineId = genericMachineEvent.MachineId;
            concreteMachineEvent.StationId = genericMachineEvent.StationId;
            concreteMachineEvent.Created = genericMachineEvent.Created;
            concreteMachineEvent.LegacyId = genericMachineEvent.LegacyId;
            concreteMachineEvent.LegacyFacilityOrigin = genericMachineEvent.LegacyFacilityOrigin;
            concreteMachineEvent.LegacyImported = genericMachineEvent.LegacyImported;
        }
    }
}
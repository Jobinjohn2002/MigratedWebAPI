using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyMachineEventTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(MachineEventType concreteMachineEventType,
                                     MachineEventType genericMachineEventType)
        {
            concreteMachineEventType.MachineEventTypeId = genericMachineEventType.MachineEventTypeId;
            concreteMachineEventType.Text = genericMachineEventType.Text;
            concreteMachineEventType.Unavailable = genericMachineEventType.Unavailable;
            concreteMachineEventType.LegacyFacilityOrigin = genericMachineEventType.LegacyFacilityOrigin;
            concreteMachineEventType.LegacyImported = genericMachineEventType.LegacyImported;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyMachineEventReasonHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(MachineEventReason concreteMachineEventReason,
                                     MachineEventReason genericMachineEventReason)
        {
            concreteMachineEventReason.MachineEventReasonId = genericMachineEventReason.MachineEventReasonId;
            concreteMachineEventReason.MachineTypeId = genericMachineEventReason.MachineTypeId;
            concreteMachineEventReason.Text = genericMachineEventReason.Text;
            concreteMachineEventReason.LegacyFacilityOrigin = genericMachineEventReason.LegacyFacilityOrigin;
            concreteMachineEventReason.LegacyImported = genericMachineEventReason.LegacyImported;
        }
    }
}
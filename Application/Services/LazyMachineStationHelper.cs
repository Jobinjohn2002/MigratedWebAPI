using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyMachineStationHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ref MachineStation concreteMachineStation,
                                     ref IMachineStation genericMachineStation)
        {
            concreteMachineStation.MachineStationId = genericMachineStation.MachineStationId;
            concreteMachineStation.MachineId = genericMachineStation.MachineId;
            concreteMachineStation.StationId = genericMachineStation.StationId;
            concreteMachineStation.LegacyFacilityOrigin = genericMachineStation.LegacyFacilityOrigin;
            concreteMachineStation.LegacyImported = genericMachineStation.LegacyImported;
        }
    }
}
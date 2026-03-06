using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyMachineHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Machine concreteMachine, Machine genericMachine)
        {
            concreteMachine.MachineId = genericMachine.MachineId;
            concreteMachine.ArchivedUserId = genericMachine.ArchivedUserId;
            concreteMachine.FacilityId = genericMachine.FacilityId;
            concreteMachine.MachineTypeId = genericMachine.MachineTypeId;
            concreteMachine.BatchPrefix = genericMachine.BatchPrefix;
            concreteMachine.Text = genericMachine.Text;
            concreteMachine.RunningTime = genericMachine.RunningTime;
            concreteMachine.Archived = genericMachine.Archived;
            concreteMachine.LegacyId = genericMachine.LegacyId;
            concreteMachine.LegacyFacilityOrigin = genericMachine.LegacyFacilityOrigin;
            concreteMachine.LegacyImported = genericMachine.LegacyImported;
            concreteMachine.CoolDownPeriod = genericMachine.CoolDownPeriod;
            concreteMachine.IsSteam = genericMachine.IsSteam;
        }
    }
}
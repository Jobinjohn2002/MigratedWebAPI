using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyMachineTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(MachineType concreteMachineType, MachineType genericMachineType)
        {
            concreteMachineType.MachineTypeId = genericMachineType.MachineTypeId;
            concreteMachineType.Text = genericMachineType.Text;
            concreteMachineType.Handler = genericMachineType.Handler;
            concreteMachineType.HasBatches = genericMachineType.HasBatches;
            concreteMachineType.IsSteriliser = genericMachineType.IsSteriliser;
            concreteMachineType.IsCarriageWasher = genericMachineType.IsCarriageWasher;

        }
    }
}
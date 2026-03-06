using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyBatchCycleHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(BatchCycle concreteBatchCycle, BatchCycle genericBatchCycle)
        {
            concreteBatchCycle.BatchCycleId = genericBatchCycle.BatchCycleId;
            concreteBatchCycle.MachineTypeId = genericBatchCycle.MachineTypeId;
            concreteBatchCycle.Text = genericBatchCycle.Text;
            concreteBatchCycle.IsChargeable = genericBatchCycle.IsChargeable;
            concreteBatchCycle.LegacyFacilityOrigin = genericBatchCycle.LegacyFacilityOrigin;
            concreteBatchCycle.LegacyImported = genericBatchCycle.LegacyImported;
        }
    }
}
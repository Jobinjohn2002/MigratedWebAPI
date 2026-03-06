using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class MachineRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public Machine Get(int id)
        {
            return Repository.Find(m => m.MachineId == id).FirstOrDefault();
        }

        /// <summary>
        /// GetAllMachinesByFacilityId operation
        /// </summary>
        public IQueryable<Machine> GetAllMachinesByFacilityId(short facilityId)
        {
            return Repository.Find(m => m.Facility.FacilityId == facilityId && m.Archived == null);
        }

        /// <summary>
        /// ReadBatchCycles operation
        /// </summary>
        public IQueryable<BatchCycle> ReadBatchCycles(int machineId)
        {
            return Repository.Find(m => m.MachineId == machineId).SelectMany(i => i.MachineBatchCycle).Select(i => i.BatchCycle);
        }
    }
}
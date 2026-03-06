using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class MachineGroupRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public MachineGroup Get(int machineGroupId)
        {
            return Repository.Find(machineGroup => machineGroup.MachineGroupId == machineGroupId).FirstOrDefault();
        }

        /// <summary>
        /// GetLastBatchByMachineGroupId operation
        /// </summary>
        public Batch GetLastBatchByMachineGroupId(int machineGroupId)
        {
            var machineGroup = Repository.Find(m => m.MachineGroupId == machineGroupId).Single();

            var batch = machineGroup.Machine.SelectMany(m => m.Batch.OrderByDescending(b => b.Created)).OrderByDescending(b => b.Created).FirstOrDefault();

            return batch;
        }
    }
}
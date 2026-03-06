using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class FailedWashRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public FailedWash Get(int failedWashId)
        {
            return Repository.Find(failedWash => failedWash.FailedWashId == failedWashId).FirstOrDefault();
        }

        /// <summary>
        /// GetFailedWashByTurnaroundEventId operation
        /// </summary>
        public FailedWash GetFailedWashByTurnaroundEventId(int turnaroundEventId)
        {
            return Repository.Find(fw => fw.TurnaroundEventId == turnaroundEventId).FirstOrDefault();
        }
    }
}
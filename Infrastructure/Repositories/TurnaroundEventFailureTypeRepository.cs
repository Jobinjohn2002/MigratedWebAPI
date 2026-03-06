using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class TurnaroundEventFailureTypeRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public TurnaroundEventFailureType Get(int turnaroundEventFailureTypeId)
        {
            return Repository.Find(turnaroundEventFailureType => turnaroundEventFailureType.TurnaroundEventFailureTypeId == turnaroundEventFailureTypeId).FirstOrDefault();
        }
	}
}
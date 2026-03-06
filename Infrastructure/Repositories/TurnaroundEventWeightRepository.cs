using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class TurnaroundEventWeightRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public TurnaroundEventWeight Get(int turnaroundEventWeightId)
        {
            return Repository.Find(turnaroundEventWeight => turnaroundEventWeight.TurnaroundEventWeightId == turnaroundEventWeightId).FirstOrDefault();
        }
	}
}
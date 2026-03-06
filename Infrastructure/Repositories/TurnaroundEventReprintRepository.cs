using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class TurnaroundEventReprintRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public TurnaroundEventReprint Get(int turnaroundEventReprintId)
        {
            return Repository.Find(turnaroundEventReprint => turnaroundEventReprint.TurnaroundEventReprintId == turnaroundEventReprintId).FirstOrDefault();
        }
	}
}
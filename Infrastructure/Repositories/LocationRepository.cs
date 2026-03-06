using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class LocationRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public Location Get(int locationId)
        {
            return Repository.Find(location => location.LocationId == locationId).FirstOrDefault();
        }
	}
}
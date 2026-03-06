using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class TurnaroundFacilityRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public TurnaroundFacility Get(int turnaroundFacilityId)
        {
            return Repository.Find(turnaroundFacility => turnaroundFacility.TurnaroundFacilityId == turnaroundFacilityId).FirstOrDefault();
        }

	    /// <summary>
	    /// Any operation
	    /// </summary>
	    public bool Any(int turnaroundId, int facilityId)
	    {
	        return Repository.Find(tf => tf.TurnaroundId == turnaroundId && tf.FacilityId == facilityId).Any();
	    }
	}
}
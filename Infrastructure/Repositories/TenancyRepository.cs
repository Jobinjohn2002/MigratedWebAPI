using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class TenancyRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public Tenancy Get(int tenancyId)
        {
            return Repository.Find(tenancy => tenancy.TenancyId == tenancyId).FirstOrDefault();
        }

        /// <summary>
        /// GetTenancyForFacility operation
        /// </summary>
        public Tenancy GetTenancyForFacility(int facilityId)
        {
            return Repository.Find(tenancy => tenancy.OwnersInTenancy.FirstOrDefault(t => t.Facility.Any(f => f.FacilityId == facilityId)) != null).FirstOrDefault();
        }
	}
}
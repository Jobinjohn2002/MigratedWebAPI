using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class OwnerRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public Owner Get(int ownerId)
        {
            return Repository.Find(owner => owner.OwnerId == ownerId).FirstOrDefault();
        }

	    /// <summary>
	    /// GetByFacilityId operation
	    /// </summary>
	    public Owner GetByFacilityId(short facilityId)
	    {
	        using (IUnitOfWork workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
	        {
	            var facilityRepo = FacilityRepository.New(workUnit);
	            var facility = facilityRepo.Get(facilityId);

	            return Repository.Find(o => o.OwnerId == facility.OwnerId).FirstOrDefault();
	        }
	    }
	}
}
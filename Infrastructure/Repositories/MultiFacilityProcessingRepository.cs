using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class MultiFacilityProcessingRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public MultiFacilityProcessing Get(int multiFacilityProcessingId)
        {
            return Repository.Find(multiFacilityProcessing => multiFacilityProcessing.MultiFacilityProcessingId == multiFacilityProcessingId).FirstOrDefault();
        }

        /// <summary>
        /// GetPrimaryFacilities operation
        /// </summary>
        public List<short> GetPrimaryFacilities(short facilityId)
        {
            var facilities = Repository.Find(mfp => mfp.AlternateProcessingFacilityId == facilityId && mfp.IsEnabled).SelectMany(x => x.MultiFacilityProcessHandShake).Where(hs => hs.IsEnabled).Select(i => i.RequestingFacilityId).ToList();
            facilities.Insert(0, facilityId);

            return facilities;
        }
	}
}
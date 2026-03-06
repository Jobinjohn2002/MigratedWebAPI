using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class StationTypeRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public StationType Get(byte stationTypeId)
        {
            return Repository.Find(st => st.StationTypeId == stationTypeId).FirstOrDefault();
        }
       
        /// <summary>
        /// GetStationsByStationTypeAndFacility operation
        /// </summary>
        public IQueryable<Station> GetStationsByStationTypeAndFacility(int stationTypeId,short facilityId)
        {
            var stations = Repository.Find(st => st.StationTypeId == stationTypeId).SelectMany(st => st.Station).Where(s => s.FacilityId == facilityId && s.Archived==null);
            return stations;
        }

        /// <summary>
        /// ReadByIds operation
        /// </summary>
        public IList<StationType> ReadByIds(IList<byte> stationTypeIds)
        {
            var stationTypeIdsAsInts = stationTypeIds.Select(i => (int)i); // ToDo: LINQ to entities doesn't like bytes for some reason
            return Repository.Find(st => stationTypeIdsAsInts.Contains(st.StationTypeId)).ToList();
        }
    }
}
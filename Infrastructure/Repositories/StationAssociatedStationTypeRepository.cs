using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// StationAssociatedStationTypeRepository
    /// </summary>
    public class StationAssociatedStationTypeRepository
    {
        /// <summary>
        /// Add operation
        /// </summary>
        public void Add(int stationId, byte stationTypeId)
        {
            using (var context = new OperativeModelContainer())
            {
                var station = new Station();
                station.StationId = stationId;

                var stationType = new StationType();
                stationType.StationTypeId = stationTypeId;

                context.Station.Attach(station);
                context.StationType.Attach(stationType);

                station.StationTypes.Add(stationType);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete operation
        /// </summary>
        public void Delete(int stationId, byte stationTypeId)
        {
            {
                var station = new Station();
                station.StationId = stationId;

                var stationType = new StationType();
                stationType.StationTypeId = stationTypeId;

                context.Station.Attach(station);
                context.StationType.Attach(stationType);

                station.StationTypes.Remove(stationType);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// IsStationUsed operation
        /// </summary>
        public bool IsStationUsed(int? facilityId, int stationTypeId)
        {
            using (var repository = new PathwayRepository())
            {
                var context = (OperativeModelContainer)repository.Container;
                var parameters = new Dictionary<string, object>();
                parameters.Add("@FacilityID", facilityId);
                parameters.Add("@StationTypeId", stationTypeId);

                var datacommand = DataCommandFactory.CreateCommand(context, CommandType.StoredProcedure, "dbo.opsapp_IsStationInUse", parameters);
                return Convert.ToBoolean(datacommand.ExecuteScalar());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// StationDeliveryPoint Repository
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// StationDeliveryPointRepository
    /// </summary>
    public class StationDeliveryPointRepository
    {
        /// <summary>
        /// Adds the specified station id.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <remarks></remarks>
        /// <summary>
        /// Add operation
        /// </summary>
        public void Add(int stationId, int deliveryPointId)
        {
            using (var context = new OperativeModelContainer())
            {
                var station = new Station {StationId = stationId};

                var deliveryPoint = new DeliveryPoint {DeliveryPointId = deliveryPointId};

                context.Station.Attach(station);
                context.DeliveryPoint.Attach(deliveryPoint);

                station.StationDeliveryPoints.Add(deliveryPoint);

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified station id.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <remarks></remarks>
        /// <summary>
        /// Delete operation
        /// </summary>
        public void Delete(int stationId, int deliveryPointId)
        {
            {
                var station = new Station {StationId = stationId};

                var deliveryPoint = new DeliveryPoint {DeliveryPointId = deliveryPointId};

                context.Station.Attach(station);
                context.DeliveryPoint.Attach(deliveryPoint);

                station.StationDeliveryPoints.Remove(deliveryPoint);

                context.SaveChanges();
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// StationDeliveryPointDataAdapter
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// StationDeliveryPointDataAdapter
    /// </summary>
    public class StationDeliveryPointDataAdapter : DataAdapterBase, IStationDeliveryPointDataAdapter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAdapterBase"/> class.
        /// </summary>
        /// <param name="efUnitOfWork">The ef unit of work.</param>
        /// <remarks></remarks>
        internal StationDeliveryPointDataAdapter(IUnitOfWork efUnitOfWork)
            : base(efUnitOfWork)
        {
        }

        #region IStationDeliveryPointDataAdapter Members

        /// <summary>
        /// Updates the specified station id.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <param name="deliveryPoints">The delivery points.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Update operation
        /// </summary>
        public bool Update(int stationId, IList<int> deliveryPoints)
        {
            if (deliveryPoints == null)
                deliveryPoints = new List<int>();

            var stationRepository = StationRepository.New(WorkUnit);
            var stationDeliveryPointRepository = new StationDeliveryPointRepository();
            var associatedDeliveryPoints = stationRepository.ReadAssociatedDeliveryPoints(stationId).Select(dp => dp.DeliveryPointId).ToList();

            var newDeliveryPoints = new List<int>();
            deliveryPoints.ToList().ForEach(dp =>
            {
                if (!associatedDeliveryPoints.Contains(dp))
                    newDeliveryPoints.Add(dp);
            });

            var removeDeliveryPoints = new List<int>();
            associatedDeliveryPoints.ToList().ForEach(dp =>
            {
                if (!deliveryPoints.Contains(dp))
                    removeDeliveryPoints.Add(dp);
            });

            using (var transaction = new TransactionScope())
            {
                foreach (var deliveryPoint in removeDeliveryPoints)
                {
                    stationDeliveryPointRepository.Delete(stationId, deliveryPoint);
                }

                foreach (int deliveryPoint in newDeliveryPoints)
                {
                    stationDeliveryPointRepository.Add(stationId, deliveryPoint);
                }

                transaction.Complete();
                return true;
            }
        }

        /// <summary>
        /// Reads the delivery points by station.
        /// </summary>
        /// <param name="stationId">The station id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadDeliveryPointsByStation operation
        /// </summary>
        public IList<DeliveryPoint> ReadDeliveryPointsByStation(int stationId)
        {
            var stationRepository = StationRepository.New(WorkUnit);
            return stationRepository.ReadAssociatedDeliveryPoints(stationId).ToList();
        }

        #endregion
    }
}
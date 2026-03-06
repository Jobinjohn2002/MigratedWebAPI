using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// StoragePointRepository
    /// </summary>
    /// <remarks></remarks>
	public partial class StoragePointRepository
	{
        /// <summary>
        /// Gets the specified storage point id.
        /// </summary>
        /// <param name="storagePointId">The storage point id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		/// <summary>
		/// Get operation
		/// </summary>
		public StoragePoint Get(int storagePointId)
        {
            return Repository.Find(storagePoint => storagePoint.StoragePointId == storagePointId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the specified storage point id.
        /// </summary>
        /// <param name="locationId">The locationId of the storage point.</param>
        /// <returns></returns>
        /// <remarks></remarks>
		/// <summary>
		/// GetByLocation operation
		/// </summary>
		public StoragePoint GetByLocation(int locationId)
        {
            return Repository.Find(storagePoint => storagePoint.LocationId == locationId && storagePoint.Archived == null).FirstOrDefault();
        }

        /// <summary>
        /// Reads the turnarounds by storage point.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadTurnaroundsByStoragePoint operation
        /// </summary>
        public IQueryable<Turnaround> ReadTurnaroundsByStoragePoint(int id)
        {
            return
                Repository.Find(sp => sp.StoragePointId == id).SelectMany(sp => sp.Turnaround).Where(
                    t => t.LastEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoPigeonHoleStock);
        }

        /// <summary>
        /// Reads the turnaroundEventss by storage point.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadTurnaroundEventsByStoragePoint operation
        /// </summary>
        public IQueryable<TurnaroundEvent> ReadTurnaroundEventsByStoragePoint(int id)
        {
            return
                Repository.Find(sp => sp.StoragePointId == id).SelectMany(sp => sp.TurnaroundEvent);
        }

        /// <summary>
        /// Reads all the turnarounds by storage point.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadAllTurnaroundsByStoragePoint operation
        /// </summary>
        public IQueryable<Turnaround> ReadAllTurnaroundsByStoragePoint(int id)
        {
            return
                Repository.Find(sp => sp.StoragePointId == id).SelectMany(sp => sp.Turnaround);
        }

        /// <summary>
        /// TurnaroundExistsInStoragePoint operation
        /// </summary>
        public bool TurnaroundExistsInStoragePoint(int id, string turnaroundExternalId)
        {
            long tmpExternalId =long.Parse(turnaroundExternalId);
            var turnarounds = Repository.Find(sp => sp.StoragePointId == id).SelectMany(sp => sp.Turnaround).Where(
                t => t.ExternalId == tmpExternalId && t.LastEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoPigeonHoleStock);
            if (turnarounds!=null && turnarounds.Count() > 0) return true; else return false;

        }
	}
}
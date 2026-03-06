using SynergyApplicationFrameworkApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using FacilityType = Pathway.Data.Models.Operative.FacilityType;
using IsolationLevel = System.Transactions.IsolationLevel;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    ///     Administration service event handler
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// AdministrationEventHandler
    /// </summary>
    public class AdministrationEventHandler : EventHandlerBase, IAdministrationEventHandler
    {
        private readonly FacilityRepository _facilityRepository;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdministrationEventHandler" /> class.
        /// </summary>
        /// <param name="operativeWorkUnit">The operative work unit.</param>
        /// <remarks></remarks>
        internal AdministrationEventHandler(IUnitOfWork operativeWorkUnit)
            : base(operativeWorkUnit)
        {
            _facilityRepository = FacilityRepository.New(operativeWorkUnit);
        }

        /// <summary>
        /// GetAdminStationId operation
        /// </summary>
        public int GetAdminStationId(int facilityId)
        {
            var stationRepository = StationRepository.New(OperativeWorkUnit);
            var station = stationRepository.ReadAdminStationByFacility(facilityId);

            return station.StationId;
        }
    }
}
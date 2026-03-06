using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class StationHelper
    {
        public static int? GetStationLocationId(BaseRequestDataContract scanDetails)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var stationRepository = StationRepository.New(workUnit);

                var station = scanDetails.StationId.HasValue ? stationRepository.Get(scanDetails.StationId.Value) : null;

                if (station != null)
                {
                    return station.LocationId;
                }
            }

            return null;
        }

        /// <summary>
        /// IsTurnaroundStation operation
        /// </summary>
        public static bool IsTurnaroundStation(int stationTypeId)
        {
            var isTurnaroundStation = false;
            switch (stationTypeId)
            {
                case (int)StationTypeIdentifier.IntoAutoclaveBatch:
                case (int)StationTypeIdentifier.OutofAutoclave:
                case (int)StationTypeIdentifier.OutofAutoclaveDispatch:
                case (int)StationTypeIdentifier.Dispatch:
                case (int)StationTypeIdentifier.Store:
                case (int)StationTypeIdentifier.TrolleyDispatch:
                case (int)StationTypeIdentifier.OOATrolleyDispatch:
                    isTurnaroundStation = true;
                    break;
            }

            return isTurnaroundStation;
        }
    }
}
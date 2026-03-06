using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class EndoscopyLocationHelper
    {
        /// <summary>
        /// GetLocationDataContract operation
        /// </summary>
        public static EndoscopyLocationDataContract GetLocationDataContract(int stationId, int locationId)
        {
            var allLocations = GetLocationDataContractsForStation(stationId);
            return StripOutUnwantedData(locationId, allLocations);
        }

        /// <summary>
        /// GetLocationDataContractsForStation operation
        /// </summary>
        public static List<EndoscopyLocationDataContract> GetLocationDataContractsForStation(int stationId)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var stationRepository = StationRepository.New(workUnit);
                var station = stationRepository.Repository.Find(s => s.StationId == stationId)
                                    .Include("Machine.MachineSetting")
                                    .Include("Machine.Tree.Leaf.Location")
                                    .SingleOrDefault();

                if (station == null)
                {
                    return new List<EndoscopyLocationDataContract>();
                }

                var ownerId = station.Facility?.OwnerId;

                var locationRepository = LocationRepository.New(workUnit);

                var stationSpecificEndoLocation = (station.Location?.LocationTypeId == (int)LocationTypeIdentifier.EndoscopeStockLocation
                                                     || station.Location?.LocationTypeId == (int)LocationTypeIdentifier.EndoscopeGeneralLocation)
                                                      ? station.Location : null;

                var allEndoscopyLocations = locationRepository.All()
                                                              .Include("Machine.Location")
                                                              .Include("Machine.Tree.Leaf.Location")//shelf                                                              
                                                              .Include("ContainerInstance")
                                                              .Where(l => (l.LocationTypeId == (int)LocationTypeIdentifier.EndoscopeStockLocation
                                                                                 || l.LocationTypeId == (int)LocationTypeIdentifier.EndoscopeGeneralLocation
                                                                          )
                                                                          && l.Leaf.Tree.OwnerId == ownerId
                                                                          && !l.Archived.HasValue
                                                                    )
                                                              .ToList();
                if (stationSpecificEndoLocation != null && allEndoscopyLocations.All(l => l.LocationId != stationSpecificEndoLocation.LocationId))
                {
                    allEndoscopyLocations.Add(stationSpecificEndoLocation);
                }

                List<opsapp_GetEndscopeLocationData_Result> endoscopeCache;
                using (var context = new OperativeModelContainer())
                {
                    endoscopeCache = context.opsapp_GetEndscopeLocationData(station.FacilityId).ToList();
                }
                var writableDryingCabinets = station
                    .Machine.Where(m => m.MachineTypeId == (int)MachineTypeIdentifier.DryingCabinet && !m.Archived.HasValue)
                    .Select(dc => dc)
                    .ToList();
                var readOnlyDryingCabinets = allEndoscopyLocations.SelectMany(loc => loc.Machine)

                    .Where(machine => machine.MachineTypeId == (int)MachineTypeIdentifier.DryingCabinet && (!machine.Archived.HasValue)
                        && !writableDryingCabinets.Contains(machine)
                    ).ToList();

                var allLocationsVacPacks = allEndoscopyLocations
                    .SelectMany(visloc => visloc.ContainerInstance.Select(ci => PullVacPackFromEndoCache(ci, endoscopeCache))
                                                                  .Where(cachedVacPack => cachedVacPack != null))
                    .ToList();

                var endoscopyLocationsList = new List<EndoscopyLocationDataContract>();

                foreach (var loc in allEndoscopyLocations)
                {
                    if (!endoscopyLocationsList.Any(locDc => locDc.Location.LocationId == loc.LocationId))
                    {
                        var writableDryingCabinetsAtThisLocation = writableDryingCabinets.Where(dc => dc.Location.Any(l => l.LocationId == loc.LocationId)).ToList();
                        var readOnlyDryingCabinetsAtThisLocation = readOnlyDryingCabinets.Where(dc => dc.Location.Any(l => l.LocationId == loc.LocationId)).ToList();
                        bool VacPacksAreVisible = (loc.LocationTypeId == (int)LocationTypeIdentifier.EndoscopeStockLocation);

                        var vacPacksAtThisLocation = allLocationsVacPacks.Where(vacPack => vacPack.CurrentLocationId == loc.LocationId).ToList();
                        var locationDataContract = GetEndoscopyLocationDataContract(loc, writableDryingCabinetsAtThisLocation, readOnlyDryingCabinetsAtThisLocation, vacPacksAtThisLocation, endoscopeCache, VacPacksAreVisible);

                        if (locationDataContract != null)
                        {
                            locationDataContract.IsHomeLocation = loc == stationSpecificEndoLocation;
                            endoscopyLocationsList.Add(locationDataContract);
                        }
                    }
                }

                return endoscopyLocationsList;
            }
        }

        private static opsapp_GetEndscopeLocationData_Result PullVacPackFromEndoCache(ContainerInstance ci, List<opsapp_GetEndscopeLocationData_Result> endoCache)
        {
            var pulledVacPack = endoCache.FirstOrDefault(ec => ec.ContainerInstanceId == ci.ContainerInstanceId);
            if (pulledVacPack == null)
            {
                return null;
            }

            if (!pulledVacPack.ContainerInstanceArchived.HasValue && pulledVacPack.CurrentTurnaroundEventEventTypeId == (int)TurnAroundEventTypeIdentifier.IntoPigeonHoleStock)
            {
                return pulledVacPack;
            }
            else
            {
                return null;
            }
        }

        private static EndoscopyLocationDataContract StripOutUnwantedData(int singleLocationId, List<EndoscopyLocationDataContract> endoscopyLocationsList)
        {
            var singleLocation = endoscopyLocationsList.FirstOrDefault(l => l.Location.LocationId == singleLocationId);

            if (singleLocation != null)
            {
                singleLocation.ParentStationExpiredCount = 0;
                singleLocation.ParentStationAlmostExpiredCount = 0;

                foreach (var otherLocation in endoscopyLocationsList)
                {
                    var counts = GetExpiredCountForLocation(otherLocation);
                    singleLocation.ParentStationExpiredCount += counts.expired;
                    singleLocation.ParentStationAlmostExpiredCount += counts.almostExpired;
                }
            }

            return singleLocation;
        }

        private static (int expired, int almostExpired) GetExpiredCountForLocation(EndoscopyLocationDataContract endoLocation)
        {
            var expiredCount = 0;
            var almostExpiredCound = 0;
            if (endoLocation.VacPacks?.Any() ?? false)
            {
                var vacPacksFacilityWarningMinutes = FacilitySettings.EndoscopeAboutToExpireWarningMinutes((short)endoLocation.VacPacks.First().FacilityId.Value) * -1;

                foreach (var vacPack in endoLocation.VacPacks)
                {
                    var counts = EndoscopeHelper.GetIsExpired(vacPack, vacPacksFacilityWarningMinutes);

                    if (counts.expired)
                    {
                        expiredCount++;
                    }
                    else if (counts.almostExpired)
                    {
                        almostExpiredCound++;
                    }
                }
            }
            if (endoLocation.DryingCabinets?.Any() ?? false)
            {
                var dyingCabsWarningMinutes = FacilitySettings.EndoscopeAboutToExpireWarningMinutes((short)endoLocation.DryingCabinets.First().Machine.FacilityId) * -1;
                foreach (var cab in endoLocation.DryingCabinets)
                {
                    var counts = EndoscopyDryingCabinetHelper.GetExpiredCountForDryingCabinet(cab, dyingCabsWarningMinutes);
                    expiredCount += counts.expired;
                    almostExpiredCound += counts.almostExpired;
                }
            }

            return (expiredCount, almostExpiredCound);
        }

        private static EndoscopyLocationDataContract GetEndoscopyLocationDataContract(
            Location location,
            List<Machine> writeableMachines,
            List<Machine> readOnlyMachines,
            List<opsapp_GetEndscopeLocationData_Result> vacPacksAtThisLocation,
            List<opsapp_GetEndscopeLocationData_Result> endoscopeCache,
            bool vacPacksAreVisible)
        {
            var newEndoLocationDataContract = new EndoscopyLocationDataContract()
            {
                Location = new LocationDataContract()
                {
                    LocationId = location.LocationId,
                    Text = location.Text,
                    Description = location.Description,
                    LocationCode = location.LocationCode,
                    ExternalId = location.ExternalId,

                },
                DryingCabinets = new List<EndoscopyDryingCabinetDataContract>(),
                VacPacks = new List<EndoscopeDataContract>(),
                VacPacksAreVisible = vacPacksAreVisible
            };

            writeableMachines.ForEach(wm => newEndoLocationDataContract.DryingCabinets.Add(EndoscopyDryingCabinetHelper.Create(wm, false, endoscopeCache)));
            foreach (var readOnlyMachine in readOnlyMachines)
            {
                if (!newEndoLocationDataContract.DryingCabinets.Any(dc => dc.Machine.Id == readOnlyMachine.MachineId))
                {
                    newEndoLocationDataContract.DryingCabinets.Add(
                        EndoscopyDryingCabinetHelper.Create(readOnlyMachine, true, endoscopeCache));
                }
            }

            newEndoLocationDataContract.DryingCabinets = newEndoLocationDataContract.DryingCabinets.OrderBy(d => d.Machine.Name).ToList();

            vacPacksAtThisLocation.ForEach(vacPac => newEndoLocationDataContract.VacPacks.Add(EndoscopyVacPackHelper.Create(vacPac)));

            if (location.LocationTypeId == (int)LocationTypeIdentifier.EndoscopeGeneralLocation
                && !newEndoLocationDataContract.DryingCabinets.Any())
            {
                return null; //if this location doesn't have vacpacks nor does it have any drying cabs then don't show it as it's empty.
            }

            return newEndoLocationDataContract;
        }

        /// <summary>
        /// EndoscopeIntoStock operation
        /// </summary>
        public static EndoscopyLocationScanAssetDataContract EndoscopeIntoStock(EndoscopeStorageScanDetails scanDetails)
        {
            return ProcessStockRequest(scanDetails, true);
        }

        /// <summary>
        /// EndoscopeRemoveFromStock operation
        /// </summary>
        public static EndoscopyLocationScanAssetDataContract EndoscopeRemoveFromStock(EndoscopeStorageScanDetails scanDetails)
        {
            return ProcessStockRequest(scanDetails, false);
        }

        private static EndoscopyLocationScanAssetDataContract ProcessStockRequest(EndoscopeStorageScanDetails scanDetails, bool addToStock)
        {
            {
                var eventToapply = TurnAroundEventTypeIdentifier.IntoPigeonHoleStock;

                if (addToStock == false)
                {
                    eventToapply = TurnAroundEventTypeIdentifier.OutOfPigeonHoleStock;
                }

                if (scanDetails.UserBadge != null)
                {
                    var userRepository = UserRepository.New(workUnit);
                    var userId = userRepository.GetByBadgeNumber(scanDetails.UserBadge).UserId;
                    scanDetails.UserId = userId;
                }

                ContainerInstance containerInstance;
                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);

                if (scanDetails.InstanceId != null)
                {
                    containerInstance = containerInstanceRepository.Get(scanDetails.InstanceId.Value);
                }
                else
                {
                    var containerInstanceList = containerInstanceRepository.PreSearchContainerInstance(scanDetails.ExternalId, scanDetails.FacilityId, false).ToList();
                    containerInstance = containerInstanceList.FirstOrDefault();

                    if (containerInstanceList.Count > 1)
                    {
                        var duplicateResult = EndoscopyDryingCabinetHelper.CreateEndoscopyLocationScanAssetDataContractResult(null, scanDetails.StationId.Value, scanDetails.SelectedVisibleLocationId);
                        duplicateResult.NonUniqueAssets = new List<AssetDetailsDataContract>();

                        SynergyTrakHelperMk3 mk3helper = new SynergyTrakHelperMk3();

                        containerInstanceList.ForEach(c => duplicateResult.NonUniqueAssets.Add(mk3helper.CreateAssetDataContract(c, null, workUnit)));

                        return duplicateResult;
                    }
                }

                if (containerInstance == null)
                {
                    Scanning.FailedScan.Add(scanDetails.ExternalId, Enums.ScanType.ContainerInstance, scanDetails.UserId, scanDetails.StationId.Value, scanDetails.StationLocationId, eventToapply);

                    var errorResult = EndoscopyDryingCabinetHelper.CreateEndoscopyLocationScanAssetDataContractResult(ErrorCodes.InvalidItem, scanDetails.StationId.Value, scanDetails.SelectedVisibleLocationId);
                    errorResult.ScannedString = scanDetails.ExternalId;
                    return errorResult;
                }

                if (containerInstance.CurrentTurnaround == null)
                {
                    var errorResult = EndoscopyDryingCabinetHelper.CreateEndoscopyLocationScanAssetDataContractResult(ErrorCodes.NoCurrentTurnaround, scanDetails.StationId.Value, scanDetails.SelectedVisibleLocationId);
                    errorResult.ScannedString = scanDetails.ExternalId;
                    return errorResult;
                }

                var stockManagementRequest = new StockManagementRequest
                {
                    CheckNotes = scanDetails.AlwaysCheckNotes,
                    LocationId = scanDetails.StorageLocationId,
                    FacilityId = scanDetails.FacilityId,
                    StationId = scanDetails.StationId,
                    UserId = scanDetails.UserId,
                    StationTypeId = scanDetails.StationTypeId,
                    EventType = (short)eventToapply,
                    Scans = new List<long>
                    {
                        containerInstance.CurrentTurnaround.ExternalId
                    }
                };

                var mk3Helper = new SynergyTrakHelperMk3(new Models.SynergyTrakData(), true);

                StockManagementDataContract<EndoscopyLocationScanAssetDataContract> stockManagementDataContract;

                if (addToStock)
                {
                    stockManagementDataContract = mk3Helper.AddToStock<EndoscopyLocationScanAssetDataContract>(stockManagementRequest);
                }
                else
                {
                    stockManagementRequest.LocationId = scanDetails.StationLocationId;
                    stockManagementDataContract = mk3Helper.RemoveFromStock<EndoscopyLocationScanAssetDataContract>(stockManagementRequest);
                }

                var result = stockManagementDataContract.ScannedAssets.First();

                result.ScannedString = scanDetails.ExternalId;

                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                turnaroundRepository.Repository.Detach(containerInstance.CurrentTurnaround);

                containerInstanceRepository.Repository.Detach(containerInstance);
                containerInstance = containerInstanceRepository.Get(containerInstance.ContainerInstanceId);

                result.EndoscopyLocationDataContract = GetLocationDataContract(scanDetails.StationId.Value, scanDetails.SelectedVisibleLocationId);

                result.ModifiedEndoscope = EndoscopeHelper.GetEndoscopeDataContract(containerInstance);

                return result;
            }
        }
    }
}
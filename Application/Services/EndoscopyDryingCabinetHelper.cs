using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class EndoscopyDryingCabinetHelper
    {
        /// <summary>
        /// Create operation
        /// </summary>
        public static EndoscopyDryingCabinetDataContract Create(Machine dryingCabinet, bool readOnly, List<opsapp_GetEndscopeLocationData_Result> endoscopeCache)
        {
            return new EndoscopyDryingCabinetDataContract()
            {
                Machine = new MachineDataContract() { Id = dryingCabinet.MachineId, Name = dryingCabinet.Text, FacilityId = dryingCabinet.FacilityId },
                ReadOnly = readOnly,
                Shelves = GetShelvesForDryingCabinet(dryingCabinet, endoscopeCache)
            };
        }

        private static List<DryingCabinetShelfLocationDataContract> GetShelvesForDryingCabinet(Machine dryingCabinet, List<opsapp_GetEndscopeLocationData_Result> endoscopeCache)
        {

            var cabinetShelves = new List<DryingCabinetShelfLocationDataContract>();
            var dryingCabLocations = dryingCabinet.Tree.Leaf.Where(lf => lf.Rgt - lf.Lft == 1).SelectMany(leaf => leaf.Location);

            foreach (var shelfLocation in dryingCabLocations)
            {
                var shelfDataContract = new DryingCabinetShelfLocationDataContract()
                {
                    Location = new LocationDataContract()
                    {
                        LocationId = shelfLocation.LocationId,
                        Text = shelfLocation.Text,
                        LocationCode = shelfLocation.LocationCode,
                        ExternalId = shelfLocation.ExternalId
                    },
                };

                AddEndoscopeToShelf(shelfDataContract, endoscopeCache, dryingCabinet);

                cabinetShelves.Add(shelfDataContract);
            }

            return cabinetShelves;
        }

        private static void AddEndoscopeToShelf(DryingCabinetShelfLocationDataContract shelf, List<opsapp_GetEndscopeLocationData_Result> endoscopeCache, Machine cabinet)
        {
            var scope = endoscopeCache.Find(s => s.CurrentLocationId == shelf.Location.LocationId);
            shelf.Endoscope = EndoscopeHelper.GetEndoscopeDataContract(scope, cabinet);
        }

        public static (int expired, int almostExpired) GetExpiredCountForDryingCabinet(EndoscopyDryingCabinetDataContract cabinet, int warningMinutes)
        {
            var expired = 0;
            var almostExpired = 0;

            foreach (var shelf in cabinet.Shelves)
            {
                if (shelf.Endoscope != null)
                {
                    var isExp = EndoscopeHelper.GetIsExpired(shelf.Endoscope, warningMinutes);
                    if (isExp.expired)
                    {
                        expired++;
                    }
                    else if (isExp.almostExpired)
                    {
                        almostExpired++;
                    }
                }
            }

            return (expired, almostExpired);
        }

        /// <summary>
        /// IntoDryingCabinet operation
        /// </summary>
        public static EndoscopyLocationScanAssetDataContract IntoDryingCabinet(EndoscopeStorageScanDetails endoscopeStorageScanDetails)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var stationRepository = StationRepository.New(workUnit);

                var station = stationRepository.Repository.Find(s => s.StationId == endoscopeStorageScanDetails.StationId).Single();

                if (endoscopeStorageScanDetails.UserBadge != null)
                {
                    var userRepository = UserRepository.New(workUnit);
                    var userId = userRepository.GetByBadgeNumber(endoscopeStorageScanDetails.UserBadge).UserId;
                    endoscopeStorageScanDetails.UserId = userId;
                }

                var dryingCabinet = station.Machine.FirstOrDefault(m => m.MachineId == endoscopeStorageScanDetails.MachineId &&
                    m.Archived == null &&
                    m.MachineTypeId == (int)MachineTypeIdentifier.DryingCabinet &&
                    m.Location.Any(loc => loc.LocationId == endoscopeStorageScanDetails.SelectedVisibleLocationId));
                if (dryingCabinet == null)
                {
                    return CreateEndoscopyLocationScanAssetDataContractResult(ErrorCodes.DryingCabinetNotAccessible, endoscopeStorageScanDetails.StationId.Value, endoscopeStorageScanDetails.SelectedVisibleLocationId);
                }

                var shelf = dryingCabinet.Tree.Leaf.SelectMany(leaf => leaf.Location).FirstOrDefault(loc => endoscopeStorageScanDetails.StorageLocationId == loc.LocationId);
                if (shelf == null)
                {
                    return CreateEndoscopyLocationScanAssetDataContractResult(ErrorCodes.DryingCabinetShelfNotFound, endoscopeStorageScanDetails.StationId.Value, endoscopeStorageScanDetails.SelectedVisibleLocationId);
                }
                if (shelf.ContainerInstance.Any())
                {
                    return CreateEndoscopyLocationScanAssetDataContractResult(ErrorCodes.DryingCabinetShelfNotEmpty, endoscopeStorageScanDetails.StationId.Value, endoscopeStorageScanDetails.SelectedVisibleLocationId);
                }
            }

            var data = new Models.SynergyTrakData
            {
                StationId = endoscopeStorageScanDetails.StationId,
                StationLocationId = endoscopeStorageScanDetails.StationLocationId
            };

            var mk3Helper = new SynergyTrakHelperMk3(data, true);

            endoscopeStorageScanDetails.Events = new List<ScanEventDataContract>()
            {
                new ScanEventDataContract()
                {
                    EventType = (int)TurnAroundEventTypeIdentifier.IntoDryingCabinet
                }
            };

            endoscopeStorageScanDetails.StationLocationId = endoscopeStorageScanDetails.StorageLocationId;

            var result = new EndoscopyLocationScanAssetDataContract();
            mk3Helper.Scan(endoscopeStorageScanDetails, result);

            result.EndoscopyLocationDataContract = EndoscopyLocationHelper.GetLocationDataContract(endoscopeStorageScanDetails.StationId.Value, endoscopeStorageScanDetails.SelectedVisibleLocationId);

            return result;
        }
        /// <summary>
        /// CreateEndoscopyLocationScanAssetDataContractResult operation
        /// </summary>
        public static EndoscopyLocationScanAssetDataContract CreateEndoscopyLocationScanAssetDataContractResult(ErrorCodes? errorCode, int stationId, int locationId)
        {
            var result = new EndoscopyLocationScanAssetDataContract()
            {
                EndoscopyLocationDataContract = EndoscopyLocationHelper.GetLocationDataContract(stationId, locationId),
                ErrorCode = (int?)errorCode
            };
            return result;
        }

        /// <summary>
        /// RemovedFromDryingCabinet operation
        /// </summary>
        public static EndoscopyLocationScanAssetDataContract RemovedFromDryingCabinet(EndoscopeStorageScanDetails endoscopeStorageScanDetails)
        {
            var result = new EndoscopyLocationScanAssetDataContract();

            {
                if (endoscopeStorageScanDetails.UserBadge != null)
                {
                    var userRepository = UserRepository.New(workUnit);
                    var userId = userRepository.GetByBadgeNumber(endoscopeStorageScanDetails.UserBadge).UserId;
                    endoscopeStorageScanDetails.UserId = userId;
                }

                var stationRepository = StationRepository.New(workUnit);

                var station = stationRepository.Repository.Find(s => s.StationId == endoscopeStorageScanDetails.StationId).Single();

                var dryingCabinet = station.Machine.FirstOrDefault(m => m.MachineId == endoscopeStorageScanDetails.MachineId &&
                   m.Archived == null &&
                   m.MachineTypeId == (int)MachineTypeIdentifier.DryingCabinet &&
                   m.Location.Any(loc => loc.LocationId == endoscopeStorageScanDetails.SelectedVisibleLocationId));
                if (dryingCabinet == null)
                {
                    return CreateEndoscopyLocationScanAssetDataContractResult(ErrorCodes.DryingCabinetNotAccessible, endoscopeStorageScanDetails.StationId.Value, endoscopeStorageScanDetails.SelectedVisibleLocationId);
                }

                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                var container = containerInstanceRepository.PreSearchContainerInstance(endoscopeStorageScanDetails.ExternalId, endoscopeStorageScanDetails.FacilityId, false).FirstOrDefault();
                if (container == null)
                {
                    container = containerInstanceRepository.Get(endoscopeStorageScanDetails.InstanceId.Value);
                }
                else
                {
                    endoscopeStorageScanDetails.InstanceId = container.ContainerInstanceId;
                }

                var intoDryingCabinetEvent = container.CurrentTurnaround.TurnaroundEvent.Where(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoDryingCabinet).OrderByDescending(te => te.Created).FirstOrDefault();
                var aerPassedEvent = container.CurrentTurnaround.TurnaroundEvent.Where(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AerPassed).OrderByDescending(te => te.Created).FirstOrDefault();
                var utcNow = DateTime.UtcNow;

                var elapsedTimeInDryingCabinet = utcNow - intoDryingCabinetEvent.Created;
                var requiredElapsedTimeToDry = new TimeSpan(0, dryingCabinet.RunningTime, 0);

                var eventToAppy = TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetExpired;

                if (elapsedTimeInDryingCabinet >= requiredElapsedTimeToDry)
                {
                    if (utcNow >= intoDryingCabinetEvent.Created.AddMinutes(MachineSettings.EndoscopeMaxDryingTimeOrDefault(endoscopeStorageScanDetails.MachineId.Value)))
                    {
                    }
                    else
                    {
                        eventToAppy = TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetDry;
                    }
                }
                else
                {
                    if ((utcNow >= intoDryingCabinetEvent.Created.AddMinutes(MachineSettings.EndoscopeMaxDryingTimeOrDefault(endoscopeStorageScanDetails.MachineId.Value))) || (utcNow >= aerPassedEvent.Created.AddMinutes(FacilitySettings.EndoscopeSterileExpiryAerPassedMinutes(aerPassedEvent.Turnaround.FacilityId))))
                    {
                        if (FacilitySettings.EndoscopeRemovedWetRelaxedExpiryRules(endoscopeStorageScanDetails.FacilityId))
                        {
                            eventToAppy = TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetWet;
                        }
                    }
                    else
                    {
                        eventToAppy = TurnAroundEventTypeIdentifier.RemovedFromDryingCabinetWet;
                    }
                }
                endoscopeStorageScanDetails.Events = new List<ScanEventDataContract>
                {
                    new ScanEventDataContract
                    {
                        EventType = (int)eventToAppy
                    }
                };

                var data = new Models.SynergyTrakData { StationId = endoscopeStorageScanDetails.StationId, StationLocationId = endoscopeStorageScanDetails.StationLocationId };
                var mk3Helper = new SynergyTrakHelperMk3(data, true);

                mk3Helper.Scan(endoscopeStorageScanDetails, result);

                var turnaroundRepository = TurnaroundRepository.New(workUnit);

                turnaroundRepository.Repository.Detach(container.CurrentTurnaround);
                containerInstanceRepository.Repository.Detach(container);

                container = containerInstanceRepository.Get(container.ContainerInstanceId);

                result.EndoscopyLocationDataContract = EndoscopyLocationHelper.GetLocationDataContract(endoscopeStorageScanDetails.StationId.Value, endoscopeStorageScanDetails.SelectedVisibleLocationId);
                result.ModifiedEndoscope = EndoscopeHelper.GetEndoscopeDataContract(container);
            }

            return result;
        }
    }
}
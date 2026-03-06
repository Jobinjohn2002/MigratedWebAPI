using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {
        /// <summary>
        /// LoadTrolleyEpoc operation
        /// </summary>
        public ScanAssetDataContract LoadTrolleyEpoc(int instanceId, int stationId, int userId)
        {
            ScanAssetDataContract scanAssetDataContract = new ScanAssetDataContract();

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var stationRepository = StationRepository.New(workUnit);
                var station = stationRepository.Get(stationId);

                _synergyTrakData.StationId = station.StationId;
                _synergyTrakData.StationTypeId = station.StationTypeId;
                _synergyTrakData.FacilityId = station.FacilityId;
                _synergyTrakData.StationLocationId = station.LocationId;

                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                var turnaround = containerInstanceRepository.GetLastLiveTurnaroundByInstance(instanceId);

                var scanDetails = new ScanDetails
                {
                    IgnoreNotesWarningsAndDecon = true,
                    InstanceId = instanceId,
                    UserId = userId,
                    StationId = station.StationId,
                    StationTypeId = station.StationTypeId,
                    StationLocationId = station.LocationId.Value,
                    ApplyEvent = true,
                    FacilityId = station.FacilityId,
                    Events = new List<ScanEventDataContract>
                    {
                        new ScanEventDataContract
                        {
                            EventType = (int) TurnAroundEventTypeIdentifier.LoadTrolleyEPOC
                        }
                    }
                };
                _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.LoadTrolleyEPOC;
                if (turnaround != null &&
                    turnaround.LastEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.LoadTrolleyEPOC)
                {
                    scanDetails.ApplyEvent = false;
                    scanDetails.Events = new List<ScanEventDataContract>();
                    _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.Unknown;
                }

                Scan(scanDetails, scanAssetDataContract);
            }

            return scanAssetDataContract;
        }

        /// <summary>
        /// LoadInstanceOntoTrolley operation
        /// </summary>
        public ScanAssetDataContract LoadInstanceOntoTrolley(int instanceId, int trolleyTurnaroundId, int userId, int stationId)
        {
            ScanAssetDataContract scanAssetDataContract = new ScanAssetDataContract();

            {
                var stationRepository = StationRepository.New(workUnit);
                var station = stationRepository.Get(stationId);

                _synergyTrakData.StationId = station.StationId;
                _synergyTrakData.StationTypeId = station.StationTypeId;
                _synergyTrakData.FacilityId = station.FacilityId;
                _synergyTrakData.StationLocationId = station.LocationId;

                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                var turnaround = containerInstanceRepository.GetLastLiveTurnaroundByInstance(instanceId);
                if (turnaround != null &&
                    turnaround.LastEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.LoadTrolleyEPOD)
                {
                    var automaticDeliveryScanDetails = new ScanDetails
                    {
                        IgnoreNotesWarningsAndDecon = true,
                        InstanceId = instanceId,
                        UserId = userId,
                        StationId = station.StationId,
                        StationTypeId = station.StationTypeId,
                        StationLocationId = station.LocationId.Value,
                        ApplyEvent = true,
                        FacilityId = station.FacilityId,
                        Events = new List<ScanEventDataContract>
                        {
                            new ScanEventDataContract
                            {
                                EventType = (int) TurnAroundEventTypeIdentifier.AutomaticDelivery
                            }
                        }
                    };

                    _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.AutomaticDelivery;

                    ProcessTurnaround(turnaround, scanAssetDataContract, automaticDeliveryScanDetails, null,
                        isStreamLined: true);
                }

                var scanDetails = new ScanDetails
                {
                    InstanceId = instanceId,
                    ParentTurnaroundId = trolleyTurnaroundId,
                    UserId = userId,
                    StationId = stationId,
                    StationTypeId = station.StationTypeId,
                    ApplyEvent = true,
                    FacilityId = station.FacilityId,
                    Events = new List<ScanEventDataContract>
                    {
                        new ScanEventDataContract
                        {
                            EventType = (int) TurnAroundEventTypeIdentifier.LoadTrolleyEPOC,

                        }
                    }
                };

                Scan(scanDetails, scanAssetDataContract);
            }

            return scanAssetDataContract;
        }

        /// <summary>
        /// MakeTrolleyAvailableForCollection operation
        /// </summary>
        public ScanAssetDataContract MakeTrolleyAvailableForCollection(int instanceId, int stationId, int userId)
        {
            ScanAssetDataContract scanAssetDataContract = new ScanAssetDataContract();

            {
                var stationRepository = StationRepository.New(workUnit);
                var station = stationRepository.Get(stationId);

                var repository = TurnaroundRepository.New(workUnit);
                var parentTurnaround = repository.GetTurnaroundsForAssigned(instanceId).FirstOrDefault();
                
                _synergyTrakData.StationId = station.StationId;
                _synergyTrakData.StationTypeId = station.StationTypeId;
                _synergyTrakData.FacilityId = station.FacilityId;
                _synergyTrakData.StationLocationId = station.LocationId;

                var scanDetails = new ScanDetails
                {
                    IgnoreNotesWarningsAndDecon = true,
                    InstanceId = instanceId,
                    UserId = userId,
                    StationId = station.StationId,
                    StationTypeId = station.StationTypeId,
                    StationLocationId = station.LocationId.Value,
                    ApplyEvent = true,
                    FacilityId = station.FacilityId,
                    ParentTurnaroundId = parentTurnaround != null ? (int?)parentTurnaround.TurnaroundId : null,
                    ParentItemTypeId = parentTurnaround != null ? (int?)parentTurnaround.ContainerMaster.ItemType.ParentItemTypeId : null,
                    Events = new List<ScanEventDataContract>
                    {
                        new ScanEventDataContract
                        {
                            EventType = (int) TurnAroundEventTypeIdentifier.AvailableForCollection
                        }
                    }
                };

                _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.AvailableForCollection;

                Scan(scanDetails, scanAssetDataContract);
            }

            return scanAssetDataContract;
        }

        /// <summary>
        /// RecordCollection operation
        /// </summary>
        public ScanAssetDataContract RecordCollection(int instanceId, int stationId, int userId)
        {
            ScanAssetDataContract scanAssetDataContract = new ScanAssetDataContract();

            {
                var stationRepository = StationRepository.New(workUnit);
                var station = stationRepository.Get(stationId);

                var repository = TurnaroundRepository.New(workUnit);
                var parentTurnaround = repository.GetTurnaroundsForAssigned(instanceId).FirstOrDefault();

                _synergyTrakData.StationId = station.StationId;
                _synergyTrakData.StationTypeId = station.StationTypeId;
                _synergyTrakData.FacilityId = station.FacilityId;
                _synergyTrakData.StationLocationId = station.LocationId;

                var scanDetails = new ScanDetails
                {
                    IgnoreNotesWarningsAndDecon = true,
                    InstanceId = instanceId,
                    UserId = userId,
                    StationId = station.StationId,
                    StationTypeId = station.StationTypeId,
                    StationLocationId = station.LocationId.Value,
                    ApplyEvent = true,
                    FacilityId = station.FacilityId,
                    ParentTurnaroundId = parentTurnaround != null ? (int?)parentTurnaround.TurnaroundId : null,
                    ParentItemTypeId = parentTurnaround != null ? (int?)parentTurnaround.ContainerMaster.ItemType.ParentItemTypeId : null,
                    Events = new List<ScanEventDataContract>
                    {
                        new ScanEventDataContract
                        {
                            EventType = (int) TurnAroundEventTypeIdentifier.Collected
                        }
                    }
                };
                _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.Collected;

                Scan(scanDetails, scanAssetDataContract);
            }

            return scanAssetDataContract;
        }

        /// <summary>
        /// DeliverTrolley operation
        /// </summary>
        public ScanAssetDataContract DeliverTrolley(int instanceId, int stationId, int userId)
        {
            ScanAssetDataContract scanAssetDataContract = new ScanAssetDataContract();

            {
                var stationRepository = StationRepository.New(workUnit);
                var station = stationRepository.Get(stationId);

                _synergyTrakData.StationId = station.StationId;
                _synergyTrakData.StationTypeId = station.StationTypeId;
                _synergyTrakData.FacilityId = station.FacilityId;
                _synergyTrakData.StationLocationId = station.LocationId;

                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                var turnaround = containerInstanceRepository.GetLastLiveTurnaroundByInstance(instanceId);

                scanAssetDataContract.DeliveryNoteId = turnaround?.DeliveryNoteId;

                var scanDetails = new ScanDetails
                {
                    IgnoreNotesWarningsAndDecon = true,
                    InstanceId = instanceId,
                    UserId = userId,
                    StationId = station.StationId,
                    StationTypeId = station.StationTypeId,
                    StationLocationId = station.LocationId.Value,
                    ApplyEvent = true,
                    FacilityId = station.FacilityId,
                    Events = new List<ScanEventDataContract>
                    {
                        new ScanEventDataContract
                        {
                            EventType = (int) TurnAroundEventTypeIdentifier.Delivered
                        }
                    }
                };
                _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.Delivered;

                Scan(scanDetails, scanAssetDataContract);
            }

            return scanAssetDataContract;
        }

        /// <summary>
        /// DeliverDeliveryNote operation
        /// </summary>
        public ScanAssetDataContract DeliverDeliveryNote(int deliveryNoteId, int stationId, int userId)
        {
            var saDC = new ScanAssetDataContract();
            {
                var stationRepository = StationRepository.New(workUnit);
                var station = stationRepository.Get(stationId);

                _synergyTrakData.StationId = station.StationId;
                _synergyTrakData.StationTypeId = station.StationTypeId;
                _synergyTrakData.FacilityId = station.FacilityId;
                _synergyTrakData.StationLocationId = station.LocationId;

                var scanDetails = new ScanDetails
                {
                    IgnoreNotesWarningsAndDecon = true,
                    DeliveryNoteExternalId = deliveryNoteId,
                    UserId = userId,
                    StationId = station.StationId,
                    StationTypeId = station.StationTypeId,
                    StationLocationId = station.LocationId.Value,
                    ApplyEvent = true,
                    FacilityId = station.FacilityId,
                    Events = new List<ScanEventDataContract>
                        {
                            new ScanEventDataContract
                            {
                                EventType = (int) TurnAroundEventTypeIdentifier.Delivered
                            }
                        }
                };
                _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.Delivered;

                Scan(scanDetails, saDC);

                return saDC;

            }
        }
    

        /// <summary>
        /// AddTrolleyToStoragePoint operation
        /// </summary>
        public List<ScanAssetDataContract> AddTrolleyToStoragePoint(int storagePointId, int trolleyId, int stationId, int userId)
        {
            ScanAssetDataContract scanAssetDataContract = new ScanAssetDataContract
            {
                UserId = userId
            };

            {
                var stationRepository = StationRepository.New(workUnit);
                var station = stationRepository.Get(stationId);

                _synergyTrakData.StationId = station.StationId;
                _synergyTrakData.StationTypeId = station.StationTypeId;
                _synergyTrakData.FacilityId = station.FacilityId;
                _synergyTrakData.StationLocationId = station.LocationId;

                var storagePointRepository = StoragePointRepository.New(workUnit);
                var storagePoint = storagePointRepository.Get(storagePointId);
                scanAssetDataContract.StoragePointId = storagePoint.StoragePointId;
                _synergyTrakData.StoragePointLocationId = storagePoint.LocationId;

                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);
                var turnaround = containerInstanceRepository.GetLastTurnaroundByInstance(trolleyId);
                scanAssetDataContract.DeliveryNoteId = turnaround.DeliveryNoteId;

                _synergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.IntoPigeonHoleStock;
                _synergyTrakData.IntoPidgeonHoleStockExtras = false;
                _synergyTrakData.UserId = userId;

                var scanDetails = new ScanDetails
                {
                    IgnoreNotesWarningsAndDecon = true,
                    InstanceId = trolleyId,
                    UserId = userId,
                    StationId = station.StationId,
                    StationTypeId = station.StationTypeId,
                    StationLocationId = station.LocationId ?? 0,
                    ApplyEvent = true,
                    FacilityId = station.FacilityId,
                    BaseItemTypeId = turnaround.BaseItemTypeId,
                    Events = new List<ScanEventDataContract>
                    {
                        new ScanEventDataContract
                        {
                            EventType = (int) TurnAroundEventTypeIdentifier.IntoPigeonHoleStock
                        }
                    }
                };

                var eventTypeRepository = EventTypeRepository.New(workUnit);
                var eventTypeRow = eventTypeRepository.Get((int)_synergyTrakData.EventTypeId);

                if (eventTypeRow != null)
                {
                    _isProcessEvent = eventTypeRow.ProcessEvent;

                    ProcessTurnaround(turnaround, scanAssetDataContract, scanDetails, null, isStreamLined: true);
                }

                return _synergyTrakData.ScanDcList;
            }

        }

        private bool ExludeTrolleyFromMFPByEvent()
        {
            return _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.LoadTrolleyEPOC
                || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.AvailableForCollection
                || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Collected
                || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.Delivered
                || _synergyTrakData.EventTypeId == TurnAroundEventTypeIdentifier.IntoPigeonHoleStock;
        }
    }
}

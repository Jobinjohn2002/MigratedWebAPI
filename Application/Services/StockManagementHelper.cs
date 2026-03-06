using SynergyApplicationFrameworkApi.Application.DTOs.Helpers;
using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {
        /// <summary>
        /// StockTake operation
        /// </summary>
        public StockManagementDataContract<ScanAssetDataContract> StockTake(StockManagementRequest addStockManagementRequest)
        {
            _ignoreNotesWarningsAndDecon = true;
            addStockManagementRequest.EventType = (short)TurnAroundEventTypeIdentifier.IntoPigeonHoleStock;
            var removeStockManagementRequest = new StockManagementRequest
            {
                UserId = addStockManagementRequest.UserId,
                EventType = (short)TurnAroundEventTypeIdentifier.OutOfPigeonHoleStock,
                Culture = addStockManagementRequest.Culture,
                FacilityId = addStockManagementRequest.FacilityId,
                NTLogon = addStockManagementRequest.NTLogon,
                StationId = addStockManagementRequest.StationId,
                PrimaryFacilityId = addStockManagementRequest.PrimaryFacilityId,
                StationTypeId = addStockManagementRequest.StationTypeId,
                LocationId = null,
                Scans = new List<long>()
            };

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);

                var inStockTurnarounds = turnaroundRepository.Repository.All().Where(turnaround =>
                    turnaround.CurrentTurnaroundEvent.TurnaroundEvent.EventTypeId ==
                    (int)TurnAroundEventTypeIdentifier.IntoPigeonHoleStock &&
                    turnaround.CurrentTurnaroundEvent.TurnaroundEvent.LocationId == addStockManagementRequest.LocationId)
                    .ToList();
                foreach (var turnaround in inStockTurnarounds)
                {
                    if (addStockManagementRequest.Scans.All(a => a != turnaround.ExternalId))
                    {
                        removeStockManagementRequest.Scans.Add(turnaround.ExternalId);
                    }
                }

                var removedTurnarounds = RemoveFromStock<ScanAssetDataContract>(removeStockManagementRequest);

                foreach (var turnaround in removedTurnarounds.ScannedAssets.Where(s => s.ErrorCode == null))
                {
                    AddToStocktakeHistory(addStockManagementRequest.UserId, turnaround.TurnaroundId.Value,
                        addStockManagementRequest.LocationId.Value, StocktakeActivityIdentifier.Missing);
                }

                var addedTurnarounds = AddToStock<ScanAssetDataContract>(addStockManagementRequest);

                foreach (var turnaround in addedTurnarounds.ScannedAssets)
                {
                    if (turnaround.ErrorCode == null)
                    {
                        if (inStockTurnarounds.All(a => a.TurnaroundId != turnaround.TurnaroundId))
                        {
                            AddToStocktakeHistory(addStockManagementRequest.UserId, turnaround.TurnaroundId.Value,
                                addStockManagementRequest.LocationId.Value, StocktakeActivityIdentifier.Added);
                        }
                        else
                        {
                            AddToStocktakeHistory(addStockManagementRequest.UserId, turnaround.TurnaroundId.Value,
                                addStockManagementRequest.LocationId.Value, StocktakeActivityIdentifier.ConfirmedPresent);
                        }
                    }
                }

                return addedTurnarounds;
            }
        }

        public StockManagementDataContract<T> AddToStock<T>(StockManagementRequest stockManagementRequest) where T : ScanAssetDataContract, new()
        {
            _synergyTrakData.StationLocationId = stockManagementRequest.LocationId;
            _synergyTrakData.IntoPidgeonHoleStockExtras = true;
            {
                return ProcessStockRequest<T>(stockManagementRequest, workUnit);
            }
        }

        public StockManagementDataContract<T> RemoveFromStock<T>(StockManagementRequest stockManagementRequest) where T : ScanAssetDataContract, new()
        {
            {
                var stationRepository = StationRepository.New(workUnit);
                var station = stationRepository.Get(stockManagementRequest.StationId.Value);
                _synergyTrakData.StationLocationId = station.LocationId;
                return ProcessStockRequest<T>(stockManagementRequest, workUnit);
            }
        }

        private StockManagementDataContract<T> ProcessStockRequest<T>(StockManagementRequest stockManagementRequest, IUnitOfWork workUnit) where T : ScanAssetDataContract, new()
        {
            var stockManagementData = new StockManagementDataContract<T>
            {
                ScannedAssets = new List<T>()
            };

            #region Trolley Processing        
            if (stockManagementRequest.TrolliesScanned != null)
            {
                foreach (var trolleyTurnaroundId in stockManagementRequest.TrolliesScanned)
                {
                    var eventToApply = TurnAroundEventTypeIdentifier.IntoPigeonHoleStock;

                    var stationRepository = StationRepository.New(workUnit);
                    var storagePointRepository = StoragePointRepository.New(workUnit);

                    var storagePoint = stockManagementRequest.LocationId.HasValue ? storagePointRepository.GetByLocation(stockManagementRequest.LocationId.Value) : null;

                    var station = stationRepository.Get(stockManagementRequest.StationId.Value);

                    _synergyTrakData.StationTypeId = stockManagementRequest.StationTypeId;
                    _synergyTrakData.StationId = station.StationId;
                    _synergyTrakData.FacilityId = stockManagementRequest.FacilityId;
                    _synergyTrakData.UserId = stockManagementRequest.UserId;

                    var scanDetails = new ScanDetails
                    {
                        AlwaysCheckNotes = stockManagementRequest.CheckNotes,
                        ApplyEvent = true,
                        StationId = stockManagementRequest.StationId,
                        StationTypeId = station.StationTypeId,
                        FacilityId = stockManagementRequest.FacilityId,
                        UserId = stockManagementRequest.UserId,
                        ParentTurnaroundId = null,
                        IsRemoveFromParent = false,

                        Events = new List<ScanEventDataContract>
                    {
                        new ScanEventDataContract
                        {
                            EventType = (int)eventToApply
                        }
                    },
                        TurnaroundId = trolleyTurnaroundId
                    };

                    var dataContract = new ScanAssetDataContract
                    {
                        StoragePointId = storagePoint?.StoragePointId,
                    };

                    Scan(scanDetails, dataContract);

                    if (dataContract.ChildItems != null)
                    {
                        if (dataContract.ErrorCode != null)
                        {
                            foreach (var child in dataContract.ChildItems)
                            {
                                child.ErrorCode = dataContract.ErrorCode;
                            }

                        }

                        foreach (var child in dataContract.ChildItems)
                        {
                            stockManagementData.ScannedAssets.Add((T)child);
                        }
                    }
                }
            }
            #endregion

            #region Individual Scans Processing
            foreach (var turnaroundExternalId in stockManagementRequest.Scans)
            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacility(turnaroundExternalId);

                #region Validation
                if (turnaround == null)
                {
                    stockManagementData.ScannedAssets.Add(new T
                    {
                        TurnaroundExternalId = turnaroundExternalId,
                        ErrorCode = (int)ErrorCodes.InvalidTurnaround,
                    });

                    Helpers.Scanning.FailedScan.Add(turnaroundExternalId, Enums.ScanType.Turnaround, stockManagementRequest.UserId,
                        stockManagementRequest.StationId.Value, _synergyTrakData.StationLocationId, TurnAroundEventTypeIdentifier.IntoPigeonHoleStock);

                    continue;
                }

                var userDeliveryPointRepo = UserDeliveryPointRepository.New(workUnit);
                var deliveryPointRepo = DeliveryPointRepository.New(workUnit);
                var deliveryPoints = userDeliveryPointRepo.ReadDeliveryPointsByUser(stockManagementRequest.UserId);
                var turnaroundDeliveryPoint = deliveryPointRepo.Get(turnaround.DeliveryPointId);
                if (turnaround.ContainerMaster.BaseItemType.ItemTypeId != (int)ItemTypeIdentifier.Endoscopy
                    || (turnaround.ContainerMaster.BaseItemType.ItemTypeId == (int)ItemTypeIdentifier.Endoscopy && stockManagementRequest.EventType != (int)TurnAroundEventTypeIdentifier.OutOfPigeonHoleStock)
                )
                {
                    if (deliveryPoints.All(d => d.CustomerDefinitionId != turnaroundDeliveryPoint.CustomerDefinitionId))
                    {
                        stockManagementData.ScannedAssets.Add(new T
                        {
                            TurnaroundExternalId = turnaroundExternalId,
                            ErrorCode = (int)ErrorCodes.InvalidTurnaround,
                        });

                        Helpers.Scanning.FailedScan.Add(turnaroundExternalId, Pathway.Enums.ScanType.Turnaround, stockManagementRequest.UserId,
                            stockManagementRequest.StationId.Value, _synergyTrakData.StationLocationId, TurnAroundEventTypeIdentifier.IntoPigeonHoleStock);

                        continue;
                    }
                }
                if (turnaround.ContainerMaster.BaseItemType.ItemTypeId == (int)ItemTypeIdentifier.Trolley)
                {
                    stockManagementData.ScannedAssets.Add(new T
                    {
                        TurnaroundExternalId = turnaroundExternalId,
                        ErrorCode = (int)ErrorCodes.StockManagementTrolleyScan,
                    });

                    Helpers.Scanning.FailedScan.Add(turnaroundExternalId, Pathway.Enums.ScanType.Turnaround, stockManagementRequest.UserId,
                        stockManagementRequest.StationId.Value, _synergyTrakData.StationLocationId, TurnAroundEventTypeIdentifier.IntoPigeonHoleStock);

                    continue;
                }

                if (stockManagementRequest.LocationId != null && stockManagementRequest.EventType == (int)TurnAroundEventTypeIdentifier.IntoPigeonHoleStock && !ValidStoragePointForTurnaround(turnaround, stockManagementRequest.LocationId.Value, workUnit))
                {
                    stockManagementData.ScannedAssets.Add(new T
                    {
                        TurnaroundExternalId = turnaroundExternalId,
                        ErrorCode = (int)ErrorCodes.InvalidTurnaround,
                    });

                    Helpers.Scanning.FailedScan.Add(turnaroundExternalId, Enums.ScanType.Turnaround, stockManagementRequest.UserId,
                        stockManagementRequest.StationId.Value, _synergyTrakData.StationLocationId, TurnAroundEventTypeIdentifier.IntoPigeonHoleStock);

                    continue;
                }
                var containerRepository = ContainerInstanceRepository.New(workUnit);
                if (turnaround.ContainerInstanceId != null)
                {
                    var turnaroundContainer = containerRepository.PreSearchContainerInstance(turnaround.ContainerInstanceId.Value, stockManagementRequest.FacilityId);

                    if (turnaroundContainer != null)
                    {
                        var latestTurnaround = containerRepository.GetLastLiveTurnaroundByInstanceForStock(turnaroundContainer.ContainerInstanceId);

                        if (turnaround.TurnaroundId != latestTurnaround.TurnaroundId)
                        {
                            stockManagementData.ScannedAssets.Add(new T
                            {
                                TurnaroundExternalId = turnaroundExternalId,
                                ErrorCode = (int)ErrorCodes.InvalidTurnaround,
                            });

                            Helpers.Scanning.FailedScan.Add(turnaroundExternalId, Pathway.Enums.ScanType.Turnaround, stockManagementRequest.UserId,
                                stockManagementRequest.StationId.Value, _synergyTrakData.StationLocationId, TurnAroundEventTypeIdentifier.IntoPigeonHoleStock);

                            continue;
                        }
                    }
                }

                #endregion

                var stationRepository = StationRepository.New(workUnit);
                var storagePointRepository = StoragePointRepository.New(workUnit);
                var orderRepository = OrderRepository.New(workUnit);

                var station = stationRepository.Get(stockManagementRequest.StationId.Value);
                var cancelledOrderContainingTurnaround = orderRepository.All().SingleOrDefault(o => o.OrderStatusId == (int)OrderStatusIdentifier.Cancelled && o.OrderLine.Any(ol => ol.TurnaroundId == turnaround.TurnaroundId));

                if (cancelledOrderContainingTurnaround != null)
                {
                    var removeOrderLineRequest = new OrderLineManagementRequest
                    {
                        OrderId = cancelledOrderContainingTurnaround.OrderId,
                        OrderModifiedDate = DateTime.UtcNow,
                        ScanDetail = new ScanDetails
                        {
                            TurnaroundExternalId = turnaround.ExternalId,
                            UserId = stockManagementRequest.UserId,
                            StationTypeId = stockManagementRequest.StationTypeId,
                            StationId = stockManagementRequest.StationId,
                            FacilityId = stockManagementRequest.FacilityId,
                        },
                        UserId = stockManagementRequest.UserId,
                        FacilityId = stockManagementRequest.FacilityId
                    };

                    var orderLine = new Helpers.Ordering.OrderLine(new Helpers.Ordering.OrderLineData());
                    var removeOrderLineResult = orderLine.Remove(removeOrderLineRequest);

                    if (removeOrderLineResult.ErrorCode != null)
                    {
                        stockManagementData.ScannedAssets.Add(new T
                        {
                            TurnaroundExternalId = turnaroundExternalId,
                            ErrorCode = (int)ErrorCodes.InvalidTurnaround,
                        });

                        continue;
                    }
                }

                var storagePoint = stockManagementRequest.LocationId.HasValue ? storagePointRepository.GetByLocation(stockManagementRequest.LocationId.Value) : null;

                _synergyTrakData.StationTypeId = stockManagementRequest.StationTypeId;
                _synergyTrakData.StationId = station.StationId;
                _synergyTrakData.FacilityId = stockManagementRequest.FacilityId;
                _synergyTrakData.UserId = stockManagementRequest.UserId;

                var scanDetails = new ScanDetails
                {
                    AlwaysCheckNotes = stockManagementRequest.CheckNotes,
                    ApplyEvent = true,
                    StationId = stockManagementRequest.StationId,
                    FacilityId = stockManagementRequest.FacilityId,
                    UserId = stockManagementRequest.UserId,
                    ParentTurnaroundId = null,
                    IsRemoveFromParent = true,
                    Events = new List<ScanEventDataContract>
                    {
                        new ScanEventDataContract
                        {
                            EventType = stockManagementRequest.EventType
                        }
                    },
                    ExternalId = turnaroundExternalId.ToString(),
                    TurnaroundExternalId = turnaroundExternalId,
                    StationTypeId = stockManagementRequest.StationTypeId
                };

                var saDataContract = new T
                {
                    TurnaroundId = turnaround.TurnaroundId,
                    EventTypeId = (TurnAroundEventTypeIdentifier)stockManagementRequest.EventType,
                    StationId = stockManagementRequest.StationId.Value,
                    UserId = stockManagementRequest.UserId,
                    StoragePointId = storagePoint?.StoragePointId,
                    ParentTurnaroundId = null,
                    IsRemoveFromParent = true
                };

                var eventTypeRepository = EventTypeRepository.New(workUnit);
                var eventTypeRow = eventTypeRepository.Get(scanDetails.Events.First().EventType);
                _synergyTrakData.EventTypeId = (TurnAroundEventTypeIdentifier)scanDetails.Events.First().EventType;

                if (eventTypeRow != null)
                {
                    _isProcessEvent = eventTypeRow.ProcessEvent;
                }

                ProcessTurnaround(turnaround, saDataContract, scanDetails, null, true, true);

                _synergyTrakData.ScanDcList.Clear();
                if (saDataContract.ErrorCode == null && (saDataContract.ContainerMasterNotes == null || !saDataContract.ContainerMasterNotes.Any()))
                {
                    if (turnaround.ContainerInstance != null)
                    {
                        turnaround.ContainerInstance.CurrentLocationId = stockManagementRequest.LocationId;
                        turnaroundRepository.Save();
                    }
                }
                else
                {
                    TurnaroundProcessing.DeniedTurnaroundEvent.Log(saDataContract);
                }

                stockManagementData.ScannedAssets.Add(saDataContract);

                if (saDataContract.ChildItems != null && saDataContract.ChildItems.Count > 0)
                {
                    foreach (var child in saDataContract.ChildItems)
                    {
                        stockManagementData.ScannedAssets.Add((T)child);
                    }
                }
            }

            #endregion
            if (stockManagementRequest.FailedScannedIds != null)
            {
                foreach (var failedScan in stockManagementRequest.FailedScannedIds)
                {
                    Helpers.Scanning.FailedScan.Add(failedScan.Input, failedScan.ScanType, stockManagementRequest.UserId, failedScan.StationId.Value, failedScan.LocationId, failedScan.EventType, failedScan.CreatedDate);
                }
            }

            return stockManagementData;
        }

        private bool ValidStoragePointForTurnaround(Turnaround turnaround, int LocationId, IUnitOfWork workUnit)
        {
            var locationRepo = LocationRepository.New(workUnit);
            var location = locationRepo.Get(LocationId);
            if (turnaround.DeliveryPoint.CustomerDefinition.OwnerId == location.Leaf.Tree.OwnerId.Value)
            {
                return true;
            }
            var turnaroundCustomerGroupId = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.CustomerGroupId;
            var tenancyAllowsCustomerGroupStockTransfer = TenancySettings.GetStockTransferCustomerGroupEnabled(location.Leaf.Tree.Owner.TenancyId);
            var turnaroundCustomerAllowsCustomerGroupStockTransfer = CustomerSettings.GetStockTransferCustomerGroupEnabled(turnaround.CustomerDefinitionId, tenancyAllowsCustomerGroupStockTransfer);
            var storagePointCustomerDefintionId = location.Leaf.Tree.Owner.CustomerDefinition.FirstOrDefault()?.CustomerDefinitionId;
            if (turnaroundCustomerAllowsCustomerGroupStockTransfer && storagePointCustomerDefintionId.HasValue)
            {
                var storagePointCustomerAllowsCustomerGroupStockTransfer = CustomerSettings.GetStockTransferCustomerGroupEnabled(storagePointCustomerDefintionId.Value, tenancyAllowsCustomerGroupStockTransfer);

                if (storagePointCustomerAllowsCustomerGroupStockTransfer
                    && turnaroundCustomerGroupId != null
                    && turnaroundCustomerGroupId == location.Leaf.Tree.Owner.CustomerDefinition.FirstOrDefault()?.CurrentCustomer.CustomerGroupId)
                {
                    return true;
                }
            }
            if (location.Leaf.Tree.Owner?.Facility.Count > 0)
            {
                var owningFacilityId = turnaround.ContainerMaster.ContainerMasterDefinition.CustomerDefinition.CurrentCustomer.FacilityId;
                var usingFacilityId = turnaround.FacilityId;
                var mfpRepository = MultiFacilityProcessingRepository.New(workUnit);
                var facilityAndMfpFacilities = mfpRepository.GetPrimaryFacilities(location.Leaf.Tree.Owner.Facility.First().FacilityId);
                if (facilityAndMfpFacilities.Contains(owningFacilityId) || facilityAndMfpFacilities.Contains(usingFacilityId))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// AddToStocktakeHistory operation
        /// </summary>
        public void AddToStocktakeHistory(int user, int turnaround, int location, StocktakeActivityIdentifier activityType)
        {
            {
                var stocktakeHistoryRepository = StocktakeHistoryRepository.New(workUnit);

                var history = StocktakeHistoryFactory.CreateEntity(workUnit,
                    created: DateTime.UtcNow,
                    userID: user,
                    turnaroundId: turnaround,
                    locationId: location,
                    stocktakeActivityId: (int)activityType
                );

                stocktakeHistoryRepository.Add(history);
                stocktakeHistoryRepository.Save();
            }
        }
    }
}

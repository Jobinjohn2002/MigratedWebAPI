using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// OrderLineData
    /// </summary>
    public class OrderLineData : Models.SynergyTrakData
    {
        /// <summary>
        /// Gets or sets OrderLineManagementRequest
        /// </summary>
        public OrderLineManagementRequest OrderLineManagementRequest { get; set; }
    }

    /// <summary>
    /// OrderLine
    /// </summary>
    public class OrderLine : BaseHelper
    {

        private new OrderLineData Data => (OrderLineData)base.Data;

        public OrderLine(OrderLineData data) : base(data) { }

        public OrderLine(OrderLineManagementRequest orderLineManagementRequest) : base(new OrderLineData() { OrderLineManagementRequest = orderLineManagementRequest }) { }

        public List<Data.Models.Operative.OrderLine> GetAllForOrder(IUnitOfWork workUnit)
        {
            return OrderLineHelper.GetAllForOrder(Data.OrderLineManagementRequest.OrderId, workUnit);
        }

        /// <summary>
        /// DeleteAllForOrder operation
        /// </summary>
        public void DeleteAllForOrder(IUnitOfWork workUnit, OrderManagementDataContract dc, ScanDetails scanDetails)
        {
            var turnaroundRepository = TurnaroundRepository.New(workUnit);

            foreach (var ol in OrderLineHelper.GetAllForOrder(Data.OrderLineManagementRequest.OrderId, workUnit))
            {
                if (ol.TurnaroundId.HasValue)
                {
                    var turnaround = turnaroundRepository.Get(ol.TurnaroundId.Value);

                    scanDetails.TurnaroundId = ol.TurnaroundId;
                    scanDetails.TurnaroundExternalId = turnaround.ExternalId;

                    ProcessOrderLineTurnaround(workUnit, dc, scanDetails, turnaround);
                }

                ol.Turnaround = null;
                ol.OrderLineStatusId = (int)OrderLineStatusIdentifier.Cancelled;
            }
        }

        /// <summary>
        /// Add operation
        /// </summary>
        public OrderManagementDataContract Add() => Add(Data.OrderLineManagementRequest);

        private OrderManagementDataContract Add(OrderLineManagementRequest orderLineManagementRequest)
        {
            var dc = new OrderManagementDataContract();
            orderLineManagementRequest.ScanDetail.Events = new List<ScanEventDataContract>
            {
                new ScanEventDataContract
                {
                    EventType = (int) TurnAroundEventTypeIdentifier.AddedToOrder
                }
            };
            try
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var orderRepository = OrderRepository.New(workUnit);
                    var turnaroundRepository = TurnaroundRepository.New(workUnit);
                    var ciRepository = ContainerInstanceRepository.New(workUnit);
                    var stationRepository = StationRepository.New(workUnit);

                    Data.StationLocationId = stationRepository.Get(orderLineManagementRequest.StationId.Value).LocationId.Value;
                    Data.UserId = orderLineManagementRequest.ScanDetail.UserId;
                    var order = orderRepository.Get(orderLineManagementRequest.OrderId);

                    #region Validation section
                    if (order.Modified != null && order.Modified != orderLineManagementRequest.OrderModifiedDate)
                    {
                        dc.ErrorCode = (int)ErrorCodes.OrderModifiedExternally;
                        return dc;
                    }

                    var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndUserAccess(orderLineManagementRequest.ScanDetail.TurnaroundExternalId.Value, Data.UserId);
                    if (turnaround == null || turnaround.ContainerMaster.BaseItemType.ItemTypeId == (int)ItemTypeIdentifier.Trolley)
                    {
                        Scanning.FailedScan.Add(orderLineManagementRequest.ScanDetail.TurnaroundExternalId.ToString(), Enums.ScanType.Turnaround, Data.UserId, TurnAroundEventTypeIdentifier.AddedToOrder, Data.StationId, Data.StationLocationId);

                        dc.ErrorCode = (int)ErrorCodes.OrderLineFail;
                        return dc;
                    }
                    if (turnaround.ContainerInstance != null)
                    {
                        var latestTurnaround = ciRepository.GetLastTurnaroundByInstance(turnaround.ContainerInstance.ContainerInstanceId);
                        if (turnaround.TurnaroundId != latestTurnaround.TurnaroundId)
                        {
                            Scanning.FailedScan.Add(orderLineManagementRequest.ScanDetail.TurnaroundExternalId.ToString(), Enums.ScanType.Turnaround, Data.UserId, TurnAroundEventTypeIdentifier.AddedToOrder, Data.StationId, Data.StationLocationId);
                            dc.ErrorCode = (int)ErrorCodes.TurnaroundIsArchived;
                            return dc;
                        }
                    }
                    var allOrdersForTurnaround = orderRepository.All().Where(o => o.OrderStatusId != (int)OrderStatusIdentifier.Archived &&
                                                                                  o.OrderStatusId != (int)OrderStatusIdentifier.Cancelled &&
                                                                                  o.OrderStatusId != (int)OrderStatusIdentifier.Dispatched &&
                                                                                  o.OrderStatusId != (int)OrderStatusIdentifier.Delivered
                    ).Where(o => o.OrderLine.Any(ol => ol.TurnaroundId == turnaround.TurnaroundId));

                    if (allOrdersForTurnaround.Any())
                    {
                        Scanning.FailedScan.Add(orderLineManagementRequest.ScanDetail.TurnaroundExternalId.ToString(), Enums.ScanType.Turnaround, Data.UserId, TurnAroundEventTypeIdentifier.AddedToOrder, Data.StationId, Data.StationLocationId);

                        if (order.OrderLine.Any(o => o.TurnaroundId == turnaround.TurnaroundId))
                        {
                            dc.ErrorCode = (int)ErrorCodes.OrderLineTurnaroundIsOnThisOrder;
                        }
                        else
                        {
                            dc.ErrorCode = (int)ErrorCodes.OrderLineTurnaroundIsOnAnotherOrder;
                            var existingOrder = allOrdersForTurnaround.FirstOrDefault();
                            if (existingOrder != null)
                            {
                                dc.AlreadyOnAnotherOrderOrderNumber = String.IsNullOrEmpty(existingOrder.AlternateId) ? existingOrder.OrderNumber : existingOrder.AlternateId;
                            }
                        }

                        return dc;
                    }
                    if (CustomerSettings.GetEvaluatedForceOrderToMatchTurnaroundDeliveryPoint(order, workUnit))
                    {
                        if (order.DeliveryPointId != turnaround.DeliveryPointId)
                        {
                            Scanning.FailedScan.Add(orderLineManagementRequest.ScanDetail.TurnaroundExternalId.ToString(), Enums.ScanType.Turnaround, Data.UserId, TurnAroundEventTypeIdentifier.AddedToOrder, Data.StationId, Data.StationLocationId);
                            dc.ErrorCode = (int)ErrorCodes.OrderLineDeliveryPointMismatch;
                            return dc;
                        }
                    }
                    else
                    {
                        if (order.DeliveryPoint.CustomerDefinition.DeliveryPoint.All(dp => dp.DeliveryPointId != turnaround.DeliveryPointId))
                        {
                            Scanning.FailedScan.Add(orderLineManagementRequest.ScanDetail.TurnaroundExternalId.ToString(), Enums.ScanType.Turnaround, Data.UserId, TurnAroundEventTypeIdentifier.AddedToOrder, Data.StationId, Data.StationLocationId);
                            dc.ErrorCode = (int)ErrorCodes.OrderLineDeliveryPointMismatch;

                            return dc;
                        }
                    }
                    if (turnaround.SterileExpiryDate != null && !OrderHelper.ValidateSterileExpiry(turnaround.SterileExpiryDate.Value, order.DeliveryDate, order.ProcedureDate))
                    {
                        Scanning.FailedScan.Add(orderLineManagementRequest.ScanDetail.TurnaroundExternalId.ToString(), Enums.ScanType.Turnaround, Data.UserId, TurnAroundEventTypeIdentifier.AddedToOrder, Data.StationId, Data.StationLocationId);
                        dc.ErrorCode = (int)ErrorCodes.OrderLineSterileExpiryFail;

                        return dc;
                    }

                    #endregion

                    #region All validation done, proceed with processing
                    var cancelledOrderContainingTurnaround = orderRepository.All().SingleOrDefault(o => o.OrderStatusId == (int)OrderStatusIdentifier.Cancelled && o.OrderLine.Any(ol => ol.TurnaroundId == turnaround.TurnaroundId));

                    if (cancelledOrderContainingTurnaround != null)
                    {
                        var removeOrderLineRequest = new OrderLineManagementRequest
                        {
                            OrderId = cancelledOrderContainingTurnaround.OrderId,
                            OrderModifiedDate = orderLineManagementRequest.OrderModifiedDate,
                            ScanDetail = new ScanDetails
                            {
                                TurnaroundExternalId = orderLineManagementRequest.ScanDetail.TurnaroundExternalId,
                                UserId = orderLineManagementRequest.ScanDetail.UserId,
                                StationTypeId = orderLineManagementRequest.ScanDetail.StationTypeId,
                                StationId = orderLineManagementRequest.ScanDetail.StationId,
                                FacilityId = orderLineManagementRequest.ScanDetail.FacilityId,
                            },
                            UserId = orderLineManagementRequest.UserId,
                            FacilityId = orderLineManagementRequest.FacilityId
                        };

                        var removeOrderLineResult = Remove(removeOrderLineRequest);

                        if (removeOrderLineResult.ErrorCode != null)
                        {
                            return removeOrderLineResult;
                        }
                    }

                    dc.TurnaroundId = turnaround.TurnaroundId;
                    ProcessOrderLineTurnaround(workUnit, dc, orderLineManagementRequest.ScanDetail, turnaround);

                    if (orderLineManagementRequest.ScanDetail.ApplyEvent)
                    {
                        if (dc.ErrorCode == null)
                        {
                            if (turnaround.ParentTurnaroundId.HasValue)
                            {
                                var parentTurnaround = turnaroundRepository.Get(turnaround.ParentTurnaroundId.Value);
                                if (parentTurnaround.ContainerMaster.BaseItemType.ItemTypeId == (int)ItemTypeIdentifier.Trolley)
                                {
                                    turnaround.ParentTurnaroundId = null;
                                }
                            }

                            var orderLineToFulfil = order.GetOrderLineThatCanBeFulfilled(turnaround.ContainerMaster.ContainerMasterDefinitionId);
                            if (orderLineToFulfil != null)
                            {
                                orderLineToFulfil.TurnaroundId = turnaround.TurnaroundId;
                                orderLineToFulfil.OrderLineStatusId = (int)OrderLineStatusIdentifier.Picked;
                                orderLineToFulfil.LastModified = DateTime.UtcNow;
                            }
                            else
                            {
                                order.OrderLine.Add(OrderLineFactory.CreateEntity(workUnit,
                                    orderId: order.OrderId,
                                    containerMasterDefinitionId: turnaround.ContainerMaster.ContainerMasterDefinitionId,
                                    turnaroundId: turnaround.TurnaroundId,
                                    orderLineStatusId: (int)OrderLineStatusIdentifier.Picked,
                                    orderLineSourceId: (int)OrderSourceIdentifier.Operative,
                                    lastModified: DateTime.UtcNow
                                ));
                            }

                            OrderHelper.UpdateOrder(new OrderManagementRequest
                            {
                                OrderId = order.OrderId,
                                DeliveryPointId = order.DeliveryPointId,
                                OrderStatusId = (int)OrderStatusIdentifier.InProcess,
                                AlternateId = order.AlternateId,
                                DeliveryDate = order.DeliveryDate,
                                ProcedureDate = order.ProcedureDate,
                                UserId = orderLineManagementRequest.ScanDetail.UserId,
                                ModifiedDate = order.Modified,
                                CaseCartNumber = order.CaseCartNumber
                            });

                            orderRepository.Save();

                            dc = OrderHelper.GetOrder(orderLineManagementRequest.UserId, order.OrderId);
                        }
                        else
                        {
                            var orderEventType = orderLineManagementRequest.ScanDetail.Events.FirstOrDefault();

                            if (orderEventType != null)
                            {
                                dc.EventTypeId = (TurnAroundEventTypeIdentifier)orderEventType.EventType;
                                dc.StationId = orderLineManagementRequest.ScanDetail.StationId.Value;
                                dc.UserId = Data.UserId;
                                TurnaroundProcessing.DeniedTurnaroundEvent.Log(dc);
                            }
                        }
                    }

                    #endregion
                }
            }
            catch
            {
                dc.ErrorCode = (int)ErrorCodes.OrderLineFail;
            }
            return dc;
        }

        /// <summary>
        /// Remove operation
        /// </summary>
        public OrderManagementDataContract Remove() => Remove(Data.OrderLineManagementRequest);

        /// <summary>
        /// Remove operation
        /// </summary>
        public OrderManagementDataContract Remove(OrderLineManagementRequest orderLineManagementRequest)
        {

            var errorDataContract = new OrderManagementDataContract();

            try
            {
                if (Remove(errorDataContract, orderLineManagementRequest))
                {
                    return OrderHelper.GetOrder(orderLineManagementRequest.UserId, orderLineManagementRequest.OrderId);
                }
                else
                {
                    errorDataContract.ErrorCode = (int)ErrorCodes.OrderFail;
                }
            }
            catch
            {
                errorDataContract.ErrorCode = (int)ErrorCodes.OrderFail;
            }

            return errorDataContract;
        }

        private bool Remove(OrderManagementDataContract dc, OrderLineManagementRequest orderLineManagementRequest)
        {
            {
                var orderRepository = OrderRepository.New(workUnit);
                var orderLineRepository = OrderLineRepository.New(workUnit);
                var turnaroundRepository = TurnaroundRepository.New(workUnit);

                var order = orderRepository.Get(orderLineManagementRequest.OrderId);
                Data.UserId = orderLineManagementRequest.ScanDetail.UserId;

                var turnaround = turnaroundRepository.GetTurnaroundByExternalIdAndFacilityId(orderLineManagementRequest.ScanDetail.TurnaroundExternalId.Value, orderLineManagementRequest.FacilityId);
                if (turnaround != null && order.OrderLine.Any(ol => ol.TurnaroundId == turnaround.TurnaroundId))
                {
                    orderLineManagementRequest.ScanDetail.Events = new List<ScanEventDataContract>
                    {
                        new ScanEventDataContract
                        {
                            EventType = (int) TurnAroundEventTypeIdentifier.RemovedFromOrder
                        }
                    };

                    ProcessOrderLineTurnaround(workUnit, dc, orderLineManagementRequest.ScanDetail, turnaround);

                    if (dc.ErrorCode == null)
                    {
                        var orderLine = order.OrderLine.Single(ol => ol.TurnaroundId == turnaround.TurnaroundId);
                        var pickableSources = new[] { OrderSourceIdentifier.API, OrderSourceIdentifier.SAF };

                        if (pickableSources.Contains(orderLine.OrderLineSourceIdentifier))
                        {
                            var matchingAdhocCMDOrderLines = order.OrderLine.Where(ol => ol.ContainerMasterDefinitionId == orderLine.ContainerMasterDefinitionId
                                                                                        && ol.OrderLineSourceIdentifier == OrderSourceIdentifier.Operative);
                            if (matchingAdhocCMDOrderLines.Any())
                            {
                                var matchingCMDOrderLine = matchingAdhocCMDOrderLines.First();
                                matchingCMDOrderLine.OrderLineSourceId = (int)orderLine.OrderLineSourceIdentifier;
                                matchingCMDOrderLine.LastModified = DateTime.UtcNow;

                                if (orderLine.HisOrderLine != null)
                                {
                                    foreach (var hisOrderLine in orderLine.HisOrderLine.ToList())
                                    {
                                        matchingCMDOrderLine.HisOrderLine.Add(hisOrderLine);
                                    }

                                    orderLine.HisOrderLine.Clear();
                                }

                                orderLineRepository.Delete(orderLine);
                            }
                            else
                            {
                                orderLine.TurnaroundId = null;
                                orderLine.OrderLineStatusId = (int)OrderLineStatusIdentifier.Ordered;
                                orderLine.LastModified = DateTime.UtcNow;
                            }
                        }
                        else
                        {
                            orderLineRepository.Delete(orderLine);
                        }

                        OrderHelper.UpdateOrder(new OrderManagementRequest
                        {
                            OrderId = order.OrderId,
                            DeliveryPointId = order.DeliveryPointId,
                            OrderStatusId = order.OrderStatusId,
                            AlternateId = order.AlternateId,
                            DeliveryDate = order.DeliveryDate,
                            ProcedureDate = order.ProcedureDate,
                            UserId = orderLineManagementRequest.ScanDetail.UserId,
                            ModifiedDate = order.Modified,
                            CaseCartNumber = order.CaseCartNumber
                        });

                        orderRepository.Save();
                        workUnit.Save();

                        return true;
                    }
                    else
                    {
                        var orderEventType = orderLineManagementRequest.ScanDetail.Events.FirstOrDefault();

                        if (orderEventType != null)
                        {
                            dc.EventTypeId = (TurnAroundEventTypeIdentifier)orderEventType.EventType;
                            dc.StationId = orderLineManagementRequest.ScanDetail.StationId.Value;
                            dc.UserId = Data.UserId;
                            TurnaroundProcessing.DeniedTurnaroundEvent.Log(dc);
                        }

                        return false;
                    }
                }
                else
                {
                    Scanning.FailedScan.Add(orderLineManagementRequest.ScanDetail.TurnaroundExternalId.ToString(), Enums.ScanType.Turnaround, Data.UserId, TurnAroundEventTypeIdentifier.RemovedFromOrder, Data.StationId, Data.StationLocationId);

                    return false;
                }
            }
        }

        private void ProcessOrderLineTurnaround(IUnitOfWork workUnit, ScanAssetDataContract saDataContract, ScanDetails scanDetail, Turnaround turnaround)
        {
            var stationRepository = StationRepository.New(workUnit);
            var station = stationRepository.Get(scanDetail.StationId.Value);
            Data.StationLocationId = saDataContract.LocationId != 0 ? station.LocationId : 0;

            var eventTypeRepository = EventTypeRepository.New(workUnit);
            var eventTypeData = eventTypeRepository.Get(scanDetail.Events.First().EventType);

            Data.StationTypeId = scanDetail.StationTypeId;
            Data.StationId = scanDetail.StationId;
            Data.FacilityId = scanDetail.FacilityId;
            Data.UserId = scanDetail.UserId;
            Data.EventTypeId = (TurnAroundEventTypeIdentifier)eventTypeData.EventTypeId;

            new SynergyTrakHelperMk3(Data, eventTypeData.ProcessEvent)
                .ProcessTurnaround(turnaround, saDataContract, scanDetail, null, isStreamLined: true, includeChildren: false);

            Data.ScanDcList?.Clear();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// OrderData
    /// </summary>
    public class OrderData : Models.SynergyTrakData
    {
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets OrderManagementRequest
        /// </summary>
        public OrderManagementRequest OrderManagementRequest { get; set; }

        /// <summary>
        /// Gets or sets OrderManagementScanDetails
        /// </summary>
        public OrderManagementScanDetails OrderManagementScanDetails { get; set; }
    }

    /// <summary>
    /// Order
    /// </summary>
    public class Order : BaseHelper
    {
        private new OrderData Data => (OrderData)base.Data;

        public Order(OrderData data) : base(data) { }

        public Order(OrderManagementRequest data) : base(new OrderData() { OrderManagementRequest = data }) { }

        /// <summary>
        /// Get operation
        /// </summary>
        public OrderManagementDataContract Get()
        {
            var dc = new OrderManagementDataContract();

            try
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var repository = OrderRepository.New(workUnit);
                    var order = repository.Get(Data.OrderManagementRequest.OrderId.Value);

                    dc = OrderHelper.GetOrderDetails(Data.OrderManagementRequest.UserId, order, workUnit, repository);
                }
            }
            catch
            {
                dc.ErrorCode = (int)ErrorCodes.OrderFail;
                throw;
            }

            return dc;
        }

        /// <summary>
        /// GetByOrderNumber operation
        /// </summary>
        public OrderManagementDataContract GetByOrderNumber()
        {
            var dc = new OrderManagementDataContract();

            try
            {
                {
                    var repository = OrderRepository.New(workUnit);
                    var order = repository.Get(Data.OrderNumber);

                    if (order != null)
                    {
                        dc = OrderHelper.GetOrderDetails(Data.UserId, order, workUnit, repository);
                    }
                }
            }
            catch
            {
                dc.ErrorCode = (int)ErrorCodes.OrderFail;
                throw;
            }

            return dc;
        }

        /// <summary>
        /// Create operation
        /// </summary>
        public OrderManagementDataContract Create() => Create(Data.OrderManagementRequest);

        private OrderManagementDataContract Create(OrderManagementRequest orderManagementRequest, int? surgicalProcedureId = null, List<OrderNote> orderNotes = null)
        {
            var dc = new OrderManagementDataContract();

            try
            {
                var transactionOptions = new TransactionOptions()
                {
                    IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                };

                using (var transaction = new TransactionScope(TransactionScopeOption.Required, transactionOptions))
                {
                    {
                        var order = new Data.Models.Operative.Order(orderManagementRequest);
                        orderNotes?.ForEach(on => order.OrderNote.Add(
                            OrderNoteFactory.CreateEntity(workUnit,
                                text: on.Text,
                                sequence: on.Sequence
                            ))
                        );

                        if (surgicalProcedureId.HasValue)
                        {
                            var spRepository = SurgicalProcedureRepository.New(workUnit);
                            order.SurgicalProcedure = spRepository.Get(surgicalProcedureId.Value);
                        }

                        if (orderManagementRequest.HisOrderId.HasValue)
                        {
                            var hisOrderRepository = HisOrderRepository.New(workUnit);
                            order.HisOrder = hisOrderRepository.Get(orderManagementRequest.HisOrderId.Value);
                        }

                        var orderRepository = OrderRepository.New(workUnit);

                        orderRepository.Add(order);
                        orderRepository.Save();

                        OrderHelper.UpdateOrderStatusHistory(order, workUnit);

                        if (order.OrderId > 0 && orderManagementRequest.InitialOrderLine?.TurnaroundExternalId != null)
                        {
                            dc = new OrderLine(
                                    new OrderLineManagementRequest()
                                    {
                                        OrderId = order.OrderId,
                                        FacilityId = orderManagementRequest.FacilityId,
                                        StationId = orderManagementRequest.StationId,
                                        ScanDetail = orderManagementRequest.InitialOrderLine
                                    }
                            ).Add();
                        }

                        if (dc.ErrorCode == null)
                        {
                            dc = order.ToDataContract();
                            transaction.Complete();
                        }
                    }
                }
            }
            catch
            {
                dc.ErrorCode = (int)ErrorCodes.OrderFail;
            }

            return dc;
        }

        /// <summary>
        /// Update operation
        /// </summary>
        public OrderManagementDataContract Update()
        {
            {
                return OrderHelper.UpdateOrder(Data.OrderManagementRequest, workUnit);
            }
        }

        /// <summary>
        /// Delete operation
        /// </summary>
        public OrderManagementDataContract Delete()
        {
            var dc = new OrderManagementDataContract();

            try
            {
                {
                    var transactionOptions = new TransactionOptions()
                    {
                        IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                    };

                    {
                        var orderRepository = OrderRepository.New(workUnit);

                        var order = orderRepository.Get(Data.ScanDetails.OrderId.Value);

                        if (order != null)
                        {
                            dc.ErrorCode = OrderHelper.UpdateOrder(new OrderManagementRequest
                            {
                                OrderId = order.OrderId,
                                DeliveryPointId = order.DeliveryPointId,
                                OrderStatusId = (int)OrderStatusIdentifier.Cancelled,
                                AlternateId = order.AlternateId,
                                DeliveryDate = order.DeliveryDate,
                                ProcedureDate = order.ProcedureDate,
                                UserId = Data.ScanDetails.UserId,
                                ModifiedDate = order.Modified,
                                CaseCartNumber = order.CaseCartNumber
                            }, workUnit).ErrorCode;

                            if (dc.ErrorCode == null)
                            {
                                var orderLine = new Helpers.Ordering.OrderLine(new OrderLineManagementRequest() { OrderId = order.OrderId });
                                orderLine.DeleteAllForOrder(workUnit, dc, Data.ScanDetails);

                                if (dc.ErrorCode == null)
                                {
                                    orderRepository.Save();

                                    workUnit.Save();
                                    transaction.Complete();
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                dc.ErrorCode = (int)ErrorCodes.OrderDeletionFail;
            }

            return dc;
        }

        /// <summary>
        /// Gets a list of order notes for an order
        /// </summary>
        /// <summary>
        /// GetNotes operation
        /// </summary>
        public GetOrderNotesResponseContract GetNotes()
        {
            var dc = new GetOrderNotesResponseContract();

            try
            {
                {
                    var repo = OrderNoteRepository.New(workUnit);

                    dc.OrderNotes = new List<OrderNoteDataContract>();
                    foreach (var row in repo.All().Where(a => a.OrderId == Data.OrderManagementRequest.OrderId).OrderByDescending(b => b.Sequence).ThenByDescending(c => c.OrderId))
                    {
                        var newNote = new OrderNoteDataContract
                        {
                            Sequence = row.Sequence,
                            Text = row.Text
                        };

                        dc.OrderNotes.Add(newNote);
                    }
                }
            }
            catch
            {
                dc.ErrorCode = (int)ErrorCodes.OrderNoteRetrievalFail;
            }

            return dc;
        }

        /// <summary>
        /// Ship operation
        /// </summary>
        public List<OrderShippingDataContract> Ship()
        {
            Log.Info("Process Orders start");
            var listdc = new List<OrderShippingDataContract>();

            foreach (var orderId in Data.OrderManagementScanDetails.OrderIds)
            {
                Log.Info($"Process OrderId: {orderId} Start");
                var dc = new OrderShippingDataContract { ProccesedTurnarounds = new List<ScanAssetDataContract>() };

                try
                {
                    var transactionOptions = new TransactionOptions()
                    {
                        IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
                    };

                    {
                        {
                            if (orderId != 0)
                            {
                                Data.StationTypeId = Data.OrderManagementScanDetails.StationTypeId;
                                Data.StationId = Data.OrderManagementScanDetails.StationId;
                                Data.FacilityId = Data.OrderManagementScanDetails.FacilityId;
                                Data.UserId = Data.OrderManagementScanDetails.UserId;
                                var repository = OrderRepository.New(workUnit);
                                var order = repository.Get(orderId);

                                Data.OrderManagementScanDetails.DeliveryPointId = order.DeliveryPointId;

                                dc.OrderReference = String.IsNullOrEmpty(order.AlternateId) ? order.OrderNumber : order.AlternateId;
                                dc.ErrorCode = OrderHelper.UpdateOrder(new OrderManagementRequest
                                {
                                    OrderId = order.OrderId,
                                    DeliveryPointId = order.DeliveryPointId,
                                    OrderStatusId = (int)OrderStatusIdentifier.Dispatched,
                                    AlternateId = order.AlternateId,
                                    DeliveryDate = order.DeliveryDate,
                                    ProcedureDate = order.ProcedureDate,
                                    UserId = Data.OrderManagementScanDetails.UserId,
                                    ModifiedDate = order.Modified,
                                    CaseCartNumber = order.CaseCartNumber
                                }, workUnit).ErrorCode;
                                CopyUncompleteLinesToNewOrder(Data.OrderManagementScanDetails, order, repository);
                                if (dc.ErrorCode == null)
                                {
                                    OrderLineHelper.ValidateOrderTurnarounds(order, dc, workUnit, Data, null);
                                    if (dc.ProccesedTurnarounds.Any(a => a.ErrorCode != null))
                                    {
                                        dc.ErrorCode = (int)ErrorCodes.IndividualTurnaroundEventErrorOnBatch;
                                    }
                                    else
                                    {
                                        var events = new List<ApplyTurnaroundEventDetails>
                                        {
                                            new ApplyTurnaroundEventDetails
                                            {
                                                EventType = TurnAroundEventTypeIdentifier.OrderShipped,
                                                UseDeliveryNoteIdFromScanDc = true,
                                            }
                                        };
                                        using (var applyEvent = InstanceFactory.GetInstance<IApplyEvent>())
                                        {
                                            applyEvent.Setup(null, Data.UserId, Data.FacilityId, Data.StationTypeId, Data.StationId);
                                            applyEvent.ApplyEvents(events, dc.ProccesedTurnarounds, Data.OrderManagementScanDetails, true);
                                        }
                                        if (dc.ProccesedTurnarounds.Any(a => a.ErrorCode != null))
                                        {
                                            dc.ErrorCode = (int)ErrorCodes.Unknown;
                                            Log.Info($"Process OrderId: {orderId} Failed");
                                        }
                                        else
                                        {
                                            transaction.Complete();
                                            Log.Info($"Process OrderId: {orderId} Complete");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                dc.ErrorCode = (int)ErrorCodes.OrderFail;
                            }

                            OrderHelper.GetOrderNotifications(workUnit, orderId, Data.OrderManagementScanDetails, dc, Data.FacilityId);
                        }
                    }
                }
                catch (Exception ex)
                {
                    dc.ErrorCode = (int)ErrorCodes.OrderFail;
                    foreach (var asset in dc.ProccesedTurnarounds)
                    {
                        asset.ErrorCode = (int)ErrorCodes.OrderFail;
                    }

                    Log.Exception(ex, $"Ship Order Exception {orderId}");
                }

                listdc.Add(dc);
            }

            Log.Info("Process Orders End");
            return listdc;
        }

        private void CopyUncompleteLinesToNewOrder(OrderManagementScanDetails scanDetails, Data.Models.Operative.Order order, OrderRepository repository)
        {
            if (scanDetails.CopyUncompleteLinesToNewOrder)
            {
                if (order.OrderSource != OrderSourceIdentifier.Operative && order.OrderLine.Any(ol => ol.TurnaroundId == null))
                {
                    var orderManagementRequest = new OrderManagementRequest
                    {
                        DeliveryPointId = order.DeliveryPointId,
                        OrderStatusId = (int)OrderStatusIdentifier.InProcess,
                        DeliveryDate = order.DeliveryDate,
                        AlternateId = order.AlternateId,
                        ProcedureDate = order.ProcedureDate,
                        UserId = scanDetails.UserId,
                        BatchNumber = order.BatchNumber,
                        OrderSourceId = order.OrderSourceId,
                        CaseCartNumber = null,
                        HisOrderId = order.HisOrder?.HisOrderId //MW: Changed after DB Update                        
                    };

                    var newOrder = Create(orderManagementRequest, order.SurgicalProcedure?.SurgicalProcedureId, order.OrderNote?.ToList());
                    foreach (var orderLine in order.OrderLine.Where(ol => ol.TurnaroundId == null && ol.OrderLineStatus.RequiresTurnaround).ToList())
                    {
                        orderLine.OrderId = newOrder.OrderId;
                    }

                    repository.Save();
                }
            }
            else
            {
                foreach (var orderLine in order.OrderLine.Where(ol => ol.OrderLineStatus.FulfilsOrderLine == false).ToList())
                {
                    orderLine.OrderLineStatusId = (int)OrderLineStatusIdentifier.CancelledByPartDispatch;
                    orderLine.LastModified = DateTime.UtcNow;
                }

                repository.Save();
            }
        }
    }
}
using SynergyApplicationFrameworkApi.Application.DTOs.Interfaces.Operative;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class OrderHelper
    {

        /// <summary>
        /// ValidateSterileExpiry operation
        /// </summary>
        public static bool ValidateSterileExpiry(DateTime sterileExpiry, DateTime deliveryDate, DateTime? procedureDate)
        {
            if ((sterileExpiry < DateTime.UtcNow) ||
                (sterileExpiry < deliveryDate))
                return false;
            return !(sterileExpiry < procedureDate);
        }

        /// <summary>
        /// GetOrder operation
        /// </summary>
        public static OrderManagementDataContract GetOrder(int userId, int orderId)
        {
            var dc = new OrderManagementDataContract();

            try
            {
                using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                {
                    var repository = OrderRepository.New(workUnit);
                    var order = repository.Get(orderId);

                    dc = GetOrderDetails(userId, order, workUnit, repository);
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
        /// UpdateOrder operation
        /// </summary>
        public static OrderManagementDataContract UpdateOrder(OrderManagementRequest orderManagementRequest)
        {
            {
                return UpdateOrder(orderManagementRequest, workUnit);
            }
        }

        /// <summary>
        /// GetOrderDetails operation
        /// </summary>
        public static OrderManagementDataContract GetOrderDetails(int userId, Data.Models.Operative.Order order, IUnitOfWork workUnit, OrderRepository repository)
        {
            var dc = order.ToDataContract();
            dc.OrderLines = OrderLineHelper.GetOrderLinesDataContract(userId, order, workUnit).ToList();

            ProcessRelatedOrders(userId, order, workUnit, repository, dc);
            ProcessOrderNotes(order, workUnit, dc);

            return dc;
        }

        /// <summary>
        /// UpdateOrderStatusHistory operation
        /// </summary>
        public static void UpdateOrderStatusHistory(Data.Models.Operative.Order order, IUnitOfWork workUnit)
        {
            var currentOrderStatusHistory = order.OrderStatusHistory.OrderByDescending(osh => osh.CreatedDate).FirstOrDefault();
            if (currentOrderStatusHistory?.OrderStatusId != order.OrderStatusId)
            {
                var orderStatusHistoryRepository = OrderStatusHistoryRepository.New(workUnit);

                var orderId = order.OrderId;
                var orderStatusId = order.OrderStatus.OrderStatusId;
                var createdDate = order.Modified ?? order.CreatedDate;

                orderStatusHistoryRepository.Add(OrderStatusHistoryFactory.CreateEntity(workUnit,
                    orderId: orderId,
                    orderStatusId: orderStatusId,
                    createdDate: createdDate,
                    userId: order.ModifiedById ?? order.CreatedById));
                orderStatusHistoryRepository.Save();
            }
        }

        /// <summary>
        /// UpdateOrder operation
        /// </summary>
        public static OrderManagementDataContract UpdateOrder(OrderManagementRequest orderManagementRequest, IUnitOfWork workUnit)
        {
            var orderDataContract = new OrderManagementDataContract();

            try
            {
                var repository = OrderRepository.New(workUnit);

                if (orderManagementRequest.OrderId.HasValue)
                {
                    orderDataContract = GetOrder(orderManagementRequest.UserId, orderManagementRequest.OrderId.Value);
                    if (orderDataContract.ModifiedDate != null && orderDataContract.ModifiedDate != orderManagementRequest.ModifiedDate)
                    {
                        orderDataContract.ErrorCode = (int)ErrorCodes.OrderModifiedExternally;
                        return orderDataContract;
                    }

                    var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                    var customer = deliveryPointRepository.GetLatestCustomerByDeliveryPoint(orderManagementRequest.DeliveryPointId);

                    if (customer.CustomerStatusId == (int)CustomerStatusTypeIdentifier.Stop)
                    {
                        orderDataContract.ErrorCode = (int)ErrorCodes.CustomerOnStop;
                        return orderDataContract;
                    }

                    var order = repository.Get(orderManagementRequest.OrderId.Value);

                    order.UpdateOrder(orderManagementRequest);

                    UpdateOrderStatusHistory(order, workUnit);

                    repository.Save();

                    orderDataContract = GetOrder(orderManagementRequest.UserId, orderManagementRequest.OrderId.Value);
                }
            }
            catch
            {
                orderDataContract.ErrorCode = (int)ErrorCodes.OrderFail;

                throw;
            }
            return orderDataContract;
        }

        /// <summary>
        /// GetOrderNotifications operation
        /// </summary>
        public static void GetOrderNotifications(IUnitOfWork workUnit, int orderId, ScanDetails scanDetails, OrderShippingDataContract dc, short? facilityId)
        {
            if (dc.ErrorCode == null)
            {
                InstanceFactory.GetInstance<ILog>().Info($"OrderId: {orderId} start notifications");
                foreach (var turnaround in dc.ProccesedTurnarounds)
                {
                    ITurnaroundEvent turnaroundEvent = TurnaroundEventFactory.CreateEntity(workUnit);
                    turnaroundEvent.TurnaroundEventId = turnaround.TurnaroundEvents.LastOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.OrderShipped).TurnaroundEventId;

                    if (turnaround.NotificationTypesFired == null)
                    {
                        var notificationEngineHelper = new NotificationEngineHelper();
                        turnaround.NotificationTypesFired = notificationEngineHelper.ProcessNotifications(turnaround, scanDetails, turnaroundEvent);
                    }
                }
                InstanceFactory.GetInstance<ILog>().Info($"OrderId: {orderId} end notifications");
            }
        }

        private static void ProcessRelatedOrders(int userId, Data.Models.Operative.Order order, IUnitOfWork workUnit, OrderRepository repository, OrderManagementDataContract dc)
        {
            var relatedOrders = repository.All().Where(o => o.BatchNumber == order.BatchNumber && o.OrderId != order.OrderId).ToList();

            foreach (var relatedOrder in relatedOrders)
            {
                var orderDataContract = relatedOrder.ToDataContract();
                orderDataContract.OrderLines = OrderLineHelper.GetOrderLinesDataContract(userId, relatedOrder, workUnit).ToList();

                if (dc.RelatedOrders == null)
                {
                    dc.RelatedOrders = new List<OrderManagementDataContract>();
                }

                dc.RelatedOrders.Add(orderDataContract);
            }
        }

        private static void ProcessOrderNotes(Data.Models.Operative.Order order, IUnitOfWork workUnit, OrderManagementDataContract dc)
        {
            var repository = OrderNoteRepository.New(workUnit);
            dc.NotesCount = repository.All().Count(n => n.OrderId == order.OrderId);
        }
    }
}
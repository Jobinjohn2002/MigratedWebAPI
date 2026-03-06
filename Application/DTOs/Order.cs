using System;
using SynergyApplicationFrameworkApi.Application.DTOs.Interfaces.Operative;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class Order
    {
        public OrderSourceIdentifier OrderSource => (OrderSourceIdentifier)OrderSourceId;

        public Order(OrderManagementRequest request)
        {
            this.DeliveryPointId = request.DeliveryPointId;
            this.OrderStatusId = request.OrderStatusId;
            this.DeliveryDate = request.DeliveryDate.Value;
            this.CreatedById = request.UserId;
            this.AlternateId = request.AlternateId;
            this.ProcedureDate = request.ProcedureDate;
            this.BatchNumber = request.BatchNumber ?? Guid.NewGuid();
            this.OrderSourceId = request.OrderSourceId ?? (int)OrderSourceIdentifier.Operative;
            this.CaseCartNumber = request.CaseCartNumber;

            this.CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// ToDataContract operation
        /// </summary>
        public OrderManagementDataContract ToDataContract()
        {
            var dispatchDate = this.OrderStatusHistory.FirstOrDefault(osh => osh.OrderStatusId == (int)OrderStatusIdentifier.Dispatched)?.CreatedDate;

            return new OrderManagementDataContract
            {
                OrderId = this.OrderId,
                CustomerId = this.DeliveryPoint.CustomerDefinition.CurrentCustomer.CustomerId,
                DeliveryPointId = this.DeliveryPointId,
                IsComplete = this.OrderStatusId == (int)OrderStatusIdentifier.Delivered || this.OrderStatusId == (int)OrderStatusIdentifier.Archived ||
                    this.OrderStatusId == (int)OrderStatusIdentifier.ReadyForDispatch || this.OrderStatusId == (int)OrderStatusIdentifier.Dispatched ||
                    this.OrderStatusId == (int)OrderStatusIdentifier.Cancelled,
                AlternateId = this.AlternateId,
                DeliveryDate = DateTime.SpecifyKind(this.DeliveryDate, DateTimeKind.Utc),
                ProcedureDate = this.ProcedureDate.HasValue ? DateTime.SpecifyKind(this.ProcedureDate.Value, DateTimeKind.Utc) : this.ProcedureDate,
                OrderNumber = this.OrderNumber,
                ModifiedDate = this.Modified,
                OrderLines = this.OrderLine.Select(ol => ol.ToDataContract()).ToList(),
                OrderSource = this.OrderSource,
                Status = (OrderStatusIdentifier)OrderStatusId,
                DispatchedDate = dispatchDate.HasValue ? DateTime.SpecifyKind(dispatchDate.Value, DateTimeKind.Utc) : dispatchDate,
                SurgeonId = this.SurgicalProcedure?.Surgeon?.SurgeonId,
                SurgeonName = this.SurgicalProcedure?.Surgeon?.Name,
                SurgicalProcedureTypeId = this.SurgicalProcedure?.SurgicalProcedureType?.SurgicalProcedureTypeId,
                SurgicalProcedureTypeName = this.SurgicalProcedure?.SurgicalProcedureType?.Name,
                CaseCartNumber = this.CaseCartNumber
            };
        }

        /// <summary>
        /// ToOrderData operation
        /// </summary>
        public OrderData ToOrderData()
        {
            return new Core.Services.Website.DataContracts.OrderData
            {
                OrderId = OrderId,
                DeliveryPointId = DeliveryPointId,
                OrderStatusId = OrderStatusId,
                CreatedDate = CreatedDate,
                DeliveryDate = DeliveryDate,
                ProcedureDate = ProcedureDate,
                DeliveryPointName = DeliveryPoint.Text,
                CreatedById = CreatedById,
                OrderNumber = OrderNumber,
                AlternateId = AlternateId,
                BatchNumber = BatchNumber,
                HisOrderId = HisOrder.HisOrderId, //MW: Changed after DB update
                CreatedBy = new Core.Services.Stations.DataContracts.UserData
                {
                    FirstName = User.FirstName,
                    Surname = User.Surname
                },
                OrderStatus = new Core.Services.Website.DataContracts.OrderStatusData
                {
                    OrderStatusId = OrderStatus.OrderStatusId,
                    Text = OrderStatus.Text,
                    CompletesOrder = OrderStatus.CompletesOrder
                },
                OrderLines = OrderLine.Select(ol => new Core.Services.Website.DataContracts.OrderLineData
                {
                    OrderLineId = ol.OrderLineId,
                    OrderId = ol.OrderId,
                    ExternalId = ol.ContainerMasterDefinition.ContainerMasters.OrderByDescending(e => e.Revision).FirstOrDefault().ExternalId,
                    ContainerMasterDefinitionId = ol.ContainerMasterDefinitionId,
                    ContainerMasterId = ol.ContainerMasterDefinition.ContainerMasters.OrderByDescending(cm => cm.Revision).FirstOrDefault().ContainerMasterId,
                    ItemName = ol.ContainerMasterDefinition.ContainerMasters.OrderByDescending(o => o.Revision).FirstOrDefault().Text,
                    TurnaroundId = ol.TurnaroundId,
                    OrderLineStatusId = ol.OrderLineStatusId,
                    LineStatus = new Core.Services.Website.DataContracts.OrderLineStatusData
                    {
                        FulfilsOrderLine = ol.OrderLineStatus.FulfilsOrderLine,
                        OrderLineStatusId = ol.OrderLineStatus.OrderLineStatusId,
                        RequiresTurnaround = ol.OrderLineStatus.RequiresTurnaround,
                        Text = ol.OrderLineStatus.Text
                    },
                    TurnaroundExternalId = ol.Turnaround != null ? ol.Turnaround.ExternalId : default(long),
                    LastTurnaroundEventId = ol.Turnaround != null ? ol.Turnaround.LastEventId.Value : default(int),
                    LastTurnaroundEventTypeId = ol.Turnaround != null ? ol.Turnaround.LastEvent.EventTypeId : default(int),
                    RemoveTurnaround = ol.Turnaround != null ? ol.Turnaround.TurnaroundEvent.Any(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.DeliveryNotePrint) : default(bool)
                })
            };
        }

        /// <summary>
        /// UpdateOrder operation
        /// </summary>
        public void UpdateOrder(OrderManagementRequest request)
        {
            this.OrderStatusId = request.OrderStatusId;
            this.DeliveryPointId = request.DeliveryPointId;
            this.DeliveryDate = request.DeliveryDate.Value;
            this.AlternateId = request.AlternateId;
            this.ProcedureDate = request.ProcedureDate;
            this.Modified = DateTime.UtcNow;
            this.ModifiedById = request.UserId;
            this.CaseCartNumber = request.CaseCartNumber;
        }

        /// <summary>
        /// GetOrderLineThatCanBeFulfilled operation
        /// </summary>
        public OrderLine GetOrderLineThatCanBeFulfilled(int containerMasterDefinitionId)
        {
            var pickableSources = new[] { OrderSourceIdentifier.API, OrderSourceIdentifier.SAF };
            if (!pickableSources.Contains(this.OrderSource))
            {
                return null;
            }
            return this.OrderLine?.FirstOrDefault(ol =>
                ol.OrderLineStatusId != (int)OrderLineStatusIdentifier.Cancelled &&
                pickableSources.Contains(ol.OrderLineSourceIdentifier) &&
                ol.TurnaroundId == null
                && ol.ContainerMasterDefinitionId == containerMasterDefinitionId
            );
        }
    }
}

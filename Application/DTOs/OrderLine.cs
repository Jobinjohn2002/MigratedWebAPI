using System;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class OrderLine
    {
        public OrderLineStatusIdentifier OrderLineStatusIdentifier => (OrderLineStatusIdentifier)OrderLineStatusId;

        public OrderSourceIdentifier OrderLineSourceIdentifier => (OrderSourceIdentifier)OrderLineSourceId;

        /// <summary>
        /// ToDataContract operation
        /// </summary>
        public OrderLineDataContract ToDataContract()
        {
            var demandSources = new[] { OrderSourceIdentifier.API, OrderSourceIdentifier.SAF };
            var dispatchDate = this.Order.OrderStatusHistory.OrderByDescending(osh => osh.CreatedDate).FirstOrDefault(osh => osh.OrderStatusId == (int)OrderStatusIdentifier.Dispatched)?.CreatedDate;
            var orderLineDataContract = new OrderLineDataContract
            {
                OrderId = this.OrderId,
                OrderLineId = this.OrderLineId,
                TurnaroundId = this.TurnaroundId,
                ContainerMasterDefinitionId = this.ContainerMasterDefinitionId,
                LatestContainerMasterName = this.ContainerMasterDefinition.ContainerMaster.Text,
                LatestContainerMasterRevision = this.ContainerMasterDefinition.ContainerMaster.Revision,
                OrderLineStatusId = this.OrderLineStatusId,
                Revision = this.Turnaround?.ContainerMaster.Revision,
                ContainerMasterName = this.Turnaround?.ContainerMaster.Text,
                ContainerInstancePrimaryId = this.Turnaround?.ContainerInstance?.PrimaryId,
                TurnaroundExternalId = this.Turnaround?.ExternalId,
                SterileExpiry = this.Turnaround?.ContainerMaster.ItemType.IsNonSterileProduct == false ? this.Turnaround?.SterileExpiryDate : null,
                HasItemException = this.Turnaround?.ItemException.Any(ie => ie.Archived == null),
                OrderLineSource = (OrderSourceIdentifier)this.OrderLineSourceId,
                ContainerMasterDefinitionDemandCount = this.Order.OrderLine.Count(ol => ol.ContainerMasterDefinitionId == ContainerMasterDefinitionId && demandSources.Contains(ol.OrderLineSourceIdentifier) && ol.OrderLineStatusIdentifier != OrderLineStatusIdentifier.Cancelled),
                ContainerMasterDefinitionFulfilledCount = this.Order.OrderLine.Count(ol => ol.ContainerMasterDefinitionId == ContainerMasterDefinitionId && ol.TurnaroundId != null),
                OrderIsOnDemand = demandSources.Contains(this.Order.OrderSource),
                AllContainerMasterDefinitionIsOnDemand =
                this.Order.OrderLine.Any(ol => ol.ContainerMasterDefinitionId == ContainerMasterDefinitionId && demandSources.Contains(ol.OrderLineSourceIdentifier)) ==
                    this.Order.OrderLine.Any(ol => ol.ContainerMasterDefinitionId == ContainerMasterDefinitionId),
                LastModified = this.LastModified,
                OrderDispatchedDate = dispatchDate.HasValue ? DateTime.SpecifyKind(dispatchDate.Value, DateTimeKind.Utc) : dispatchDate
            };

            if (orderLineDataContract.SterileExpiry.HasValue)
            {
                orderLineDataContract.SterileExpiry = DateTime.SpecifyKind(orderLineDataContract.SterileExpiry.Value, DateTimeKind.Utc);
            }

            return orderLineDataContract;
        }
    }
}

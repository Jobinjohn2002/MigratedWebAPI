using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Turnaround Tab Detail Data
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// TurnaroundTabDetailData
    /// </summary>
    public class TurnaroundTabDetailData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public TurnaroundTabDetailData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnaroundTabDetailData"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <remarks></remarks>
        public TurnaroundTabDetailData(ITurnaroundTabDetail data)
        {
            TurnaroundId = data.TurnaroundId;
            CustomerEmail = data.CustomerEmail;
            DeliveryPointId = data.DeliveryPointId;
            CustomerId = data.CustomerId;
            IsTurnaroundInQuarantine = data.IsTurnaroundInQuarantine;
            ContainerInstanceId = data.ContainerInstanceId;
            IsTurnaroundArchived = data.IsTurnaroundArchived;
            ExternalId = data.ExternalId;
            LastEventName = data.LastEventName;
            LastEventTypeId = data.LastEventTypeId;
            ContainerMasterId = data.ContainerMasterId;
            ItemType = data.ItemType;
            ServiceRequirementId = data.ServiceRequirementId;
            DeliveryPointEmail = data.DeliveryPointEmail;
            BaseType = data.BaseType;
            CanSaveTurnaround = data.CanSaveTurnaround;
            LatestContainerMasterId = data.LatestContainerMasterId;
            InvoiceLineId = data.InvoiceLineId;
            CustomerDefinitionId = data.CustomerDefinitionId;
            FacilityId = data.FacilityId;
            CanQuarantine = data.CanQuarantine;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnaroundTabDetailData"/> class.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="externalId">the external id</param>
        /// <param name="customerEmail">The customer email.</param>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <param name="customerId">The customer id.</param>
        /// <param name="isTurnaroundInQuaranteen">The is turnaround in quaranteen.</param>
        /// <param name="containerInstanceId">The container instance id.</param>
        /// <param name="isTurnaroundArchived">Whether turnaround is archived or not</param>
        /// <param name="lastEventName">last event name</param>
        /// <param name="lastEventTypeId">last event type id</param>
        /// <param name="containerMasterId">container master id</param>
        /// <param name="itemType">item type</param>
        /// <remarks></remarks>
        public TurnaroundTabDetailData(long? turnaroundId, long? externalId, string customerEmail, int? deliveryPointId, int? customerId,
                                       bool? isTurnaroundInQuaranteen, int? containerInstanceId, bool? isTurnaroundArchived,
                                       string lastEventName, int? lastEventTypeId, int containerMasterId, string itemType, string deliveryPointEmail, int? invoiceLineId)
        {
            TurnaroundId = turnaroundId;
            CustomerEmail = customerEmail;
            DeliveryPointId = deliveryPointId;
            CustomerId = customerId;
            IsTurnaroundInQuarantine = isTurnaroundInQuaranteen;
            ContainerInstanceId = containerInstanceId;
            IsTurnaroundArchived = isTurnaroundArchived;
            ExternalId = externalId;
            LastEventName = lastEventName;
            LastEventTypeId = lastEventTypeId;
            ContainerMasterId = containerMasterId;
            ItemType = itemType;
            DeliveryPointEmail = deliveryPointEmail;
            InvoiceLineId = invoiceLineId;
        }

        #region ITurnaroundTabDetail Members

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        public long? ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the turnaround uid.
        /// </summary>
        /// <value>The turnaround uid.</value>
        /// <remarks></remarks>
        public long? TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>The customer email.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerEmail
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the deliverypoint id.
        /// </summary>
        /// <value>The deliverypoint id.</value>
        /// <remarks></remarks>
        public int? DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        /// <value>The customer id.</value>
        /// <remarks></remarks>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the is turnaround in quarantine.
        /// </summary>
        /// <value>The is turnaround in quarantine.</value>
        /// <remarks></remarks>
        public bool? IsTurnaroundInQuarantine { get; set; }

        /// <summary>
        /// Gets or sets the container instance id.
        /// </summary>
        /// <value>The container instance id.</value>
        /// <remarks></remarks>
        public int? ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the ContainerMasterId 
        /// </summary>
        /// <value>The ContainerMasterId .</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }

        /// <summary>
        /// Gets or sets the whether turnaround is archived or not.
        /// </summary>
        /// <value>whether turnaround is archived or not.</value>
        /// <remarks></remarks>
        public bool? IsTurnaroundArchived { get; set; }

        /// <summary>
        /// Gets or sets the last event name.
        /// </summary>
        /// <value>The last event name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LastEventName
        /// </summary>
        public string LastEventName { get; set; }

        /// <summary>
        /// Gets or sets The last event id.
        /// </summary>
        /// <value>The last event id.</value>
        /// <remarks></remarks>
        public int? LastEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets item type.
        /// </summary>
        /// <value>The item type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets Service Requirement.
        /// </summary>
        /// <value>The Service Requirement.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets Delivery Point Email.
        /// </summary>
        /// <value>The Delivery Point Email.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointEmail
        /// </summary>
        public string DeliveryPointEmail { get; set; }

        /// <summary>
        /// Gets or sets the base item type
        /// </summary>
        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }

        /// <summary>
        /// gets or sets the boolean value for turnaround save
        /// </summary>
        /// <summary>
        /// Gets or sets CanSaveTurnaround
        /// </summary>
        public bool CanSaveTurnaround { get; set; }

        /// <summary>
        /// Gets or sets the latest ContainerMasterId .
        /// </summary>
        /// <value>The latest ContainerMasterId.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LatestContainerMasterId
        /// </summary>
        public int LatestContainerMasterId { get; set; }

        /// <summary>
        /// Gets or sets the invoice line id.
        /// </summary>
        /// <value>
        /// The invoice line id.
        /// </value>
        public int? InvoiceLineId { get; set; }

        /// <summary>
        /// Gets or sets the customer definition id.
        /// </summary>
        /// <value>
        /// The customer definition id.
        /// </value>
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the Facility id.
        /// </summary>
        /// <value>
        /// The Facility id.
        /// </value>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets CanQuarantine
        /// </summary>
        public bool CanQuarantine { get; set; }
       
        #endregion
    }
}
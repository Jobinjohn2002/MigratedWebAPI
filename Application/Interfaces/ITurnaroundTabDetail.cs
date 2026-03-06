using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Turnaround Tab Detail Interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// ITurnaroundTabDetail
    /// </summary>
    public interface ITurnaroundTabDetail
    {
        /// <summary>
        /// Gets or sets the turnaround uid.
        /// </summary>
        /// <value>The turnaround uid.</value>
        /// <remarks></remarks>
        long? TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        long? ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the deliverypoint id.
        /// </summary>
        /// <value>The deliverypoint id.</value>
        /// <remarks></remarks>
        int? DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        /// <value>The customer id.</value>
        /// <remarks></remarks>
        int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the is turnaround in quarantine.
        /// </summary>
        /// <value>The is turnaround in quarantine.</value>
        /// <remarks></remarks>
        bool? IsTurnaroundInQuarantine { get; set; }

        /// <summary>
        /// Gets or sets the customer email.
        /// </summary>
        /// <value>The customer email.</value>
        /// <remarks></remarks>
        string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or sets the container instance id.
        /// </summary>
        /// <value>The container instance id.</value>
        /// <remarks></remarks>
        int? ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the ContainerMasterId .
        /// </summary>
        /// <value>The ContainerMasterId.</value>
        /// <remarks></remarks>
        int ContainerMasterId { get; set; }

        /// <summary>
        /// Gets or sets the latest ContainerMasterId .
        /// </summary>
        /// <value>The latest ContainerMasterId.</value>
        /// <remarks></remarks>
        int LatestContainerMasterId { get; set; }

        /// <summary>
        /// Gets or sets the whether turnaround is archived or not.
        /// </summary>
        /// <value>whether turnaround is archived or not.</value>
        /// <remarks></remarks>
        bool? IsTurnaroundArchived { get; set; }

        /// <summary>
        /// Gets or sets the last event name.
        /// </summary>
        /// <value>The last event name.</value>
        /// <remarks></remarks>
        string LastEventName { get; set; }

        /// <summary>
        /// Gets or sets The last event id.
        /// </summary>
        /// <value>The last event id.</value>
        /// <remarks></remarks>
        int? LastEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets the item type
        /// </summary>
        string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the Service Requirement Id
        /// </summary>
        int ServiceRequirementId { get; set; }

        /// <summary>
        /// gets or sets the delivery point email
        /// </summary>
        string DeliveryPointEmail { get; set; }

        /// <summary>
        /// Gets or sets the base item type
        /// </summary>
        string BaseType { get; set; }

        /// <summary>
        /// gets or sets the boolean value for turnaround save
        /// </summary>
        bool CanSaveTurnaround { get; set; }

        /// <summary>
        /// Gets or sets the invoice line id.
        /// </summary>
        /// <value>
        /// The invoice line id.
        /// </value>
        int? InvoiceLineId { get; set; }

        /// <summary>
        /// Gets or sets the customer definition id.
        /// </summary>
        /// <value>
        /// The customer definition id.
        /// </value>
        int CustomerDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the Facility id.
        /// </summary>
        /// <value>
        /// The Facility id.
        /// </value>
        short FacilityId { get; set; }

        bool CanQuarantine { get; set; }
    }
}
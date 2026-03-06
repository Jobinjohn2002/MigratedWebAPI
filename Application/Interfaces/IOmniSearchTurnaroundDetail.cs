using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IOmniSearchTurnaroundDetail
    /// </summary>
    public interface IOmniSearchTurnaroundDetail
    {
        /// <summary>
        /// Gets or sets the turnaround id.
        /// </summary>
        /// <value>The turnaround id.</value>
        /// <remarks></remarks>
        int TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        /// <remarks></remarks>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the service requiement id.
        /// </summary>
        /// <value>The service requirement id.</value>
        /// <remarks></remarks>
        int ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the service requiement name.
        /// </summary>
        /// <value>The service requiement name.</value>
        /// <remarks></remarks>
        string ServicerequirementName { get; set; }

        /// <summary>
        /// Gets or sets the delivery point id.
        /// </summary>
        /// <value>The delivery point id.</value>
        /// <remarks></remarks>
        int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the delivery point name.
        /// </summary>
        /// <value>The delivery point name.</value>
        /// <remarks></remarks>
        string DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        /// <value>The customer id.</value>
        /// <remarks></remarks>
        int CustomerId { get; set; }

        int CustomerStatusId { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        /// <value>The customer name.</value>
        /// <remarks></remarks>
        string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        /// <remarks></remarks>
        int? ItemId { get; set; }

        /// <summary>
        /// Gets or sets the item name.
        /// </summary>
        /// <value>The item name.</value>
        /// <remarks></remarks>
        string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        /// <remarks></remarks>
        string ItemExternalId { get; set; }

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The instance id.</value>
        /// <remarks></remarks>
        int? InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the instance primary id.
        /// </summary>
        /// <value>The instance primary id.</value>
        /// <remarks></remarks>
        string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets the delivery note id.
        /// </summary>
        /// <value>The delivery note id.</value>
        /// <remarks></remarks>
        int? DeliveryNoteId { get; set; }

        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>The expiry id.</value>
        /// <remarks></remarks>
        DateTime Expiry { get; set; }

        /// <summary>
        /// Gets or sets the legacy internal id.
        /// </summary>
        /// <value>The legacy internal id.</value>
        /// <remarks></remarks>
        int? LegacyInternalId { get; set; }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        long ExternalId { get; set; }
        /// <summary>
        /// Gets or sets the last event.
        /// </summary>
        /// <value>The last event.</value>
        /// <remarks></remarks>
        string LastEvent { get; set; }

        /// <summary>
        /// Gets or sets the last event date.
        /// </summary>
        /// <value>The last event date.</value>
        /// <remarks></remarks>
        DateTime? LastEventDate { get; set; }

        /// <summary>
        /// The RAG priority of the turnaround
        /// </summary>
        TurnaroundPriority Priority { get; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        bool IsArchived { get; set; }
    }
}

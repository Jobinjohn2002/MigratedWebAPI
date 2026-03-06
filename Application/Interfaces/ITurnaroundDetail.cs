using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// TurnaroundDetail interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// ITurnaroundDetail
    /// </summary>
    public interface ITurnaroundDetail
    {

        /// <summary>
        /// Gets or sets the turnaround id.
        /// </summary>
        /// <value>The turnaround id.</value>
        /// <remarks></remarks>
        int? TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the ExternalId id.
        /// </summary>
        /// <value>The ExternalId id.</value>
        /// <remarks></remarks>
        long? ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        /// <remarks></remarks>
        string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the customer id.
        /// </summary>
        /// <value>The customer id.</value>
        /// <remarks></remarks>
        int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the delivery point id.
        /// </summary>
        /// <value>The delivery point id.</value>
        /// <remarks></remarks>
        int? DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the name of the delivery point.
        /// </summary>
        /// <value>The name of the delivery point.</value>
        /// <remarks></remarks>
        string DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets the service requirement id.
        /// </summary>
        /// <value>The service requirement id.</value>
        /// <remarks></remarks>
        int? ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the deliverynote id.
        /// </summary>
        /// <value>The deliverynote id.</value>
        /// <remarks></remarks>
        int? DeliveryNoteId { get; set; }

        /// <summary>
        /// Gets or sets the deliverynote external id.
        /// </summary>
        /// <value>The deliverynote external id.</value>
        /// <remarks></remarks>
        int? DeliveryNoteExternalId { get; set; }

        /// <summary>
        /// Gets or sets the item external id.
        /// </summary>
        /// <value>The item external id.</value>
        /// <remarks></remarks>
        string ItemExternalId { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        /// <remarks></remarks>
        string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the Master id.
        /// </summary>
        /// <value>The Master Id.</value>
        /// <remarks></remarks>
        int MasterId { get; set; }

        /// <summary>
        /// Gets or sets the Master Type.
        /// </summary>
        /// <value>The Master Type.</value>
        /// <remarks></remarks>
        MasterType MasterType { get; set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        /// <remarks></remarks>
        string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the name of the autoclave.
        /// </summary>
        /// <value>The name of the autoclave.</value>
        /// <remarks></remarks>
        string AutoclaveName { get; set; }

        /// <summary>
        /// Gets or sets the autoclave batch.
        /// </summary>
        /// <value>The autoclave batch.</value>
        /// <remarks></remarks>
        int AutoclaveBatch { get; set; }

        /// <summary>
        /// Gets or sets the name of the washer.
        /// </summary>
        /// <value>The name of the washer.</value>
        /// <remarks></remarks>
        string WasherName { get; set; }

        /// <summary>
        /// Gets or sets the washer batch.
        /// </summary>
        /// <value>The washer batch.</value>
        /// <remarks></remarks>
        int WasherBatch { get; set; }

        /// <summary>
        /// Gets or sets the washer machine id
        /// </summary>
        int MachineId { get; set; }

        /// <summary>
        /// Gets or sets the Container id.
        /// </summary>
        /// <value>The Container Id.</value>
        /// <remarks></remarks>
        int ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the Container external id.
        /// </summary>
        /// <value>The Container external id.</value>
        /// <remarks></remarks>
        string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets the Expiry.
        /// </summary>
        /// <value>The Expiry.</value>
        /// <remarks></remarks>
        DateTime Expiry { get; set; }

        /// <summary>
        /// Gets or sets the Order Id
        /// </summary>
        /// <value>OrderId</value>
        /// <remarks></remarks>
        int? OrderId { get; set; }

        /// <summary>
        /// Gets or sets the Order Number
        /// </summary>
        /// <value>OrderNumber</value>
        /// <remarks></remarks>
        string OrderNumber { get; set; }

        /// <summary>
        /// gets or sets the auto clave processed facility
        /// </summary>
        string AutoClaveProcessedFacility { get; set; }

        /// <summary>
        /// gets or sets the washer processed facility
        /// </summary>
        string WasherProcessedFacility { get; set; }

        /// <summary>
        /// gets or sets the Customer Facility Name
        /// </summary>
        string CustomerFacilityName { get; set; }
        /// <summary>
        /// gets or sets the Is Identifiable
        /// </summary>
        bool IsIdentifiable { get; set; }

        bool IsEndoscope { get; set; }
        int AerWasherBatch { get; set; }
        string AerWasherName { get; set; }
        string AerWasherBatchExternalId { get; set; }
        int AerWasherMachineId { get; set; }
        string AerWasherProcessedFacility { get; set; }

        bool CanQuarantine { get; set; }

        bool DisableTrolleyCustomerRestriction { get; set; }

        bool ShowDisableTrolleyCustomerRestriction { get; set; }
        bool CanDisableTrolleyCustomerRestriction { get; set; }
    }
}

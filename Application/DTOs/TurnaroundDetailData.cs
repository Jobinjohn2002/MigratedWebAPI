using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Turnaround Detail Data
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// TurnaroundDetailData
    /// </summary>
    public class TurnaroundDetailData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public TurnaroundDetailData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnaroundDetailData"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <remarks></remarks>
        public TurnaroundDetailData(ITurnaroundDetail data)
        {
            TurnaroundId = data.TurnaroundId;
            CustomerName = data.CustomerName;
            CustomerId = data.CustomerId;
            DeliveryPointId = data.DeliveryPointId;
            DeliveryPointName = data.DeliveryPointName;
            ServiceRequirementId = data.ServiceRequirementId;
            DeliveryNoteId = data.DeliveryNoteId;
            DeliveryNoteExternalId = data.DeliveryNoteExternalId;
            ItemExternalId = data.ItemExternalId;
            ItemName = data.ItemName;
            ItemType = data.ItemType;
            AutoclaveName = data.AutoclaveName;
            AutoclaveBatch = data.AutoclaveBatch;
            WasherName = data.WasherName;
            WasherBatch = data.WasherBatch;
            ExternalId = data.ExternalId;
            MasterType = data.MasterType;
            MasterId = data.MasterId;
            ContainerInstanceId = data.ContainerInstanceId;
            ContainerInstancePrimaryId = data.ContainerInstancePrimaryId;
            Expiry = data.Expiry;
            OrderNumber = data.OrderNumber;
            OrderId = data.OrderId;
            AutoClaveProcessedFacility = data.AutoClaveProcessedFacility;
            WasherProcessedFacility = data.WasherProcessedFacility;
            CustomerFacilityName = data.CustomerFacilityName;
            IsIdentifiable = data.IsIdentifiable;
            IsEndoscope = data.IsEndoscope;
            AerWasherBatch = data.AerWasherBatch;
            AerWasherBatchExternalId = data.AerWasherBatchExternalId;
            AerWasherMachineId = data.AerWasherMachineId;
            AerWasherName = data.AerWasherName;
            AerWasherProcessedFacility = data.AerWasherProcessedFacility;
            CanQuarantine = data.CanQuarantine;
            DisableTrolleyCustomerRestriction = data.DisableTrolleyCustomerRestriction;
    }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnaroundDetailData"/> class.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <param name="externalId">The External Id</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="deliverypointId">The deliverypoint id.</param>
        /// <param name="deliveryPointName">Name of the delivery point.</param>
        /// <param name="serviceRequirementId">The service requirement id.</param>
        /// <param name="deliveryNoteId">The deliverynote id.</param>
        /// <param name="deliveryNoteExternalId">The deliverynote external id.</param>
        /// <param name="itemExternalId">The item external id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="itemType">Type of the item.</param>
        /// <param name="autoclaveName">Name of the autoclave.</param>
        /// <param name="autoclaveBatch">The autoclave batch.</param>
        /// <param name="washerName">Name of the washer.</param>
        /// <param name="washerBatch">The washer batch.</param>
        /// <remarks></remarks>
        public TurnaroundDetailData(int turnaroundId, long externalId, string customerName, int deliverypointId,
                                    string deliveryPointName, int serviceRequirementId, int deliveryNoteId,
                                    int deliveryNoteExternalId
                                    , string itemExternalId, string itemName, string itemType, string autoclaveName,
                                    int autoclaveBatch, string washerName, int washerBatch, bool isEndoscope, string aerWasherName, int aerWasherBatch)
        {
            TurnaroundId = turnaroundId;
            CustomerName = customerName;
            DeliveryPointId = deliverypointId;
            DeliveryPointName = deliveryPointName;
            ServiceRequirementId = serviceRequirementId;
            DeliveryNoteId = deliveryNoteId;
            DeliveryNoteExternalId = deliveryNoteExternalId;
            ItemExternalId = itemExternalId;
            ItemName = itemName;
            ItemType = itemType;
            AutoclaveName = autoclaveName;
            AutoclaveBatch = autoclaveBatch;
            WasherName = washerName;
            WasherBatch = washerBatch;
            IsEndoscope = isEndoscope;
            AerWasherName = aerWasherName;
            AerWasherBatch = aerWasherBatch;
            ExternalId = externalId;
        }

        #region ITurnaroundDetail Members

        /// <summary>
        /// Gets or sets the turnaround id.
        /// </summary>
        /// <value>The turnaround id.</value>
        /// <remarks></remarks>
        public int? TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the ExternalId id.
        /// <value>The ExternalId id.</value>
        /// </summary>
        public long? ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>The name of the customer.</value>
        /// <remarks></remarks>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the delivery point id.
        /// </summary>
        /// <value>The delivery point id.</value>
        /// <remarks></remarks>
        public int? DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the name of the delivery point.
        /// </summary>
        /// <value>The name of the delivery point.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets the service requirement id.
        /// </summary>
        /// <value>The service requirement id.</value>
        /// <remarks></remarks>
        public int? ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the deliverynote id.
        /// </summary>
        /// <value>The deliverynote id.</value>
        /// <remarks></remarks>
        public int? DeliveryNoteId { get; set; }

        /// <summary>
        /// Gets or sets the deliverynote external id.
        /// </summary>
        /// <value>The deliverynote external id.</value>
        /// <remarks></remarks>
        public int? DeliveryNoteExternalId { get; set; }

        /// <summary>
        /// Gets or sets the item external id.
        /// </summary>
        /// <value>The item external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }

        /// <summary>
        /// Gets or sets the Master id.
        /// </summary>
        /// <value>The Master Id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterId
        /// </summary>
        public int MasterId { get; set; }

        /// <summary>
        /// Gets or sets the Container id.
        /// </summary>
        /// <value>The Container Id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        /// <summary>
        /// Gets or sets the Container external id.
        /// </summary>
        /// <value>The Container external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }

        /// <summary>
        /// Gets or sets the Expiry.
        /// </summary>
        /// <value>The Expiry.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }

        /// <summary>
        /// Gets or sets the Master Type.
        /// </summary>
        /// <value>The Master Type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterType
        /// </summary>
        public MasterType MasterType { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the name of the autoclave.
        /// </summary>
        /// <value>The name of the autoclave.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets AutoclaveName
        /// </summary>
        public string AutoclaveName { get; set; }

        /// <summary>
        /// Gets or sets the autoclave batch.
        /// </summary>
        /// <value>The autoclave batch.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets AutoclaveBatch
        /// </summary>
        public int AutoclaveBatch { get; set; }

        /// <summary>
        /// Gets or sets the autoclave batch.
        /// </summary>
        /// <value>The autoclave batch.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets AutoclaveBatchExternalId
        /// </summary>
        public string AutoclaveBatchExternalId { get; set; }

        /// <summary>
        /// Gets or sets the name of the washer.
        /// </summary>
        /// <value>The name of the washer.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets WasherName
        /// </summary>
        public string WasherName { get; set; }

        /// <summary>
        /// Gets or sets the washer batch.
        /// </summary>
        /// <value>The washer batch.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets WasherBatch
        /// </summary>
        public int WasherBatch { get; set; }

        /// <summary>
        /// Gets or sets the washer machine  id.
        /// </summary>
        /// <value>The washer Machine id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }

        /// <summary>
        /// Gets or sets the washer batch.
        /// </summary>
        /// <value>The washer batch.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets WasherBatchExternalId
        /// </summary>
        public string WasherBatchExternalId { get; set; }

        /// <summary>
        /// Gets or sets the washer machine  id.
        /// </summary>
        /// <value>The washer Machine id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets WasherMachineId
        /// </summary>
        public int WasherMachineId { get; set; }

        /// <summary>
        /// Gets or sets the washer machine  id.
        /// </summary>
        /// <value>The washer Machine id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets AutoClaveMachineId
        /// </summary>
        public int AutoClaveMachineId { get; set; }
        
        /// <summary>
        /// Gets or sets the Order Id
        /// </summary>
        /// <value>OrderId</value>
        /// <remarks></remarks>
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or sets the Order Number
        /// </summary>
        /// <value>OrderNumber</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// gets or sets the auto clave processed facility
        /// </summary>
        /// <summary>
        /// Gets or sets AutoClaveProcessedFacility
        /// </summary>
        public string AutoClaveProcessedFacility { get; set; }

        /// <summary>
        /// gets or sets the washer processed facility
        /// </summary>
        /// <summary>
        /// Gets or sets WasherProcessedFacility
        /// </summary>
        public string WasherProcessedFacility { get; set; }

        /// <summary>
        /// gets or sets the Customer Facility Name
        /// </summary>
        /// <summary>
        /// Gets or sets CustomerFacilityName
        /// </summary>
        public string CustomerFacilityName { get; set; }
        /// <summary>
        /// gets or sets the Is Identifiable for Container instance
        /// </summary>
        /// <summary>
        /// Gets or sets IsIdentifiable
        /// </summary>
        public bool IsIdentifiable { get; set; }
        /// <summary>
        /// Gets or sets IsEndoscope
        /// </summary>
        public bool IsEndoscope { get; set; }
        /// <summary>
        /// Gets or sets AerWasherBatch
        /// </summary>
        public int AerWasherBatch { get; set; }
        /// <summary>
        /// Gets or sets AerWasherName
        /// </summary>
        public string AerWasherName { get; set; }
        /// <summary>
        /// Gets or sets AerWasherBatchExternalId
        /// </summary>
        public string AerWasherBatchExternalId { get; set; }
        /// <summary>
        /// Gets or sets AerWasherMachineId
        /// </summary>
        public int AerWasherMachineId { get; set; }
        /// <summary>
        /// Gets or sets AerWasherProcessedFacility
        /// </summary>
        public string AerWasherProcessedFacility { get; set; }
        /// <summary>
        /// Gets or sets CanQuarantine
        /// </summary>
        public bool CanQuarantine { get; set; }
        /// <summary>
        /// Gets or sets DisableTrolleyCustomerRestriction
        /// </summary>
        public bool DisableTrolleyCustomerRestriction { get; set; }
        /// <summary>
        /// Gets or sets ShowDisableTrolleyCustomerRestriction
        /// </summary>
        public bool ShowDisableTrolleyCustomerRestriction { get; set; }
        /// <summary>
        /// Gets or sets CanDisableTrolleyCustomerRestriction
        /// </summary>
        public bool CanDisableTrolleyCustomerRestriction { get; set; }

        #endregion
    }
}
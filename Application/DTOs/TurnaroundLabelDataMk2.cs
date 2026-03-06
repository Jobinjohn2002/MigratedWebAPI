using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundLabelDataMk2
    /// </summary>
    public class TurnaroundLabelDataMk2
    {
        public TurnaroundLabelDataMk2(string serialNumber,
            string itemExternalId,
            string itemName,
            short quantity,
            IList<ItemExceptionLabelInfo> exceptions,
            string facilityName,
            string customerName,
            string customerGs1,
            string deliveryPointName,
            string address,
            string town,
            string postcode,
            string telephone,
            string gtin,
            IList<string> additionalDetails,
            DateTime printDate,
            DateTime expiryDate,
            bool showQuantity,
            decimal lastKnownWeight,
            decimal referenceWeight,
            string additionalInfo,
            string componentSerialNumber,
            DateTime? processedDate,
            DateTime? deconEndDate,
            string processingMachine,
            string batchCycle)
        {
            SerialNumber = serialNumber;
            ItemExternalId = itemExternalId;
            ItemName = itemName;
            Quantity = quantity;
            Exceptions = exceptions;
            FacilityName = facilityName;
            CustomerName = customerName;
            CustomerGs1 = customerGs1;
            DeliveryPointName = deliveryPointName;
            Address = address;
            Town = town;
            Postcode = postcode;
            Telephone = telephone;
            Gtin = gtin;
            AdditionalDetails = additionalDetails;
            PrintDate = printDate;
            ExpiryDate = expiryDate;
            ShowQuantity = showQuantity;
            LastKnownWeight = lastKnownWeight;
            ReferenceWeight = referenceWeight;
            AdditionalInfo = additionalInfo;
            ComponentSerialNumber = componentSerialNumber;
            ProcessedDate = processedDate;
            DeconEndDate = deconEndDate;
            ProcessingMachine = processingMachine;
            BatchCycle = batchCycle;
        }
        #region Properties

        /// <summary>
        /// Gets the serial number. Commonly used to hold the turnaround external id.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets SerialNumber
        /// </summary>
        public string SerialNumber { get; }

        /// <summary>
        /// Gets the item external id.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; }

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; }

        /// <summary>
        /// Gets the quantity.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public short Quantity { get; }

        /// <summary>
        /// Gets the exceptions.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Exceptions
        /// </summary>
        public IList<ItemExceptionLabelInfo> Exceptions { get; }

        /// <summary>
        /// Gets the name of the facility.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; }

        /// <summary>
        /// Gets the customer G s1.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerGs1
        /// </summary>
        public string CustomerGs1 { get; }

        /// <summary>
        /// Gets the name of the delivery point.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public string Address { get; }

        /// <summary>
        /// Gets the town.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Town
        /// </summary>
        public string Town { get; }

        /// <summary>
        /// Gets the postcode.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Postcode
        /// </summary>
        public string Postcode { get; }

        /// <summary>
        /// Gets the telephone.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Telephone
        /// </summary>
        public string Telephone { get; }

        /// <summary>
        /// Gets the gtin.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Gtin
        /// </summary>
        public string Gtin { get; }

        /// <summary>
        /// Gets the additional details.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets AdditionalDetails
        /// </summary>
        public IList<string> AdditionalDetails { get; }

        /// <summary>
        /// Gets the print date.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets PrintDate
        /// </summary>
        public DateTime PrintDate { get; }

        /// <summary>
        /// Gets the expiry date.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExpiryDate
        /// </summary>
        public DateTime ExpiryDate { get; }

        /// <summary>
        /// Gets the show quantity.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ShowQuantity
        /// </summary>
        public bool ShowQuantity { get; }

        /// <summary>
        /// Gets or sets AdditionalInfo
        /// </summary>
        public string AdditionalInfo { get; }

        /// <summary>
        /// Gets or sets LastKnownWeight
        /// </summary>
        public Decimal LastKnownWeight { get; }

        /// <summary>
        /// Gets or sets ReferenceWeight
        /// </summary>
        public Decimal ReferenceWeight { get; }

        /// <summary>
        /// Gets the Component (Item) Serial Number.
        /// </summary>
        /// <summary>
        /// Gets or sets ComponentSerialNumber
        /// </summary>
        public string ComponentSerialNumber { get; }

        /// <summary>
        /// Gets the processed datetime (generally turnaround event datetime)
        /// </summary>
        public DateTime? ProcessedDate { get; }

        /// <summary>
        /// Gets the date time Decontamination Ended.
        /// </summary>
        public DateTime? DeconEndDate { get; }

        /// <summary>
        /// Gets the name of the processing machine.
        /// </summary>
        /// <summary>
        /// Gets or sets ProcessingMachine
        /// </summary>
        public string ProcessingMachine { get; }

        /// <summary>
        /// Gets the batch cycle id.
        /// </summary>
        /// <summary>
        /// Gets or sets BatchCycle
        /// </summary>
        public string BatchCycle { get; }

        #endregion
    }
}
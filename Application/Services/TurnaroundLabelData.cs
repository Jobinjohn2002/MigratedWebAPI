using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// TurnaroundLabelData
    /// </summary>
    public class TurnaroundLabelData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public TurnaroundLabelData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TurnaroundLabelData"/> class.
        /// </summary>
        /// <param name="labelDefinitionTemplate">The label definition template.</param>
        /// <param name="labelDefinition">The label definition.</param>
        /// <param name="serialNumber">The serial number.</param>
        /// <param name="itemExternalId">The item external id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="exceptions">The exceptions.</param>
        /// <param name="facilityName">Name of the facility.</param>
        /// <param name="customerName">Name of the customer.</param>
        /// <param name="customerGs1">The customer G s1.</param>
        /// <param name="deliveryPointName">Name of the delivery point.</param>
        /// <param name="address">The address.</param>
        /// <param name="town">The town.</param>
        /// <param name="postcode">The postcode.</param>
        /// <param name="telephone">The telephone.</param>
        /// <param name="gtin">The gtin.</param>
        /// <param name="additionalDetails">The additional details.</param>
        /// <param name="printDate">The print date.</param>
        /// <param name="expiryDate">The expiry date.</param>
        /// <param name="showQuantity"></param>
        /// <remarks></remarks>
        public TurnaroundLabelData(string labelDefinitionTemplate,
                                   string labelDefinition,
                                   string serialNumber,
                                   string itemExternalId,
                                   string itemName,
                                   short quantity,
                                   IList<string> exceptions,
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
                                   bool showQuantity)
        {
            LabelDefinitionTemplate = labelDefinitionTemplate;
            LabelDefinition = labelDefinition;
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
        }

        #region Properties

        /// <summary>
        /// Gets the label definition template.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LabelDefinitionTemplate
        /// </summary>
        public string LabelDefinitionTemplate { get; private set; }

        /// <summary>
        /// Gets the label definition.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LabelDefinition
        /// </summary>
        public string LabelDefinition { get; private set; }

        /// <summary>
        /// Gets the serial number.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets SerialNumber
        /// </summary>
        public string SerialNumber { get; private set; }

        /// <summary>
        /// Gets the item external id.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; private set; }

        /// <summary>
        /// Gets the name of the item.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; private set; }

        /// <summary>
        /// Gets the quantity.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public short Quantity { get; private set; }

        /// <summary>
        /// Gets the exceptions.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Exceptions
        /// </summary>
        public IList<string> Exceptions { get; private set; }

        /// <summary>
        /// Gets the name of the facility.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; private set; }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; private set; }

        /// <summary>
        /// Gets the customer G s1.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerGs1
        /// </summary>
        public string CustomerGs1 { get; private set; }

        /// <summary>
        /// Gets the name of the delivery point.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; private set; }

        /// <summary>
        /// Gets the address.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Address
        /// </summary>
        public string Address { get; private set; }

        /// <summary>
        /// Gets the town.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Town
        /// </summary>
        public string Town { get; private set; }

        /// <summary>
        /// Gets the postcode.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Postcode
        /// </summary>
        public string Postcode { get; private set; }

        /// <summary>
        /// Gets the telephone.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Telephone
        /// </summary>
        public string Telephone { get; private set; }

        /// <summary>
        /// Gets the gtin.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Gtin
        /// </summary>
        public string Gtin { get; private set; }

        /// <summary>
        /// Gets the additional details.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets AdditionalDetails
        /// </summary>
        public IList<string> AdditionalDetails { get; private set; }

        /// <summary>
        /// Gets the print date.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets PrintDate
        /// </summary>
        public DateTime PrintDate { get; private set; }

        /// <summary>
        /// Gets the expiry date.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExpiryDate
        /// </summary>
        public DateTime ExpiryDate { get; private set; }

        /// <summary>
        /// Gets the show quantity.
        /// </summary>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ShowQuantity
        /// </summary>
        public bool ShowQuantity { get; private set; }

        #endregion
    }
}
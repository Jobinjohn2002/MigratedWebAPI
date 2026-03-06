using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Represents the information about an ItemException for display on a QA label
    /// </summary>
    /// <summary>
    /// ItemExceptionLabelInfo
    /// </summary>
    public class ItemExceptionLabelInfo
    {
        public ItemExceptionLabelInfo(string manufacturersReference, string itemMasterExternalId, string itemMasterName, int itemExceptionsQuantity, string itemExceptionReason, string exceptionDescription)
        {
            ManufacturersReference = manufacturersReference;
            ItemMasterExternalId = itemMasterExternalId;
            ItemMasterName = itemMasterName;
            ItemExceptionQuantity = itemExceptionsQuantity;
            ItemExceptionReason = itemExceptionReason;
            ExceptionDescription = exceptionDescription;
        }
        
        /// <summary>
        /// Gets or sets the Manufacturer's reference.
        /// </summary>
        /// <summary>
        /// Gets or sets ManufacturersReference
        /// </summary>
        public string ManufacturersReference { get; private set; }

        /// <summary>
        /// Gets the External Id of the Item Master that the item is associated with.
        /// </summary>
        /// <summary>
        /// Gets or sets ItemMasterExternalId
        /// </summary>
        public string ItemMasterExternalId { get; private set; }

        /// <summary>
        /// Gets the name of the Item Master that the item is associated with.
        /// </summary>
        /// <summary>
        /// Gets or sets ItemMasterName
        /// </summary>
        public string ItemMasterName { get; private set; }

        /// <summary>
        /// Gets the number of ItemExceptions of this type.
        /// </summary>
        /// <summary>
        /// Gets or sets ItemExceptionQuantity
        /// </summary>
        public int ItemExceptionQuantity { get; private set; }

        /// <summary>
        /// Gets the reason for the ItemException.
        /// </summary>
        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public string ItemExceptionReason { get; private set; }

        /// <summary>
        /// Gets the description of the exception to be used in "old" label definitions
        /// using the "[EXCEPTIONS0]|[EXCEPTIONS1]|...[EXCEPTIONS11]" style templates.
        /// </summary>
        /// <summary>
        /// Gets or sets ExceptionDescription
        /// </summary>
        public string ExceptionDescription { get; private set; }
    }
}
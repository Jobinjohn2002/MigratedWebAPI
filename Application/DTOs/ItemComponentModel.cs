using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemComponentModel
    /// </summary>
    public class ItemComponentModel
    {
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinitionId
        /// </summary>
        public int ItemMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeId
        /// </summary>
        public int BaseItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentNote
        /// </summary>
        public string ContainerContentNote { get; set; }
        /// <summary>
        /// Gets or sets ManufacurersRef
        /// </summary>
        public string ManufacurersRef { get; set; }

        /// <summary>
        /// Gets or sets ItemExceptions
        /// </summary>
        public List<ItemComponentExceptionModel> ItemExceptions { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionHistory
        /// </summary>
        public List<ItemExceptionsDataContract> ItemExceptionHistory { get; set; }
    }
}

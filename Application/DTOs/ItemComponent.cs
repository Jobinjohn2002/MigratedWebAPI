using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemComponent
    /// </summary>
    public class ItemComponent
    {
        public ItemComponent()
        {
            
        }

        public ItemComponent(int containerMasterId, int itemId, string itemExternalId,int itemMasterDefinitionId,
            string itemName, int componentQuantity, int itemExceptionQuantity, string itemExceptionReason, int itemTypeId, string itemType,int baseItemTypeId, string baseItemType)
        {
            ContainerMasterId = containerMasterId;
            ItemExternalId = itemExternalId;
            ItemId = itemId;
            ItemMasterDefinitionId = itemMasterDefinitionId;
            ItemName = itemName;
            ComponentQuantity = componentQuantity;
            ItemExceptionQuantity = itemExceptionQuantity;
            ItemExceptionReason = itemExceptionReason;
            ItemTypeId = itemTypeId;
            ItemType = itemType;
            BaseItemType = baseItemType;
            BaseItemTypeId = baseItemTypeId;

        }

        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }

        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }

        /// <summary>
        /// Gets or sets ItemMasterDefinitionId
        /// </summary>
        public int ItemMasterDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Gets or sets ComponentQuantity
        /// </summary>
        public int ComponentQuantity { get; set; }

        /// <summary>
        /// Gets or sets ItemExceptionQuantity
        /// </summary>
        public int ItemExceptionQuantity { get; set; }

        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public string ItemExceptionReason { get; set; }

        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets BaseItemTypeId
        /// </summary>
        public int BaseItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets BaseItemType
        /// </summary>
        public string BaseItemType { get; set; }
    }
}

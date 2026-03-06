using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ComponentDetail
    /// </summary>
    public class ComponentDetail
    {
        public ComponentDetail()
        {}

        public ComponentDetail( int containerMasterId,int? itemId,string itemExternalId,int itemMasterDefinitionId, string itemName,int componentQuantity,byte itemExceptionQuantity, string itemExceptionReason,short? itemTypeId,string itemType,short? baseItemTypeId,string baseItemType)
        {
            ContainerMasterId =containerMasterId;
            ItemMasterDefinitionId = itemMasterDefinitionId; 
            ItemId = itemId;
            ItemExternalId = itemExternalId;
            ItemName = itemName;
            ComponentQuantity = componentQuantity;
            ItemExceptionQuantity = itemExceptionQuantity;
            ItemExceptionReason = itemExceptionReason;
            ItemTypeId = itemTypeId;
            ItemType = itemType;
            BaseItemTypeId = baseItemTypeId;
            BaseItemType = baseItemType;
        }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }

        public int? ItemId { get; set; }

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
        public byte ItemExceptionQuantity { get; set; }

        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public string ItemExceptionReason { get; set; }

        public short? ItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        public short? BaseItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets BaseItemType
        /// </summary>
        public string BaseItemType { get; set; }
    }
}

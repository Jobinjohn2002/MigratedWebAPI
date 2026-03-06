using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ComponentDetailData
    /// </summary>
    public class ComponentDetailData
    {
        public ComponentDetailData(IComponentDetail component)
        {
            ContainerMasterId = component.ContainerMasterId;
            ItemId = component.ItemId;
            ItemMasterDefinitionId = component.ItemMasterDefinitionId;
            ItemExternalId = component.ItemExternalId;
            ItemName = component.ItemName;
            ComponentQuantity = component.ComponentQuantity;
            ItemExceptionQuantity = component.ItemExceptionQuantity;
            ItemExceptionReason = component.ItemExceptionReason;
            ItemTypeId = component.ItemTypeId;
            ItemType = component.ItemType;
            BaseItemTypeId = component.BaseItemTypeId;
            BaseItemType = component.BaseItemType;
        }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterDefinitionId
        /// </summary>
        public int ItemMasterDefinitionId { get; set; }
        public int? ItemId { get; set; }
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    [Serializable]
    /// <summary>
    /// ComponentListData
    /// </summary>
    public class ComponentListData : StationDataBase
    {

        public ComponentListData(int itemMasterId,
                                             short itemTypeId,
                                             string externalId,
                                             string text, int quantity, int containerContentId, int? itemMasterDefinitionId, int packed, IList<ItemExceptionReasonData> itemExceptionReason, int itemExceptionReasonId, int itemExceptionQuantity,IList<ItemInstanceData> itemInstance,int existingItemExceptionQuantity,int existingItemExceptionReasonId,int itemExceptionId) 
        {
            ItemMasterId = itemMasterId;
            ItemTypeId = itemTypeId;
            ExternalId = externalId;
            Text = text;
            Quantity = quantity;
            ContainerContentId = containerContentId;
            ItemMasterDefinitionId = itemMasterDefinitionId;
            Packed = packed;
            ItemExceptionReason = itemExceptionReason;
            ItemExceptionReasonId = itemExceptionReasonId;
            ItemExceptionQuantity = itemExceptionQuantity;
            ItemInstance = itemInstance;
            ExistingItemExceptionQunatity = existingItemExceptionQuantity;
            ExistingItemExceptionReasonId = existingItemExceptionReasonId;
            ItemExceptionId = itemExceptionId;            
        }
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentId
        /// </summary>
        public int ContainerContentId { get; set; }
        public int? ItemMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets Packed
        /// </summary>
        public int Packed { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public IList<ItemExceptionReasonData> ItemExceptionReason { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReasonId
        /// </summary>
        public int ItemExceptionReasonId { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionQuantity
        /// </summary>
        public int ItemExceptionQuantity { get; set; }
        /// <summary>
        /// Gets or sets ItemInstance
        /// </summary>
        public IList<ItemInstanceData> ItemInstance { get; set; }
        /// <summary>
        /// Gets or sets ExistingItemExceptionReasonId
        /// </summary>
        public int ExistingItemExceptionReasonId { get; set; }
        /// <summary>
        /// Gets or sets ExistingItemExceptionQunatity
        /// </summary>
        public int ExistingItemExceptionQunatity { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionId
        /// </summary>
        public int ItemExceptionId { get; set; }
    }
}

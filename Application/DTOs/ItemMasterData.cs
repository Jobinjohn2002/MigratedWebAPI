using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ItemMasterData
    {
        public ItemMasterData() { }
        public ItemMasterData(IItemMaster genericObj,
            ItemInstanceData itemInstance,
            ItemTypeData itemType,
            ItemTypeData baseItemType,
            int position)
            : this(genericObj)
        {
            ItemInstance = itemInstance;
            ItemType = itemType;
            BaseItemType = baseItemType;
            Position = position;
        }

        #region extra Members
        /// <summary>
        /// Gets or sets ItemInstance
        /// </summary>
        public ItemInstanceData ItemInstance { get; set; }
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public ItemTypeData ItemType { get; set; }
        /// <summary>
        /// Gets or sets BaseItemType
        /// </summary>
        public ItemTypeData BaseItemType { get; set; }
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }
        public int? ComponentQuntity { get; set; }
        public int? ItemExceptionQuantity { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public string ItemExceptionReason { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ChildItemTypeName
        /// </summary>
        public string ChildItemTypeName { get; set; }

        /// <summary>
        /// Gets or sets the Customer Gtin
        /// </summary>
        /// <value>The Customer Gtin.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Total
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNotes
        /// </summary>
        public IList<ContainerMasterNoteData> ContainerMasterNotes { get; set; }
        /// <summary>
        /// Gets or sets Warnings
        /// </summary>
        public IList<WarningData> Warnings { get; set; }
        public int? OwnerId { get; set; }
        /// <summary>
        /// Gets or sets Manufacturer
        /// </summary>
        public ManufacturerDataContract Manufacturer { get; set; }
        #endregion
    }
}
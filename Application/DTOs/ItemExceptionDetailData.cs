using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemExceptionDetailData
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// ItemExceptionDetailData
    /// </summary>
    public class ItemExceptionDetailData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public ItemExceptionDetailData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemExceptionDetailData"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <remarks></remarks>
        public ItemExceptionDetailData(IItemExceptionDetail data)
        {
            ItemExceptionId = data.ItemExceptionId;
            InstanceId = data.InstanceId;
            Quantity = data.Quantity;
            CompQty = data.CompQty;
            ReasonId = data.ReasonId;
            ReasonName = data.ReasonName;
            Trackable = data.Trackable;
            ItemMasterId = data.ItemMasterId;
            ItemName = data.ItemName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemExceptionDetailData"/> class.
        /// </summary>
        /// <param name="itemExceptionId">The ItemException id.</param>
        /// <param name="instanceId">The instance id.</param>
        /// <param name="quantity">The quantity.</param>
        /// <param name="compQty">The comp qty.</param>
        /// <param name="reasonId">The reason id.</param>
        /// <param name="reasonName">Name of the reason.</param>
        /// <param name="trackable">if set to <c>true</c> [trackable].</param>
        /// <param name="itemMasterId">The item master id.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <remarks></remarks>
        public ItemExceptionDetailData(int? itemExceptionId, int? instanceId, short quantity, short compQty, int? reasonId,
                                      string reasonName, bool trackable, int? itemMasterId, string itemName)
        {
            ItemExceptionId = itemExceptionId;
            InstanceId = instanceId;
            Quantity = quantity;
            CompQty = compQty;
            ReasonId = reasonId;
            ReasonName = reasonName;
            Trackable = trackable;
            ItemMasterId = itemMasterId;
            ItemName = itemName;
        }

        #region IItemExceptionDetail Members

        /// <summary>
        /// Gets or sets the ItemException id.
        /// </summary>
        /// <value>The ItemException id.</value>
        /// <remarks></remarks>
        public int? ItemExceptionId { get; set; }

        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        /// <value>The instance id.</value>
        /// <remarks></remarks>
        public int? InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public short Quantity { get; set; }

        /// <summary>
        /// Gets or sets the comp qty.
        /// </summary>
        /// <value>The comp qty.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CompQty
        /// </summary>
        public short CompQty { get; set; }

        /// <summary>
        /// Gets or sets the reason id.
        /// </summary>
        /// <value>The reason id.</value>
        /// <remarks></remarks>
        public int? ReasonId { get; set; }

        /// <summary>
        /// Gets or sets the name of the reason.
        /// </summary>
        /// <value>The name of the reason.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ReasonName
        /// </summary>
        public string ReasonName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IItemExceptionDetail"/> is trackable.
        /// </summary>
        /// <value><c>true</c> if trackable; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Trackable
        /// </summary>
        public bool Trackable { get; set; }

        /// <summary>
        /// Gets or sets the item master id.
        /// </summary>
        /// <value>The item master id.</value>
        /// <remarks></remarks>
        public int? ItemMasterId { get; set; }

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
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ChildItemTypeName
        /// </summary>
        public string ChildItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }

        #endregion
    }
}
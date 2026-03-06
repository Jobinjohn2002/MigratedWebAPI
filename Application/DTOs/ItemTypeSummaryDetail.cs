using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemTypeSummaryDetail
    /// </summary>
    public class ItemTypeSummaryDetail
    {
        /// <summary>
        /// Gets or sets the itemtype id.
        /// </summary>
        /// <value>The item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Active Items Count of the Item Type.
        /// </summary>
        /// <value>The item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ActiveItemCount
        /// </summary>
        public int ActiveItemCount { get; set; }

        /// <summary>
        /// Gets or sets the Item Type Name.
        /// </summary>
        /// <value>The item type name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }

        /// <summary>
        /// gets or sets the parent item type
        /// </summary>
        public short? ParentItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Parent Item Type Name.
        /// </summary>
        /// <value>The parent item type name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ParentItemTypeName
        /// </summary>
        public string ParentItemTypeName { get; set; }
    }
}

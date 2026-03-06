using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DashboardItem
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// DashboardItem
    /// </summary>
    public class DashboardItem
    {
        /// <summary>
        /// Gets or sets the type of the synergy item.
        /// </summary>
        /// <value>The type of the synergy item.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets SynergyItemType
        /// </summary>
        public EntityType SynergyItemType { get; set; }

        /// <summary>
        /// Gets or sets the type of the item.
        /// </summary>
        /// <value>The type of the item.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Identifier
        /// </summary>
        public int Identifier { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public string ItemId { get; set; }

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
        /// Gets or sets the item description.
        /// </summary>
        /// <value>The item description.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemDescription
        /// </summary>
        public string ItemDescription { get; set; }
    }
}
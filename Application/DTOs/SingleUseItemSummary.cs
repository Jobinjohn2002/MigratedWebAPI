using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SingleUseItemSummary
    /// </summary>
    public class SingleUseItemSummary
    {
        public SingleUseItemSummary()
        { }

        public SingleUseItemSummary(ISingleUseItemSummary data)
        {
            ItemMasterId = data.ItemMasterId;
            ExternalId = data.ExternalId;
            Name = data.Name;
            ItemType = data.ItemType;
            BasePrice = data.BasePrice;
            Indexation = data.Indexation;
        }

        public SingleUseItemSummary(int itemMasterId, string externalId, string name, string itemType, decimal? basePrice, decimal? indexation)
        {
            ItemMasterId = itemMasterId;
            ExternalId = externalId;
            Name = name;
            ItemType = itemType;
            BasePrice = basePrice;
            Indexation = indexation;
        }

        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }

        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        public decimal? BasePrice { get; set; }

        public decimal? Indexation { get; set; }
    }
}

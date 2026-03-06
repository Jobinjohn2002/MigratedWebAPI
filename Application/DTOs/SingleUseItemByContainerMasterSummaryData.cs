using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SingleUseItemByContainerMasterSummaryData
    /// </summary>
    public class SingleUseItemByContainerMasterSummaryData
    {
        public SingleUseItemByContainerMasterSummaryData()
        { }

        public SingleUseItemByContainerMasterSummaryData(ISingleUseItemByContainerMasterSummary data)
        {
            ExternalId = data.ExternalId;
            Name = data.Name;
            ItemType = data.ItemType;
            Quantity = data.Quantity;
            BasePrice = data.BasePrice;
            Indexation = data.Indexation;
        }

        public SingleUseItemByContainerMasterSummaryData(string externalId, string name, string itemType, int quantity, decimal basePrice, decimal indexation)
        {
            ExternalId = externalId;
            Name = name;
            ItemType = itemType;
            Quantity = quantity;
            BasePrice = basePrice;
            Indexation = indexation;
        }
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
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets BasePrice
        /// </summary>
        public decimal BasePrice { get; set; }
        /// <summary>
        /// Gets or sets Indexation
        /// </summary>
        public decimal Indexation { get; set; }
    }
}

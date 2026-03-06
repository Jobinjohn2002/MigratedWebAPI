using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustomerItemsSummary
    /// </summary>
    public class CustomerItemsSummary
    {
        public CustomerItemsSummary()
        { }

        public CustomerItemsSummary(ICustomerItemsSummary data)
        {
            ContainerMasterDefinitionId = data.ContainerMasterDefinitionId;
            ContainerMasterId = data.ContainerMasterId;
            ExternalId = data.ExternalId;
            Name = data.Name;
            BaseType = data.BaseType;
            ItemType = data.ItemType;
            Revision = data.Revision;
            Instances = data.Instances;
            PriceCategoryName = data.PriceCategoryName;
            ReprocessingPrice = data.ReprocessingPrice;
            SingleUseItemPrice = data.SingleUseItemPrice;
            AdjustmentPrice = data.AdjustmentPrice;
            TotalPrice = data.TotalPrice;
        }

        public CustomerItemsSummary(int containerMasterDefinitionId, int containerMasterId, string externalId, string name, string baseType, string itemType, int revision,
            int instances, string priceCategoryName, decimal reprocessingPrice, decimal singleUseItemPrice, decimal adjustmentPrice, decimal totalPrice)
        {
            ContainerMasterDefinitionId = containerMasterDefinitionId;
            ContainerMasterId = containerMasterId;
            ExternalId = externalId;
            Name = name;
            BaseType = baseType;
            ItemType = itemType;
            Revision = revision;
            Instances = instances;
            PriceCategoryName = priceCategoryName;
            ReprocessingPrice = reprocessingPrice;
            SingleUseItemPrice = singleUseItemPrice;
            AdjustmentPrice = adjustmentPrice;
            TotalPrice = totalPrice;
        }

        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }

        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets BaseType
        /// </summary>
        public string BaseType { get; set; }

        /// <summary>
        /// Gets or sets ItemType
        /// </summary>
        public string ItemType { get; set; }

        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public int Revision { get; set; }

        /// <summary>
        /// Gets or sets Instances
        /// </summary>
        public int Instances { get; set; }

        /// <summary>
        /// Gets or sets FinancialComponentCount
        /// </summary>
        public int FinancialComponentCount { get; set; }

        /// <summary>
        /// Gets or sets PriceCategoryName
        /// </summary>
        public string PriceCategoryName { get; set; }

        /// <summary>
        /// Gets or sets ReprocessingPrice
        /// </summary>
        public decimal ReprocessingPrice { get; set; }

        /// <summary>
        /// Gets or sets SingleUseItemPrice
        /// </summary>
        public decimal SingleUseItemPrice { get; set; }

        /// <summary>
        /// Gets or sets AdjustmentPrice
        /// </summary>
        public decimal AdjustmentPrice { get; set; }

        /// <summary>
        /// Gets or sets TotalPrice
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}

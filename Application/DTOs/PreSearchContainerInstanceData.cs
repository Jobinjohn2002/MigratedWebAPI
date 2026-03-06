using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// PreSearchContainerInstanceData
    /// </summary>
    public class PreSearchContainerInstanceData
    {
        public PreSearchContainerInstanceData(
            int instanceId,
            string containerInstancePrimaryId,
            int itemId,
            string itemName,
            int customerId,
            string customerName,
            int legacyInternalId,
            string legacyExternalId, 
            bool isItemInstance, 
            string alternateExternalId)
        {
            InstanceId = instanceId;
            ContainerInstancePrimaryId = containerInstancePrimaryId;
            ItemId = itemId;
            ItemName = itemName;
            CustomerId = customerId;
            CustomerName = customerName;
            LegacyInternalId = legacyInternalId;
            LegacyExternalId = legacyExternalId;
            IsItemInstance = isItemInstance;
            AlternalteExternalId = alternateExternalId;
        }

        #region IStationData Members
        /// <summary>
        /// Gets or sets InstanceId
        /// </summary>
        public int InstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets LegacyInternalId
        /// </summary>
        public int LegacyInternalId { get; set; }
        /// <summary>
        /// Gets or sets LegacyExternalId
        /// </summary>
        public string LegacyExternalId { get; set; }
        /// <summary>
        /// Gets or sets IsItemInstance
        /// </summary>
        public bool IsItemInstance { get; set; }
        /// <summary>
        /// Gets or sets AlternalteExternalId
        /// </summary>
        public string AlternalteExternalId { get; set; }

        #endregion
    }
}
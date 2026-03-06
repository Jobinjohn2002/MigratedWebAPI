using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ConfirmDeliveryModel
    /// </summary>
    public class ConfirmDeliveryModel
    {
        /// <summary>
        /// Gets or sets TrolleyPrimaryId
        /// </summary>
        public string TrolleyPrimaryId { get; set; }
        public string TrolleyLabel => TrolleyPrimaryId;
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public string DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets ConfirmTrolleyId
        /// </summary>
        public string ConfirmTrolleyId { get; set; }
        /// <summary>
        /// Gets or sets isDelivered
        /// </summary>
        public bool isDelivered { get; set; }
        /// <summary>
        /// Gets or sets isParentItem
        /// </summary>
        public bool isParentItem { get; set; }

        public long? TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementText
        /// </summary>
        public string ServiceRequirementText { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeText
        /// </summary>
        public string ItemTypeText { get; set; }

        /// <summary>
        /// Gets or sets ChildContainers
        /// </summary>
        public IEnumerable<TrolleyContents> ChildContainers { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNotes
        /// </summary>
        public IEnumerable<DeliveryNoteModel> DeliveryNotes { get; set; }
    }
}
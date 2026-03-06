using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DeliveryNoteDataContract
    /// </summary>
    public class DeliveryNoteDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public int DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public int ExternalId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointRequiresProof
        /// </summary>
        public bool DeliveryPointRequiresProof { get; set; }
        /// <summary>
        /// Gets or sets IsPrinted
        /// </summary>
        public bool IsPrinted { get; set; }
        public DateTime? PrintedTimestamp { get; set; }
        /// <summary>
        /// Gets or sets ItemsCount
        /// </summary>
        public int ItemsCount { get; set; }
        /// <summary>
        /// Gets or sets FastTrackItemsCount
        /// </summary>
        public int FastTrackItemsCount { get; set; }
        public DateTime? EarliestItemExpiry { get; set; }
        public bool? IsTrolleyDeliveryNote { get; set; }

    }
}
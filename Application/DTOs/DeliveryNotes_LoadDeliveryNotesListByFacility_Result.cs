using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class DeliveryNotes_LoadDeliveryNotesListByFacility_Result
    {
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public int DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public int ExternalId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets IsTrolleyDeliveryNote
        /// </summary>
        public bool IsTrolleyDeliveryNote { get; set; }
        /// <summary>
        /// Gets or sets PhysicalCopyCreated
        /// </summary>
        public Nullable<bool> PhysicalCopyCreated { get; set; }
        public System.DateTime Printed { get; set; }
        /// <summary>
        /// Gets or sets PrintedUserId
        /// </summary>
        public int PrintedUserId { get; set; }
        public Nullable<System.DateTime> ExpectedDelivery { get; set; }
        /// <summary>
        /// Gets or sets PrintedStatus
        /// </summary>
        public bool PrintedStatus { get; set; }
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
        /// Gets or sets ItemsCount
        /// </summary>
        public short ItemsCount { get; set; }
        public Nullable<System.DateTime> EarliestItemExpiry { get; set; }
        /// <summary>
        /// Gets or sets FastTrackItemsCount
        /// </summary>
        public short FastTrackItemsCount { get; set; }
    }
}

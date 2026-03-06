using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DeliveryNoteRequestDataContract
    /// </summary>
    public class DeliveryNoteRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public int ExternalId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryNoteId
        /// </summary>
        public int DeliveryNoteId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        public int? DeliveryPointId { get; set; }
        public DateTime? SearchDate { get; set; }
    }
}
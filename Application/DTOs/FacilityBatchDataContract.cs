using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityBatchDataContract
    /// </summary>
    public class FacilityBatchDataContract
    {
        /// <summary>
        /// Gets or sets BatchId
        /// </summary>
        public int BatchId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets ItemCount
        /// </summary>
        public int ItemCount { get; set; }
        public int? FailureTypeId { get; set; }
        /// <summary>
        /// Gets or sets IsOverDue
        /// </summary>
        public bool IsOverDue { get; set; }
        /// <summary>
        /// Gets or sets ItemCountByTotal
        /// </summary>
        public string ItemCountByTotal { get; set; }
    }
}
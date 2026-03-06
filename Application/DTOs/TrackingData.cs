using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// TrackingData
    /// </summary>
    public class TrackingData
    {
        /// <summary>
        /// Gets or sets ItemExternalId
        /// </summary>
        public string ItemExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemName
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceExternalId
        /// </summary>
        public string ItemInstanceExternalId { get; set; }
        /// <summary>
        /// Gets or sets Packed
        /// </summary>
        public int Packed { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionQuantity
        /// </summary>
        public int ItemExceptionQuantity { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public string ItemExceptionReason { get; set; }
        /// <summary>
        /// Gets or sets User
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
    }
}

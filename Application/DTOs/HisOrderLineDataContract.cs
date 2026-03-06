using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HisOrderLineDataContract
    /// </summary>
    public class HisOrderLineDataContract
    {
        /// <summary>
        /// Gets or sets HisOrderLineId
        /// </summary>
        public int HisOrderLineId { get; set; }
        /// <summary>
        /// Gets or sets HisOrderId
        /// </summary>
        public int HisOrderId { get; set; }
        /// <summary>
        /// Gets or sets HisResourceCode
        /// </summary>
        public string HisResourceCode  { get; set; }
        /// <summary>
        /// Gets or sets HisResourceName
        /// </summary>
        public string HisResourceName { get; set; }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets Matched
        /// </summary>
        public bool Matched { get; set; }
        public int? HisDataCrossMatchingId { get; set; }
        /// <summary>
        /// Gets or sets OrderPlaced
        /// </summary>
        public bool OrderPlaced { get; set; }
    }
}

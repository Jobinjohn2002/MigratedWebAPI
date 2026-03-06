using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HisDataCrossMatchingDataContract
    /// </summary>
    public class HisDataCrossMatchingDataContract
    {
        /// <summary>
        /// Gets or sets HisDataCrossMatchingId
        /// </summary>
        public int HisDataCrossMatchingId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets HisDataCrossMatchType
        /// </summary>
        public HisDataCrossMatchTypeIdentifier HisDataCrossMatchType { get; set; }
        /// <summary>
        /// Gets or sets HisIdentifier
        /// </summary>
        public string HisIdentifier { get; set; }
        /// <summary>
        /// Gets or sets HisResourceName
        /// </summary>
        public string HisResourceName { get; set; }
        /// <summary>
        /// Gets or sets Ignore
        /// </summary>
        public bool Ignore { get; set; }
        public int? SynergyTrakId { get; set; }
        /// <summary>
        /// Gets or sets SynergyTrakText
        /// </summary>
        public string SynergyTrakText { get; set; }
        /// <summary>
        /// Gets or sets SynergyTrakReference
        /// </summary>
        public string SynergyTrakReference { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUserId
        /// </summary>
        public int CreatedByUserId { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets ModifiedByUserId
        /// </summary>
        public int ModifiedByUserId { get ; set; }
        /// <summary>
        /// Gets or sets ModifiedDate
        /// </summary>
        public DateTime ModifiedDate { get; set; }
        public DateTime? Archived { get ; set; }  
        public int? ArchivedUserId { get; set; }
        public int? ActiveOrdersAffected { get; set; }
        /// <summary>
        /// Gets or sets TotalRows
        /// </summary>
        public int TotalRows { get; set; }
    }
}

using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HisDataCrossMatchCommonSearchParameters
    /// </summary>
    public class HisDataCrossMatchCommonSearchParameters
    {
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; } 
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets HisResourceCode
        /// </summary>
        public string HisResourceCode { get; set; }
        /// <summary>
        /// Gets or sets HisResourceName
        /// </summary>
        public string HisResourceName { get; set; }
        public HisDataCrossMatchTypeIdentifier? CrossMatchType { get; set; }
        /// <summary>
        /// Gets or sets Skip
        /// </summary>
        public int Skip { get; set; }
        /// <summary>
        /// Gets or sets Take
        /// </summary>
        public int Take { get; set; }
        /// <summary>
        /// Gets or sets OrderDesc
        /// </summary>
        public bool OrderDesc { get; set; }
        /// <summary>
        /// Gets or sets OrderBy
        /// </summary>
        public string OrderBy { get; set; }
    }
}

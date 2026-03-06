using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HisOrderDataSearchParameters
    /// </summary>
    public class HisOrderDataSearchParameters
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets OrderRef
        /// </summary>
        public string OrderRef { get; set; }
        /// <summary>
        /// Gets or sets Customername
        /// </summary>
        public string Customername { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets Surgeon
        /// </summary>
        public string Surgeon { get; set; }
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

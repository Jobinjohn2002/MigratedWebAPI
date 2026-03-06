using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// FastTrackRequestsData
    /// </summary>
    public class FastTrackRequestsData
    {
        /// <summary>
        /// Gets or sets FastTrackRequestId
        /// </summary>
        public int FastTrackRequestId { get; set; }
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        public int? StatusId { get; set; }
        /// <summary>
        /// Gets or sets StatusName
        /// </summary>
        public string StatusName { get; set; }
        public DateTime? RequiredDate { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets RequestedBy
        /// </summary>
        public string RequestedBy { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUserId
        /// </summary>
        public int CreatedByUserId { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets TotalCount
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// Gets or sets AdditionalInformation
        /// </summary>
        public string AdditionalInformation { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets FastTrackRequestLines
        /// </summary>
        public List<FastTrackRequestLineData> FastTrackRequestLines { get; set; }
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public List<Comment> Comments { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public sealed partial class BatchData
    {
        public BatchData()
        {
        }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets NumOfTurnarounds
        /// </summary>
        public int NumOfTurnarounds { get; set; }
        public DateTime? ReleaseTime { get; set; }
        /// <summary>
        /// Gets or sets ReleaseUser
        /// </summary>
        public string ReleaseUser { get; set; }
        /// <summary>
        /// Gets or sets ReleaseUserId
        /// </summary>
        public int ReleaseUserId { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public List<CommentData> Comments { get; set; }
        /// <summary>
        /// Gets or sets CycleTypeText
        /// </summary>
        public string CycleTypeText { get; set; }
        /// <summary>
        /// Gets or sets IsChargeable
        /// </summary>
        public bool IsChargeable { get; set; }
        /// <summary>
        /// Gets or sets IsSteriliser
        /// </summary>
        public bool IsSteriliser { get; set; }
        /// <summary>
        /// Gets or sets IsAer
        /// </summary>
        public bool IsAer { get; set; }
        public int? ItemCount { get; set; }
        /// <summary>
        /// Gets or sets BatchStatusText
        /// </summary>
        public string BatchStatusText { get; set; }
        /// <summary>
        /// Gets or sets BatchFailureReasonText
        /// </summary>
        public string BatchFailureReasonText { get; set; }
        /// <summary>
        /// Gets or sets BatchReleasedBy
        /// </summary>
        public string BatchReleasedBy { get; set; }
        /// <summary>
        /// Gets or sets ArchivedUserName
        /// </summary>
        public string ArchivedUserName { get; set; }
        /// <summary>
        /// Gets or sets ArchivedReason
        /// </summary>
        public string ArchivedReason { get; set; }
        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public int MachineTypeId { get; set; }
        /// <summary>
        /// Gets or sets FirstItemScannedOut
        /// </summary>
        public string FirstItemScannedOut { get; set; }
        public DateTime? FirstItemScannedOutDate { get; set; }
        /// <summary>
        /// Gets or sets ItemsPassed
        /// </summary>
        public int ItemsPassed { get; set; }
        /// <summary>
        /// Gets or sets ItemsFailed
        /// </summary>
        public int ItemsFailed { get; set; }
        /// <summary>
        /// Gets or sets TotalItem
        /// </summary>
        public int TotalItem { get; set; }
        /// <summary>
        /// Gets or sets NumOfFastTrack
        /// </summary>
        public int NumOfFastTrack { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public string ServiceRequirement { get; set; }
    }

}

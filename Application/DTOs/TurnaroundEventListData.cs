using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundEventListData
    /// </summary>
    public class TurnaroundEventListData
    {
        public TurnaroundEventListData(ITurnaroundEventList data)
        {
            TurnaroundEventId = data.TurnaroundEventId;
            TurnaroundEventTypeId = data.TurnaroundEventTypeId;
            TurnaroundEventType = data.TurnaroundEventType;
            Created = data.Created;
			CreatedUserId = data.CreatedUserId;
            CreatedUser = data.CreatedUser;
            AdditionalInfo = data.AdditionalInfo;
            AdditionalInfoExtended = data.AdditionalInfoExtended;
            AdditionalInfoFields = new Dictionary<string, string>(data.AdditionalInfoFields);
            BatchId = data.BatchId;
            ComplianceReason = data.ComplianceReason;
            TurnaroundEnded = data.TurnaroundEnded;
            QuarantineReasonId = data.QuarantineReasonId;
            NextEventTypeId = data.NextEventTypeId;
            IsProcessEvent = data.IsProcessEvent;
            FacilityName = data.FacilityName;
            FacilityId = data.FacilityId;
        }

        public TurnaroundEventListData(int turnaroundEventId, short turnaroundEventTypeId, string turnaroundEventType, DateTime created, int createdUserId, string createdUser, string additionalInfo, string additionalInfoExtended, int? batchId,  string complianceReason, bool turnaroundEnded = false)
        {
			TurnaroundEventId = turnaroundEventId;
            TurnaroundEventTypeId = turnaroundEventTypeId;
            TurnaroundEventType = turnaroundEventType;
            Created = created;
			CreatedUserId = createdUserId;
            CreatedUser = createdUser;
            AdditionalInfo = additionalInfo;
            AdditionalInfoExtended = additionalInfoExtended;
            BatchId = batchId;
            ComplianceReason = complianceReason;
            TurnaroundEnded = turnaroundEnded;
        }

        public TurnaroundEventListData()
        { }
        /// <summary>
        /// Gets or sets AdditionalInfoFields
        /// </summary>
        public Dictionary<string, string> AdditionalInfoFields { get; set; } = new Dictionary<string, string>();
		/// <summary>
		/// Gets or sets TurnaroundEventId
		/// </summary>
		public int TurnaroundEventId { get; set; }
		/// <summary>
		/// Gets or sets CreatedUserId
		/// </summary>
		public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventUid
        /// </summary>
        public Guid TurnaroundEventUid { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventTypeId
        /// </summary>
        public short TurnaroundEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEventType
        /// </summary>
        public string TurnaroundEventType { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserUid
        /// </summary>
        public Guid CreatedUserUid { get; set; }
        /// <summary>
        /// Gets or sets CreatedUser
        /// </summary>
        public string CreatedUser { get; set; }
        /// <summary>
        /// Gets or sets AdditionalInfo
        /// </summary>
        public string AdditionalInfo { get; set; }
        /// <summary>
        /// Gets or sets AdditionalInfoExtended
        /// </summary>
        public string AdditionalInfoExtended { get; set; }
        public int? BatchId { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }
        /// <summary>
        /// Gets or sets ProcessEvent
        /// </summary>
        public bool ProcessEvent { get; set; }
        /// <summary>
        /// Gets or sets ComplianceReason
        /// </summary>
        public string ComplianceReason { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundEnded
        /// </summary>
        public bool TurnaroundEnded { get; set; }
        /// <summary>
        /// Gets or sets QuarantineReasonId
        /// </summary>
        public short QuarantineReasonId { get; set; }
        public int? NextEventTypeId { get; set; }
        public bool? IsProcessEvent { get; set; }

        /// <summary>
        /// Gets or sets the Facility Name
        /// </summary>
        /// <value>OrderNumber</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets the Facility Id
        /// </summary>
        /// <value>OrderNumber</value>
        /// <remarks></remarks>
        public int? FacilityId { get; set; } 
    }
}

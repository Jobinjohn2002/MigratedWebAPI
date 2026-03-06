using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// BaseReplyDataContract
    /// </summary>
    public class BaseReplyDataContract
    {
        [IgnoreDataMember]
        private DateTime _utcNow = DateTime.UtcNow;

        [NonSerialized]
        [IgnoreDataMember]
        private ExtensionDataObject extensionData;

        [IgnoreDataMember]
        public ExtensionDataObject ExtensionData
        {
            get { return extensionData; }
            set { extensionData = value; }
        }
        public int? ErrorCode { get; set; }
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets InternalMessage
        /// </summary>
        public string InternalMessage { get; set; }
        /// <summary>
        /// Gets or sets OperationDurationMs
        /// </summary>
        public long OperationDurationMs { get; set; }
        /// <summary>
        /// Gets or sets DataSizeBytes
        /// </summary>
        public long DataSizeBytes { get; set; }
        public DateTime UtcNow 
        {
            get
            {
                return DateTime.SpecifyKind(_utcNow, DateTimeKind.Utc);
            }
            set
            {
                _utcNow = value;
            }
        }
        /// <summary>
        /// Gets or sets Hash
        /// </summary>
        public string Hash { get; set; }
        /// <summary>
        /// Gets or sets Reports
        /// </summary>
        public List<ReportDataContract> Reports { get; set; }
        /// <summary>
        /// Gets or sets NotificationTypesFired
        /// </summary>
        public List<CommunicationTypeIdentifier> NotificationTypesFired { get; set; }
        /// <summary>
        /// Gets or sets Labels
        /// </summary>
        public List<TurnaroundLabelDataContract> Labels { get; set; }
        /// <summary>
        /// Gets or sets NotificationLabels
        /// </summary>
        public List<TurnaroundLabelDataContract> NotificationLabels { get; set; }
        public ApplicationType? ApplicationType { get; set; }
    }
}
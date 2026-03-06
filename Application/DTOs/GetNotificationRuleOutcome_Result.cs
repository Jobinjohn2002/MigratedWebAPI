using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class GetNotificationRuleOutcome_Result
    {
        /// <summary>
        /// Gets or sets NotificationRuleId
        /// </summary>
        public int NotificationRuleId { get; set; }
        /// <summary>
        /// Gets or sets NotificationOutputId
        /// </summary>
        public int NotificationOutputId { get; set; }
        /// <summary>
        /// Gets or sets PrintContentTypeId
        /// </summary>
        public int PrintContentTypeId { get; set; }
        /// <summary>
        /// Gets or sets PerBatch
        /// </summary>
        public bool PerBatch { get; set; }
        /// <summary>
        /// Gets or sets PreviouslyProcessedBatch
        /// </summary>
        public Nullable<bool> PreviouslyProcessedBatch { get; set; }
        /// <summary>
        /// Gets or sets OutputTypeId
        /// </summary>
        public byte OutputTypeId { get; set; }
        /// <summary>
        /// Gets or sets CommunicationTypeId
        /// </summary>
        public short CommunicationTypeId { get; set; }
        /// <summary>
        /// Gets or sets RecipientTypeId
        /// </summary>
        public short RecipientTypeId { get; set; }
        /// <summary>
        /// Gets or sets NumberOfCopies
        /// </summary>
        public short NumberOfCopies { get; set; }
        /// <summary>
        /// Gets or sets ReportPath
        /// </summary>
        public string ReportPath { get; set; }
        /// <summary>
        /// Gets or sets LblTemplateId
        /// </summary>
        public Nullable<byte> LblTemplateId { get; set; }
        /// <summary>
        /// Gets or sets LblDataId
        /// </summary>
        public Nullable<byte> LblDataId { get; set; }
        /// <summary>
        /// Gets or sets SecondLblTemplateId
        /// </summary>
        public Nullable<byte> SecondLblTemplateId { get; set; }
        /// <summary>
        /// Gets or sets SecondLblDataId
        /// </summary>
        public Nullable<byte> SecondLblDataId { get; set; }
        /// <summary>
        /// Gets or sets CanProcess
        /// </summary>
        public bool CanProcess { get; set; }
        /// <summary>
        /// Gets or sets Reprintable
        /// </summary>
        public bool Reprintable { get; set; }
    }
}

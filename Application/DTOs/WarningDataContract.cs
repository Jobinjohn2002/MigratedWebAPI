using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// WarningDataContract
    /// </summary>
    public class WarningDataContract : BaseReplyDataContract
    {
        public long? TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets MasterName
        /// </summary>
        public string MasterName { get; set; }
        /// <summary>
        /// Gets or sets WarningId
        /// </summary>
        public int WarningId { get; set; }
        public int? TurnaroundLeadIn { get; set; }
        public int? LeadInDays { get; set; }
        public int? MaximumDays { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets WarningOnly
        /// </summary>
        public bool WarningOnly { get; set; }
        public int? MaximumTurnarounds { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundWarningCount
        /// </summary>
        public int TurnaroundWarningCount { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets IsComponent
        /// </summary>
        public bool IsComponent { get; set; }
    }
}
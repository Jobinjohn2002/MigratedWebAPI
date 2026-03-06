using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// MFPProductionOverviewData
    /// </summary>
    public class MFPProductionOverviewData
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public int EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }
        /// <summary>
        /// Gets or sets AnyOverdue
        /// </summary>
        public int AnyOverdue { get; set; }
    }
}

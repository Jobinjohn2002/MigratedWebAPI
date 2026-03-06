using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TrolleyDispatchTrolleySummaryDataContract
    /// </summary>
    public class TrolleyDispatchTrolleySummaryDataContract
    {
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public List<string> DeliveryPoints { get; set; }
        /// <summary>
        /// Gets or sets TotalItemCount
        /// </summary>
        public int TotalItemCount { get; set; }
        /// <summary>
        /// Gets or sets FastTrackCount
        /// </summary>
        public int FastTrackCount { get; set; }
        /// <summary>
        /// Gets or sets OverdueCount
        /// </summary>
        public int OverdueCount { get; set; }
        /// <summary>
        /// Gets or sets ExpiringSoonCount
        /// </summary>
        public int ExpiringSoonCount { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementText
        /// </summary>
        public string ServiceRequirementText { get; set; }
        public DateTime? ExpiryDate { get; set; }
        /// <summary>
        /// Gets or sets HasIncompleteLoanSet
        /// </summary>
        public bool HasIncompleteLoanSet { get; set; }
    }
}

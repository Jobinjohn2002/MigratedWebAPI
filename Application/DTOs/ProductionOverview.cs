using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProductionOverview
    /// </summary>
    public class ProductionOverview
    {

        public ProductionOverview(int lastEventTypeId, string lastEventName, string serviceRequirementName, int countOfItems)
        {
            LastEventTypeId = lastEventTypeId;
            LastEventName = lastEventName;
            ServiceRequirementName = serviceRequirementName;
            CountOfItems = countOfItems;
        }

        /// <summary>
        /// Gets or sets LastEventTypeId
        /// </summary>
        public int LastEventTypeId { get; set; }
        /// <summary>
        /// Gets or sets LastEventName
        /// </summary>
        public string LastEventName { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementName
        /// </summary>
        public string ServiceRequirementName { get; set; }
        /// <summary>
        /// Gets or sets CountOfItems
        /// </summary>
        public int CountOfItems { get; set; }
    }
}

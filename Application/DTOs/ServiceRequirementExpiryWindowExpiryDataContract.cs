using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ServiceRequirementExpiryWindowExpiryDataContract
    /// </summary>
    public class ServiceRequirementExpiryWindowExpiryDataContract
    {
        /// <summary>
        /// Gets or sets CustomerDefintionId
        /// </summary>
        public int CustomerDefintionId { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirementId
        /// </summary>
        public int ServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets DayOfWeek
        /// </summary>
        public byte DayOfWeek { get; set; }
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public TimeSpan Expiry { get; set; }
    }
}

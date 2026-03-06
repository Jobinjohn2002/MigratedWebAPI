using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    ///  Service Requirement Calculation Compound Type
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// ServiceRequirementExpiry
    /// </summary>
    public class ServiceRequirementExpiry
    {
        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>The expiry.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Expiry
        /// </summary>
        public DateTime Expiry { get; set; }

    }
}

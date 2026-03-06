using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// Service Requirement Expiry Interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IServiceRequirementExpiry
    /// </summary>
    public interface IServiceRequirementExpiry
    {
        /// <summary>
        /// Gets or sets the expiry.
        /// </summary>
        /// <value>The expiry.</value>
        /// <remarks></remarks>
        DateTime Expiry { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IServiceRequirementDetail
    /// </summary>
    public interface IServiceRequirementDetail
    {
        /// <summary>
        /// Gets or sets the service requirement id.
        /// </summary>
        /// <value>The service requirement id.</value>
        /// <remarks></remarks>
        int ServiceRequirementId { get; set; }

        /// <summary>
        /// Gets or sets the name of the service requirement.
        /// </summary>
        /// <value>The name of the service requirement.</value>
        /// <remarks></remarks>
        string ServiceRequirementName { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        /// <remarks></remarks>
        int Items { get; set; }

        /// <summary>
        /// Gets or sets the items overdue.
        /// </summary>
        /// <value>The items overdue.</value>
        /// <remarks></remarks>
        int ItemsOverdue { get; set; }
    }
}
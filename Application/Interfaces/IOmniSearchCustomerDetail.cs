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
    /// IOmniSearchCustomerDetail
    /// </summary>
    public interface IOmniSearchCustomerDetail
    {
        /// <summary>
        /// Gets or sets the customer uid.
        /// </summary>
        /// <value>The customer uid.</value>
        /// <remarks></remarks>
        int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the customer uid.
        /// </summary>
        /// <value>The customer uid.</value>
        /// <remarks></remarks>
        int CustomerStatusId { get; set; }

        /// <summary>
        /// Gets or sets the customer uid.
        /// </summary>
        /// <value>The customer uid.</value>
        /// <remarks></remarks>
        string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        int Revision { get; set; }
        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>The created.</value>
        /// <remarks></remarks>
        DateTime Created { get; set; }      
        /// <summary>
        /// Gets or sets the facility.
        /// </summary>
        /// <value>The facility.</value>
        /// <remarks></remarks>
        string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets the facility uid.
        /// </summary>
        /// <value>The facility uid.</value>
        /// <remarks></remarks>
        short FacilityId { get; set; }

        /// <summary>
        /// Gets or sets the facility.
        /// </summary>
        /// <value>The facility.</value>
        /// <remarks></remarks>
        string CustomerGroupName { get; set; }

        /// <summary>
        /// Gets or sets the facility uid.
        /// </summary>
        /// <value>The facility uid.</value>
        /// <remarks></remarks>
        int? CustomerGroupId { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        bool IsArchived { get; set; }
    }
}

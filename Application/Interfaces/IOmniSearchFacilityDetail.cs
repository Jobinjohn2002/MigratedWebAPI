using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// OmniSearchFacilityDetail interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IOmniSearchFacilityDetail
    /// </summary>
    public interface IOmniSearchFacilityDetail
    {
        /// <summary>
        /// Gets or sets the facility uid.
        /// </summary>
        /// <value>The facility uid.</value>
        /// <remarks></remarks>
        short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        string Name { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        bool IsArchived { get; set; }
    }
}

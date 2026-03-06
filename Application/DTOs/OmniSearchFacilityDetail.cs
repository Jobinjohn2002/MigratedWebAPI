using SynergyApplicationFrameworkApi.Application.DTOs.Interfaces.Operative.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Omni Search Facility details custom type.
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// OmniSearchFacilityDetail
    /// </summary>
    public class OmniSearchFacilityDetail
    {
        /// <summary>
        /// Initialize the new instance of class.
        /// </summary>
        /// <remarks></remarks>
        public OmniSearchFacilityDetail()
        {
        }

        /// <summary>
        /// Initialize the new instance of class.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="name">The name.</param>
        /// <param name="isArchived"></param>
        /// <remarks></remarks>
        public OmniSearchFacilityDetail(short facilityId, string name)
        {
            FacilityId = facilityId;
            Name = name;
        }

        /// <summary>
        /// Initialize the new instance of class.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="name">The name.</param>
        /// <param name="isArchived"></param>
        /// <remarks></remarks>
        public OmniSearchFacilityDetail(short facilityId, string name, bool isArchived)
        {
            FacilityId = facilityId;
            Name = name;
            IsArchived = isArchived;
        }

        /// <summary>
        /// Gets or sets the index id.
        /// </summary>
        /// <value>The index id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IndexId
        /// </summary>
        public int IndexId { get; set; }

        #region IOmniSearchFacilityDetail Members

        /// <summary>
        /// Gets or sets the facility uid.
        /// </summary>
        /// <value>The facility uid.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets the is Archived record flag.
        /// </summary>
        /// <summary>
        /// Gets or sets IsArchived
        /// </summary>
        public bool IsArchived { get; set; }

        #endregion
    }
}
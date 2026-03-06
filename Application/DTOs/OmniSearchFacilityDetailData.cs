using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OmniSearchFacilityDetailData
    /// </summary>
    public class OmniSearchFacilityDetailData
    {
        /// <summary>
        /// Initialize the new instance of class.
        /// </summary>
        /// <remarks></remarks>
        public OmniSearchFacilityDetailData()
        {

        }

        /// <summary>
        /// Initialize the new instance of class.
        /// </summary>
        /// <param name="facilityId">The facility uid.</param>
        /// <param name="name">The name.</param>
        /// <param name="isArchived"></param>
        /// <remarks></remarks>
        public OmniSearchFacilityDetailData(short facilityId, string name, bool isArchived)
        {
            FacilityId = facilityId;
            Name = name;
            IsArchived = isArchived;
        }

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
    }
}

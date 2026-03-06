using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopyLocationDataContract
    /// </summary>
    public class EndoscopyLocationDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets DryingCabinets
        /// </summary>
        public List<EndoscopyDryingCabinetDataContract> DryingCabinets { get; set; }
        /// <summary>
        /// Gets or sets VacPacks
        /// </summary>
        public List<EndoscopeDataContract> VacPacks { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public LocationDataContract Location { get; set; }
        public int? ParentStationExpiredCount { get; set; }
        public int? ParentStationAlmostExpiredCount { get; set; }
        /// <summary>
        /// Gets or sets IsHomeLocation
        /// </summary>
        public bool IsHomeLocation { get; set; }
        /// <summary>
        /// Gets or sets VacPacksAreVisible
        /// </summary>
        public bool VacPacksAreVisible { get; set; } = true;
    }
}

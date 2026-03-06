using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopyStationDataContract
    /// </summary>
    public class EndoscopyStationDataContract : BaseReplyDataContract
    {

        /// <summary>
        /// Gets or sets Locations
        /// </summary>
        public List<EndoscopyLocationDataContract> Locations { get; set; }

        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }
    }
}

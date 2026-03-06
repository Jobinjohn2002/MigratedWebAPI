using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LocationsDataContract
    /// </summary>
    public class LocationsDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Locations
        /// </summary>
        public List<LocationDataContract> Locations { get; set; }
    }
}
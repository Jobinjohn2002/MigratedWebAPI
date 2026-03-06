using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Describes a location, e.g. a delivery point we ship finished product to.
    /// </summary>
    /// <summary>
    /// LocationInfo
    /// </summary>
    public class LocationInfo
    {
        /// <summary>
        /// The name of the location name, e.g. the name of the delivery point at the hospital.
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The name of the hospital this location is associated to.
        /// </summary>
        /// <summary>
        /// Gets or sets Hospital
        /// </summary>
        public string Hospital { get; set; }
    }
}
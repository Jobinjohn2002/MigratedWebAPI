using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DryingCabinetShelfLocationDataContract
    /// </summary>
    public class DryingCabinetShelfLocationDataContract 
    {
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public LocationDataContract Location { get; set; }
        public EndoscopeDataContract Endoscope{ get; set; }

    }
}

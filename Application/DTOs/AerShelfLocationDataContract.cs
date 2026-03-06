using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AerShelfLocationDataContract
    /// </summary>
    public class AerShelfLocationDataContract : LocationDataContract
    {
        /// <summary>
        /// Gets or sets Endoscopes
        /// </summary>
        public List<EndoscopeDataContract> Endoscopes { get; set; }
    }
}

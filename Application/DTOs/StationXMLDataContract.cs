using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StationXMLDataContract
    /// </summary>
    public class StationXMLDataContract
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets XML
        /// </summary>
        public string XML { get; set; }
    }
}

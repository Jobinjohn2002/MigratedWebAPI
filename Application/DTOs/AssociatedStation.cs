using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AssociatedStation
    /// </summary>
    public class AssociatedStation
    {
        /// <summary>
        /// Gets or sets StationId
        /// </summary>
        public int StationId { get; set; }
        public StationTypeCategoryIdentifier StationCategory {get;set;}
    }
}

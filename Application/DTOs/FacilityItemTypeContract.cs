using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class FacilityItemTypeContract
    {
        public bool? Selected { get; set; }
        public int? ExpiryDays { get; set; }
        /// <summary>
        /// Gets or sets IsComponent
        /// </summary>
        public bool IsComponent { get; set; }
        
    }
}

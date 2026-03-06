using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SelectedFacilityDataContract
    /// </summary>
    public class SelectedFacilityDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets SelectedFacilityId
        /// </summary>
        public int SelectedFacilityId { get; set; }
    }
}
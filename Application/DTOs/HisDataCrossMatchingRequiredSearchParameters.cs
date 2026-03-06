using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// HisDataCrossMatchingRequiredSearchParameters
    /// </summary>
    public class HisDataCrossMatchingRequiredSearchParameters : HisDataCrossMatchCommonSearchParameters
    {        
        /// <summary>
        /// Gets or sets Procedures
        /// </summary>
        public string Procedures { get; set; }
        /// <summary>
        /// Gets or sets Surgeons
        /// </summary>
        public string Surgeons { get; set; }
        public DateTime? EarliestRequiredDate { get; set; }
    }
}

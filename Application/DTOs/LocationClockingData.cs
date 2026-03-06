using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
   /// <summary>
   /// LocationClockingData
   /// </summary>
   public class LocationClockingData: DataContractBase
    {
        /// <summary>
        /// Gets or sets TotalUsers
        /// </summary>
        public int TotalUsers { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets LocationName
        /// </summary>
        public string LocationName { get; set; }
    }
}

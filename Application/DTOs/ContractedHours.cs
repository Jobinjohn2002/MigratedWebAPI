using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class ContractedHours
    {
        /// <summary>
        /// Gets or sets ContractedHoursId
        /// </summary>
        public int ContractedHoursId { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets DayOfWeek
        /// </summary>
        public short DayOfWeek { get; set; }
        /// <summary>
        /// Gets or sets Opening
        /// </summary>
        public short Opening { get; set; }
        /// <summary>
        /// Gets or sets Closing
        /// </summary>
        public short Closing { get; set; }
        /// <summary>
        /// Gets or sets Closed
        /// </summary>
        public bool Closed { get; set; }
        /// <summary>
        /// Gets or sets LegacyFacilityOrigin
        /// </summary>
        public Nullable<int> LegacyFacilityOrigin { get; set; }
        public Nullable<System.DateTime> LegacyImported { get; set; }
    
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public virtual Customer Customer { get; set; }
    }
}

using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilitiesDataContract
    /// </summary>
    public class FacilitiesDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets Facilities
        /// </summary>
        public List<FacilityDataContract> Facilities { get; set; }
        /// <summary>
        /// Gets or sets MultiProcessingFacilities
        /// </summary>
        public List<int> MultiProcessingFacilities { get; set; }
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public List<CustomerDataContract> Customers { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirements
        /// </summary>
        public List<ServiceRequirementDataContract> ServiceRequirements { get; set; }
        /// <summary>
        /// Gets or sets FacilityDateTimeFormats
        /// </summary>
        public DateTimeFormatDataContract FacilityDateTimeFormats { get; set; }
        /// <summary>
        /// Gets or sets StationTypes
        /// </summary>
        public List<StationDataContract> StationTypes { get; set; }
    }
}
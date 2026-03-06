using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Dynamic data that needs refreshing periodically
    /// </summary>
    /// <summary>
    /// DynamicDataDataContract
    /// </summary>
    public class DynamicDataDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets LastRetrieved
        /// </summary>
        public DateTime LastRetrieved { get; set; }
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public List<CustomerDataContract> Customers { get; set; }
        /// <summary>
        /// Gets or sets Facilities
        /// </summary>
        public List<FacilityDataContract> Facilities { get; set; }
        /// <summary>
        /// Gets or sets PrimaryFacility
        /// </summary>
        public FacilityDataContract PrimaryFacility { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirements
        /// </summary>
        public List<ServiceRequirementDataContract> ServiceRequirements { get; set; }
        /// <summary>
        /// Gets or sets Machines
        /// </summary>
        public List<MachineDataContract> Machines { get; set; }
        /// <summary>
        /// Gets or sets StationTypes
        /// </summary>
        public List<StationDataContract> StationTypes { get; set; }
        /// <summary>
        /// Gets or sets ServerUtcTime
        /// </summary>
        public DateTime ServerUtcTime { get; set; }
        /// <summary>
        /// Gets or sets Printers
        /// </summary>
        public List<PrinterDataContract> Printers { get; set; }
        /// <summary>
        /// Gets or sets MultiProcessingFacilities
        /// </summary>
        public List<FacilityDataContract> MultiProcessingFacilities { get; set; }
        /// <summary>
        /// Gets or sets Settings
        /// </summary>
        public List<SettingDataContract> Settings { get; set; }
        public int? StationLocationId { get; set; }
        /// <summary>
        /// Gets or sets FacilityStationLocationTrees
        /// </summary>
        public List<LocationDataContract> FacilityStationLocationTrees { get; set; }
        /// <summary>
        /// Gets or sets IsDeconStationUsed
        /// </summary>
        public bool IsDeconStationUsed { get; set; }
        /// <summary>
        /// Gets or sets FacilitiesEndoscopes
        /// </summary>
        public List<BasicContainerInstanceDataContract> FacilitiesEndoscopes { get; set; }

    }
}
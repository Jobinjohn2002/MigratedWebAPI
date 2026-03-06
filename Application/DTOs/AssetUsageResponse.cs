using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AssetUsageResponse
    /// </summary>
    public class AssetUsageResponse
    {
        /// <summary>
        /// The list of asset usages
        /// </summary>
        /// <summary>
        /// Gets or sets Assets
        /// </summary>
        public List<AssetUsageInfo> Assets { get; set; }

        /// <summary>
        /// The list of asset that were not found
        /// </summary>
        /// <summary>
        /// Gets or sets AssetsNotFound
        /// </summary>
        public IEnumerable<string> AssetsNotFound { get; set; } // not sure on this, but for now
    }

    /// <summary>
    /// AssetUsageInfo
    /// </summary>
    public class AssetUsageInfo
    {
        /// <summary>
        /// [Reserved] - for future use (to uniquely identify the asset) - please refer to the Identifiers property which includes all identifiers for the Asset)
        /// </summary>
        /// <summary>
        /// Gets or sets AssetNumber
        /// </summary>
        public string AssetNumber { get; set; }

        /// <summary>
        /// The date the asset was last used
        /// </summary>
        public DateTime? LastSterilizationDate { get; set; }

        /// <summary>
        /// The current turnarounds service requirement fast track status
        /// </summary>
        /// <summary>
        /// Gets or sets CurrentServiceRequirementFastTrack
        /// </summary>
        public bool CurrentServiceRequirementFastTrack { get; set; }

        /// <summary>
        /// The assets default service requirement fast track status
        /// </summary>
        /// <summary>
        /// Gets or sets DefaultServiceRequirementFastTrack
        /// </summary>
        public bool DefaultServiceRequirementFastTrack { get; set; }

        /// <summary>
        /// The date a maintenance report was raised against the asset since the specified usage date
        /// </summary>
        public DateTime? MaintenanceReportRaised { get; set; }

        /// <summary>
        /// The number of times the assets was used since the specified usage date
        /// </summary>
        /// <summary>
        /// Gets or sets RecentUsages
        /// </summary>
        public int RecentUsages { get; set; }

        /// <summary>
        /// The total number of times the asset has been used
        /// </summary>
        /// <summary>
        /// Gets or sets TotalUsages
        /// </summary>
        public int TotalUsages { get; set; }

        /// <summary>
        /// The facility the asset is being processed by
        /// </summary>
        /// <summary>
        /// Gets or sets Facility
        /// </summary>
        public string Facility { get; set; }

        /// <summary>
        /// The current location (event) of the asset
        /// </summary>
        /// <summary>
        /// Gets or sets CurrentLocation
        /// </summary>
        public string CurrentLocation { get; set; }

        /// <summary>
        /// Shows whether a request for Maintenance is still outstanding
        /// </summary>
        /// <summary>
        /// Gets or sets ScheduledForMaintenance
        /// </summary>
        public bool ScheduledForMaintenance { get; internal set; }
    }
}

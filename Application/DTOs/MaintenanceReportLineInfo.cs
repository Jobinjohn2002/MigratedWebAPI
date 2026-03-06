using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Maintenance Report Line Info.
    /// </summary>
    /// <summary>
    /// MaintenanceReportLineInfo
    /// </summary>
    public class MaintenanceReportLineInfo
    {
        /// <summary>
        /// The product number.
        /// </summary>
        /// <summary>
        /// Gets or sets ProductNumber
        /// </summary>
        public string ProductNumber { get; set; }
        /// <summary>
        /// The product name.
        /// </summary>
        /// <summary>
        /// Gets or sets ProductName
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// The asset number.
        /// </summary>
        /// <summary>
        /// Gets or sets AssetNumber
        /// </summary>
        public string AssetNumber { get; set; }
        /// <summary>
        /// The maintenance activity code.
        /// </summary>
        /// <summary>
        /// Gets or sets ActivityCode
        /// </summary>
        public string ActivityCode { get; set; }
        /// <summary>
        /// The maintenance activity name.
        /// </summary>
        /// <summary>
        /// Gets or sets ActivityName
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// The replacement asset number.
        /// </summary>
        /// <summary>
        /// Gets or sets ReplacementAssetNumber
        /// </summary>
        public string ReplacementAssetNumber { get; set; }
        /// <summary>
        /// The maintenance line status.
        /// </summary>
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
    }
}
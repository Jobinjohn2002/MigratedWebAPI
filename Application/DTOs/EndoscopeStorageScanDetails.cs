using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopeStorageScanDetails
    /// </summary>
    public class EndoscopeStorageScanDetails : ScanDetails
    {
        /// <summary>
        /// Gets or sets StorageLocationId
        /// </summary>
        public int StorageLocationId { get; set; }
        /// <summary>
        /// Gets or sets SelectedVisibleLocationId
        /// </summary>
        public int SelectedVisibleLocationId { get; set; }
        /// <summary>
        /// Gets or sets UserBadge
        /// </summary>
        public string UserBadge { get; set; }
    }
}

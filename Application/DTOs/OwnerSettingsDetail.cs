using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// OwnerSettingsDetail
    /// </summary>
    public class OwnerSettingsDetail
    {
        /// <summary>
        /// Gets or sets OwnerId
        /// </summary>
        public int OwnerId { get; set; }
        /// <summary>
        /// Gets or sets Facilities
        /// </summary>
        public string Facilities { get; set; }
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public string Customers { get; set; }
        /// <summary>
        /// Gets or sets Settings
        /// </summary>
        public TableModel Settings { get; set; }
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public SettingsConfirmation Confirmation { get; set; }
    }
}
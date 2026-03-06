using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DeliveryPointSettingsDetail
    /// </summary>
    public class DeliveryPointSettingsDetail
    {
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }
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
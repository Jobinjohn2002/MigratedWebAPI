using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// CustSettingsDetail
    /// </summary>
    public class CustSettingsDetail
    {
        /// <summary>
        /// Gets or sets CustomerDefinitionID
        /// </summary>
        public int CustomerDefinitionID { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
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
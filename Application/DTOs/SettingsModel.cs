using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum SettingsConfirmation : byte
    {
        None = 0,
        Synchronised = 1,
        Deleted = 2,
        Saved = 3,
        Duplicate = 4
    }

    /// <summary>
    /// SettingsModel
    /// </summary>
    public class SettingsModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public SettingsConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets Settings
        /// </summary>
        public TableModel Settings { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum StoragePointModelTab
    {
        Details = 0,
        Stock = 1
    }

    /// <summary>
    /// StoragePointDetailsModel
    /// </summary>
    public class StoragePointDetailsModel
    {
        /// <summary>
        /// Gets or sets SelectedTab
        /// </summary>
        public StoragePointModelTab SelectedTab { get; set; }
        /// <summary>
        /// Gets or sets StoragePoint
        /// </summary>
        public StoragePoint StoragePoint { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public Location Location { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public Customer Customer { get; set; }
        /// <summary>
        /// Gets or sets AccessibleData
        /// </summary>
        public GroupedRowTableModel AccessibleData { get; set; }
        /// <summary>
        /// Gets or sets ReadonlyData
        /// </summary>
        public GroupedRowTableModel ReadonlyData { get; set; }
        /// <summary>
        /// Gets or sets Saved
        /// </summary>
        public bool Saved { get; set; }
        /// <summary>
        /// Gets or sets Updated
        /// </summary>
        public bool Updated { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// Gets or sets UsagePoint
        /// </summary>
        public bool UsagePoint { get; set; }
    }
}
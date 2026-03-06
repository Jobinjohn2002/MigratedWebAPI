using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StoragePointCreateModel
    /// </summary>
    public class StoragePointCreateModel
    {
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public IEnumerable<SelectListItem> Customers { get; set; }

        [SmartPropertyValidation]
        public int? CustomerDefinitionID { get; set; }
        
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

        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemMasterSummary
    /// </summary>
    public class ItemMasterSummary
    {
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemDescription
        /// </summary>
        public string ItemDescription { get; set; }
        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public int Revision { get; set; }
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Gets or sets BatchCycle
        /// </summary>
        public string BatchCycle { get; set; }
        /// <summary>
        /// Gets or sets Speciality
        /// </summary>
        public string Speciality { get; set; }
    }
}

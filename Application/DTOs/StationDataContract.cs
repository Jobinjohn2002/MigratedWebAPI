using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// StationDataContract
    /// </summary>
    public class StationDataContract
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets DisplayOrder
        /// </summary>
        public int DisplayOrder { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets Logon
        /// </summary>
        public string Logon { get; set; }
        /// <summary>
        /// Gets or sets Location
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// Gets or sets LocationCode
        /// </summary>
        public string LocationCode { get; set; }
        /// <summary>
        /// Gets or sets Culture
        /// </summary>
        public string Culture { get; set; }
        /// <summary>
        /// Gets or sets AllowAssignNotes
        /// </summary>
        public bool AllowAssignNotes { get; set; }
        /// <summary>
        /// Gets or sets StationCategory
        /// </summary>
        public StationTypeCategoryIdentifier StationCategory { get; set; }
    }
}
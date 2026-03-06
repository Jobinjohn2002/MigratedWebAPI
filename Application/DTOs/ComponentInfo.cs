using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Component Info.
    /// </summary>
    /// <summary>
    /// ComponentInfo
    /// </summary>
    public class ComponentInfo
    {
        /// <summary>
        /// The component identifiers.
        /// </summary>
        /// <summary>
        /// Gets or sets Identifiers
        /// </summary>
        public List<Identifier> Identifiers { get; set; }
        
        /// <summary>
        /// The component name.
        /// </summary>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The component category.
        /// </summary>
        /// <summary>
        /// Gets or sets Category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The item definition identifier.
        /// </summary>
        public int? ItemMasterDefinitionId { get; set; }
    }
}
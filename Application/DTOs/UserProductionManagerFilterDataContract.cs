using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// UserProductionManagerFilterDataContract
    /// </summary>
    public class UserProductionManagerFilterDataContract
    {
        public int? UserProductionManagerFilterId { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets FilterJSON
        /// </summary>
        public string FilterJSON { get; set; }
        /// <summary>
        /// Gets or sets Order
        /// </summary>
        public int Order { get; set; }
        /// <summary>
        /// Gets or sets ShowInProductionOnly
        /// </summary>
        public bool ShowInProductionOnly { get; set; }
        /// <summary>
        /// Gets or sets IncludeStock
        /// </summary>
        public bool IncludeStock { get; set; }
        /// <summary>
        /// Gets or sets Events
        /// </summary>
        public List<string> Events { get; set; }
        /// <summary>
        /// Gets or sets BaseTypes
        /// </summary>
        public List<string> BaseTypes { get; set; }
        /// <summary>
        /// Gets or sets Customers
        /// </summary>
        public List<string> Customers { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public List<string> DeliveryPoints { get; set; }
        /// <summary>
        /// Gets or sets Types
        /// </summary>
        public List<string> Types { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirements
        /// </summary>
        public List<string> ServiceRequirements { get; set; }
        /// <summary>
        /// Gets or sets GroupEvents
        /// </summary>
        public List<string> GroupEvents { get; set; }
        /// <summary>
        /// Gets or sets GroupServiceRequirements
        /// </summary>
        public List<string> GroupServiceRequirements { get; set; }

    }
}

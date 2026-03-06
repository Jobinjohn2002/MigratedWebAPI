using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MachineDataContract
    /// </summary>
    public class MachineDataContract
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
        /// Gets or sets Type
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// Gets or sets Prefix
        /// </summary>
        public string Prefix { get; set; }
        public int? EventReasonId { get; set; }
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public int EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public int FacilityId { get; set; }
        /// <summary>
        /// Gets or sets IsSteam
        /// </summary>
        public bool IsSteam { get; set; }
    }
}
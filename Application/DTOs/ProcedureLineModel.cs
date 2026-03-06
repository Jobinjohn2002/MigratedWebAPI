using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProcedureLineModel
    /// </summary>
    public class ProcedureLineModel
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public string TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Gets or sets Expired
        /// </summary>
        public bool Expired { get; set; }

        /// <summary>
        /// Gets or sets StatusId
        /// </summary>
        public byte StatusId { get; set; }
        /// <summary>
        /// Gets or sets Added
        /// </summary>
        public bool Added { get; set; }
        /// <summary>
        /// Gets or sets Delete
        /// </summary>
        public bool Delete { get; set; }
        /// <summary>
        /// Gets or sets Statuses
        /// </summary>
        public IEnumerable<GroupedListItem> Statuses { get; set; }
        /// <summary>
        /// Gets or sets Error
        /// </summary>
        public bool Error { get; set; }
        /// <summary>
        /// Gets or sets Restricted
        /// </summary>
        public bool Restricted { get; set; }
        /// <summary>
        /// Gets or sets CleanedInternally
        /// </summary>
        public bool CleanedInternally { get; set; }
        /// <summary>
        /// Gets or sets CleanedExternally
        /// </summary>
        public bool CleanedExternally { get; set; }
        /// <summary>
        /// Gets or sets IsFlexScope
        /// </summary>
        public bool IsFlexScope { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ServiceRequirementDataContract
    /// </summary>
    public class ServiceRequirementDataContract
    {
        /// <summary>
        /// Gets or sets DefinitionId
        /// </summary>
        public int DefinitionId { get; set; }
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundMinutes
        /// </summary>
        public long TurnaroundMinutes { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
    }
}
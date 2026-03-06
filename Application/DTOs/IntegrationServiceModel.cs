using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// IntegrationServiceModel
    /// </summary>
    public class IntegrationServiceModel
    {
        /// <summary>
        /// Gets or sets MachineIntegrationType
        /// </summary>
        public MachineIntegrationType MachineIntegrationType { get; set; }
        /// <summary>
        /// Gets or sets MachineType
        /// </summary>
        public MachineTypeIdentifier MachineType { get; set; }
        /// <summary>
        /// Gets or sets IdentifierValue
        /// </summary>
        public string IdentifierValue { get; set; }
        /// <summary>
        /// Gets or sets ServiceParameters
        /// </summary>
        public ServiceParameterModel ServiceParameters { get; set; }
    }
}
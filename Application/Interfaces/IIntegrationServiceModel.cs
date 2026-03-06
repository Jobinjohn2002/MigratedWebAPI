using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IIntegrationServiceModel
    /// </summary>
    public interface IIntegrationServiceModel
    {
        ServiceParameterModel ServiceParameters { get; set; }
        MachineIntegrationType MachineIntegrationType { get; set; }
        MachineTypeIdentifier MachineType { get; set; }
        string IdentifierValue { get; set; } //Example: BatchId
    }
}

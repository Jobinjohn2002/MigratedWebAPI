using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyServiceRequirementDefinitionHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ServiceRequirementDefinition concreteServiceRequirementDefinition,
                                     ServiceRequirementDefinition genericServiceRequirementDefinition)
        {
            concreteServiceRequirementDefinition.ServicerequirementDefinitionId =
                genericServiceRequirementDefinition.ServicerequirementDefinitionId;
            concreteServiceRequirementDefinition.CustomerDefinitionId =
                genericServiceRequirementDefinition.CustomerDefinitionId;
            concreteServiceRequirementDefinition.LegacyId = genericServiceRequirementDefinition.LegacyId;
            concreteServiceRequirementDefinition.LegacyFacilityOrigin =
                genericServiceRequirementDefinition.LegacyFacilityOrigin;
            concreteServiceRequirementDefinition.LegacyImported = genericServiceRequirementDefinition.LegacyImported;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerMasterDefinitionHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerMasterDefinition concreteContainerMasterDefinition,
                                     ContainerMasterDefinition genericContainerMasterDefinition)
        {
            concreteContainerMasterDefinition.ContainerMasterDefinitionId =
                genericContainerMasterDefinition.ContainerMasterDefinitionId;
            concreteContainerMasterDefinition.CustomerDefinitionId =
                genericContainerMasterDefinition.CustomerDefinitionId;
            concreteContainerMasterDefinition.LegacyId = genericContainerMasterDefinition.LegacyId;
            concreteContainerMasterDefinition.LegacyCustomerId = genericContainerMasterDefinition.LegacyCustomerId;
            concreteContainerMasterDefinition.LegacyFacilityOrigin =
                genericContainerMasterDefinition.LegacyFacilityOrigin;
            concreteContainerMasterDefinition.LegacyImported = genericContainerMasterDefinition.LegacyImported;
        }
    }
}
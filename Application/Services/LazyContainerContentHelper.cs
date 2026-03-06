using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerContentHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerContent concreteContainerContent,
                                     ContainerContent genericContainerContent)
        {
            concreteContainerContent.ContainerContentId = genericContainerContent.ContainerContentId;
            concreteContainerContent.ContainerContentNoteId = genericContainerContent.ContainerContentNoteId;
            concreteContainerContent.ContainerMasterId = genericContainerContent.ContainerMasterId;
            concreteContainerContent.ItemMasterDefinitionId = genericContainerContent.ItemMasterDefinitionId;
            concreteContainerContent.Quantity = genericContainerContent.Quantity;
            concreteContainerContent.Position = genericContainerContent.Position;
            concreteContainerContent.ComponentListPrint = genericContainerContent.ComponentListPrint;
            concreteContainerContent.LegacyId = genericContainerContent.LegacyId;
            concreteContainerContent.LegacyCustomerId = genericContainerContent.LegacyCustomerId;
            concreteContainerContent.LegacyFacilityOrigin = genericContainerContent.LegacyFacilityOrigin;
            concreteContainerContent.LegacyImported = genericContainerContent.LegacyImported;
        }
    }
}
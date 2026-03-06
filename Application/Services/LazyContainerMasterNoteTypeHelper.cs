using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerMasterNoteTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerMasterNoteType concreteContainerMasterNoteType,
                                     ContainerMasterNoteType genericContainerMasterNoteType)
        {
            concreteContainerMasterNoteType.ContainerMasterNoteTypeId =
                genericContainerMasterNoteType.ContainerMasterNoteTypeId;
            concreteContainerMasterNoteType.Text = genericContainerMasterNoteType.Text;
            concreteContainerMasterNoteType.LegacyFacilityOrigin = genericContainerMasterNoteType.LegacyFacilityOrigin;
            concreteContainerMasterNoteType.LegacyImported = genericContainerMasterNoteType.LegacyImported;
        }
    }
}
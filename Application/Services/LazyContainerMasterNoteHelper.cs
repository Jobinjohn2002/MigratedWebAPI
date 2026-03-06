using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerMasterNoteHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerMasterNote concreteContainerMasterNote,
                                     ContainerMasterNote genericContainerMasterNote)
        {
            concreteContainerMasterNote.ContainerMasterNoteId = genericContainerMasterNote.ContainerMasterNoteId;
            concreteContainerMasterNote.ContainerMasterNoteTypeId = genericContainerMasterNote.ContainerMasterNoteTypeId;
            concreteContainerMasterNote.ContainerMasterId = genericContainerMasterNote.ContainerMasterId;
            concreteContainerMasterNote.Text = genericContainerMasterNote.Text;
            concreteContainerMasterNote.LegacyId = genericContainerMasterNote.LegacyId;
            concreteContainerMasterNote.LegacyFacilityOrigin = genericContainerMasterNote.LegacyFacilityOrigin;
            concreteContainerMasterNote.LegacyImported = genericContainerMasterNote.LegacyImported;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerContentNoteHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerContentNote concreteContainerContentNote,
                                     ContainerContentNote genericContainerContentNote)
        {
            concreteContainerContentNote.ContainerContentNoteId = genericContainerContentNote.ContainerContentNoteId;
            concreteContainerContentNote.Text = genericContainerContentNote.Text;
            concreteContainerContentNote.LegacyId = genericContainerContentNote.LegacyId;
            concreteContainerContentNote.LegacyCustomerId = genericContainerContentNote.LegacyCustomerId;
            concreteContainerContentNote.LegacyFacilityOrigin = genericContainerContentNote.LegacyFacilityOrigin;
            concreteContainerContentNote.LegacyImported = genericContainerContentNote.LegacyImported;
        }
    }
}
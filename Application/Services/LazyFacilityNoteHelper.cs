using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyFacilityNoteHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(FacilityNote concreteFacilityNote, FacilityNote genericFacilityNote)
        {
            concreteFacilityNote.FacilityNoteId = genericFacilityNote.FacilityNoteId;
            concreteFacilityNote.ArchiveduserId = genericFacilityNote.ArchiveduserId;
            concreteFacilityNote.CreatedUserId = genericFacilityNote.CreatedUserId;
            concreteFacilityNote.FacilityId = genericFacilityNote.FacilityId;
            concreteFacilityNote.Text = genericFacilityNote.Text;
            concreteFacilityNote.Created = genericFacilityNote.Created;
            concreteFacilityNote.Archived = genericFacilityNote.Archived;
            concreteFacilityNote.LegacyFacilityOrigin = genericFacilityNote.LegacyFacilityOrigin;
            concreteFacilityNote.LegacyImported = genericFacilityNote.LegacyImported;
        }
    }
}
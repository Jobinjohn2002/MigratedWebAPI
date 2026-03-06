using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyTurnaroundNoteHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(TurnaroundNote concreteTurnaroundNote,
                                     TurnaroundNote genericTurnaroundNote)
        {
            concreteTurnaroundNote.TurnaroundNoteId = genericTurnaroundNote.TurnaroundNoteId;
            concreteTurnaroundNote.CreatedUserId = genericTurnaroundNote.CreatedUserId;
            concreteTurnaroundNote.TurnaroundId = genericTurnaroundNote.TurnaroundId;
            concreteTurnaroundNote.Text = genericTurnaroundNote.Text;
            concreteTurnaroundNote.Created = genericTurnaroundNote.Created;
            concreteTurnaroundNote.LegacyId = genericTurnaroundNote.LegacyId;
            concreteTurnaroundNote.LegacyFacilityOrigin = genericTurnaroundNote.LegacyFacilityOrigin;
            concreteTurnaroundNote.LegacyImported = genericTurnaroundNote.LegacyImported;
        }
    }
}
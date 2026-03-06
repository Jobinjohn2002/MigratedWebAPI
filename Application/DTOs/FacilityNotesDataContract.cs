using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// FacilityNotesDataContract
    /// </summary>
    public class FacilityNotesDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets FacilityNotes
        /// </summary>
        public List<FacilityNoteDataContract> FacilityNotes { get; set; }
    }
}
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AddNoteDataContract
    /// </summary>
    public class AddNoteDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets NoteText
        /// </summary>
        public string NoteText { get; set; }
        /// <summary>
        /// Gets or sets StationTypes
        /// </summary>
        public List<int> StationTypes { get; set; }
    }
}
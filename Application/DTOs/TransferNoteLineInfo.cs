using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TransferNoteLineInfo
    /// </summary>
    public class TransferNoteLineInfo
    {
        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public TurnaroundInfo Turnaround { get; set; }
    }
}
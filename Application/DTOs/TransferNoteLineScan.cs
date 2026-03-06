using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// TransferNoteLineScan
    /// </summary>
    public class TransferNoteLineScan
    {
        /// <summary>
        /// Gets or sets TransferNoteId
        /// </summary>
        public int TransferNoteId { get; set; }
        /// <summary>
        /// Gets or sets TrolleyExternalId
        /// </summary>
        public string TrolleyExternalId { get; set; }
    }
}
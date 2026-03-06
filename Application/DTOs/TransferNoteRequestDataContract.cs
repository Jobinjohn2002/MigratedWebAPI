using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TransferNoteRequestDataContract
    /// </summary>
    public class TransferNoteRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets TransferNoteId
        /// </summary>
        public int TransferNoteId { get; set; }
    }
}
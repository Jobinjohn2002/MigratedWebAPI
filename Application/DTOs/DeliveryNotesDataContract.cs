using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DeliveryNotesDataContract
    /// </summary>
    public class DeliveryNotesDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets DeliveryNotes
        /// </summary>
        public List<DeliveryNoteDataContract> DeliveryNotes { get; set; }
    }
}
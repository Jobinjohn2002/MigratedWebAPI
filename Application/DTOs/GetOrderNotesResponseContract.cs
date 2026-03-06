using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// GetOrderNotesResponseContract
    /// </summary>
    public class GetOrderNotesResponseContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets OrderNotes
        /// </summary>
        public List<OrderNoteDataContract> OrderNotes { get; set; }
    }
}

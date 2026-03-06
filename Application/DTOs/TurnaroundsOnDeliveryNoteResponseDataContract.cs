using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundsOnDeliveryNoteResponseDataContract
    /// </summary>
    public class TurnaroundsOnDeliveryNoteResponseDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Turnarounds
        /// </summary>
        public List<DeliveryNoteTurnaroundDataContract> Turnarounds { get; set; }
    }
}
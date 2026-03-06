using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TransferNotePriorityListDataContract
    /// </summary>
    public class TransferNotePriorityListDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public List<TransferNotePriorityItem> Items { get; set; } 
    }
}

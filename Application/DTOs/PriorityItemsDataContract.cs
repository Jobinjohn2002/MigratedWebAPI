using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// PriorityItemsDataContract
    /// </summary>
    public class PriorityItemsDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets PriorityItems
        /// </summary>
        public List<PriorityItemDataContract> PriorityItems { get; set; }
    }
}
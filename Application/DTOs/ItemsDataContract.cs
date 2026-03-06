using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemsDataContract
    /// </summary>
    public class ItemsDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public List<ItemDataContract> Items { get; set; }
    }
}
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemInstancesDataContract
    /// </summary>
    public class ItemInstancesDataContract
    {
                /// <summary>
        /// item count
        /// </summary>
        /// <summary>
        /// Gets or sets ItemCount
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// Turnaround data's
        /// </summary>
        /// <summary>
        /// Gets or sets ItemInstanceListData
        /// </summary>
        public IList<ItemInstanceData> ItemInstanceListData { get; set; }

    }
}

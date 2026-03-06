using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemExceptionGroupedData
    /// </summary>
    public class ItemExceptionGroupedData
    {
        public ItemExceptionGroupedData()
        {
        }

        public ItemExceptionGroupedData(IItemException genericObj) : base(genericObj)
        {
        }
        /// <summary>
        /// Gets or sets Quantity
        /// </summary>
        public int Quantity { get; set; }
    }
}

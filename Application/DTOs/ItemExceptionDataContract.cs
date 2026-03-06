using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemExceptionDataContract
    /// </summary>
    public class ItemExceptionDataContract
    {
        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public ItemExceptionReasonDataContract ItemExceptionReason { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionQuantity
        /// </summary>
        public int ItemExceptionQuantity { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentId
        /// </summary>
        public int ContainerContentId { get; set; }
    }
}

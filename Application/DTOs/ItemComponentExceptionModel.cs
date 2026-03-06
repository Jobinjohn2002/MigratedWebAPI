using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemComponentExceptionModel
    /// </summary>
    public class ItemComponentExceptionModel
    {
        /// <summary>
        /// Gets or sets ItemExceptionQuantity
        /// </summary>
        public int ItemExceptionQuantity { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReason
        /// </summary>
        public string ItemExceptionReason { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReasonId
        /// </summary>
        public int ItemExceptionReasonId { get; set; }

    }
}
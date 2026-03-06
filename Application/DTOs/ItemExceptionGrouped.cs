using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemExceptionGrouped
    /// </summary>
    public class ItemExceptionGrouped
    {
        /// <summary>
        /// Gets or sets ItemExceptionReasonId
        /// </summary>
        public byte ItemExceptionReasonId { get; set; }

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

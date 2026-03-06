using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemExceptionsDataContract
    /// </summary>
    public class ItemExceptionsDataContract
    {
        /// <summary>
        /// Gets or sets CreatedISO
        /// </summary>
        public string CreatedISO { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentId
        /// </summary>
        public int ContainerContentId { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptionReasonId
        /// </summary>
        public int ItemExceptionReasonId { get; set; }
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ItemExceptionReasonDataContract
    /// </summary>
    public class ItemExceptionReasonDataContract
    {
        /// <summary>
        /// Gets or sets ItemExceptionReasonId
        /// </summary>
        public byte ItemExceptionReasonId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets RemovedFromContainer
        /// </summary>
        public bool RemovedFromContainer { get; set; }
    }
}

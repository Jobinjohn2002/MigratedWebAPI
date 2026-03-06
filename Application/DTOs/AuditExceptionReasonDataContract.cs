using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AuditExceptionReasonDataContract
    /// </summary>
    public class AuditExceptionReasonDataContract
    {
        /// <summary>
        /// Gets or sets ExceptionReasonId
        /// </summary>
        public AuditLineExceptionReasonIdentifier ExceptionReasonId { get; set; }
        /// <summary>
        /// Gets or sets DisplayText
        /// </summary>
        public string DisplayText { get; set; }
    }
}

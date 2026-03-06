using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SurgicalProcedureWarningResponse
    /// </summary>
    public class SurgicalProcedureWarningResponse
    {
        /// <summary>
        /// A unique identifer of the type of warning message
        /// </summary>
        /// <summary>
        /// Gets or sets Code
        /// </summary>
        public SurgicalProcedureValidationWarning Code { get; set; }

        /// <summary>
        /// A formatted message describing the warning
        /// </summary>
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// If provided, this value represents the specific turnaround the warning is associated to
        /// </summary>
        public long? TurnaroundId { get; set; }
    }
}

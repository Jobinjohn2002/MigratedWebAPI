using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Surgical Procedure Response.
    /// </summary>
    /// <summary>
    /// SurgicalProcedureResponse
    /// </summary>
    public class SurgicalProcedureResponse
    {
        /// <summary>
        /// The unique surgical procedure number for the newly created surgical procedure record
        /// </summary>
        /// <summary>
        /// Gets or sets SurgicalProcedureNumber
        /// </summary>
        public string SurgicalProcedureNumber { get; set; }

        /// <summary>
        /// A list of warnings that that were generated while creating the surgical procedure
        /// </summary>
        /// <summary>
        /// Gets or sets Warnings
        /// </summary>
        public IEnumerable<SurgicalProcedureWarningResponse> Warnings { get; set; }
    }
}
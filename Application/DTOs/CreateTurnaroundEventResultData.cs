using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Compound data type for the result set from a create event stored procedure.
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// CreateTurnaroundEventResultData
    /// </summary>
    public class CreateTurnaroundEventResultData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTurnaroundEventResultData"/> class.
        /// </summary>
        /// <param name="returnCode">The return code.</param>
        /// <param name="trolleyTurnaroundId">The return code.</param>
        /// <remarks></remarks>
        public CreateTurnaroundEventResultData(int returnCode, int trolleyTurnaroundId)
        {
            ReturnCode = returnCode;
            TurnaroundId = trolleyTurnaroundId;
        }

        /// <summary>
        /// Gets or sets the return code.
        /// </summary>
        /// <value>The return code.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ReturnCode
        /// </summary>
        public int ReturnCode { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }

    }
}

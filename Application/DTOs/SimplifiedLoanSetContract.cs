using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SimplifiedLoanSetContract
    /// </summary>
    public class SimplifiedLoanSetContract
    {
        /// <summary>
        /// Gets or sets LoanSetId
        /// </summary>
        public int LoanSetId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
    }
}

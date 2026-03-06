using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// MLDMissedLoanKitLineModel
    /// </summary>
    public class MLDMissedLoanKitLineModel
    {
        /// <summary>
        /// Gets or sets MissedContainerInstanceExternalId
        /// </summary>
        public string MissedContainerInstanceExternalId { get; set; }
        /// <summary>
        /// Gets or sets MissedLoanKitExternalId
        /// </summary>
        public string MissedLoanKitExternalId { get; set; }
        /// <summary>
        /// Gets or sets NextLoanKitExternalId
        /// </summary>
        public string NextLoanKitExternalId { get; set; }
    }
}

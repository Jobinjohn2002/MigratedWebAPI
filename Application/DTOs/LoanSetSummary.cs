using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// LoanSetProcedureSummary
    /// </summary>
    public class LoanSetProcedureSummary
    {
        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
    }

    /// <summary>
    /// LoanSetSummary
    /// </summary>
    public class LoanSetSummary
    {
        /// <summary>
        /// Gets or sets LoanSetID
        /// </summary>
        public int LoanSetID { get; set; }
        /// <summary>
        /// Gets or sets ExternalID
        /// </summary>
        public string ExternalID { get; set; }
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets NextProcedure
        /// </summary>
        public LoanSetProcedureSummary NextProcedure { get; set; }
        /// <summary>
        /// Gets or sets LoanItems
        /// </summary>
        public int LoanItems { get; set; }
    }
}

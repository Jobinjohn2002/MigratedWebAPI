using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum LoanSetConfirmation
    {
        None = 0,
        New = 1,
        Updated = 2,
        Comment = 3,
        StatusChange = 4
    }

    /// <summary>
    /// CatalogueLoanSetEmailModel
    /// </summary>
    public class CatalogueLoanSetEmailModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public LoanSetConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets LoanSet
        /// </summary>
        public LoanSet LoanSet { get; set; }
        /// <summary>
        /// Gets or sets LoanSetOriginator
        /// </summary>
        public User LoanSetOriginator { get; set; }
        /// <summary>
        /// Gets or sets LoanSetUpdatedBy
        /// </summary>
        public User LoanSetUpdatedBy { get; set; }
    }
}
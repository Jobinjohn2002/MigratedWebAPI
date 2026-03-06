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
    /// LoanSetEmailModel
    /// </summary>
    public class LoanSetEmailModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public LoanSetConfirmation Confirmation { get; set; }
        /// <summary>
        /// Gets or sets LoanSet
        /// </summary>
        public LoanSetModel LoanSet { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefid
        /// </summary>
        public int CustomerDefid { get; set; }
        /// <summary>
        /// Gets or sets Owner
        /// </summary>
        public User Owner { get; set; }
        /// <summary>
        /// Gets or sets EmailFacility
        /// </summary>
        public bool EmailFacility { get; set; }
        /// <summary>
        /// Gets or sets EmailUser
        /// </summary>
        public bool EmailUser { get; set; }
        /// <summary>
        /// Gets or sets EmailOwner
        /// </summary>
        public bool EmailOwner { get; set; }
    }
}
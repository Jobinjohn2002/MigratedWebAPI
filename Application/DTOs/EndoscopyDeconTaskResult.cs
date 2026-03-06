using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// EndoscopyDeconTaskResult
    /// </summary>
    public class EndoscopyDeconTaskResult
    {
        /// <summary>
        /// Gets or sets DeconTaskId
        /// </summary>
        public int DeconTaskId { get; set; }
        public bool? Result { get; set; }
        public int? FailureTypeId { get; set; }
        public DateTime? Created { get; set; }
        /// <summary>
        /// Gets or sets FailureText
        /// </summary>
        public string FailureText { get; set; }
    }
}

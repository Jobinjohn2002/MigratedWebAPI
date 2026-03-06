using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// TurnaroundUsageModel
    /// </summary>
    public class TurnaroundUsageModel
    {
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets SurgeonName
        /// </summary>
        public string SurgeonName { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets SurgeonId
        /// </summary>
        public string SurgeonId { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets CaseId
        /// </summary>
        public string CaseId { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets PatientId
        /// </summary>
        public string PatientId { get; set; }
        [SmartPropertyValidation]
        public DateTime? DateUsed { get; set; }
    }
}
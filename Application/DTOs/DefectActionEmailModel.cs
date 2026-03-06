using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DefectActionEmailModel
    /// </summary>
    public class DefectActionEmailModel
    {
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets TurnaroundExternalID
        /// </summary>
        public string TurnaroundExternalID { get; set; }

        /// <summary>
        /// Gets or sets ActionType
        /// </summary>
        public string ActionType { get; set; }

        /// <summary>
        /// Gets or sets ActionDescription
        /// </summary>
        public string ActionDescription { get; set; }

        /// <summary>
        /// Gets or sets ActionUser
        /// </summary>
        public string ActionUser { get; set; }

        public DateTime? ActionDate { get; set; }
    }
}
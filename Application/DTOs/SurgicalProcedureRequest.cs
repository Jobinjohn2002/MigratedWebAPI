using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Surgical Procedure Request.
    /// </summary>
    /// <summary>
    /// SurgicalProcedureRequest
    /// </summary>
    public class SurgicalProcedureRequest
    {
        /// <summary>
        /// The name of the hospital where the surgical procedure is performed
        /// </summary>
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets Hospital
        /// </summary>
        public string Hospital { get; set; }

        /// <summary>
        /// The name of the usage point where the surgical procedure is performed
        /// </summary>
        [Required]
        [MaxLength(50)]
        /// <summary>
        /// Gets or sets UsagePoint
        /// </summary>
        public string UsagePoint { get; set; }

        /// <summary>
        /// A unique reference to identify the surgical procedure
        /// </summary>
        [MaxLength(64)]
        /// <summary>
        /// Gets or sets CaseReference
        /// </summary>
        public string CaseReference { get; set; }

        /// <summary>
        /// A collection of turnarounds that were available for the procedure, and their corresponding usage states.
        /// </summary>
        [Required]
        /// <summary>
        /// Gets or sets AssociatedTurnarounds
        /// </summary>
        public List<SurgicalProcedureTurnaround> AssociatedTurnarounds { get; set; }

        /// <summary>
        /// A unique reference to identify the patient that had the procedure
        /// </summary>
        [Required]
        [MaxLength(64)]
        /// <summary>
        /// Gets or sets PatientReference
        /// </summary>
        public string PatientReference { get; set; }

        /// <summary>
        /// The name of a person/entity who this record was created on behalf of
        /// </summary>
        [MaxLength(64)]
        /// <summary>
        /// Gets or sets RequestedOnBehalfOf
        /// </summary>
        public string RequestedOnBehalfOf { get; set; }

        /// <summary>
        /// A value to indiciate if the surgeon used any additional instruments that aren't provided in the AssociatedTurnarounds collection
        /// </summary>
        /// <summary>
        /// Gets or sets AdditionalInstrumentsUsed
        /// </summary>
        public bool AdditionalInstrumentsUsed { get; set; }

        /// <summary>
        /// Details of the surgeon who performed the surgical procedure
        /// </summary>
        /// <summary>
        /// Gets or sets Surgeon
        /// </summary>
        public SurgicalProcedureSurgeon Surgeon { get; set; }

        /// <summary>
        /// Details of the type of surgical procedure
        /// </summary>
        /// <summary>
        /// Gets or sets SurgicalProcedureType
        /// </summary>
        public SurgicalProcedureType SurgicalProcedureType { get; set; }

        /// <summary>
        /// The date when the surgical procedure is to be performed (or when it was performed, if creating the record retrospectively). The date should be provided in ISO format.
        /// </summary>
        public DateTime? ScheduledOn { get; set; }

        /// <summary>
        /// A value to indicate whether or not the turnarounds should be automatically transferred to the provided usage point. By default this value is false.
        /// </summary>
        /// <summary>
        /// Gets or sets MoveStock
        /// </summary>
        public bool MoveStock { get; set; }
    }
}
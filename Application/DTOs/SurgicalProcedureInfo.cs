using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Surgical Procedure Info.
    /// </summary>
    /// <summary>
    /// SurgicalProcedureInfo
    /// </summary>
    public class SurgicalProcedureInfo
    {
        /// <summary>
        /// The name of the hospital where the surgical procedure is performed
        /// </summary>
        /// <summary>
        /// Gets or sets Hospital
        /// </summary>
        public string Hospital { get; set; }

        /// <summary>
        /// The name of the usage point where the surgical procedure is performed
        /// </summary>
        /// <summary>
        /// Gets or sets UsagePoint
        /// </summary>
        public string UsagePoint { get; set; }

        /// <summary>
        /// A unique reference to identify the surgical procedure
        /// </summary>
        /// <summary>
        /// Gets or sets CaseReference
        /// </summary>
        public string CaseReference { get; set; }

        /// <summary>
        /// A collection of turnarounds that were available for the procedure, and their corresponding usage states.
        /// </summary>
        /// <summary>
        /// Gets or sets AssociatedTurnarounds
        /// </summary>
        public List<SurgicalProcedureTurnaround> AssociatedTurnarounds { get; set; }

        /// <summary>
        /// A unique reference to identify the patient that had the procedure
        /// </summary>
        /// <summary>
        /// Gets or sets PatientReference
        /// </summary>
        public string PatientReference { get; set; }

        /// <summary>
        /// The name of a person/entity who this record was created on behalf of
        /// </summary>
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
        /// When the surgical procedure was performed (or scheduled to be performed)
        /// </summary>
        public DateTime? ScheduledOn { get; set; }
    }
}
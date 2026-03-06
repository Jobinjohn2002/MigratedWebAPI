using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SurgicalProcedureCreateModel
    /// </summary>
    public class SurgicalProcedureCreateModel
    {
        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }
        [SmartPropertyValidation]
        public int? LocationId { get; set; }
        /// <summary>
        /// Gets or sets Locations
        /// </summary>
        public IEnumerable<GroupedListItem> Locations { get; set; }
        [SmartPropertyValidation]
        public DateTime? ScheduledOn { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets CaseReference
        /// </summary>
        public string CaseReference { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets PatientReference
        /// </summary>
        public string PatientReference { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ProcedureName
        /// </summary>
        public string ProcedureName { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ProcedureReference
        /// </summary>
        public string ProcedureReference { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets SurgeonName
        /// </summary>
        public string SurgeonName { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets SurgeonReference
        /// </summary>
        public string SurgeonReference { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets RequestedOnBehalfOf
        /// </summary>
        public string RequestedOnBehalfOf { get; set; }
        /// <summary>
        /// Gets or sets AdditionalInstrumentsUsed
        /// </summary>
        public bool AdditionalInstrumentsUsed { get; set; }
    }
}
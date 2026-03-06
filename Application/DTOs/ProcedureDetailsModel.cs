using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProcedureDetailsModel
    /// </summary>
    public class ProcedureDetailsModel
    {
        /// <summary>
        /// Gets or sets Result
        /// </summary>
        public HttpStatusCode Result { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureId
        /// </summary>
        public int SurgicalProcedureId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets Locations
        /// </summary>
        public IEnumerable<GroupedListItem> Locations { get; set; }
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
        public DateTime? ScheduledOn { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets RequestedOnBehalfOf
        /// </summary>
        public string RequestedOnBehalfOf { get; set; }

        /// <summary>
        /// Gets or sets AdditionalInstrumentsUsed
        /// </summary>
        public bool AdditionalInstrumentsUsed { get; set; }
        /// <summary>
        /// Gets or sets OrderNumber
        /// </summary>
        public string OrderNumber { get; set; }
        public int? OrderId { get; set; }
    }
}
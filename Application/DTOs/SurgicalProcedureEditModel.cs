using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// SurgicalProcedureEditModel
    /// </summary>
    public class SurgicalProcedureEditModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public SurgicalProcedureRedirect Confirmation { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureId
        /// </summary>
        public int SurgicalProcedureId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets CreatedOn
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// Gets or sets CreatedBy
        /// </summary>
        public string CreatedBy { get; set; }
        /// <summary>
        /// Gets or sets CreatedByUserId
        /// </summary>
        public int CreatedByUserId { get; set; }
        public DateTime? ModifiedOn { get; set; }
        /// <summary>
        /// Gets or sets ModifiedBy
        /// </summary>
        public string ModifiedBy { get; set; }
        public int? ModifiedByUserId { get; set; }

        /// <summary>
        /// Gets or sets Details
        /// </summary>
        public ProcedureDetailsModel Details { get; set; }
        /// <summary>
        /// Gets or sets Surgeon
        /// </summary>
        public SurgeonModel Surgeon { get; set; }
        /// <summary>
        /// Gets or sets ProcedureType
        /// </summary>
        public ProcedureTypeModel ProcedureType { get; set; }

        /// <summary>
        /// Gets or sets AssociatedTurnarounds
        /// </summary>
        public ProcedureTurnaroundModel AssociatedTurnarounds { get; set; }
    }
}
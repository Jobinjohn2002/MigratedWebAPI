using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum SurgicalProcedureRedirect
    {
        None = 0,
        CreatedFromOrder = 1,
        ExistingForOrder = 2
    }

    /// <summary>
    /// SurgicalProcedureModel
    /// </summary>
    public class SurgicalProcedureModel
    {
        /// <summary>
        /// Gets or sets Confirmation
        /// </summary>
        public SurgicalProcedureRedirect Confirmation { get; set; }

        /// <summary>
        /// Gets or sets Procedure
        /// </summary>
        public SurgicalProcedure Procedure { get; set; }
        /// <summary>
        /// Gets or sets AssociatedTurnarounds
        /// </summary>
        public TableModel AssociatedTurnarounds { get; set; }
    }
}
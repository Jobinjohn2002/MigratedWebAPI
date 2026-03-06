using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProcedureTurnaroundModel
    /// </summary>
    public class ProcedureTurnaroundModel
    {
        public ProcedureTurnaroundModel()
        {
            Lines = new List<ProcedureLineModel>();
        }

        /// <summary>
        /// Gets or sets Result
        /// </summary>
        public HttpStatusCode Result { get; set; }
        /// <summary>
        /// Gets or sets SurgicalProcedureId
        /// </summary>
        public int SurgicalProcedureId { get; set; }
        /// <summary>
        /// Gets or sets Turnaround
        /// </summary>
        public string Turnaround { get; set; }
        /// <summary>
        /// Gets or sets StatusId
        /// </summary>
        public byte StatusId { get; set; }
        /// <summary>
        /// Gets or sets Lines
        /// </summary>
        public List<ProcedureLineModel> Lines { get; set; }
        /// <summary>
        /// Gets or sets Statuses
        /// </summary>
        public IEnumerable<GroupedListItem> Statuses { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
    }
}
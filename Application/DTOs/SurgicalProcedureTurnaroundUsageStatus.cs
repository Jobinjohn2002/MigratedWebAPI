using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum SurgicalProcedureTurnaroundUsageStatus
    {
        /// <summary>
        /// The item has been assigned to a surgical procedure, but its usage status is currently unknown.
        /// </summary>
        Assigned = 1,
        /// <summary>
        /// The item was assigned to a surgical procedure, remains unopened and hence wasn't used during the procedure.
        /// </summary>
        Unused = 2,
        /// <summary>
        /// The item was assigned to a surgical procedure, it was opened but it wasn't used during the procedure.
        /// </summary>
        OpenedUnused = 3,
        /// <summary>
        /// The item was assigned to a surgical procedure, it was opened and used during the procedure.
        /// </summary>
        Used = 4
    }
}
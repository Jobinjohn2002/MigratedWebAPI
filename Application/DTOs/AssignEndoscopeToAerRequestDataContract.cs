using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// AssignEndoscopeToAerRequestDataContract
    /// </summary>
    public class AssignEndoscopeToAerRequestDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        public int? InstanceId { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets NewBatchName
        /// </summary>
        public string NewBatchName { get; set; }
        public int? StationTypeId { get; set; }
        public int? PinReasonId { get; set; }
        /// <summary>
        /// Gets or sets IgnoreNotesWarningsAndDecon
        /// </summary>
        public bool IgnoreNotesWarningsAndDecon { get; set; }
    }
}

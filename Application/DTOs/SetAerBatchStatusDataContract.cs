using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// SetAerBatchStatusDataContract
    /// </summary>
    public class SetAerBatchStatusDataContract : BaseRequestDataContract
    {
        /// <summary>
        /// Gets or sets StationTypeId
        /// </summary>
        public int StationTypeId { get; set; }
        /// <summary>
        /// Gets or sets MachineId
        /// </summary>
        public int MachineId { get; set; }
        public byte? FailureTypeId { get; set; }
        /// <summary>
        /// Gets or sets FailureText
        /// </summary>
        public string FailureText { get; set; }
        /// <summary>
        /// Gets or sets StationLocationId
        /// </summary>
        public int StationLocationId { get; set; }
        public int? PinReasonId { get; set; }
        public bool? GetNotesFirst { get; set; }
    }
}

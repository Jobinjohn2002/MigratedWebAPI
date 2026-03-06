using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ConfirmVerifyProcessingParametersContract
    /// </summary>
    public class ConfirmVerifyProcessingParametersContract
    {
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public byte MachineTypeId { get; set; }
        /// <summary>
        /// Gets or sets ProcessingBatchCycleIds
        /// </summary>
        public IEnumerable<int> ProcessingBatchCycleIds { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
    }
}

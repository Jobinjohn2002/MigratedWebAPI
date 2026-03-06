using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// Turnaround Info.
    /// </summary>
    /// 
    /// <summary>
    /// TurnaroundInfo
    /// </summary>
    public class TurnaroundInfo
    {
        /// <summary>
        /// The turnaroundId of the turnaroundEvent we found.
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }

        /// <summary>
        /// The turnaroundId of the turnaroundEvent we found.
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }

        /// <summary>
        /// The UserId of the user that created the turnaround.
        /// </summary>
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The faciltyId where this turnaround was created.
        /// </summary>
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }

        /// <summary>
        /// The turnaround events that have been applied to this turnaround.
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundEvents
        /// </summary>
        public List<TurnaroundEventInfo> TurnaroundEvents { get; set; }

        /// <summary>
        /// The container master details of the turnaround.
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public ContainerMasterinfo ContainerMaster { get; set; }

        /// <summary>
        /// The container instance details of the turnaround.
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerInstance
        /// </summary>
        public ContainerInstanceInfo ContainerInstance { get; set; }
    }
}

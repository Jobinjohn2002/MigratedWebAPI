using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// TurnaroundEventList interface
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// ITurnaroundEventList
    /// </summary>
    public interface ITurnaroundEventList
    {
        /// <summary>
        /// Gets or sets the turnaround event id.
        /// </summary>
        /// <value>The turnaround event id.</value>
        /// <remarks></remarks>
        int TurnaroundEventId { get; set; }

        /// <summary>
        /// Gets or sets the turnaround event type id.
        /// </summary>
        /// <value>The turnaround event type id.</value>
        /// <remarks></remarks>
        short TurnaroundEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the turnaround event.
        /// </summary>
        /// <value>The type of the turnaround event.</value>
        /// <remarks></remarks>
        string TurnaroundEventType { get; set; }

        /// <summary>
        /// Gets or sets the created.
        /// </summary>
        /// <value>The created.</value>
        /// <remarks></remarks>
        DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the created user id.
        /// </summary>
        /// <value>The created user id.</value>
        /// <remarks></remarks>
        int CreatedUserId { get; set; }

        /// <summary>
        /// Gets or sets the created user.
        /// </summary>
        /// <value>The created user.</value>
        /// <remarks></remarks>
        string CreatedUser { get; set; }

        /// <summary>
        /// Gets or sets the additional info.
        /// </summary>
        /// <value>The additional info.</value>
        /// <remarks></remarks>
        string AdditionalInfo { get; set; }

        string AdditionalInfoExtended { get; set; }

        Dictionary<string, string> AdditionalInfoFields { get; set; }

        /// <summary>
        /// Gets or sets the BatchId.
        /// </summary>
        /// <value>The BatchId.</value>
        /// <remarks></remarks>
        int? BatchId { get; set; }

        /// <summary>
        /// gets or sets the expiry
        /// </summary>
        DateTime Expiry { get; set; }

        /// <summary>
        /// gets or sets whether the event is process event or not
        /// </summary>
        bool ProcessEvent { get; set; }

        /// <summary>
        /// gets or sets Compliance Reason
        /// </summary>
        string ComplianceReason { get; set; }

        /// <summary>
        /// Gets or sets whether the Turnaround has ended or not
        /// </summary>
        bool TurnaroundEnded { get; set; }

        /// <summary>
        /// Gets or sets Quarantine Reason Id
        /// </summary>
        short QuarantineReasonId { get; set; }

        /// <summary>
        /// Gets or sets NextEventTypeId
        /// </summary>
        int? NextEventTypeId { get; set; }

        bool? IsProcessEvent { get; set; }

        string FacilityName { get; set; }

        int? FacilityId { get; set; } 
    }
}
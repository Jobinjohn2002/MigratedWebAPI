using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// WorkflowDataContract
    /// </summary>
    public class WorkflowDataContract
    {
        /// <summary>
        /// Workflow Id
        /// </summary>
        /// <summary>
        /// Gets or sets WorkflowId
        /// </summary>
        public int WorkflowId { get; set; }

        /// <summary>
        /// Is this an End Event
        /// </summary>
        /// <summary>
        /// Gets or sets IsEnd
        /// </summary>
        public bool IsEnd { get; set; }

        /// <summary>
        /// Is this a best practice
        /// </summary>
        /// <summary>
        /// Gets or sets IsBestPractice
        /// </summary>
        public bool IsBestPractice { get; set; }

        /// <summary>
        /// Facility Id
        /// </summary>
        public int? FacilityId { get; set; }

        /// <summary>
        /// Item Type Id
        /// </summary>
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }

        /// <summary>
        /// For Individual Instrument Tracking
        /// </summary>
        /// <summary>
        /// Gets or sets ForIndividualInstrumentTracking
        /// </summary>
        public bool ForIndividualInstrumentTracking { get; set; }

        /// <summary>
        /// Is Required Proof
        /// </summary>
        /// <summary>
        /// Gets or sets IsRequiredProof
        /// </summary>
        public bool IsRequiredProof { get; set; }

        /// <summary>
        /// Is Release Required
        /// </summary>
        /// <summary>
        /// Gets or sets IsReleaseRequired
        /// </summary>
        public bool IsReleaseRequired { get; set; }

        /// <summary>
        /// Next Event Type Id
        /// </summary>
        /// <summary>
        /// Gets or sets NextEventTypeId
        /// </summary>
        public int NextEventTypeId { get; set; }

        /// <summary>
        /// Next Event Name
        /// </summary>
        /// <summary>
        /// Gets or sets NextEvent
        /// </summary>
        public string NextEvent { get; set; }

        /// <summary>
        /// Rank
        /// </summary>
        /// <summary>
        /// Gets or sets Rank
        /// </summary>
        public int Rank { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// AutomaticEventDetailsDataContract
    /// </summary>
    public class AutomaticEventDetailsDataContract
    {
        /// <summary>
        /// Gets or sets ContainerInstanceAutomaticEventId
        /// </summary>
        public int ContainerInstanceAutomaticEventId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets EventToApplyId
        /// </summary>
        public short EventToApplyId { get; set; }
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Gets or sets TriggerEvents
        /// </summary>
        public List<AutomaticEventTriggerEventDetails> TriggerEvents { get; set; }

        /// <summary>
        /// Gets or sets Properties
        /// </summary>
        public AutomaticEventProperties Properties { get; set; }
        public int? CreatedTurnaroundEventId { get; set; } //To sent back to let user know that a turnaroundEvent has been created.
        /// <summary>
        /// Gets or sets IsBeingAssessed
        /// </summary>
        public bool IsBeingAssessed { get; set; }
    }

    [Serializable]
    /// <summary>
    /// AutomaticEventTriggerEventDetails
    /// </summary>
    public class AutomaticEventTriggerEventDetails
    {
        /// <summary>
        /// Gets or sets EventTypeId
        /// </summary>
        public short EventTypeId { get; set; }
        /// <summary>
        /// Gets or sets Activated
        /// </summary>
        public bool Activated { get; set; }
        /// <summary>
        /// Gets or sets IsBeingAssessed
        /// </summary>
        public bool IsBeingAssessed { get; set; }
    }

}
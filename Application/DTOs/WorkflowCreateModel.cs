using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// WorkflowCreateModel
    /// </summary>
    public class WorkflowCreateModel
    {
        /// <summary>
        /// Gets or sets FacilityId
        /// </summary>
        public short FacilityId { get; set; }
        /// <summary>
        /// Gets or sets FacilityOwnerId
        /// </summary>
        public int FacilityOwnerId { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets ProcessingMode
        /// </summary>
        public KnownProcessingMode ProcessingMode { get; set; }
        /// <summary>
        /// Gets or sets Message
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// Gets or sets AvailableItemTypes
        /// </summary>
        public List<GroupedListItem> AvailableItemTypes { get; set; }
        /// <summary>
        /// Gets or sets AvailableFromEventTypes
        /// </summary>
        public List<SelectListItem> AvailableFromEventTypes { get; set; }
        /// <summary>
        /// Gets or sets AvailableToEventTypes
        /// </summary>
        public List<SelectListItem> AvailableToEventTypes { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }
        [SmartPropertyValidation]
        public short? FromEventTypeId { get; set; }
        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ToEventTypeId
        /// </summary>
        public short ToEventTypeId { get; set; }

        /// <summary>
        /// Gets or sets IsEnd
        /// </summary>
        public bool IsEnd { get; set; }
        /// <summary>
        /// Gets or sets IsFacilitySpecific
        /// </summary>
        public bool IsFacilitySpecific { get; set;  }
        /// <summary>
        /// Gets or sets IsBestPractice
        /// </summary>
        public bool IsBestPractice { get; set; }
    }

    /// <summary>
    /// Message
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets Success
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }
    }
}
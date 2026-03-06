using System;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ClockingEventReplyDataContract
    /// </summary>
    public class ClockingEventReplyDataContract : BaseReplyDataContract
    {
        /// <summary>
        /// Gets or sets Successful
        /// </summary>
        public bool Successful { get; set; }
        /// <summary>
        /// Gets or sets IsMandatory
        /// </summary>
        public bool IsMandatory { get; set; }
        /// <summary>
        /// Gets or sets ClockingEventType
        /// </summary>
        public ClockingEventTypeIdentifier ClockingEventType { get; set; }
        /// <summary>
        /// Gets or sets LocationPath
        /// </summary>
        public string LocationPath { get; set; }
        /// <summary>
        /// Gets or sets LocationId
        /// </summary>
        public int LocationId { get; set; }
        /// <summary>
        /// Gets or sets FirstName
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets Surname
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Gets or sets UserId
        /// </summary>
        public int UserId { get; set; }
        public DateTime? LastEventTime { get; set; }
    }
}
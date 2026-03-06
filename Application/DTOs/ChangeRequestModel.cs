using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public enum ChangeRequestType
    {
        New,
        Update
    }

    /// <summary>
    /// ChangeRequestModel
    /// </summary>
    public class ChangeRequestModel
    {
        /// <summary>
        /// Gets or sets ChangeRequestId
        /// </summary>
        public int ChangeRequestId { get; set; }
        /// <summary>
        /// Gets or sets ChangeType
        /// </summary>
        public ChangeRequestType ChangeType { get; set; }
        public int? CustomerDefinitionID { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ProductReference
        /// </summary>
        public string ProductReference { get; set; }
        [SmartPropertyValidation]
        public int? DeliveryPointId { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ProductDescription
        /// </summary>
        public string ProductDescription { get; set; }
        /// <summary>
        /// Gets or sets AttachProductSpecification
        /// </summary>
        public bool AttachProductSpecification { get; set; }
        /// <summary>
        /// Gets or sets AttachManafacturersInstructions
        /// </summary>
        public bool AttachManafacturersInstructions { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Reason
        /// </summary>
        public string Reason { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public string Comments { get; set; }

        [SmartPropertyValidation]
        public int? EstimatedAnnualUsage { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets RequestedBy
        /// </summary>
        public string RequestedBy { get; set; }
        /// <summary>
        /// Gets or sets RequestAction
        /// </summary>
        public short RequestAction { get; set; }
        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }
        /// <summary>
        /// Gets or sets LocationID
        /// </summary>
        public int LocationID { get; set; }

        /// <summary>
        /// Gets or sets ChangeControlNoteStatus
        /// </summary>
        public string ChangeControlNoteStatus { get; set; }
    }
}
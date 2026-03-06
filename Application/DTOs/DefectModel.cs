using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// DefectModel
    /// </summary>
    public class DefectModel
    {
        /// <summary>
        /// Gets or sets Reference
        /// </summary>
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public DateTime Date { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets ReportedBy
        /// </summary>
        public string ReportedBy { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Department
        /// </summary>
        public string Department { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public string Position { get; set; }

        [SmartPropertyValidation]
        public int? LocationID { get; set; }

        [SmartPropertyValidation]
        public byte? ClassificationID { get; set; }
        public int? CustomClassificationId { get; set; }
        /// <summary>
        /// Gets or sets Classification
        /// </summary>
        public string Classification { get; set; }

        [SmartPropertyValidation]
        public byte? SeverityID { get; set; }
        public int? CustomSeverityId { get; set; }
        /// <summary>
        /// Gets or sets Severity
        /// </summary>
        public string Severity { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets Comments
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// Gets or sets EmailSent
        /// </summary>
        public bool EmailSent { get; set; }

        public int? DefectID { get; set; }

        /// <summary>
        /// Gets or sets ShowGettingStarted
        /// </summary>
        public bool ShowGettingStarted { get; set; }

        [SmartPropertyValidation]
        /// <summary>
        /// Gets or sets TurnaroundExternalID
        /// </summary>
        public string TurnaroundExternalID { get; set; }

        /// <summary>
        /// Gets or sets ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets ProductDescription
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets ProductAlternateId
        /// </summary>
        public string ProductAlternateId { get; set; }

        /// <summary>
        /// Gets or sets ProductLotNumber
        /// </summary>
        public string ProductLotNumber { get; set; }

        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets InstancePrimaryID
        /// </summary>
        public string InstancePrimaryID { get; set; }

        public int? ContainerInstanceId { get; set; }
    }
}
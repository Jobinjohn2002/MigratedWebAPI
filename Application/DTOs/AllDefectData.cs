using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SynergyApplicationFrameworkApi.Application.Interfaces;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// AllDefectData
    /// </summary>
    public class AllDefectData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AllDefectData"/> class.
        /// </summary>
        /// <param name="genericDefect">The generic defect.</param>
        /// <remarks></remarks>
        public AllDefectData(IDefect genericDefect)
        {
            ExternalId = genericDefect.ExternalId;
            DefectId = genericDefect.DefectId;
            DefectTypeName = "Defect";
            DefectRaised = genericDefect.Raised;
            TurnaroundId = genericDefect.TurnaroundId.GetValueOrDefault();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AllDefectData"/> class.
        /// </summary>
        /// <param name="genericDefect">The generic defect.</param>
        /// <remarks></remarks>
        public AllDefectData(ICustomerDefect genericDefect)
        {
            ExternalId = genericDefect.ExternalId;
            DefectId = genericDefect.CustomerDefectId;
            DefectTypeName = "Customer Defect";
            DefectRaised = genericDefect.Created;
            TurnaroundId = genericDefect.TurnaroundId;
        }

        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        /// Gets or sets the defect id.
        /// </summary>
        /// <value>The defect id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectId
        /// </summary>
        public int DefectId { get; set; }

        /// <summary>
        /// Gets or sets the name of the defect type.
        /// </summary>
        /// <value>The name of the defect type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectTypeName
        /// </summary>
        public string DefectTypeName { get; set; }

        /// <summary>
        /// Gets or sets the defect raised.
        /// </summary>
        /// <value>The defect raised.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectRaised
        /// </summary>
        public DateTime DefectRaised { get; set; }

        /// <summary>
        /// Gets or sets the name of the delivery point.
        /// </summary>
        /// <value>The name of the delivery point.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public String DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets the defect classification.
        /// </summary>
        /// <value>The defect classification.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectClassification
        /// </summary>
        public string DefectClassification { get; set; }

        /// <summary>
        /// Gets or sets the defect severity.
        /// </summary>
        /// <value>The defect severity.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectSeverity
        /// </summary>
        public string DefectSeverity { get; set; }

        /// <summary>
        /// Gets or sets the instance uid.
        /// </summary>
        /// <value>The instance uid.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets InstanceUid
        /// </summary>
        public Guid InstanceUid { get; set; }

        /// <summary>
        /// Gets or sets the turnaround uid.
        /// </summary>
        /// <value>The turnaround uid.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the name of the defect status.
        /// </summary>
        /// <value>The name of the defect status.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectStatusName
        /// </summary>
        public String DefectStatusName { get; set; }

        /// <summary>
        /// Gets or sets whether defect is customer defect or not.
        /// </summary>
        /// <value>true - customer defect, false - defect</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IsCustomerDefect
        /// </summary>
        public bool IsCustomerDefect { get; set; }
    }
}
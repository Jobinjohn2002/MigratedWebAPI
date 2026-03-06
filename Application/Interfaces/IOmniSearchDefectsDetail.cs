using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// IOmniSearchDefectsDetail
    /// </summary>
    public interface IOmniSearchDefectsDetail
    {
        /// <summary>
        /// Gets or sets customer name
        /// </summary>
        /// <value>The customer name</value>
        /// <remarks></remarks>
        string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the customer uid.
        /// </summary>
        /// <value>The customer uid.</value>
        /// <remarks></remarks>
        int CustomerId { get; set; }

        int CustomerStatusId { get; set; }

        /// <summary>
        /// Gets or sets classification.
        /// </summary>
        /// <value>The classification.</value>
        /// <remarks></remarks>
        string DefectClassification { get; set; }

        /// <summary>
        /// Gets or sets the severity
        /// </summary>
        /// <value>The severity</value>
        /// <remarks></remarks>
        string DefectSeverity { get; set; }

        /// <summary>
        /// Gets or sets defect status.
        /// </summary>
        /// <value>The defect status.</value>
        /// <remarks></remarks>
        string DefectStatus { get; set; }

        /// <summary>
        /// Gets or sets defect id.
        /// </summary>
        /// <value>The defect id.</value>
        /// <remarks></remarks>
        int DefectId { get; set; }

        /// <summary>
        /// Gets or sets the delivery point name.
        /// </summary>
        /// <value>The delivery point name.</value>
        /// <remarks></remarks>
        string DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets the  delivery point id.
        /// </summary>
        /// <value>The  delivery point id.</value>
        /// <remarks></remarks>
        int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the legacy internal id.
        /// </summary>
        /// <value>The legacy internal id.</value>
        /// <remarks></remarks>
        long? LegacyInternalId { get; set; }

        /// <summary>
        /// Gets or sets the legacy external id.
        /// </summary>
        /// <value>The legacy external id.</value>
        /// <remarks></remarks>
        string LegacyExternalId { get; set; }

        /// <summary>
        /// Gets or sets the raised.
        /// </summary>
        /// <value>The raised.</value>
        /// <remarks></remarks>
        DateTime Raised { get; set; }

        /// <summary>
        /// Gets or sets the reporting department.
        /// </summary>
        /// <value>The reporting department.</value>
        /// <remarks></remarks>
        string ReportingDepartment { get; set; }

        /// <summary>
        /// Gets or sets the reporting user name.
        /// </summary>
        /// <value>The reporting user name.</value>
        /// <remarks></remarks>
        string ReportingUserName { get; set; }

        /// <summary>
        /// Gets or sets the reporting user position.
        /// </summary>
        /// <value>The reporting user position.</value>
        /// <remarks></remarks>
        string ReportingUserPosition { get; set; }

        /// <summary>
        /// Gets or sets the turnaround id.
        /// </summary>
        /// <value>The turnaround id.</value>
        /// <remarks></remarks>
        int? TurnaroundId { get; set; }

        /// <summary>
        /// Gets or sets the turnaround external id.
        /// </summary>
        /// <value>The turnaround external id.</value>
        /// <remarks></remarks>
        string TurnaroundExternalId { get; set; }

        string DefectType { get; set; }
    }
}

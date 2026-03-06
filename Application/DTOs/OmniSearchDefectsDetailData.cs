using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// OmniSearchDefectsDetailData
    /// </summary>
    public class OmniSearchDefectsDetailData
    {
         /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <remarks></remarks>
        public OmniSearchDefectsDetailData()
        {

        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>       
        /// <remarks></remarks>
        public OmniSearchDefectsDetailData(string customerName,
                                            int customerId,
                                            int customerStatusId,
                                            string defectClassification,
                                            string defectSeverity,
                                            string defectStatus,
                                            int defectId,
                                            string deliveryPointName,
                                            int deliveryPointId,
                                            long? legacyInternalId,
                                            string legacyExternalId,
                                            DateTime raised,
                                            string reportingDepartment,
                                            string reportingUserName,
                                            string reportingUserPosition,
                                            int? turnaroundId,
                                            string turnaroundExternalId,
                                            string defectType)
        {

            CustomerName = customerName;
            CustomerId = customerId;
            CustomerStatusId = customerStatusId;
            DefectClassification = defectClassification;
            DefectSeverity = defectSeverity;
            DefectStatus = defectStatus;
            DefectId = defectId;
            DeliveryPointName = deliveryPointName;
            DeliveryPointId = deliveryPointId;
            LegacyInternalId = legacyInternalId;
            LegacyExternalId = legacyExternalId;
            Raised = raised;
            ReportingDepartment = reportingDepartment;
            ReportingUserName = reportingUserName;
            ReportingUserPosition = reportingUserPosition;
            TurnaroundId = turnaroundId;
            TurnaroundExternalId = turnaroundExternalId;
            DefectType = defectType;
        }

        /// <summary>
        /// Gets or sets customer name
        /// </summary>
        /// <value>The customer name</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the customer uid.
        /// </summary>
        /// <value>The customer uid.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerStatusId
        /// </summary>
        public int CustomerStatusId { get; set; }

        /// <summary>
        /// Gets or sets classification.
        /// </summary>
        /// <value>The classification.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectClassification
        /// </summary>
        public string DefectClassification { get; set; }

        /// <summary>
        /// Gets or sets the severity
        /// </summary>
        /// <value>The severity</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectSeverity
        /// </summary>
        public string DefectSeverity { get; set; }

        /// <summary>
        /// Gets or sets defect status.
        /// </summary>
        /// <value>The defect status.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectStatus
        /// </summary>
        public string DefectStatus { get; set; }

        /// <summary>
        /// Gets or sets defect id.
        /// </summary>
        /// <value>The defect id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefectId
        /// </summary>
        public int DefectId { get; set; }

        /// <summary>
        /// Gets or sets the delivery point name.
        /// </summary>
        /// <value>The delivery point name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointName
        /// </summary>
        public string DeliveryPointName { get; set; }

        /// <summary>
        /// Gets or sets the  delivery point id.
        /// </summary>
        /// <value>The  delivery point id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }

        /// <summary>
        /// Gets or sets the legacy internal id.
        /// </summary>
        /// <value>The legacy internal id.</value>
        /// <remarks></remarks>
        public long? LegacyInternalId { get; set; }

        /// <summary>
        /// Gets or sets the legacy external id.
        /// </summary>
        /// <value>The legacy external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LegacyExternalId
        /// </summary>
        public string LegacyExternalId { get; set; }

        /// <summary>
        /// Gets or sets the raised.
        /// </summary>
        /// <value>The raised.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Raised
        /// </summary>
        public DateTime Raised { get; set; }

        /// <summary>
        /// Gets or sets the reporting department.
        /// </summary>
        /// <value>The reporting department.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ReportingDepartment
        /// </summary>
        public string ReportingDepartment { get; set; }

        /// <summary>
        /// Gets or sets the reporting user name.
        /// </summary>
        /// <value>The reporting user name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ReportingUserName
        /// </summary>
        public string ReportingUserName { get; set; }

        /// <summary>
        /// Gets or sets the reporting user position.
        /// </summary>
        /// <value>The reporting user position.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ReportingUserPosition
        /// </summary>
        public string ReportingUserPosition { get; set; }

        /// <summary>
        /// Gets or sets the turnaround id.
        /// </summary>
        /// <value>The turnaround id.</value>
        /// <remarks></remarks>
        public int? TurnaroundId { get; set; }       
        
        /// <summary>
        /// Gets or sets the turnaround external id.
        /// </summary>
        /// <value>The turnaround id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public string TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets DefectType
        /// </summary>
        public string DefectType { get; set; }
    }
}

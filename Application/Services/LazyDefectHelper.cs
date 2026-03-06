using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDefectHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Defect concreteDefect, Defect genericDefect)
        {
            concreteDefect.DefectId = genericDefect.DefectId;
            concreteDefect.ContainerInstanceId = genericDefect.ContainerInstanceId;
            concreteDefect.CreatedUserId = genericDefect.CreatedUserId;
            concreteDefect.DefectClassificationId = genericDefect.DefectClassificationId;
            concreteDefect.DefectResponsibilityId = genericDefect.DefectResponsibilityId;
            concreteDefect.DefectSeverityId = genericDefect.DefectSeverityId;
            concreteDefect.DefectStatusId = genericDefect.DefectStatusId;
            concreteDefect.DeliveryPointId = genericDefect.DeliveryPointId;
            concreteDefect.ImmediateActionUserId = genericDefect.ImmediateActionUserId;
            concreteDefect.LongTermActionUserId = genericDefect.LongTermActionUserId;
            concreteDefect.ReviewUserId = genericDefect.ReviewUserId;
            concreteDefect.TurnaroundId = genericDefect.TurnaroundId;
            concreteDefect.SignedForSynergyUserId = genericDefect.SignedForSynergyUserId;
            concreteDefect.ExternalId = genericDefect.ExternalId;
            concreteDefect.Raised = genericDefect.Raised;
            concreteDefect.Received = genericDefect.Received;
            concreteDefect.ReportingDepartment = genericDefect.ReportingDepartment;
            concreteDefect.ReporterUserName = genericDefect.ReporterUserName;
            concreteDefect.ReporterUserPosition = genericDefect.ReporterUserPosition;
            concreteDefect.ItemName = genericDefect.ItemName;
            concreteDefect.GeneralFaultCount = genericDefect.GeneralFaultCount;
            concreteDefect.OtherDetails = genericDefect.OtherDetails;
            concreteDefect.ImmediateAction = genericDefect.ImmediateAction;
            concreteDefect.ImmediateActionDate = genericDefect.ImmediateActionDate;
            concreteDefect.LongTermAction = genericDefect.LongTermAction;
            concreteDefect.LongTermActionDate = genericDefect.LongTermActionDate;
            concreteDefect.SignedForTrustUserName = genericDefect.SignedForTrustUserName;
            concreteDefect.ReviewInformation = genericDefect.ReviewInformation;
            concreteDefect.Reviewed = genericDefect.Reviewed;
            concreteDefect.LegacyId = genericDefect.LegacyId;
            concreteDefect.LegacyFacilityOrigin = genericDefect.LegacyFacilityOrigin;
            concreteDefect.LegacyImported = genericDefect.LegacyImported;
            concreteDefect.QuarantineAfterWash = genericDefect.QuarantineAfterWash;	
            concreteDefect.ContainerMasterId = genericDefect.ContainerMasterId;
            concreteDefect.IncidentDate = genericDefect.IncidentDate;
            concreteDefect.DefectSourceId = genericDefect.DefectSourceId;
            concreteDefect.UnTrackedProductId = genericDefect.UnTrackedProductId;
            concreteDefect.CustomSeverityId = genericDefect.CustomSeverityId;
            concreteDefect.CustomClassificationId = genericDefect.CustomClassificationId;
        }
    }
}
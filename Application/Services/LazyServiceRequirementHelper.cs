using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyServiceRequirementHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ServiceRequirement concreteServiceRequirement,
                                     ServiceRequirement genericServiceRequirement)
        {
            concreteServiceRequirement.ServiceRequirementId = genericServiceRequirement.ServiceRequirementId;
            concreteServiceRequirement.ArchivedUserId = genericServiceRequirement.ArchivedUserId;
            concreteServiceRequirement.CreatedUserId = genericServiceRequirement.CreatedUserId;
            concreteServiceRequirement.ExpiryCalculationTypeId = genericServiceRequirement.ExpiryCalculationTypeId;
            concreteServiceRequirement.ServiceRequirementDefinitionId =
                genericServiceRequirement.ServiceRequirementDefinitionId;
            concreteServiceRequirement.Text = genericServiceRequirement.Text;
            concreteServiceRequirement.Revision = genericServiceRequirement.Revision;
            concreteServiceRequirement.TurnaroundMinutes = genericServiceRequirement.TurnaroundMinutes;
            concreteServiceRequirement.Margin = genericServiceRequirement.Margin;
            concreteServiceRequirement.MarginAppliesToReprocessing =
                genericServiceRequirement.MarginAppliesToReprocessing;
            concreteServiceRequirement.MarginAppliesToSingleUse = genericServiceRequirement.MarginAppliesToSingleUse;
            concreteServiceRequirement.MarginAppliesToOther = genericServiceRequirement.MarginAppliesToOther;
            concreteServiceRequirement.GraceMinutes = genericServiceRequirement.GraceMinutes;
            concreteServiceRequirement.Effective = genericServiceRequirement.Effective;
            concreteServiceRequirement.Created = genericServiceRequirement.Created;
            concreteServiceRequirement.Archived = genericServiceRequirement.Archived;
            concreteServiceRequirement.LegacyId = genericServiceRequirement.LegacyId;
            concreteServiceRequirement.LegacyFacilityOrigin = genericServiceRequirement.LegacyFacilityOrigin;
            concreteServiceRequirement.LegacyImported = genericServiceRequirement.LegacyImported;
            concreteServiceRequirement.IsFastTrack = genericServiceRequirement.IsFastTrack;
        }
    }
}
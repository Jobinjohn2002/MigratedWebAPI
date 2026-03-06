using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerInstanceHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerInstance concreteContainerInstance,
                                     ContainerInstance genericContainerInstance)
        {
            concreteContainerInstance.ContainerInstanceId = genericContainerInstance.ContainerInstanceId;
            concreteContainerInstance.ArchivedUserId = genericContainerInstance.ArchivedUserId;
            concreteContainerInstance.ContainerMasterDefinitionId = genericContainerInstance.ContainerMasterDefinitionId;
            concreteContainerInstance.CreatedUserId = genericContainerInstance.CreatedUserId;
            concreteContainerInstance.CurrentLocationId = genericContainerInstance.CurrentLocationId;
            concreteContainerInstance.DeliveryPointId = genericContainerInstance.DeliveryPointId;
            concreteContainerInstance.ServiceRequirementDefinitionId = genericContainerInstance.ServiceRequirementDefinitionId;
            concreteContainerInstance.FacilityId = genericContainerInstance.FacilityId;
            concreteContainerInstance.Created = genericContainerInstance.Created;
            concreteContainerInstance.Archived = genericContainerInstance.Archived;
            concreteContainerInstance.TurnaroundCount = genericContainerInstance.TurnaroundCount;
            concreteContainerInstance.TurnaroundWarningCount = genericContainerInstance.TurnaroundWarningCount;
            concreteContainerInstance.LegacyId = genericContainerInstance.LegacyId;
            concreteContainerInstance.LegacyExternalId = genericContainerInstance.LegacyExternalId;
            concreteContainerInstance.LegacyIdReplaced = genericContainerInstance.LegacyIdReplaced;
            concreteContainerInstance.LegacyFacilityOrigin = genericContainerInstance.LegacyFacilityOrigin;
            concreteContainerInstance.LegacyImported = genericContainerInstance.LegacyImported;
            concreteContainerInstance.Text = genericContainerInstance.Text;
            concreteContainerInstance.Giai = genericContainerInstance.Giai;
            concreteContainerInstance.GS1ProductCode = genericContainerInstance.GS1ProductCode;
            concreteContainerInstance.QALabelProductCodeId = genericContainerInstance.QALabelProductCodeId;
            concreteContainerInstance.Linear1dBarcodeId = genericContainerInstance.Linear1dBarcodeId;
            concreteContainerInstance.Datamatrix2dBarcodeId = genericContainerInstance.Datamatrix2dBarcodeId;
            concreteContainerInstance.ModifiedById = genericContainerInstance.ModifiedById;
            concreteContainerInstance.ModifiedByDate = genericContainerInstance.ModifiedByDate;
            concreteContainerInstance.IsIdentifiable = genericContainerInstance.IsIdentifiable;
            concreteContainerInstance.WeighingRequired = genericContainerInstance.WeighingRequired;
            concreteContainerInstance.AdditionalInfo = genericContainerInstance.AdditionalInfo;
        }
    }
}
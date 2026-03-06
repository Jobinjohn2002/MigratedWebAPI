using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerMasterHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerMaster concreteContainerMaster,
                                     ContainerMaster genericContainerMaster)
        {
            concreteContainerMaster.ContainerMasterId = genericContainerMaster.ContainerMasterId;
            concreteContainerMaster.ChargableBatchCycleId = genericContainerMaster.ChargableBatchCycleId;
            concreteContainerMaster.CategoryId = genericContainerMaster.CategoryId;
            concreteContainerMaster.ComplexityId = genericContainerMaster.ComplexityId;
            concreteContainerMaster.ContainerMasterDefinitionId = genericContainerMaster.ContainerMasterDefinitionId;
            concreteContainerMaster.CreatedUserId = genericContainerMaster.CreatedUserId;
            concreteContainerMaster.ItemStatusId = genericContainerMaster.ItemStatusId;
            concreteContainerMaster.ItemTypeId = genericContainerMaster.ItemTypeId;
            concreteContainerMaster.MachineTypeId = genericContainerMaster.MachineTypeId;
            concreteContainerMaster.SpecialityId = genericContainerMaster.SpecialityId;
            concreteContainerMaster.ExternalId = genericContainerMaster.ExternalId;
            concreteContainerMaster.Text = genericContainerMaster.Text;
            concreteContainerMaster.Revision = genericContainerMaster.Revision;
            concreteContainerMaster.Created = genericContainerMaster.Created;
            concreteContainerMaster.IPOH = genericContainerMaster.IPOH;
            concreteContainerMaster.ManufacturersReference = genericContainerMaster.ManufacturersReference;
            concreteContainerMaster.NumberOfLabels = genericContainerMaster.NumberOfLabels;
            concreteContainerMaster.IndependentQualityAssuranceCheck =
                genericContainerMaster.IndependentQualityAssuranceCheck;
            concreteContainerMaster.TrackIndividualInstruments = genericContainerMaster.TrackIndividualInstruments;
            concreteContainerMaster.LegacyId = genericContainerMaster.LegacyId;
            concreteContainerMaster.LegacyCustomerId = genericContainerMaster.LegacyCustomerId;
            concreteContainerMaster.LegacyFacilityOrigin = genericContainerMaster.LegacyFacilityOrigin;
            concreteContainerMaster.LegacyImported = genericContainerMaster.LegacyImported;
            concreteContainerMaster.PrinterTypeId = genericContainerMaster.PrinterTypeId;
            concreteContainerMaster.Gtin = genericContainerMaster.Gtin;
            concreteContainerMaster.PinRequestReasonId = genericContainerMaster.PinRequestReasonId;
            concreteContainerMaster.Archived = genericContainerMaster.Archived;
            concreteContainerMaster.ArchivedUserId = genericContainerMaster.ArchivedUserId;
            concreteContainerMaster.CoolingTime = genericContainerMaster.CoolingTime;
        }
    }
}
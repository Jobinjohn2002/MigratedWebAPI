using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerMasterPriceAdjustmentHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerMasterPriceAdjustment concreteContainerMasterPriceAdjustment,
                                     ContainerMasterPriceAdjustment genericContainerMasterPriceAdjustment)
        {
            concreteContainerMasterPriceAdjustment.ContainerMasterPriceAdjustmentId =
                genericContainerMasterPriceAdjustment.ContainerMasterPriceAdjustmentId;
            concreteContainerMasterPriceAdjustment.ContainerMasterId =
                genericContainerMasterPriceAdjustment.ContainerMasterId;
            concreteContainerMasterPriceAdjustment.Text = 
                genericContainerMasterPriceAdjustment.Text;
            concreteContainerMasterPriceAdjustment.Adjustment = 
                genericContainerMasterPriceAdjustment.Adjustment;
            concreteContainerMasterPriceAdjustment.ApplyServiceRequirementFactor =
                genericContainerMasterPriceAdjustment.ApplyServiceRequirementFactor;
            concreteContainerMasterPriceAdjustment.LegacyId = 
                genericContainerMasterPriceAdjustment.LegacyId;
            concreteContainerMasterPriceAdjustment.LegacyFacilityOrigin =
                genericContainerMasterPriceAdjustment.LegacyFacilityOrigin;
            concreteContainerMasterPriceAdjustment.LegacyImported = 
                genericContainerMasterPriceAdjustment.LegacyImported;
            concreteContainerMasterPriceAdjustment.ContainerMasterPriceAdjustmentTypeId =
                genericContainerMasterPriceAdjustment.ContainerMasterPriceAdjustmentTypeId;
        }
    }
}
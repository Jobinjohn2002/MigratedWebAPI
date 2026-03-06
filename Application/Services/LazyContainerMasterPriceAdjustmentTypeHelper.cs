using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyContainerMasterPriceAdjustmentTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(ContainerMasterPriceAdjustmentType concreteContainerMasterPriceAdjustmentType,
                                     ContainerMasterPriceAdjustmentType genericContainerMasterPriceAdjustmentType)
        {
            concreteContainerMasterPriceAdjustmentType.ContainerMasterPriceAdjustmentTypeId =
                genericContainerMasterPriceAdjustmentType.ContainerMasterPriceAdjustmentTypeId;
            concreteContainerMasterPriceAdjustmentType.Text = genericContainerMasterPriceAdjustmentType.Text;
        }
    }
}
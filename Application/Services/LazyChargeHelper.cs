using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyChargeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Charge concreteCharge, Charge genericCharge)
        {
            concreteCharge.ChargeId = genericCharge.ChargeId;
            concreteCharge.ArchivedUserId = genericCharge.ArchivedUserId;
            concreteCharge.ChargeListCategoryId = genericCharge.ChargeListCategoryId;
            concreteCharge.ContainerInstanceId = genericCharge.ContainerInstanceId;
            concreteCharge.ContainerMasterId = genericCharge.ContainerMasterId;
            concreteCharge.CreatedUserId = genericCharge.CreatedUserId;
            concreteCharge.CustomerDefinitionId = genericCharge.CustomerDefinitionId;
            concreteCharge.DeliveryPointId = genericCharge.DeliveryPointId;
            concreteCharge.InvoiceId = genericCharge.InvoiceId;
            concreteCharge.Created = genericCharge.Created;
            concreteCharge.Archived = genericCharge.Archived;
            concreteCharge.LegacyId = genericCharge.LegacyId;
            concreteCharge.LegacyFacilityOrigin = genericCharge.LegacyFacilityOrigin;
            concreteCharge.LegacyImported = genericCharge.LegacyImported;
            concreteCharge.Value = genericCharge.Value;
        }
    }
}
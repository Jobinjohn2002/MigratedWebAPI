using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDeliveryTypeHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(DeliveryType concreteDeliveryType, DeliveryType genericDeliveryType)
        {
            concreteDeliveryType.DeliveryTypeId = genericDeliveryType.DeliveryTypeId;
            concreteDeliveryType.Text = genericDeliveryType.Text;
            concreteDeliveryType.LegacyFacilityOrigin = genericDeliveryType.LegacyFacilityOrigin;
            concreteDeliveryType.LegacyImported = genericDeliveryType.LegacyImported;
        }
    }
}
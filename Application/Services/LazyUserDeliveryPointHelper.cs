using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyUserDeliveryPointHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(UserDeliveryPoint concreteUserDeliveryPoint,
                                     UserDeliveryPoint genericUserDeliveryPoint)
        {
            concreteUserDeliveryPoint.UserDeliveryPointId = genericUserDeliveryPoint.UserDeliveryPointId;
            concreteUserDeliveryPoint.DeliveryPointId = genericUserDeliveryPoint.DeliveryPointId;
            concreteUserDeliveryPoint.UserId = genericUserDeliveryPoint.UserId;
            concreteUserDeliveryPoint.LegacyFacilityOrigin = genericUserDeliveryPoint.LegacyFacilityOrigin;
            concreteUserDeliveryPoint.LegacyImported = genericUserDeliveryPoint.LegacyImported;
        }
    }
}
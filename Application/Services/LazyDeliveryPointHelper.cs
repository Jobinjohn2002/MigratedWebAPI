using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDeliveryPointHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(DeliveryPoint concreteDeliveryPoint, DeliveryPoint genericDeliveryPoint)
        {
            concreteDeliveryPoint.DeliveryPointId = genericDeliveryPoint.DeliveryPointId;
            concreteDeliveryPoint.AddressId = genericDeliveryPoint.AddressId;
            concreteDeliveryPoint.ArchivedUserId = genericDeliveryPoint.ArchivedUserId;
            concreteDeliveryPoint.CustomerDefinitionId = genericDeliveryPoint.CustomerDefinitionId;
            concreteDeliveryPoint.DeliveryTypeId = genericDeliveryPoint.DeliveryTypeId;
            concreteDeliveryPoint.DirectorateId = genericDeliveryPoint.DirectorateId;
            concreteDeliveryPoint.Text = genericDeliveryPoint.Text;
            concreteDeliveryPoint.Archived = genericDeliveryPoint.Archived;
            concreteDeliveryPoint.StockLocation = genericDeliveryPoint.StockLocation;
            concreteDeliveryPoint.RequiresProof = genericDeliveryPoint.RequiresProof;
            concreteDeliveryPoint.LegacyId = genericDeliveryPoint.LegacyId;
            concreteDeliveryPoint.LegacyFacilityOrigin = genericDeliveryPoint.LegacyFacilityOrigin;
            concreteDeliveryPoint.LegacyImported = genericDeliveryPoint.LegacyImported;
            concreteDeliveryPoint.LocationId = genericDeliveryPoint.LocationId;
            concreteDeliveryPoint.RestrictedForBatchTag = genericDeliveryPoint.RestrictedForBatchTag;
            concreteDeliveryPoint.CreatePhysicalDeliveryNote = genericDeliveryPoint.CreatePhysicalDeliveryNote;
            concreteDeliveryPoint.RestrictedForTrolleys = genericDeliveryPoint.RestrictedForTrolleys;
        }
    }
}
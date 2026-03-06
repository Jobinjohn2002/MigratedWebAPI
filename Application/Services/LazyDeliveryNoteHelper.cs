using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyDeliveryNoteHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(DeliveryNote concreteDeliveryNote, DeliveryNote genericDeliveryNote)
        {
            concreteDeliveryNote.DeliveryNoteId = genericDeliveryNote.DeliveryNoteId;
            concreteDeliveryNote.DeliveryPointId = genericDeliveryNote.DeliveryPointId;
            concreteDeliveryNote.FacilityId = genericDeliveryNote.FacilityId;
            concreteDeliveryNote.PrintedUserId = genericDeliveryNote.PrintedUserId;
            concreteDeliveryNote.ExternalId = genericDeliveryNote.ExternalId;
            concreteDeliveryNote.Printed = genericDeliveryNote.Printed;
            concreteDeliveryNote.PrintedStatus = genericDeliveryNote.PrintedStatus;
            concreteDeliveryNote.LegacyFacilityOrigin = genericDeliveryNote.LegacyFacilityOrigin;
            concreteDeliveryNote.LegacyImported = genericDeliveryNote.LegacyImported;
            concreteDeliveryNote.PhysicalCopyCreated = genericDeliveryNote.PhysicalCopyCreated;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyTurnaroundHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(Turnaround concreteTurnaround, Turnaround genericTurnaround)
        {
            concreteTurnaround.TurnaroundId = genericTurnaround.TurnaroundId;
            concreteTurnaround.ContainerInstanceId = genericTurnaround.ContainerInstanceId;
            concreteTurnaround.ContainerMasterId = genericTurnaround.ContainerMasterId;
            concreteTurnaround.CreatedUserId = genericTurnaround.CreatedUserId;
            concreteTurnaround.DeliveryNoteId = genericTurnaround.DeliveryNoteId;
            concreteTurnaround.DeliveryPointId = genericTurnaround.DeliveryPointId;
            concreteTurnaround.FacilityId = genericTurnaround.FacilityId;
            concreteTurnaround.InvoiceLineId = genericTurnaround.InvoiceLineId;
            concreteTurnaround.ItemInstanceId = genericTurnaround.ItemInstanceId;
            concreteTurnaround.ParentTurnaroundId = genericTurnaround.ParentTurnaroundId;
            concreteTurnaround.ServiceRequirementId = genericTurnaround.ServiceRequirementId;
            concreteTurnaround.StoragePointId = genericTurnaround.StoragePointId;
            concreteTurnaround.ExternalId = genericTurnaround.ExternalId;
            concreteTurnaround.Created = genericTurnaround.Created;
            concreteTurnaround.Expiry = genericTurnaround.Expiry;
            concreteTurnaround.LegacyId = genericTurnaround.LegacyId;
            concreteTurnaround.LegacyFacilityOrigin = genericTurnaround.LegacyFacilityOrigin;
            concreteTurnaround.LegacyImported = genericTurnaround.LegacyImported;
            concreteTurnaround.StartEventId = genericTurnaround.StartEventId;
            concreteTurnaround.LastEventId = genericTurnaround.LastEventId;
            concreteTurnaround.SterileExpiryDate = genericTurnaround.SterileExpiryDate;
        }
    }
}
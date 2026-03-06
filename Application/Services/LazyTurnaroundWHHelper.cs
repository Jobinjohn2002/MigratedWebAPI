using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class LazyTurnaroundWHHelper
    {
        /// <summary>
        /// PopulateConcrete operation
        /// </summary>
        public void PopulateConcrete(TurnaroundWH concreteTurnaroundWH, TurnaroundWH genericTurnaroundWH)
        {
            concreteTurnaroundWH.TurnaroundWHId = genericTurnaroundWH.TurnaroundWHId;
            concreteTurnaroundWH.ContainerMasterDefinitionId = genericTurnaroundWH.ContainerMasterDefinitionId;
            concreteTurnaroundWH.ContainerMasterId = genericTurnaroundWH.ContainerMasterId;
            concreteTurnaroundWH.ContainerMasterExternalId = genericTurnaroundWH.ContainerMasterExternalId;
            concreteTurnaroundWH.ContainerMasterName = genericTurnaroundWH.ContainerMasterName;
            concreteTurnaroundWH.ContainerMasterBaseItemTypeId = genericTurnaroundWH.ContainerMasterBaseItemTypeId;
            concreteTurnaroundWH.ContainerMasterBaseItemType = genericTurnaroundWH.ContainerMasterBaseItemType;
            concreteTurnaroundWH.ContainerMasterItemTypeId = genericTurnaroundWH.ContainerMasterItemTypeId;
            concreteTurnaroundWH.ContainerMasterItemType = genericTurnaroundWH.ContainerMasterItemType;
            concreteTurnaroundWH.ContainerInstanceId = genericTurnaroundWH.ContainerInstanceId;
            concreteTurnaroundWH.ServiceRequirementId = genericTurnaroundWH.ServiceRequirementId;
            concreteTurnaroundWH.ServiceRequirementName = genericTurnaroundWH.ServiceRequirementName;
            concreteTurnaroundWH.DeliveryPointId = genericTurnaroundWH.DeliveryPointId;
            concreteTurnaroundWH.DeliveryPointName = genericTurnaroundWH.DeliveryPointName;
            concreteTurnaroundWH.CustomerDefinitionId = genericTurnaroundWH.CustomerDefinitionId;
            concreteTurnaroundWH.CustomerId = genericTurnaroundWH.CustomerId;
            concreteTurnaroundWH.CustomerName = genericTurnaroundWH.CustomerName;
            concreteTurnaroundWH.FacilityId = genericTurnaroundWH.FacilityId;
            concreteTurnaroundWH.FacilityName = genericTurnaroundWH.FacilityName;
            concreteTurnaroundWH.DeliveryNoteId = genericTurnaroundWH.DeliveryNoteId;
            concreteTurnaroundWH.DeliveryNoteExternalId = genericTurnaroundWH.DeliveryNoteExternalId;
            concreteTurnaroundWH.StartEventTime = genericTurnaroundWH.StartEventTime;
            concreteTurnaroundWH.LastEventId = genericTurnaroundWH.LastEventId;
            concreteTurnaroundWH.LastEventTypeId = genericTurnaroundWH.LastEventTypeId;
            concreteTurnaroundWH.LastEventName = genericTurnaroundWH.LastEventName;
            concreteTurnaroundWH.LastEventTime = genericTurnaroundWH.LastEventTime;
            concreteTurnaroundWH.NextEventTypeId = genericTurnaroundWH.NextEventTypeId;
            concreteTurnaroundWH.NextEventName = genericTurnaroundWH.NextEventName;
            concreteTurnaroundWH.Expiry = genericTurnaroundWH.Expiry;
            concreteTurnaroundWH.BatchId = genericTurnaroundWH.BatchId;
            concreteTurnaroundWH.BatchExternalId = genericTurnaroundWH.BatchExternalId;
            concreteTurnaroundWH.TurnaroundId = genericTurnaroundWH.TurnaroundId;
            concreteTurnaroundWH.TurnaroundExternalId = genericTurnaroundWH.TurnaroundExternalId;
            concreteTurnaroundWH.ParentTurnaroundId = genericTurnaroundWH.ParentTurnaroundId;
            concreteTurnaroundWH.HasChildren = genericTurnaroundWH.HasChildren;
            concreteTurnaroundWH.LegacyFacilityOrigin = genericTurnaroundWH.LegacyFacilityOrigin;
            concreteTurnaroundWH.LegacyImported = genericTurnaroundWH.LegacyImported;
            concreteTurnaroundWH.SterileExpiryDate = genericTurnaroundWH.SterileExpiryDate;

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface ITurnaroundWH : IEntityData
	{		
		int TurnaroundWHId { get; set; }
			
		int ContainerMasterDefinitionId { get; set; }
			
		int ContainerMasterId { get; set; }
			
		string ContainerMasterExternalId { get; set; }
			
		string ContainerMasterName { get; set; }
			
		short ContainerMasterBaseItemTypeId { get; set; }
			
		string ContainerMasterBaseItemType { get; set; }
			
		short ContainerMasterItemTypeId { get; set; }
			
		string ContainerMasterItemType { get; set; }
			
		int? ContainerInstanceId { get; set; }
			
		int ServiceRequirementId { get; set; }
			
		string ServiceRequirementName { get; set; }
			
		int DeliveryPointId { get; set; }
			
		string DeliveryPointName { get; set; }
			
		int CustomerDefinitionId { get; set; }
			
		int CustomerId { get; set; }
			
		string CustomerName { get; set; }
			
		short FacilityId { get; set; }
			
		string FacilityName { get; set; }
			
		int? DeliveryNoteId { get; set; }
			
		int? DeliveryNoteExternalId { get; set; }
			
		DateTime? StartEventTime { get; set; }
			
		int? LastEventId { get; set; }
			
		short? LastEventTypeId { get; set; }
			
		string LastEventName { get; set; }
			
		DateTime? LastEventTime { get; set; }
			
		short? NextEventTypeId { get; set; }
			
		string NextEventName { get; set; }
			
		DateTime Expiry { get; set; }
			
		int? BatchId { get; set; }
			
		string BatchExternalId { get; set; }
			
		int TurnaroundId { get; set; }
			
		long TurnaroundExternalId { get; set; }
			
		int? ParentTurnaroundId { get; set; }
			
		bool? HasChildren { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		DateTime? SterileExpiryDate { get; set; }
	}
}
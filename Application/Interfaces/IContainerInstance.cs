using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IContainerInstance : IEntityData
	{		
		int ContainerInstanceId { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		int ContainerMasterDefinitionId { get; set; }
			
		int CreatedUserId { get; set; }
			
		int DeliveryPointId { get; set; }
			
		int ServiceRequirementDefinitionId { get; set; }
			
		short FacilityId { get; set; }
			
		DateTime Created { get; set; }
			
		DateTime? Archived { get; set; }
			
		int TurnaroundCount { get; set; }
			
		int? LegacyId { get; set; }
			
		string LegacyExternalId { get; set; }
			
		bool? LegacyIdReplaced { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		string Text { get; set; }
			
		int? Giai { get; set; }
			
		string GS1ProductCode { get; set; }
			
		short? QuarantineEventTypeId { get; set; }
			
		short? QuarantineReasonId { get; set; }
			
		short? Linear1dBarcodeId { get; set; }
			
		short? Datamatrix2dBarcodeId { get; set; }
			
		short? QALabelProductCodeId { get; set; }
			
		int TurnaroundWarningCount { get; set; }
			
		int? CurrentProcessEventId { get; set; }
			
		int? CurrentLocationId { get; set; }
			
		int? ModifiedById { get; set; }
			
		DateTime? ModifiedByDate { get; set; }
			
		bool IsIdentifiable { get; set; }
			
		bool WeighingRequired { get; set; }
			
		string AdditionalInfo { get; set; }
	}
}
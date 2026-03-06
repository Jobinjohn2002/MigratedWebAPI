using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IDefect : IEntityData
	{		
		int DefectId { get; set; }
			
		int? ContainerInstanceId { get; set; }
			
		int CreatedUserId { get; set; }
			
		byte DefectClassificationId { get; set; }
			
		byte DefectResponsibilityId { get; set; }
			
		byte DefectSeverityId { get; set; }
			
		byte DefectStatusId { get; set; }
			
		int DeliveryPointId { get; set; }
			
		int? ImmediateActionUserId { get; set; }
			
		int? LongTermActionUserId { get; set; }
			
		int? ReviewUserId { get; set; }
			
		int? TurnaroundId { get; set; }
			
		int? SignedForSynergyUserId { get; set; }
			
		string ExternalId { get; set; }
			
		DateTime Raised { get; set; }
			
		DateTime Received { get; set; }
			
		string ReportingDepartment { get; set; }
			
		string ReporterUserName { get; set; }
			
		string ReporterUserPosition { get; set; }
			
		string ItemName { get; set; }
			
		short GeneralFaultCount { get; set; }
			
		string OtherDetails { get; set; }
			
		string ImmediateAction { get; set; }
			
		DateTime? ImmediateActionDate { get; set; }
			
		string LongTermAction { get; set; }
			
		DateTime? LongTermActionDate { get; set; }
			
		string SignedForTrustUserName { get; set; }
			
		string ReviewInformation { get; set; }
			
		DateTime? Reviewed { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		bool QuarantineAfterWash { get; set; }
			
		int? ContainerMasterId { get; set; }
			
		DateTime? IncidentDate { get; set; }
			
		int? DefectSourceId { get; set; }
			
		int? UnTrackedProductId { get; set; }
			
		int? CustomSeverityId { get; set; }
			
		int? CustomClassificationId { get; set; }
	}
}
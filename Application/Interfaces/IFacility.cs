using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IFacility : IEntityData
	{		
		short FacilityId { get; set; }
			
		int AddressId { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		string Text { get; set; }
			
		string EmailAddress { get; set; }
			
		DateTime? Archived { get; set; }
			
		byte UTCOffset { get; set; }
			
		byte DLSOffset { get; set; }
			
		string SubjectText { get; set; }
			
		string BodyText { get; set; }
			
		bool IndependentQualityAssuranceCheck { get; set; }
			
		bool WashRelease { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		bool? PrintSecondaryLabel { get; set; }
			
		bool? ItemAliasEnabled { get; set; }
			
		bool? BiologicalIndicatorEnabled { get; set; }
			
		int OwnerId { get; set; }
			
		bool FacilityCatalogueEnabled { get; set; }
			
		bool TenancyCatalogueEnabled { get; set; }
			
		bool GlobalCatalogueEnabled { get; set; }
			
		short ProcessingModeId { get; set; }
			
		int ModifiedByUserId { get; set; }
			
		DateTime ModifiedDate { get; set; }
			
		bool IsFDAEnabled { get; set; }
			
		bool IsPerformancePauseEnabled { get; set; }
			
		int ClockingConfigurationTypeId { get; set; }
			
		bool PrintSingleSecondaryLabel { get; set; }
			
		bool MatchReferenceWeights { get; set; }
			
		decimal PreWashToleranceKg { get; set; }
			
		decimal PostWashToleranceKg { get; set; }
			
		int DelayedBiTestTypeId { get; set; }
			
		bool ScanAllIdentifiedItemsMarksAsPacked { get; set; }
			
		bool OverrideCooldownContainer { get; set; }
			
		byte FacilityTypeId { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
	
namespace SynergyApplicationFrameworkApi.Application.Interfaces
{   
	public partial interface IContainerMaster : IEntityData
	{		
		int ContainerMasterId { get; set; }
			
		int ChargableBatchCycleId { get; set; }
			
		int CategoryId { get; set; }
			
		short ComplexityId { get; set; }
			
		int ContainerMasterDefinitionId { get; set; }
			
		int CreatedUserId { get; set; }
			
		byte ItemStatusId { get; set; }
			
		short ItemTypeId { get; set; }
			
		byte MachineTypeId { get; set; }
			
		short SpecialityId { get; set; }
			
		string ExternalId { get; set; }
			
		string Text { get; set; }
			
		short Revision { get; set; }
			
		DateTime Created { get; set; }
			
		int IPOH { get; set; }
			
		string ManufacturersReference { get; set; }
			
		byte NumberOfLabels { get; set; }
			
		bool IndependentQualityAssuranceCheck { get; set; }
			
		bool TrackIndividualInstruments { get; set; }
			
		int? LegacyId { get; set; }
			
		int? LegacyCustomerId { get; set; }
			
		int? LegacyFacilityOrigin { get; set; }
			
		DateTime? LegacyImported { get; set; }
			
		byte? PrinterTypeId { get; set; }
			
		string Gtin { get; set; }
			
		int? ArchivedUserId { get; set; }
			
		DateTime? Archived { get; set; }
			
		int? PinRequestReasonId { get; set; }
			
		bool? BiologicalIndicatorEnabled { get; set; }
			
		int LabourLevelId { get; set; }
			
		DateTime? LastChangeAffectingWeightTime { get; set; }
			
		int? CoolingTime { get; set; }
	}
}
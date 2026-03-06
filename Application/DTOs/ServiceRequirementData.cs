using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class ServiceRequirementData
	{
        public ServiceRequirementData()
        {
        }

        public ServiceRequirementData(IServiceRequirement genericObj, IList<ServiceRequirementData> children, short[] itemTypes)
			: this(genericObj)
		{
			Children = children;
			ItemTypes = itemTypes;
		}

		public ServiceRequirementData(int? archivedUserId, int createdUserId, byte expiryCalculationTypeId, int serviceRequirementDefinitionId, string text, short revision, short turnaroundMinutes, double margin, bool marginAppliesToReprocessing, bool marginAppliesToSingleUse, bool marginAppliesToOther, short graceMinutes, DateTime effective, DateTime created, DateTime? archived, int? legacyId, int? legacyFacilityOrigin, DateTime? legacyImported)
			: this(0, archivedUserId,createdUserId, expiryCalculationTypeId, serviceRequirementDefinitionId, text, revision, turnaroundMinutes, margin, marginAppliesToReprocessing, marginAppliesToSingleUse, marginAppliesToOther, graceMinutes, effective, created, archived, legacyId, legacyFacilityOrigin, legacyImported,false)
		{
		}

		public ServiceRequirementData(int? archivedUserId, int createdUserId, byte expiryCalculationTypeId, int serviceRequirementDefinitionId, string text, short revision, short turnaroundMinutes, double margin, bool marginAppliesToReprocessing, bool marginAppliesToSingleUse, bool marginAppliesToOther, short graceMinutes, DateTime effective, DateTime created, DateTime? archived, int? legacyId, int? legacyFacilityOrigin, DateTime? legacyImported,short[] itemTypes)
			: this(0, archivedUserId, createdUserId, expiryCalculationTypeId, serviceRequirementDefinitionId, text, revision, turnaroundMinutes, margin, marginAppliesToReprocessing, marginAppliesToSingleUse, marginAppliesToOther, graceMinutes, effective, created, archived, legacyId, legacyFacilityOrigin, legacyImported, false)
		{
			ItemTypes = itemTypes;
		}

		public ServiceRequirementData(int? archivedUserId, int createdUserId, byte expiryCalculationTypeId, int serviceRequirementDefinitionId, string text, short revision, short turnaroundMinutes, double margin, bool marginAppliesToReprocessing, bool marginAppliesToSingleUse, bool marginAppliesToOther, short graceMinutes, DateTime effective, DateTime created, DateTime? archived, int? legacyId, int? legacyFacilityOrigin, DateTime? legacyImported,IList<ServiceRequirementData> children, short[] itemTypes)
			: this(0, archivedUserId, createdUserId, expiryCalculationTypeId, serviceRequirementDefinitionId, text, revision, turnaroundMinutes, margin, marginAppliesToReprocessing, marginAppliesToSingleUse, marginAppliesToOther, graceMinutes, effective, created, archived, legacyId, legacyFacilityOrigin, legacyImported, false)
		{
			ItemTypes = itemTypes;
			Children = children;
		}

        public ServiceRequirementData(int? archivedUserId, int createdUserId, byte expiryCalculationTypeId, int serviceRequirementDefinitionId, string text, short revision, short turnaroundMinutes, double margin, bool marginAppliesToReprocessing, bool marginAppliesToSingleUse, bool marginAppliesToOther, short graceMinutes, DateTime effective, DateTime created, DateTime? archived, int? legacyId, int? legacyFacilityOrigin, DateTime? legacyImported, IList<ServiceRequirementData> children, short[] itemTypes, bool isFastTrack)
            : this(0, archivedUserId, createdUserId, expiryCalculationTypeId, serviceRequirementDefinitionId, text, revision, turnaroundMinutes, margin, marginAppliesToReprocessing, marginAppliesToSingleUse, marginAppliesToOther, graceMinutes, effective, created, archived, legacyId, legacyFacilityOrigin, legacyImported, isFastTrack)
        {
            ItemTypes = itemTypes;
            Children = children;
        }
		public ServiceRequirementData(IServiceRequirement genericObj, short[] itemTypes)
			: this(genericObj, null, itemTypes)
		{
		}
		/// <summary>
		/// Gets or sets Children
		/// </summary>
		public IList<ServiceRequirementData> Children { get; set; }
        public short[] ItemTypes { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeList
        /// </summary>
        public List<ItemTypeData> ItemTypeList { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// The number of turnarounds associated with this event type
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundCount
        /// </summary>
        public int TurnaroundCount { get; set; }
    }
}
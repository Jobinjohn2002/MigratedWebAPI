using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SynergyApplicationFrameworkApi.Application.DTOs
{
	public partial class LabourBandData
	{
		public LabourBandData(string text, decimal cost, short maximumComponents, DateTime created, int createdUserId, DateTime? archived, int? archivedUserId, int customerId, int? legacyInternalId)
			: this(0, text, cost, maximumComponents, created, createdUserId, archived, archivedUserId, customerId, legacyInternalId)
		{
		}

		public LabourBandData(string text, decimal cost, short maximumComponents, DateTime created, int createdUserId, DateTime? archived, int? archivedUserId, int customerId, short[] itemTypes, int? legacyInternalId)
			: this(0, text, cost, maximumComponents, created, createdUserId, archived, archivedUserId, customerId, legacyInternalId)
		{
			SetItemTypes(itemTypes);
		}

		public LabourBandData(int labourBandId, string text, decimal cost, short maximumComponents, DateTime created, int createdUserId, DateTime? archived, int? archivedUserId, int customerId, short[] itemTypes, int? legacyInternalId)
			: this(labourBandId, text, cost, maximumComponents, created, createdUserId, archived, archivedUserId, customerId, legacyInternalId)
		{
			SetItemTypes(itemTypes);
		}
		private short[] __itemTypes;

		public short[] GetItemTypes()
		{
			return __itemTypes;
		}

		/// <summary>
		/// SetItemTypes operation
		/// </summary>
		public void SetItemTypes(short[] value)
		{
			__itemTypes = value;
		}
	}
}
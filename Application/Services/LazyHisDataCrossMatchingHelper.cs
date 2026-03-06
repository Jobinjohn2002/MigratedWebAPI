using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyHisDataCrossMatchingHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(HisDataCrossMatching concreteHisDataCrossMatching, HisDataCrossMatching genericHisDataCrossMatching)
        {
					
			concreteHisDataCrossMatching.HisDataCrossMatchingId = genericHisDataCrossMatching.HisDataCrossMatchingId;			
			concreteHisDataCrossMatching.CustomerDefinitionId = genericHisDataCrossMatching.CustomerDefinitionId;			
			concreteHisDataCrossMatching.HisDataCrossMatchingTypeId = genericHisDataCrossMatching.HisDataCrossMatchingTypeId;			
			concreteHisDataCrossMatching.HisIdentifier = genericHisDataCrossMatching.HisIdentifier;			
			concreteHisDataCrossMatching.HisResourceName = genericHisDataCrossMatching.HisResourceName;			
			concreteHisDataCrossMatching.Ignore = genericHisDataCrossMatching.Ignore;			
			concreteHisDataCrossMatching.SynergyTrakId = genericHisDataCrossMatching.SynergyTrakId;			
			concreteHisDataCrossMatching.CreatedByUserId = genericHisDataCrossMatching.CreatedByUserId;			
			concreteHisDataCrossMatching.CreatedDate = genericHisDataCrossMatching.CreatedDate;			
			concreteHisDataCrossMatching.Archived = genericHisDataCrossMatching.Archived;			
			concreteHisDataCrossMatching.ArchivedUserId = genericHisDataCrossMatching.ArchivedUserId;			
			concreteHisDataCrossMatching.ModifiedByUserId = genericHisDataCrossMatching.ModifiedByUserId;			
			concreteHisDataCrossMatching.ModifiedDate = genericHisDataCrossMatching.ModifiedDate;
		}
	}
}
		
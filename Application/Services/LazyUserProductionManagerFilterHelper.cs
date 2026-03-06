using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyUserProductionManagerFilterHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(UserProductionManagerFilter concreteUserProductionManagerFilter, UserProductionManagerFilter genericUserProductionManagerFilter)
        {
					
			concreteUserProductionManagerFilter.UserProductionManagerFilterId = genericUserProductionManagerFilter.UserProductionManagerFilterId;			
			concreteUserProductionManagerFilter.UserId = genericUserProductionManagerFilter.UserId;			
			concreteUserProductionManagerFilter.FacilityId = genericUserProductionManagerFilter.FacilityId;			
			concreteUserProductionManagerFilter.Name = genericUserProductionManagerFilter.Name;			
			concreteUserProductionManagerFilter.FilterJSON = genericUserProductionManagerFilter.FilterJSON;
		}
	}
}
		
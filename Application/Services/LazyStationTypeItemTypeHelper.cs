using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyStationTypeItemTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(StationTypeItemType concreteStationTypeItemType, StationTypeItemType genericStationTypeItemType)
        {
					
			concreteStationTypeItemType.StationTypeItemTypeId = genericStationTypeItemType.StationTypeItemTypeId;			
			concreteStationTypeItemType.StationTypeId = genericStationTypeItemType.StationTypeId;			
			concreteStationTypeItemType.ItemTypeId = genericStationTypeItemType.ItemTypeId;			
			concreteStationTypeItemType.Assigned = genericStationTypeItemType.Assigned;
		}
	}
}
		
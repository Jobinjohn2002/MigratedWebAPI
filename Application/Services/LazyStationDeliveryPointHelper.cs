using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyStationDeliveryPointHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(ref StationDeliveryPoint concreteStationDeliveryPoint, ref IStationDeliveryPoint genericStationDeliveryPoint)
        {
					
			concreteStationDeliveryPoint.StationDeliveryPointId = genericStationDeliveryPoint.StationDeliveryPointId;			
			concreteStationDeliveryPoint.DeliveryPoint_DeliveryPointId = genericStationDeliveryPoint.DeliveryPoint_DeliveryPointId;			
			concreteStationDeliveryPoint.Station_StationId = genericStationDeliveryPoint.Station_StationId;
		}
	}
}
		
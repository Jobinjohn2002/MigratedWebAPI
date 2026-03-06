using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFailedScanHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FailedScan concreteFailedScan, FailedScan genericFailedScan)
        {
					
			concreteFailedScan.FailedScanId = genericFailedScan.FailedScanId;			
			concreteFailedScan.Input = genericFailedScan.Input;			
			concreteFailedScan.ScanTypeId = genericFailedScan.ScanTypeId;			
			concreteFailedScan.StationId = genericFailedScan.StationId;			
			concreteFailedScan.LocationId = genericFailedScan.LocationId;			
			concreteFailedScan.EventTypeId = genericFailedScan.EventTypeId;			
			concreteFailedScan.CreatedDate = genericFailedScan.CreatedDate;			
			concreteFailedScan.CreatedByUserId = genericFailedScan.CreatedByUserId;
		}
	}
}
		
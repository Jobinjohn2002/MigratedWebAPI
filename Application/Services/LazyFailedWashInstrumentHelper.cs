using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFailedWashInstrumentHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FailedWashInstrument concreteFailedWashInstrument, FailedWashInstrument genericFailedWashInstrument)
        {
					
			concreteFailedWashInstrument.FailedWashInstrumentId = genericFailedWashInstrument.FailedWashInstrumentId;			
			concreteFailedWashInstrument.FailedWashId = genericFailedWashInstrument.FailedWashId;			
			concreteFailedWashInstrument.ItemMasterId = genericFailedWashInstrument.ItemMasterId;			
			concreteFailedWashInstrument.Quantity = genericFailedWashInstrument.Quantity;
		}
	}
}
		
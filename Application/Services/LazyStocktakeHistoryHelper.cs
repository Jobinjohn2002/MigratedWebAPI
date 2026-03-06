using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyStocktakeHistoryHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(StocktakeHistory concreteStocktakeHistory, StocktakeHistory genericStocktakeHistory)
        {
					
			concreteStocktakeHistory.StocktakeHistoryId = genericStocktakeHistory.StocktakeHistoryId;			
			concreteStocktakeHistory.Created = genericStocktakeHistory.Created;			
			concreteStocktakeHistory.UserID = genericStocktakeHistory.UserID;			
			concreteStocktakeHistory.TurnaroundId = genericStocktakeHistory.TurnaroundId;			
			concreteStocktakeHistory.LocationId = genericStocktakeHistory.LocationId;			
			concreteStocktakeHistory.StocktakeActivityId = genericStocktakeHistory.StocktakeActivityId;
		}
	}
}
		
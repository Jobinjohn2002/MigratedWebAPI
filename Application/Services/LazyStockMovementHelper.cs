using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyStockMovementHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(StockMovement concreteStockMovement, StockMovement genericStockMovement)
        {
					
			concreteStockMovement.StockMovementId = genericStockMovement.StockMovementId;			
			concreteStockMovement.LocationId = genericStockMovement.LocationId;			
			concreteStockMovement.ItemMasterDefinitionId = genericStockMovement.ItemMasterDefinitionId;			
			concreteStockMovement.Quantity = genericStockMovement.Quantity;			
			concreteStockMovement.StockTransactionId = genericStockMovement.StockTransactionId;
		}
	}
}
		
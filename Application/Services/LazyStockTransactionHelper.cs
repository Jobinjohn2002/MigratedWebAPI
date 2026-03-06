using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyStockTransactionHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(StockTransaction concreteStockTransaction, IStockTransaction genericStockTransaction)
        {	
			concreteStockTransaction.StockTransactionId = genericStockTransaction.StockTransactionId;			
			concreteStockTransaction.StockTransactionTypeId = genericStockTransaction.StockTransactionTypeId;			
			concreteStockTransaction.CreatedUserId = genericStockTransaction.CreatedUserId;			
			concreteStockTransaction.ReferenceNo = genericStockTransaction.ReferenceNo;			
			concreteStockTransaction.Created = genericStockTransaction.Created;
		}
	}
}
		
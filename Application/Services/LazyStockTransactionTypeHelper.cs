using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyStockTransactionTypeHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(StockTransactionType concreteStockTransactionType, StockTransactionType genericStockTransactionType)
        {
					
			concreteStockTransactionType.StockTransactionTypeId = genericStockTransactionType.StockTransactionTypeId;			
			concreteStockTransactionType.Text = genericStockTransactionType.Text;
		}
	}
}
		
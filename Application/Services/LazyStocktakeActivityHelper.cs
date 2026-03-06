using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyStocktakeActivityHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(StocktakeActivity concreteStocktakeActivity, StocktakeActivity genericStocktakeActivity)
        {
					
			concreteStocktakeActivity.StocktakeActivityId = genericStocktakeActivity.StocktakeActivityId;			
			concreteStocktakeActivity.Text = genericStocktakeActivity.Text;
		}
	}
}
		
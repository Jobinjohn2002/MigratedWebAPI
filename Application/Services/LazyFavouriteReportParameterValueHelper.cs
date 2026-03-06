using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFavouriteReportParameterValueHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FavouriteReportParameterValue concreteFavouriteReportParameterValue, FavouriteReportParameterValue genericFavouriteReportParameterValue)
        {
					
			concreteFavouriteReportParameterValue.FavouriteReportParameterValueId = genericFavouriteReportParameterValue.FavouriteReportParameterValueId;			
			concreteFavouriteReportParameterValue.Value = genericFavouriteReportParameterValue.Value;			
			concreteFavouriteReportParameterValue.FavouriteReportParameterId = genericFavouriteReportParameterValue.FavouriteReportParameterId;
		}
	}
}
		
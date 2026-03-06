using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFavouriteReportParameterHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FavouriteReportParameter concreteFavouriteReportParameter, FavouriteReportParameter genericFavouriteReportParameter)
        {
					
			concreteFavouriteReportParameter.FavouriteReportParameterId = genericFavouriteReportParameter.FavouriteReportParameterId;			
			concreteFavouriteReportParameter.FavouriteReportId = genericFavouriteReportParameter.FavouriteReportId;			
			concreteFavouriteReportParameter.Name = genericFavouriteReportParameter.Name;			
		}
	}
}
		
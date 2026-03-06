using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{   
	public partial class LazyFavouriteReportHelper
	{
		/// <summary>
		/// PopulateConcrete operation
		/// </summary>
		public void PopulateConcrete(FavouriteReport concreteFavouriteReport, FavouriteReport genericFavouriteReport)
        {
					
			concreteFavouriteReport.FavouriteReportId = genericFavouriteReport.FavouriteReportId;			
			concreteFavouriteReport.UserId = genericFavouriteReport.UserId;			
			concreteFavouriteReport.ReportId = genericFavouriteReport.ReportId;			
			concreteFavouriteReport.Name = genericFavouriteReport.Name;			
			concreteFavouriteReport.OutputTypeId = genericFavouriteReport.OutputTypeId;			
			concreteFavouriteReport.Description = genericFavouriteReport.Description;
		}
	}
}
		
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class FavouriteReportRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public FavouriteReport Get(int favouriteReportId)
        {
            return Repository.Find(favouriteReport => favouriteReport.FavouriteReportId == favouriteReportId).FirstOrDefault();
        }
	}
}
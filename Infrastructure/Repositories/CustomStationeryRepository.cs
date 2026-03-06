using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class CustomStationeryRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public CustomStationery Get(int customStationeryId)
        {
            return Repository.Find(customStationery => customStationery.CustomStationeryId == customStationeryId).FirstOrDefault();
        }
	}
}
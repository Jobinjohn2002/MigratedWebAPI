using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class CustomStationeryLogicRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public CustomStationeryLogic Get(int customStationeryLogicId)
        {
            return Repository.Find(customStationeryLogic => customStationeryLogic.CustomStationeryLogicId == customStationeryLogicId).FirstOrDefault();
        }
	}
}
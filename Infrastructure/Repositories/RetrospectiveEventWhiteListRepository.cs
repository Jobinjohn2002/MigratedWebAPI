using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class RetrospectiveEventWhiteListRepository
	{
		/// <summary>
		/// Get operation
		/// </summary>
		public RetrospectiveEventWhiteList Get(int retrospectiveEventWhiteListId)
        {
            return Repository.Find(retrospectiveEventWhiteList => retrospectiveEventWhiteList.RetrospectiveEventWhiteListID == retrospectiveEventWhiteListId).FirstOrDefault();
        }

        /// <summary>
        /// GetEventWhiteListByItemTypeId operation
        /// </summary>
        public IList<RetrospectiveEventWhiteList> GetEventWhiteListByItemTypeId(int itemTypeId)
        {
            return Repository.Find(retrospectiveEventWhiteList => retrospectiveEventWhiteList.ItemTypeId == itemTypeId).ToList();
        }

    }
}
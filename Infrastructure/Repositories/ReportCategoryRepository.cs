using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{   
	public partial class ReportCategoryRepository
	{
        /// <summary>
        /// Get operation
        /// </summary>
        public ReportCategory Get(int reportCategoryId)
        {
            return Repository.Find(reportCategory => reportCategory.ReportCategoryId == reportCategoryId).FirstOrDefault();
        }

        /// <summary>
        /// ReadAllReportCategories operation
        /// </summary>
        public IQueryable<ReportCategory> ReadAllReportCategories()
        {
            return Repository.Find(rc => rc.IsLive);
        }

        /// <summary>
        /// ReadNestedReportCategory operation
        /// </summary>
        public IQueryable<ReportCategory> ReadNestedReportCategory()
        {
            return Repository.Find(rc => rc.IsLive && rc.ParentId == null);
        }
       
	}
}
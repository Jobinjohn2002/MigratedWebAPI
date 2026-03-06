using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class ReportRepository
    {
        /// <summary>
        /// Gets the specified report.
        /// </summary>
        /// <param name="reportId">The report id.</param>
        /// <summary>
        /// Get operation
        /// </summary>
        public Report Get(short reportId)
        {
            return Repository.Find(report => report.ReportId == reportId).FirstOrDefault();
        }

        /// <summary>
        /// Reads all live reports that a user can have access to via Tenancy or Facility level access.
        /// </summary>
        /// <param name="userId">The id of the User</param>
        /// <summary>
        /// GetAllReports operation
        /// </summary>
        public IQueryable<Report> GetAllReports(int userId)
        {
            var context = (OperativeModelContainer)Repository.UnitOfWork.Context;

            var tenancyOwnerIds = from t in context.Tenancy
                                  join u in context.User on t.TenancyId equals u.TenancyId
                                  where u.UserId == userId && t.OwnerId != null
                                  select (int)t.OwnerId;

            var facilityOwnerIds = from uf in context.UserFacility
                                   join f in context.Facility on uf.FacilityId equals f.FacilityId
                                   where uf.UserId == userId
                                   select f.OwnerId;

            var ownerIds = facilityOwnerIds.Concat(tenancyOwnerIds);

            var reports = (from r in context.Report
                          join ora in context.OwnerReportAccess on r.ReportId equals ora.ReportId
                          from t in context.Tenancy.Where(t => t.OwnerId == ora.OwnerId).DefaultIfEmpty()
                          from f in context.Facility.Where(f => f.OwnerId == ora.OwnerId).DefaultIfEmpty()
                          where r.IsLive == true
                          && ownerIds.Contains(ora.OwnerId)
                          select r).Distinct();

            return reports;
        }

        /// <summary>
        /// Gets all reports by report category id.
        /// </summary>
        /// <param name="reportCategoryId">The report category uid.</param>
        /// <summary>
        /// GetAllReportsByReportCategoryId operation
        /// </summary>
        public IQueryable<Report> GetAllReportsByReportCategoryId(int reportCategoryId)
        {
            return Repository.Find(report => report.ReportCategoryId == reportCategoryId && report.IsLive);
        }

        /// <summary>
        /// Gets all reports under the selected parent
        /// </summary>
        /// <param name="reportCategoryId">parent category id </param>
        /// <summary>
        /// GetReportsByParentReportCategory operation
        /// </summary>
        public IQueryable<Report> GetReportsByParentReportCategory(int reportCategoryId)
        {
            var reportCategoryRepository = ReportCategoryRepository.New(Repository.UnitOfWork);
            IEnumerable<int> reportcategoryints = GetChildrenReports(reportCategoryRepository.All().Where((ctgy => ctgy.IsLive)), reportCategoryId, new List<int> { reportCategoryId });
            var reports = Repository.All();

            return (from report in reports.Where(rpt => rpt.IsLive)
                    join categoryuid in reportcategoryints on report.ReportCategoryId equals categoryuid
                    select report).Distinct().OrderBy(i => i.Text);
        }

        /// <summary>
        /// Gets Child Reports using Category Ids
        /// </summary>
        private IEnumerable<int> GetChildrenReports(IQueryable<ReportCategory> reportCategories, int categoryId, List<int> ints)
        {
            if (reportCategories.Where(T => T.ParentId == categoryId).Count() > 0)
            {
                var children = reportCategories.Where(T => T.ParentId == categoryId).ToList();
                foreach (var childcategory in children.Where(childcategory => reportCategories.Where(T => T.ParentId == childcategory.ReportCategoryId || T.ReportCategoryId == childcategory.ReportCategoryId).Count() > 0))
                {
                    ints.Add(childcategory.ReportCategoryId);
                    GetChildrenReports(reportCategories, childcategory.ReportCategoryId, ints);
                }
            }
            return ints;
        }

    }
}
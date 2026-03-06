using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IGlobalDataContext
    /// </summary>
    public interface IGlobalDataContext : IDisposable
    {
        IQueryable<Role> GetRoles(Expression<Func<Role, bool>> predicate, IPathwayRepository repository);

        IQueryable<UserCategory> GetUserCategories(Expression<Func<UserCategory, bool>> predicate, IPathwayRepository repository);

        IQueryable<UsageStatus> GetUsageStatuses(Expression<Func<UsageStatus, bool>> predicate, IPathwayRepository repository);

        IQueryable<MaintenanceInstrumentStatu> GetMaintenanceInstrumentStatuses(Expression<Func<MaintenanceInstrumentStatu, bool>> predicate, IPathwayRepository repository);

        IQueryable<MaintenanceReportStatus> GetMaintenanceStatuses(Expression<Func<MaintenanceReportStatus, bool>> predicate, IPathwayRepository repository);

        IQueryable<ItemType> GetItemTypes(Expression<Func<ItemType, bool>> predicate, IPathwayRepository repository);
    }
}

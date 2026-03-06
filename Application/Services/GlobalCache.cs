using System;
using System.Collections.Generic;
using System.Linq;
using ICacheManager = Synergy.Web.ICacheManager;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class GlobalCache
    {
        internal static ICacheManager Cache => InstanceFactory.GetInstance<ICacheManager>();
        internal static IGlobalDataContext Context => InstanceFactory.GetInstance<IGlobalDataContext>();

        internal static class Keys
        {
            internal static readonly GlobalCacheKey UsageStatusesKey = GlobalCacheKey.Create(CommonGlobalCacheKey.UsageStatuses);
            internal static readonly GlobalCacheKey MaintenanceInstrumentStatusKey = GlobalCacheKey.Create(CommonGlobalCacheKey.MaintenanceInstrumentStatuses);
            internal static readonly GlobalCacheKey MaintenanceStatusKey = GlobalCacheKey.Create(CommonGlobalCacheKey.MaintenanceReportStatuses);
            internal static readonly GlobalCacheKey AvailableCultures = GlobalCacheKey.Create(CommonGlobalCacheKey.AvailableCultures);
            internal static readonly GlobalCacheKey ItemTypesKey = GlobalCacheKey.Create(CommonGlobalCacheKey.ItemTypes);
        }

        public static List<string> AvailableCultures
        {
            get
            {
                if (Cache.TryFetch(Keys.AvailableCultures, out List<string> items))
                {
                    return items;
                }

                using (var repository = InstanceFactory.GetInstance<IPathwayRepository>())
                {
                    items = repository.All<Culture>().Select(a => a.Code).ToList();
                    Cache.Store(Keys.AvailableCultures, items);
                }

                return items;
            }
        }

        public static List<UsageStatus> UsageStatuses
        {
            get
            {
                if (Cache.TryFetch(Keys.UsageStatusesKey, out List<UsageStatus> items))
                {
                    return items;
                }

                {
                    items = Context
                        .GetUsageStatuses(st => true, repository)
                        .ToList();

                    Cache.Store(Keys.UsageStatusesKey, items);
                }

                return items;
            }
        }

        public static List<MaintenanceReportStatus> MaintenanceStatuses
        {
            get
            {
                if (Cache.TryFetch(Keys.MaintenanceStatusKey, out List<MaintenanceReportStatus> items))
                {
                    return items;
                }

                {
                    items = Context
                        .GetMaintenanceStatuses(s => true, repository)
                        .ToList();

                    Cache.Store(Keys.MaintenanceStatusKey, items);
                }

                return items;
            }
        }

        public static List<MaintenanceInstrumentStatu> MaintenanceInstrumentStatuses
        {
            get
            {
                if (Cache.TryFetch(Keys.MaintenanceInstrumentStatusKey, out List<MaintenanceInstrumentStatu> items))
                {
                    return items;
                }

                {
                    items = Context
                        .GetMaintenanceInstrumentStatuses(s => true, repository)
                        .ToList();

                    Cache.Store(Keys.MaintenanceInstrumentStatusKey, items);
                }

                return items;
            }
        }

        public static List<ItemType> ItemTypes
        {
            get
            {
                if(Cache.TryFetch(Keys.ItemTypesKey, out List<ItemType> itemTypes))
                {
                    return itemTypes;
                }

                {
                    itemTypes = Context
                        .GetItemTypes(s => true, repository)
                        .ToList();

                    Cache.Store(Keys.ItemTypesKey, itemTypes);
                }

                return itemTypes;
            }
        }
    }
}

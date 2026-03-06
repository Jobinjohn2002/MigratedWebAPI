using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class DbContextExtensions
    {
        public static EntityKey GetEntityKey<T>(this DbContext context, T entity) where T : class
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;

            ObjectStateEntry entry = null;
            if (entity != null && objectContext.ObjectStateManager.TryGetObjectStateEntry(entity, out entry))
                return entry.EntityKey;

            return null;
        }
    }
}

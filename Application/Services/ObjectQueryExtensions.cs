using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class ObjectQueryExtensions
    {
        public static ObjectQuery<T> IncludeMany<T>(this ObjectQuery<T> query, params string[] includes)
        {
            if (query == null)
                throw new ArgumentNullException();

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }

            return query;
        }
    }
}

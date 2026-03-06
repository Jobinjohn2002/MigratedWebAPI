using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class IQueryableExtensions
    {
        /// <summary>
        /// Includes multiple include expressions to eager load navigation properties.
        /// </summary>
        /// <typeparam name="T">The type of objects in the query.</typeparam>
        /// <param name="query">The queryable object.</param>
        /// <param name="includes">A set of expressions describing navigation properties to eager load.</param>
        /// <returns>A queryable object.</returns>
        public static IQueryable<T> IncludeMany<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (query == null)
                throw new ArgumentNullException("query");

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }

        /// <summary>
        /// Includes multiple include paths to eager load navigation properties
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public static IQueryable<T> IncludeMany<T>(this IQueryable<T> query, params string[] includes) where T : class
        {
            if (query == null)
                throw new ArgumentNullException("query");

            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}

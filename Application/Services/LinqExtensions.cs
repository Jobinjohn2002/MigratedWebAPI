using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class LinqExtensions
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

        #region Entity Framework Extensions

        private static IDictionary<DbContext, IList<object>> registeredEntities;

        private static void SynergyFlagForSave<TEntity>(this DbContext context, TEntity entity, EntityState state) where TEntity : class
        {
            var entitySet = context.Set(typeof(TEntity));

            if (entity != null)
            {
                if (registeredEntities == null)
                {
                    registeredEntities = new Dictionary<DbContext, IList<object>>();
                }
                if (!registeredEntities.ContainsKey(context))
                {
                    registeredEntities.Add(context, new List<object>());
                }
                registeredEntities[context].Add(entity);
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    switch (state)
                    {
                        case EntityState.Added:
                            {
                                entitySet.Add(entity);
                                break;
                            }
                        case EntityState.Modified:
                        case EntityState.Deleted:
                            {
                                entitySet.Attach(entity);
                                break;
                            }
                    }
                }
                context.Entry(entity).State = state;
            }
        }

        private static void SynergyFlagForSave<TEntity>(this DbContext context, IEnumerable<TEntity> entities, EntityState state)
            where TEntity : class
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    context.SynergyFlagForSave(entity, state);
                }
            }
        }

        private static void SynergyFlagForSave<TEntity>(this DbContext context, ICollection<TEntity> entities, EntityState state)
            where TEntity : class
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    context.SynergyFlagForSave(entity, state);
                }
            }
        }

        private static void SynergyFlagForSave<TEntity>(this DbContext context, IQueryable<TEntity> entities, EntityState state)
            where TEntity : class
        {
            if (entities != null)
            {
                foreach (var entity in entities)
                {
                    context.SynergyFlagForSave(entity, state);
                }
            }
        }

        public static void SynergyCreate<TEntity>(this DbContext context, TEntity entity)
          where TEntity : class
        {
            context.SynergyFlagForSave(entity, EntityState.Added);
        }

        public static void SynergyCreate<TEntity>(this DbContext context, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            context.SynergyFlagForSave(entities, EntityState.Added);
        }

        public static void SynergyCreate<TEntity>(this DbContext context, ICollection<TEntity> entities)
            where TEntity : class
        {
            context.SynergyFlagForSave(entities, EntityState.Added);
        }

        public static void SynergyCreate<TEntity>(this DbContext context, IQueryable<TEntity> entities)
            where TEntity : class
        {
            context.SynergyFlagForSave(entities, EntityState.Added);
        }

        public static void SynergyUpdate<TEntity>(this DbContext context, TEntity entity)
            where TEntity : class
        {
            context.SynergyFlagForSave(entity, EntityState.Modified);
        }

        public static void SynergyUpdate<TEntity>(this DbContext context, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            context.SynergyFlagForSave(entities, EntityState.Modified);
        }

        public static void SynergyUpdate<TEntity>(this DbContext context, ICollection<TEntity> entities)
            where TEntity : class
        {
            context.SynergyFlagForSave(entities, EntityState.Modified);
        }

        public static void SynergyUpdate<TEntity>(this DbContext context, IQueryable<TEntity> entities)
            where TEntity : class
        {
            context.SynergyFlagForSave(entities, EntityState.Modified);
        }

        public static void SynergyDelete<TEntity>(this DbContext context, TEntity entity)
            where TEntity : class
        {
            context.SynergyFlagForSave(entity, EntityState.Deleted);
        }

        public static void SynergyDelete<TEntity>(this DbContext context, IEnumerable<TEntity> entities)
            where TEntity : class
        {
            context.SynergyFlagForSave(entities, EntityState.Deleted);
        }

        public static void SynergyDelete<TEntity>(this DbContext context, ICollection<TEntity> entities)
            where TEntity : class
        {
            context.SynergyFlagForSave(entities, EntityState.Deleted);
        }

        public static void SynergyDelete<TEntity>(this DbContext context, IQueryable<TEntity> entities)
            where TEntity : class
        {
            context.SynergyFlagForSave(entities, EntityState.Deleted);
        }

        /// <summary>
        /// SynergySaveChanges operation
        /// </summary>
        public static void SynergySaveChanges(this DbContext context)
        {
            foreach (var entity in ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Deleted))
            {
                if (!entity.IsRelationship && !registeredEntities[context].Contains(entity.Entity))
                {
                    entity.ChangeState(EntityState.Detached);
                }
            }
            registeredEntities.Remove(context);
            context.SaveChanges();
        }

        #endregion

        #region IEnumerable Extensions

        public static bool? SynergyUnanimousValue<TSource>(this IEnumerable<TSource> source, Func<TSource, bool?> property)
        {
            return source.SynergyUnanimousValue(i => (bool?)property(i), false, null);
        }

        public static TResult SynergyUnanimousValue<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> property, TResult emptyValue, TResult defaultValue)
        {
            if (source.Any())
            {
                TResult unanimousValue = property(source.First());
                if (source.All(i => Equals(property(i), unanimousValue)))
                {
                    return unanimousValue;
                }
                else
                {
                    return defaultValue;
                }
            }
            else
            {
                return emptyValue;
            }
        }

        public static IEnumerable<TResult> SynergySelectRecursive<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, Expression<Func<TSource, IEnumerable<TSource>>> sourceChildren, Expression<Func<TResult, IEnumerable<TResult>>> resultChildren)
        {
            var sourceChildrenProperty = typeof(TSource).GetProperty(((MemberExpression)sourceChildren.Body).Member.Name);
            var resultChildrenProperty = typeof(TResult).GetProperty(((MemberExpression)resultChildren.Body).Member.Name);
            return source.SynergySelectRecursive(selector, sourceChildrenProperty, resultChildrenProperty);
        }

        private static IEnumerable<TResult> SynergySelectRecursive<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, PropertyInfo sourceChildren, PropertyInfo resultChildren)
        {
            IList<TResult> result = new List<TResult>();
            foreach (var sourceItem in source)
            {
                var resultItem = selector.Invoke(sourceItem);
                var sourceChildrenValue = (IEnumerable<TSource>)sourceChildren.GetValue(sourceItem, null);
                if (sourceChildrenValue != null)
                {
                    resultChildren.SetValue(resultItem, sourceChildrenValue.SynergySelectRecursive(selector, sourceChildren, resultChildren), null);
                }
                result.Add(resultItem);
            }
            return result;
        }
        /// <summary>
        ///  This is an extension method to be used to pivot the items and the pivoting 
        ///  expression can be given dynamically and this is used in production main screen called (production summary details)
        /// </summary>
        public static Dictionary<TKey1, Dictionary<TKey2, TValue>> Pivot<TSource, TKey1, TKey2, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey1> key1Selector, Func<TSource, TKey2> key2Selector, Func<IEnumerable<TSource>, TValue> aggregate)
        {
            return source.GroupBy(key1Selector).Select(
                x => new
                {
                    X = x.Key,
                    Y = source.GroupBy(key2Selector).Select(
                        z => new
                        {
                            Z = z.Key,
                            V = aggregate(from item in source
                                          where key1Selector(item).Equals(x.Key)
                                          && key2Selector(item).Equals(z.Key)
                                          select item
                            )

                        }
                    ).ToDictionary(e => e.Z, o => o.V)
                }
            ).ToDictionary(e => e.X, o => o.Y);
        }

        #endregion

        #region IQueryable Extensions
        public static IOrderedQueryable<TEntity> SynergyOrderBy<TEntity>(this IQueryable<TEntity> query, object keySelector, bool ascending)
        {
            var keyType = keySelector.GetType().GetGenericArguments()[0].GetGenericArguments()[1];
            if (keyType == typeof(bool))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, bool>>)keySelector, ascending);
            }
            else if (keyType == typeof(bool?))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, bool?>>)keySelector, ascending);
            }
            else if (keyType == typeof(short))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, short>>)keySelector, ascending);
            }
            else if (keyType == typeof(short?))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, short?>>)keySelector, ascending);
            }
            else if (keyType == typeof(int))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, int>>)keySelector, ascending);
            }
            else if (keyType == typeof(int?))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, int?>>)keySelector, ascending);
            }
            else if (keyType == typeof(long))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, long>>)keySelector, ascending);
            }
            else if (keyType == typeof(long?))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, long?>>)keySelector, ascending);
            }
            else if (keyType == typeof(float))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, float>>)keySelector, ascending);
            }
            else if (keyType == typeof(float?))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, float?>>)keySelector, ascending);
            }
            else if (keyType == typeof(double))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, double>>)keySelector, ascending);
            }
            else if (keyType == typeof(double?))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, double?>>)keySelector, ascending);
            }
            else if (keyType == typeof(decimal))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, decimal>>)keySelector, ascending);
            }
            else if (keyType == typeof(decimal?))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, decimal?>>)keySelector, ascending);
            }
            else if (keyType == typeof(string))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, string>>)keySelector, ascending);
            }
            else if (keyType == typeof(DateTime))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, DateTime>>)keySelector, ascending);
            }
            else if (keyType == typeof(DateTime?))
            {
                return query.SynergyOrderBy((Expression<Func<TEntity, DateTime?>>)keySelector, ascending);
            }
            else
            {
                throw new NotSupportedException(string.Format("SynergyOrderBy does not support columns of type {0}", keyType.Name));
            }
        }

        public static IOrderedQueryable<TEntity> SynergyOrderBy<TEntity, TKey>(this IQueryable<TEntity> query, Expression<Func<TEntity, TKey>> keySelector, bool ascending)
        {
            if (ascending)
            {
                return query.OrderBy(keySelector);
            }
            else
            {
                return query.OrderByDescending(keySelector);
            }
        }

        public static DataFilter<TEntity> SynergyCreateFilter<TEntity>(this IQueryable<TEntity> query, DataFilter filter)
        {
            return new DataFilter<TEntity>(filter);
        }

        public static IQueryable<TEntity> SynergyFilter<TEntity>(this IQueryable<TEntity> query, DataFilter<TEntity> filter)
        {
            if (filter != null && filter.BaseFilter != null)
            {
                if (filter.HasSearchExpression)
                {
                    query = query.Where(filter.SearchExpression);
                }
                filter.ItemCount = query.Count(); // Important that this is done in SQL (as opposed to bringing back entire dataset into memory)
                if (filter.OrderByExpression != null)
                {
                    query = query.SynergyOrderBy(filter.OrderByExpression, filter.OrderByAscending);
                }
                if (filter.Skip > 0)
                {
                    query = query.Skip(filter.Skip);
                }
                if (filter.Take != null)
                {
                    query = query.Take(filter.Take.Value);
                }
            }
            return query;
        }

        #endregion
    }
}
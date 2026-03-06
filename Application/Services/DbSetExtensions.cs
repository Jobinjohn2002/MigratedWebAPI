using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class DbSetExtensions
    {
        public static void AddObject<T>(this DbSet<T> entitySet, T entity) where T : class
        {
            entitySet.Add(entity);
        }

        public static void DeleteObject<T>(this DbSet<T> entitySet, T entity) where T : class
        {
            entitySet.Remove(entity);
        }
    }
}

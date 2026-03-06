using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class OperativeModelContainer
    {
        public void DeleteObject<T>(T entity) where T : class
        {
            DbSet<T> dbSet = Set<T>();

            dbSet.Remove(entity);
        }

        public void AddObject<T>(T entity) where T : class
        {
            DbSet<T> dbSet = Set<T>();

            dbSet.Add(entity);
        }
        public void ApplyCurrentValues<T>(T entity) where T : class
        {
            Entry(entity).CurrentValues.SetValues(entity);
        }
    }
}

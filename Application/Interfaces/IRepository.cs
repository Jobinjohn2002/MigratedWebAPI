using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// IRepository
    /// </summary>
    public interface IRepository : IDisposable
    {
        string Database { get; }

        string Server { get; }

        DbConnection Connection { get; }

        int Count<T>() where T : class;

        int Count<T>(Expression<Func<T, bool>> expression) where T : class;

        T Find<T>(params object[] keyValues) where T : class;

        T First<T>(Expression<Func<T, bool>> expression) where T : class;
        
        T FirstOrDefault<T>(Expression<Func<T, bool>> expression) where T : class;
        
        T Single<T>(Expression<Func<T, bool>> expression) where T : class;
        
        T SingleOrDefault<T>(Expression<Func<T, bool>> expression) where T : class;

        IQueryable<T> Where<T>(Expression<Func<T, bool>> expression) where T : class;

        IQueryable<T> All<T>() where T : class;

        bool Any<T>(Expression<Func<T, bool>> expression) where T : class;

        void Save<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        void DeleteRange<T>(IEnumerable<T> entity) where T : class;

        void Detach<T>(T entity) where T : class;

        void Reload<T>(T entity) where T : class;

        void Load<T, TProp>(T entity, Expression<Func<T, TProp>> property)
            where T : class
            where TProp : class;

        int ExecuteQuery(string query, params ObjectParameter[] parameters);
        IEnumerable<T> ExecuteQuery<T>(string query, params ObjectParameter[] parameters) where T : class;

        IEnumerable<T> ExecuteTableFunction<T>(string functionName, params ObjectParameter[] parameters) where T : class;

        bool HasPendingChanges();

        int CommitChanges();

        IDataManager DataManager { get; }

        void BulkInsert<T>(IEnumerable<T> entities) where T : class;
    }
}

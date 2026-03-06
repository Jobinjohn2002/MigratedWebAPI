using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Interfaces
{
    /// <summary>
    /// ExecuteQueryHandler operation
    /// </summary>
    public delegate void ExecuteQueryHandler(DataSet data);
    public delegate T ExecuteQueryRowHandler<out T>(DataRow row, DataTable table, DataSet set);

    /// <summary>
    /// IDataManager
    /// </summary>
    public interface IDataManager : IDisposable
    {
        T ExecuteScalar<T>(string commandText, CommandType commandType, params SqlParameter[] parameters);

        int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters);

        DataSet ExecuteQuery(string commandText, CommandType commandType, params SqlParameter[] parameters);

        void ExecuteQuery(ExecuteQueryHandler callback, string commandText, CommandType commandType, params SqlParameter[] parameters);

        List<T> ExecuteQuery<T>(ExecuteQueryRowHandler<T> callback, string commandText, CommandType commandType, params SqlParameter[] parameters);

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        void Close();
    }

    public abstract class QueryRow
    {
        /// <summary>
        /// Gets or sets RowNumber
        /// </summary>
        public int RowNumber { get; set; }
        /// <summary>
        /// Gets or sets TotalResults
        /// </summary>
        public int TotalResults { get; set; }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// DataManager
    /// </summary>
    public class DataManager
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;

        public DataManager(PathwayRepository repository)
            : this(repository.Container)
        {
        }

        public DataManager(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");

            if (connectionString.Length == 0)
                throw new ArgumentException("Connection string cannot be empty", "connectionString");

            _connection = new SqlConnection(connectionString);
        }

        public DataManager(DbContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var connection = context.Database.Connection as SqlConnection;

            if (connection != null)
                _connection = connection;

            if (_connection == null)
                throw new NotSupportedException("DataManager only supports SQLConnection");
        }

        private SqlDataAdapter GetAdapter(SqlCommand command)
        {
            return new SqlDataAdapter(command);
        }

        private SqlCommand GetCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var com = new SqlCommand
            {
                Connection = _connection,
                CommandText = commandText,
                CommandType = commandType
            };

            if (_transaction != null)
                com.Transaction = _transaction;

            if (parameters != null && parameters.Any())
                com.Parameters.AddRange(parameters);

            Open();

            return com;
        }

        public T ExecuteScalar<T>(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using (var com = GetCommand(commandText, commandType, parameters))
            {
                var result = com.ExecuteScalar();

                return (T)Convert.ChangeType(result, typeof(T));
            }
        }

        /// <summary>
        /// ExecuteNonQuery operation
        /// </summary>
        public int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            if (commandText == null)
                throw new ArgumentNullException("commandText");

            if (commandText.Length == 0)
                throw new ArgumentException("Command text cannot be empty", "commandText");

            {
                return com.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// ExecuteQuery operation
        /// </summary>
        public DataSet ExecuteQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            {
                using (var ada = GetAdapter(com))
                {
                    var data = new DataSet();

                    ada.Fill(data);

                    return data;
                }
            }
        }

        /// <summary>
        /// ExecuteQuery operation
        /// </summary>
        public void ExecuteQuery(ExecuteQueryHandler callback, string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            var data = ExecuteQuery(commandText, commandType, parameters);

            callback(data);
        }

        public List<T> ExecuteQuery<T>(ExecuteQueryRowHandler<T> callback, string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            if (callback == null)
                throw new ArgumentNullException("callback");

            var data = ExecuteQuery(commandText, commandType, parameters);

            var entities = new List<T>();

            if (data.Tables.Count > 0)
            {
                var table = data.Tables[0];

                if (table.Rows.Count > 0)
                {
                    entities.AddRange(
                        from DataRow dr in table.Rows
                        select callback(dr, table, data)
                    );
                }
            }

            return entities;
        }

        /// <summary>
        /// BeginTransaction operation
        /// </summary>
        public void BeginTransaction()
        {
            Open();

            if (_transaction != null)
                throw new InvalidOperationException("Underlying transaction already exists");

            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// CommitTransaction operation
        /// </summary>
        public void CommitTransaction()
        {
            if (_transaction == null)
                throw new NullReferenceException("Underlying transaction is null");

            _transaction.Commit();

            _transaction.Dispose();
        }

        /// <summary>
        /// RollbackTransaction operation
        /// </summary>
        public void RollbackTransaction()
        {
            if (_transaction == null)
                throw new NullReferenceException("Underlying transaction is null");

            _transaction.Commit();

            _transaction.Dispose();
        }

        private void Open()
        {
            if (_connection == null)
                throw new NullReferenceException("Underlying connection is null");

            if (_connection.State != ConnectionState.Open)
                _connection.Open();
        }

        /// <summary>
        /// Close operation
        /// </summary>
        public void Close()
        {
            if (_transaction != null)
                RollbackTransaction();

            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
            }
        }

        /// <summary>
        /// Dispose operation
        /// </summary>
        public void Dispose()
        {
            Close();

            _connection.Dispose();
        }
    }

}
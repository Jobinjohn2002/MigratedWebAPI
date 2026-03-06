using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// DataCommand
    /// </summary>
    public class DataCommand
    {
        #region Private members
        private readonly CommandType _commandtype;
        private readonly string _commandText;
        private readonly IDictionary<string, object> _parameters;
        private readonly DbContext _context;
        #endregion

        #region Constructor
        public DataCommand(DbContext context, CommandType commandType, string commandText, IDictionary<string, object> parameters)
        {
            _context = context;
            _commandtype = commandType;
            _commandText = commandText;
            _parameters = parameters;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// GetDbCommand operation
        /// </summary>
        public DbCommand GetDbCommand(DbCommand dbCommand)
        {
            dbCommand.CommandText = _commandText;
            dbCommand.CommandType = _commandtype;

            if (_parameters != null && _parameters.Count > 0)
            {
                foreach (var param in _parameters)
                {
                    var parameter = dbCommand.CreateParameter();
                    parameter.ParameterName = param.Key;
                    parameter.Value = param.Value ?? DBNull.Value;

                    dbCommand.Parameters.Add(parameter);
                }
            }

            return dbCommand;
        }

        private T PopulateEntity<T>(IDataRecord record) where T : class
        {
            var entity = (T)Activator.CreateInstance(typeof(T));

            if (record != null && record.FieldCount > 0)
            {
                var entityType = entity.GetType();

                for (var index = 0; index < record.FieldCount; index++)
                {
                    if (DBNull.Value == record[index]) continue;
                    var property = entityType.GetProperty(record.GetName(index));
                    if (property != null)
                    {
                        property.SetValue(entity, record[property.Name], null);
                    }
                }
            }
            return entity;
        }
        #endregion

        #region Public Methods
        public IList<T> GetEntityList<T>() where T : class
        {
            var entityList = new List<T>();
            var currentConnection = _context.Database.Connection as SqlConnection;
            if (currentConnection != null)
                if (currentConnection != null)
                    using (var storedConnection = currentConnection)
                    {
                        storedConnection.Open();
                        using (var command = GetDbCommand(storedConnection.CreateCommand()))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        entityList.Add(PopulateEntity<T>(reader));
                                    }
                                }
                            }
                        }
                    }
            return entityList;
        }
        #endregion

        /// <summary>
        /// ExecuteNonQuery operation
        /// </summary>
        public void ExecuteNonQuery()
        {
            var currentConnection = _context.Database.Connection as SqlConnection;
            if (currentConnection != null)
                if (currentConnection != null)
                    {
                        storedConnection.Open();
                        {
                            command.ExecuteNonQuery();
                        }
                    }
        }

        /// <summary>
        /// ExecuteScalar operation
        /// </summary>
        public object ExecuteScalar()
        {
            var currentConnection = _context.Database.Connection as SqlConnection;
            object result = null;
            if (currentConnection != null)
            {
                if (currentConnection != null)
                {
                    try
                    {
                        if (currentConnection.State != ConnectionState.Open)
                        {
                            currentConnection.Open();
                        }
                        using (var command = GetDbCommand(currentConnection.CreateCommand()))
                        {
                            result = command.ExecuteScalar();
                        }
                        if (currentConnection.State == ConnectionState.Open)
                        {
                            currentConnection.Close();
                        }
                    }
                    finally
                    {
                        if (currentConnection.State == ConnectionState.Open)
                        {
                            currentConnection.Close();
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// ExecuteWorkflowSP operation
        /// </summary>
        public WorkflowReturnType ExecuteWorkflowSP()
        {
            var currentConnection = _context.Database.Connection as SqlConnection;

            if (currentConnection != null)
            {
                if (currentConnection != null)
                {
                    {
                        storedConnection.Open();

                        {
                            DbDataReader reader = command.ExecuteReader();

                            if ((reader != null) && (reader.HasRows))
                            {
                                reader.Read();

                                WorkflowReturnType wfrt = new WorkflowReturnType();

                                object obj = reader["ReturnCode"];

                                if ((obj != null) && (obj is int))
                                {
                                    wfrt.ReturnCode = Convert.ToInt32(obj);
                                }

                                obj = reader["TurnaroundId"];

                                if ((obj != null) && (obj is int))
                                {
                                    wfrt.TurnaroundId = Convert.ToInt32(obj);
                                }

                                obj = reader["HasWarning"];

                                if ((obj != null) && (obj is int))
                                {
                                    wfrt.HasWarning = Convert.ToBoolean(obj);
                                }

                                obj = reader["HasNotes"];

                                if ((obj != null) && (obj is int))
                                {
                                    wfrt.HasNotes = Convert.ToBoolean(obj);
                                }

                                return wfrt;
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
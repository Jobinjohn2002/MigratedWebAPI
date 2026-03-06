using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    /// <summary>
    /// PathwayWarehouseRepository,
    /// </summary>
    public class PathwayWarehouseRepository : IDisposable
    {
        internal class Constants
        {
            internal class Procedures
            {
                internal const string TargetTimeModes = "dbo.SetTargetTimeOverride";
            }

            internal class Args
            {
                internal const string PrtGroupId = "PRT_GroupId";
                internal const string PrtGroupName = "PRT_GroupName";
                internal const string Operation = "Operation";
                internal const string Override = "Override";
            }
        }

        /// <summary>
        /// GetProcessGroupModes operation
        /// </summary>
        public List<ProcessGroupMode> GetProcessGroupModes(string connectionString, Guid userId, int containerMasterDefinitionId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(Constants.Procedures.TargetTimeModes, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ContainerMasterDefinitionId", containerMasterDefinitionId).SqlDbType = SqlDbType.Int;
                    command.Parameters.AddWithValue("@SystemId", userId).SqlDbType = SqlDbType.UniqueIdentifier;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@TVP", SqlDbType = SqlDbType.Structured, Value = ConvertTo(new List<ProcessGroupMode>()), TypeName = "GroupOperationTableType" });

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var data = new DataTable();
                        adapter.Fill(data);

                        return ConvertTo(data);
                    }
                }
            }
        }

        /// <summary>
        /// SetProcessGroupModes operation
        /// </summary>
        public void SetProcessGroupModes(string connectionString, Guid userId, int containerMasterDefinitionId, List<ProcessGroupMode> modes)
        {
            if (modes == null || modes.Count == 0)
                return;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(Constants.Procedures.TargetTimeModes, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ContainerMasterDefinitionId", containerMasterDefinitionId).SqlDbType = SqlDbType.Int;
                    command.Parameters.AddWithValue("@SystemId", userId).SqlDbType = SqlDbType.UniqueIdentifier;
                    command.Parameters.Add(new SqlParameter { ParameterName = "@TVP", SqlDbType = SqlDbType.Structured, Value = ConvertTo(modes), TypeName = "GroupOperationTableType" });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// ConvertTo operation
        /// </summary>
        public static DataTable ConvertTo(IEnumerable<ProcessGroupMode> modes)
        {
            var data = new DataTable();
            data.Columns.Add(Constants.Args.PrtGroupId, typeof(int));
            data.Columns.Add(Constants.Args.Override, typeof(bool));

            foreach (var mode in modes)
            {
                data.Rows.Add(mode.ProcessGroupId, mode.Overridden);
            }

            return data;
        }

        /// <summary>
        /// ConvertTo operation
        /// </summary>
        public static List<ProcessGroupMode> ConvertTo(DataTable data)
        {
            var modes = new List<ProcessGroupMode>();

            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow dr in data.Rows)
                {
                    var mode = new ProcessGroupMode
                    {
                        Overridden = dr[Constants.Args.Override] == DBNull.Value ? false : Convert.ToBoolean(dr[Constants.Args.Override]),
                        ProcessGroupId = Convert.ToInt32(dr[Constants.Args.PrtGroupId]),
                        Name = "" + dr[Constants.Args.PrtGroupName]
                    };

                    modes.Add(mode);
                }
            }

            return modes;
        }

        /// <summary>
        /// Dispose operation
        /// </summary>
        public void Dispose()
        {
        }
    }

    public class ProcessGroupMode
    {
        public int ProcessGroupId { get; set; }
        public bool Overridden { get; set; }
        public string Name { get; set; } = "";
    }
}
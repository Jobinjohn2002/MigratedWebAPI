using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class Database
    {
        public static class Pathway
        {
            public static class Tables
            {
                public const string DefectClassification = "DefectClassification";
                public const string DefectSeverity = "DefectSeverity";
            }

            public static class StoredProcedures
            {
                public static class SystemAdmin
                {
                    public const string SwitchTenancy = "dbo.SAF_SystemAdmin_Switch_Tenancy";
                }
            }

            public static class GetInvalidBatchCyclesContainers
            {
                /// <summary>
                /// GetInvalidBatchCycleContainers operation
                /// </summary>
                public static IEnumerable<dynamic> GetInvalidBatchCycleContainers(int tenancyId, int batchCycleId)
                {
                    using (var repository = InstanceFactory.GetInstance<IPathwayRepository>())
                    {
                        var parameters = new SqlParameter[2];

                        parameters[0] = new SqlParameter
                        {
                            ParameterName = "TenancyId",
                            Value = tenancyId,
                            SqlDbType = SqlDbType.Int
                        };

                        parameters[1] = new SqlParameter
                        {
                            ParameterName = "BatchCycle",
                            Value = batchCycleId,
                            SqlDbType = SqlDbType.Int
                        };

                        var data = repository.DataManager.ExecuteQuery("ConfigurableList_GetInvalidContainers", CommandType.StoredProcedure, parameters);

                        Int32 rowCount = 0;
                        DataRow[] selectRows;

                        rowCount = Convert.ToInt32(data.Tables[0].Rows.Count);
                        selectRows = data.Tables[0].Select();

                        var dataTable = data.Tables[0];

                        dataTable.Rows.CopyTo(selectRows, 0);
                        return selectRows.AsEnumerable();
                    }
                }
            }

            public static class GetInvalidMachineTypesContainers
            {
                /// <summary>
                /// GetInvalidMachineTypeContainers operation
                /// </summary>
                public static IEnumerable<dynamic> GetInvalidMachineTypeContainers(int tenancyId, int machineTypeId)
                {
                    {
                        var parameters = new SqlParameter[2];

                        parameters[0] = new SqlParameter
                        {
                            ParameterName = "TenancyId",
                            Value = tenancyId,
                            SqlDbType = SqlDbType.Int
                        };

                        parameters[1] = new SqlParameter
                        {
                            ParameterName = "machineType",
                            Value = machineTypeId,
                            SqlDbType = SqlDbType.Int
                        };

                        var data = repository.DataManager.ExecuteQuery("ConfigurableList_GetInvalidMachineTypeContainers", CommandType.StoredProcedure, parameters);

                        Int32 rowCount = 0;
                        DataRow[] selectRows;

                        rowCount = Convert.ToInt32(data.Tables[0].Rows.Count);
                        selectRows = data.Tables[0].Select();

                        var dataTable = data.Tables[0];

                        dataTable.Rows.CopyTo(selectRows, 0);
                        return selectRows.AsEnumerable();
                    }
                }
            }
        }

        private const string GetTableNames = "SELECT O.object_id AS ObjectId, CAST(o.name AS VARCHAR(255)) AS [Text] FROM sys.objects O JOIN sys.schemas S ON O.schema_id = S.schema_id WHERE O.type_desc = 'USER_TABLE' AND S.name = 'dbo' ORDER BY O.name";

        private static readonly Dictionary<string, IReadOnlyDictionary<string, int>> Databases =
            new Dictionary<string, IReadOnlyDictionary<string, int>>();

        /// <summary>
        /// TryGetTableId operation
        /// </summary>
        public static bool TryGetTableId(this IRepository repository, string tableName, out int id)
        {
            id = 0;

            if (string.IsNullOrEmpty(tableName))
                return false;

            var databaseName = GetDatabaseName(repository);

            if (!Databases.ContainsKey(databaseName))
            {
                var data = repository.DataManager.ExecuteQuery(GetTableNames, CommandType.Text);

                var tables = data.Tables[0].Rows.Cast<DataRow>().ToDictionary(dr => ("" + dr["Text"]).ToUpper(CultureInfo.InvariantCulture), dr => Convert.ToInt32(dr["ObjectId"]));

                Databases[databaseName] = tables;
            }

            var databaseTables = Databases[databaseName];

            var key = tableName.ToUpper(CultureInfo.InvariantCulture);

            if (databaseTables.ContainsKey(key))
            {
                id = databaseTables[key];
                return true;
            }

            return false;
        }

        private static string GetDatabaseName(IRepository repository)
        {
            return @"{0}\{0}".FormatWith(repository.Server, repository.Database).ToUpper(CultureInfo.InvariantCulture);
        }
    }
}

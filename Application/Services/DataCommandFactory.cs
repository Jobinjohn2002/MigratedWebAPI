using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// DataCommandFactory
    /// </summary>
    public class DataCommandFactory
    {
        /// <summary>
        /// CreateCommand operation
        /// </summary>
        public static IDataCommand CreateCommand(DbContext context, CommandType commandType, string commandText, IDictionary<string, object> parameters)
        {
            return new DataCommand(context, commandType, commandText, parameters);
        }

        /// <summary>
        /// ExecuteStoredProcedure operation
        /// </summary>
        public static WorkflowReturnType ExecuteStoredProcedure(DbContext context, string storedProcedureName, IDictionary<string, object> parameters)
        {
            IDataCommand cmd = DataCommandFactory.CreateCommand(context, CommandType.StoredProcedure, storedProcedureName, parameters);

            if (cmd != null)
            {
                return cmd.ExecuteWorkflowSP();
            }

            return null;
        }
    }
}

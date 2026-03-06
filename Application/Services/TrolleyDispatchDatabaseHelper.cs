using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// TrolleyDispatchDatabaseHelper
    /// </summary>
    public class TrolleyDispatchDatabaseHelper
    {

        /// <summary>
        /// GetTrolley operation
        /// </summary>
        public List<TrolleyDispatch_GetTrolleySummary_Result> GetTrolley(string scannedString, int facilityId, IPathwayRepository repository)
        {
            bool disposeRepository = false;
            try
            {
                if (repository == null)
                {
                    disposeRepository = true;
                    repository = InstanceFactory.GetInstance<IPathwayRepository>();
                }
                return repository.DataManager.ExecuteQuery<TrolleyDispatch_GetTrolleySummary_Result>((row, table, set) => new TrolleyDispatch_GetTrolleySummary_Result
                {
                    TrolleyInstanceId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.TrolleyInstanceId)]),
                    IsOwner = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.IsOwner)]),
                    CanProcessForAnyCustomerFacility = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.CanProcessForAnyCustomerFacility)]),
                    CanProcessForMFPCustomer = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.CanProcessForMFPCustomer)])
                },
                                         "dbo.TrolleyDispatch_GetTrolleySummary",
                                         CommandType.StoredProcedure,
                                         new SqlParameter()
                                         {
                                             ParameterName = "@ScannedString",
                                             Value = scannedString,
                                             DbType = DbType.String
                                         },
                                         new SqlParameter()
                                         {
                                             ParameterName = "@facilityID",
                                             Value = facilityId,
                                             DbType = DbType.Int32
                                         }
                 );
            }
            finally
            {
                if (disposeRepository)
                    repository.Dispose();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// IVendorMaintenanceHelper
    /// </summary>
    public interface IVendorMaintenanceHelper : IDisposable
    {
        IList<VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result> GetVendorMaintenanceActivityInformation(int vendorID);
        bool RemoveVendorMaintenanceActivityFromAllCustomers(int vendorId, int maintenanceActivityId);
        IList<VendorMaintenance_GetAllContractsForVendor_Result> GetVendorContractActivities(int vendorId);

    }

    public sealed class VendorMaintenanceHelper
    {

        /// <summary>
        /// Dispose operation
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// GetVendorMaintenanceActivityInformation operation
        /// </summary>
        public IList<VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result> GetVendorMaintenanceActivityInformation(int vendorID)
        {
            if (vendorID == 0)
                return new List<VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result>();

            using (var repository = InstanceFactory.GetInstance<IPathwayRepository>())
            {
                var dataManager = repository.DataManager;

                var data = dataManager.ExecuteQuery<VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result>((row, table, set) =>
                {
                    return new VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result
                    {
                        Created = row["Created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[nameof(VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result.Created)]),
                        MaintenanceActivityId = Convert.ToInt32(row[nameof(VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result.MaintenanceActivityId)]),
                        NumberOfContractsActivityInUse = Convert.ToInt32(row[nameof(VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result.NumberOfContractsActivityInUse)]),
                        NumberOfCustomersActivityEnabledFor = Convert.ToInt32(row[nameof(VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result.NumberOfCustomersActivityEnabledFor)]),
                        Text = row[nameof(VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result.Text)].ToString(),
                        VendorMaintenanceActivityId = Convert.ToInt32(row[nameof(VendorMaintenance_GetMaintenanceActivityInfoForVendor_Result.VendorMaintenanceActivityId)])
                    };
                }, StoredProcedureNames.VendorMaintenance_GetMaintenanceActivityInfoForVendor, CommandType.StoredProcedure, new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@VendorId", Value = vendorID, DbType = DbType.Int32
                    }
                    });
                return data;
            }
        }

        /// <summary>
        /// GetVendorContractActivities operation
        /// </summary>
        public IList<VendorMaintenance_GetAllContractsForVendor_Result> GetVendorContractActivities(int vendorId)
        {
            if (vendorId == 0)
                return new List<VendorMaintenance_GetAllContractsForVendor_Result>();

            {
                var dataManager = repository.DataManager;

                var data = dataManager.ExecuteQuery<VendorMaintenance_GetAllContractsForVendor_Result>((row, table, set) =>
                {
                    return new VendorMaintenance_GetAllContractsForVendor_Result
                    {
                        Created = row["Created"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[nameof(VendorMaintenance_GetAllContractsForVendor_Result.Created)]),
                        VendorMaintenanceActivityId = Convert.ToInt32(row[nameof(VendorMaintenance_GetAllContractsForVendor_Result.VendorMaintenanceActivityId)]),
                         ContractId = Convert.ToInt32(row[nameof(VendorMaintenance_GetAllContractsForVendor_Result.ContractId)]),
                          ContractVendorMaintenanceId = Convert.ToInt32(row[nameof(VendorMaintenance_GetAllContractsForVendor_Result.ContractVendorMaintenanceId)]),
                           Cost = Convert.ToDecimal(row[nameof(VendorMaintenance_GetAllContractsForVendor_Result.Cost)]),
                            CreatedUserId = Convert.ToInt32(row[nameof(VendorMaintenance_GetAllContractsForVendor_Result.CreatedUserId)]),
                             InUse = Convert.ToBoolean(row[nameof(VendorMaintenance_GetAllContractsForVendor_Result.InUse)]),
                              VendorId = Convert.ToInt32(row[nameof(VendorMaintenance_GetAllContractsForVendor_Result.VendorId)])
                    };
                }, StoredProcedureNames.VendorMaintenance_GetAllContractsForVendor, CommandType.StoredProcedure, new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@VendorID", Value = vendorId, DbType = DbType.Int32
                    }
                    });
                return data;
            }
        }

        /// <summary>
        /// RemoveVendorMaintenanceActivityFromAllCustomers operation
        /// </summary>
        public bool RemoveVendorMaintenanceActivityFromAllCustomers(int vendorId, int maintenanceActivityId)
        {
            if (vendorId == 0)
                return false;

            try
            {

                {
                    var dataManager = repository.DataManager;

                    var data = dataManager.ExecuteQuery(StoredProcedureNames.VendorMaintenance_RemoveMaintenanceActivityForVendorAndContracts, CommandType.StoredProcedure, new SqlParameter[]
                    {
                        new SqlParameter()
                        {
                            ParameterName = "@VendorID", Value = vendorId, DbType = DbType.Int32
                        },
                         new SqlParameter()
                        {
                            ParameterName = "@MaintenanceActivityId", Value = maintenanceActivityId, DbType = DbType.Int32
                        }
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
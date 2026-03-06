using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// ITrolleyDatabaseHelper
    /// </summary>
    public interface ITrolleyDatabaseHelper : IDisposable
    {
        IList<TrolleyDispatch_GetTrolleyContents_Result> GetTrolleyContents(int trolleyInstanceId);
        IList<TrolleyDispatch_GetTrolleyHubSummary_Result> GetTrolleyHubSummary(int facilityId);
        IList<TrolleyDispatch_GetTrolleySummary_Result> GetTrolleySummary(string trolleyInstancePrimaryId, int facilityId);
        IList<int> AssignTrolleyContentsToDeliveryNote(int trolleyInstanceId, int facilityId, int userId, int stationId, int stationTypeId, int? pinReasonId);

        IList<TrolleyDeliveryNotesDataContract> AssignTrolleyContentsToDeliveryNote_Bulk(IList<int> trolleyInstanceId, int facilityId, int userId, int stationId, int stationTypeId, int? pinReasonId);
        bool FaciltyHasOutstandingMFPTurnarounds(int processingFacilityId, int trolleyOwnerId);
        IList<TrolleyDispatch_GetSuggestedTurnarounds_Result> GetSuggestedTurnarounds(int facilityId, List<int> nonSterileItemsCurrentEventTypeIds, List<int> sterileItemsCurrentEventTypeIds, int? customerId, int? deliveryPointId);

        List<int> GetTrolleysWithIncompleteLoanSets(int facilityId);

        
    }

    public sealed class TrolleyDatabaseHelper
    {
        /// <summary>
        /// Returns a list of items assigned to a trolley
        /// </summary>
        /// <param name="trolleyInstanceId">This is the container instance id</param>
        /// <returns></returns>
        /// <summary>
        /// GetTrolleyContents operation
        /// </summary>
        public IList<TrolleyDispatch_GetTrolleyContents_Result> GetTrolleyContents(int trolleyInstanceId)
        {
            using (var repository = InstanceFactory.GetInstance<IPathwayRepository>())
            {
                var dataManager = repository.DataManager;

                var data = dataManager.ExecuteQuery<TrolleyDispatch_GetTrolleyContents_Result>((row, table, set) =>
                {
                    return new TrolleyDispatch_GetTrolleyContents_Result
                    {
                        ContainerInstanceId = row[nameof(TrolleyDispatch_GetTrolleyContents_Result.ContainerInstanceId)] == DBNull.Value ? (int?)null : Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.ContainerInstanceId)]),
                        ContainerInstancePrimaryId = row[nameof(TrolleyDispatch_GetTrolleyContents_Result.ContainerInstancePrimaryId)].ToString(),
                        CustomerId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.CustomerId)]),
                        CustomerName = row[nameof(TrolleyDispatch_GetTrolleyContents_Result.CustomerName)].ToString(),
                        DeliveryPointId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.DeliveryPointId)]),
                        DeliveryPointName = row[nameof(TrolleyDispatch_GetTrolleyContents_Result.DeliveryPointName)].ToString(),
                        ExpiryDate = row[nameof(TrolleyDispatch_GetTrolleyContents_Result.ExpiryDate)] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.ExpiryDate)]),
                        IsFastTrack = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.IsFastTrack)]),
                        IsSupplementary = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.IsSupplementary)]),
                        IsExtra = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.IsExtra)]),
                        IsTray = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.IsTray)]),
                        Name = row[nameof(TrolleyDispatch_GetTrolleyContents_Result.Name)].ToString(),
                        ServiceRequirement = row[nameof(TrolleyDispatch_GetTrolleyContents_Result.ServiceRequirement)].ToString(),
                        TurnaroundExternalId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.TurnaroundExternalId)]),
                        LastEventDateTime = Convert.ToDateTime(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.LastEventDateTime)]),
                        LastEventTypeId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.LastEventTypeId)]),
                        DeliveryNoteId = row[nameof(TrolleyDispatch_GetTrolleyContents_Result.DeliveryNoteId)] == DBNull.Value ? (int?)null : Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.DeliveryNoteId)]),
                        ItemType = row[nameof(TrolleyDispatch_GetTrolleyContents_Result.ItemType)].ToString(),
                        IsExpiringSoon = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.IsExpiringSoon)]),
                        RestrictedForTrolleys = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.RestrictedForTrolleys)]),
                        DisableTrolleyCustomerRestriction = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.DisableTrolleyCustomerRestriction)])
                    };
                }, StoredProcedureNames.TrolleyDispatch_GetTrolleyContents, CommandType.StoredProcedure, new SqlParameter[]
                {
                            new SqlParameter()
                            {
                                ParameterName = "@TrolleyInstanceId", Value = trolleyInstanceId, DbType = DbType.Int32
                            }
                });
                return data;
            }
        }

        /// <summary>
        /// Returns suggested turnarounds to be scanned onto a trolley
        /// </summary>
        /// <param name="facilityId">station facility id</param>
        /// <param name="nonSterileItemsCurrentEventTypeId">the last event of the turnaround for non sterile items</param>
        /// <param name="sterileItemsCurrentEventTypeId">the last event of the turnaround for sterile items</param>
        /// <param name="customerId">If set will restrict turnarounds by customer ID</param>
        /// <param name="deliveryPointId">If set will restrict turnarounds by delivery point ID</param>
        /// <returns></returns>
        /// <summary>
        /// GetSuggestedTurnarounds operation
        /// </summary>
        public IList<TrolleyDispatch_GetSuggestedTurnarounds_Result> GetSuggestedTurnarounds(int facilityId, List<int> nonSterileItemsCurrentEventTypeIds, List<int> sterileItemsCurrentEventTypeIds, int? customerId, int? deliveryPointId)
        {
            {
                var dataManager = repository.DataManager;
                string formattedNonSterileItemsCurrentEventTypeIds = string.Join(",", nonSterileItemsCurrentEventTypeIds);
                string formattedSterileItemsCurrentEventTypeIds = string.Join(",",sterileItemsCurrentEventTypeIds);
                var data = dataManager.ExecuteQuery<TrolleyDispatch_GetSuggestedTurnarounds_Result>((row, table, set) =>
                {
                    return new TrolleyDispatch_GetSuggestedTurnarounds_Result
                    {
                        ContainerMasterName = row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.ContainerMasterName)].ToString(),
                        ServiceRequirementName = row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.ServiceRequirementName)].ToString(),
                        DeliveryPointId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.DeliveryPointId)]),
                        DeliveryPointName = row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.DeliveryPointName)].ToString(),
                        Expiry = row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.Expiry)] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.Expiry)]),
                        IsFastTrack = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.IsFastTrack)]),
                        TurnaroundExternalId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.TurnaroundExternalId)]),
                        IsSupplementary = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyContents_Result.IsSupplementary)]),
                        IsExtra = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.IsExtra)]),
                        IsTray = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.IsTray)]),
                        BatchExternalID = row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.BatchExternalID)].ToString(),
                        BatchPassedDateTime= row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.BatchPassedDateTime)] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[nameof(TrolleyDispatch_GetSuggestedTurnarounds_Result.BatchPassedDateTime)]),
                    };
                }, StoredProcedureNames.TrolleyDispatch_GetSuggestedTurnarounds, CommandType.StoredProcedure, new SqlParameter[]
                {
                            new SqlParameter()
                            {
                                ParameterName = "@FacilityId", Value = facilityId, DbType = DbType.Int32
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@NonSterileCurrentEventTypeIDS", Value = formattedNonSterileItemsCurrentEventTypeIds, DbType = DbType.String
                            },
                             new SqlParameter()
                            {
                                ParameterName = "@SterileCurrentEventTypeIDS", Value = formattedSterileItemsCurrentEventTypeIds, DbType = DbType.String
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@CustomerID", Value = customerId, DbType = DbType.Int32
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@DeliveryPointID", Value = deliveryPointId, DbType = DbType.Int32
                            }
                });
                return data;
            }
        }

        /// <summary>
        /// GetTrolleysWithIncompleteLoanSets operation
        /// </summary>
        public List<int> GetTrolleysWithIncompleteLoanSets(int facilityId)
        {
            {
                return repository.DataManager.ExecuteQuery((row, table, set) =>
                {
                    return Convert.ToInt32(row["TurnaroundId"]);
                },
                "dbo.[TrolleysWithIncompleteLoanSets]", CommandType.StoredProcedure,
                new SqlParameter()
                {
                    ParameterName = "@FacilityID",
                    Value = facilityId,
                    DbType = DbType.Int32

                });
            }
        }

        /// <summary>
        /// This returns a list of trolleys for the trolley Dispatch screen (Trolleys at trolley started event)
        /// </summary>
        /// <param name="facilityId">This is the facility to return trolleys for</param>
        /// <returns></returns>
        /// <summary>
        /// GetTrolleyHubSummary operation
        /// </summary>
        public IList<TrolleyDispatch_GetTrolleyHubSummary_Result> GetTrolleyHubSummary(int facilityId)
        {
            {
                var dataManager = repository.DataManager;

                var data = dataManager.ExecuteQuery<TrolleyDispatch_GetTrolleyHubSummary_Result>((row, table, set) =>
                {
                    return new TrolleyDispatch_GetTrolleyHubSummary_Result
                    {
                        ContainerInstanceId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.ContainerInstanceId)]),
                        CustomerId = DBNull.Value.Equals(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.CustomerId)]) ? null : (int?)Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.CustomerId)]),
                        CustomerName = DBNull.Value.Equals(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.CustomerName)]) ? null : row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.CustomerName)].ToString(),
                        DeliveryPointId = DBNull.Value.Equals(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.DeliveryPointId)]) ? null : (int?)Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.DeliveryPointId)]),
                        DeliveryPointName = DBNull.Value.Equals(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.DeliveryPointName)]) ? null : row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.DeliveryPointName)].ToString(),
                        ContainerInstancePrimaryId = row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.ContainerInstancePrimaryId)].ToString(),
                        IsFastTrack = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.IsFastTrack)]),
                        IsOverdue = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.IsOverdue)]),
                        IsExpiringSoon = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.IsExpiringSoon)]),
                        ServiceRequirementName = row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.ServiceRequirementName)].ToString(),
                        Expiry = row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.Expiry)] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[nameof(TrolleyDispatch_GetTrolleyHubSummary_Result.Expiry)])
                    };
                }, StoredProcedureNames.TrolleyDispatch_GetTrolleyHubSummary, CommandType.StoredProcedure, new SqlParameter[]
                {
                            new SqlParameter()
                            {
                                ParameterName = "@FacilityId", Value = facilityId, DbType = DbType.Int32
                            }
                });
                return data;
            }
        }

        /// <summary>
        /// Creates Delivery Notes and assigns trolley contents to them.
        /// </summary>
        /// <returns>List of Delivery Note Ids that were created</returns>
        /// <summary>
        /// AssignTrolleyContentsToDeliveryNote operation
        /// </summary>
        public IList<int> AssignTrolleyContentsToDeliveryNote(int trolleyInstanceId, int facilityId, int userId, int stationId, int stationTypeId, int? pinReasonId)
        {
            {
                var dataManager = repository.DataManager;

                var data = dataManager.ExecuteQuery<int>((row, table, set) =>
                {
                    return Convert.ToInt32(row["DeliveryNoteID"].ToString());
                }, StoredProcedureNames.TrolleyDispatch_AssignContentsToDeliveryNote, CommandType.StoredProcedure, new SqlParameter[]
                {
                            new SqlParameter()
                            {
                                ParameterName = "@FacilityID", Value = facilityId, DbType = DbType.Int32
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@UserId", Value = userId, DbType = DbType.Int32
                            },
                             new SqlParameter()
                            {
                                ParameterName = "@TrolleyInstanceId", Value = trolleyInstanceId, DbType = DbType.Int32
                            },
                              new SqlParameter()
                            {
                                ParameterName = "@StationId", Value = stationId, DbType = DbType.Int32
                            },
                              new SqlParameter()
                            {
                                ParameterName = "@StationTypeId", Value = stationTypeId, DbType = DbType.Int32
                            },
                              new SqlParameter()
                            {
                                ParameterName = "@PinReasonId", Value = (object) pinReasonId ?? DBNull.Value, DbType = DbType.Int32, IsNullable = true
                            },
                });
                return data;
            }
        }

        /// <summary>
        /// AssignTrolleyContentsToDeliveryNote_Bulk operation
        /// </summary>
        public IList<TrolleyDeliveryNotesDataContract> AssignTrolleyContentsToDeliveryNote_Bulk(IList<int> trolleyInstanceIds, int facilityId, int userId, int stationId, int stationTypeId, int? pinReasonId)
        {
            var results = new List<TrolleyDeliveryNotesDataContract>();
            var dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));

            foreach (var id in trolleyInstanceIds)
            {
                dt.Rows.Add(id);
            }

            {
                repository.DataManager.ExecuteQuery(data => 
                {
                    if(data.Tables.Count > 0)
                    {
                        var table = data.Tables[0];

                        if(table.Rows.Count > 0)
                        {
                            foreach (DataRow row in table.Rows)
                            {
                                if(!results.Any(result => result.TrolleyContainerInstanceId == Convert.ToInt32(row["TrolleyContainerInstanceId"])))
                                {
                                    results.Add(new TrolleyDeliveryNotesDataContract { TrolleyContainerInstanceId = Convert.ToInt32(row["TrolleyContainerInstanceId"]), DeliveryNoteIds = new List<int>() });
                                }

                                var entry = results.First(result => result.TrolleyContainerInstanceId == Convert.ToInt32(row["TrolleyContainerInstanceId"]));
                                if (!entry.DeliveryNoteIds.Any(did => did == Convert.ToInt32(row["DeliveryNoteId"])))
                                {
                                    entry.DeliveryNoteIds.Add(Convert.ToInt32(row["DeliveryNoteId"]));
                                }
                            }
                        }
                    }

                }, "dbo.TrolleyDispatch_AssignContentsToDeliveryNote_Bulk", CommandType.StoredProcedure,
                    new SqlParameter
                    {
                        ParameterName = "@TrolleyInstanceIds",
                        Value = dt,
                        TypeName = "[dbo].[IDTable]",
                        SqlDbType = SqlDbType.Structured
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@FacilityID",
                        Value = facilityId,
                        DbType = DbType.Int32
                    },
                        new SqlParameter()
                        {
                            ParameterName = "@UserId",
                            Value = userId,
                            DbType = DbType.Int32
                        },
                          new SqlParameter()
                          {
                              ParameterName = "@StationId",
                              Value = stationId,
                              DbType = DbType.Int32
                          },
                          new SqlParameter()
                          {
                              ParameterName = "@StationTypeId",
                              Value = stationTypeId,
                              DbType = DbType.Int32
                          },
                          new SqlParameter()
                          {
                              ParameterName = "@PinReasonId",
                              Value = (object)pinReasonId ?? DBNull.Value,
                              DbType = DbType.Int32,
                              IsNullable = true
                          });

                return results;
            }
        }

        /// <summary>
        /// This method queries the database for a summary of trolley information
        /// </summary>
        /// <param name="trolleyInstancePrimaryId">This is the primary id of the trolley</param>
        /// <param name="facilityId">This is the facility that is wanting to process the trolley.</param>
        /// <returns>A trolley summary model</returns>
        /// <summary>
        /// GetTrolleySummary operation
        /// </summary>
        public IList<TrolleyDispatch_GetTrolleySummary_Result> GetTrolleySummary(string trolleyInstancePrimaryId, int facilityId)
        {
            {
                var dataManager = repository.DataManager;

                var data = dataManager.ExecuteQuery<TrolleyDispatch_GetTrolleySummary_Result>((row, table, set) =>
                {
                    return new TrolleyDispatch_GetTrolleySummary_Result
                    {
                        TrolleyInstancePrimaryId = row[nameof(TrolleyDispatch_GetTrolleySummary_Result.TrolleyInstancePrimaryId)].ToString(),
                        TrolleyName = row[nameof(TrolleyDispatch_GetTrolleySummary_Result.TrolleyName)].ToString(),
                        LastEventTypeId = row[nameof(TrolleyDispatch_GetTrolleySummary_Result.LastEventTypeId)] == DBNull.Value ? default(Int16) : Convert.ToInt16(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.LastEventTypeId)]),
                        TrolleyTurnaroundExternalID = row[nameof(TrolleyDispatch_GetTrolleySummary_Result.TrolleyTurnaroundExternalID)] == DBNull.Value ? default(Int64) : Convert.ToInt64(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.TrolleyTurnaroundExternalID)]),
                        CustomerDefinitionId = row[nameof(TrolleyDispatch_GetTrolleySummary_Result.CustomerDefinitionId)] == DBNull.Value ? (int?)null : Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.CustomerDefinitionId)]),
                        TurnaroundId = row[nameof(TrolleyDispatch_GetTrolleySummary_Result.TurnaroundId)] == DBNull.Value ? (int?)null : Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.TurnaroundId)]),
                        HasTurnaroundEnded = row[nameof(TrolleyDispatch_GetTrolleySummary_Result.HasTurnaroundEnded)] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.HasTurnaroundEnded)]),
                        NextEvent = row[nameof(TrolleyDispatch_GetTrolleySummary_Result.NextEvent)].ToString(),
                        TrolleyInstanceId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.TrolleyInstanceId)]),
                        TrolleyContainerMasterId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.TrolleyContainerMasterId)]),
                        ItemTypeId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.ItemTypeId)]),
                        ProcessingFacilityId = row[nameof(TrolleyDispatch_GetTrolleySummary_Result.ProcessingFacilityId)] == DBNull.Value ? (int?)null : Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.ProcessingFacilityId)]),
                        OwnerFacilityId = Convert.ToInt32(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.OwnerFacilityId)]),
                        IsOwner = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.IsOwner)]),
                        CanProcessForAnyCustomerFacility = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.CanProcessForAnyCustomerFacility)]),
                        CanProcessForMFPCustomer = Convert.ToBoolean(row[nameof(TrolleyDispatch_GetTrolleySummary_Result.CanProcessForMFPCustomer)])
                    };
                }, StoredProcedureNames.TrolleyDispatch_GetTrolleySummary, CommandType.StoredProcedure, new SqlParameter[]
                {
                        new SqlParameter()
                        {
                            ParameterName = "@ScannedString", Value = trolleyInstancePrimaryId, DbType = DbType.String
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@facilityID", Value = facilityId, DbType = DbType.Int32
                        }
                });
                return data.ToList();
            }
        }

        /// <summary>
        /// LoadDeliveryNotesListByFacility operation
        /// </summary>
        public IList<DeliveryNotes_LoadDeliveryNoteListByFacility_Result> LoadDeliveryNotesListByFacility(int facilityId, int take)
        {
         
            {
                var dataManager = repository.DataManager;

                var data = dataManager.ExecuteQuery<DeliveryNotes_LoadDeliveryNoteListByFacility_Result>((row, table, set) =>
                {
                    return new DeliveryNotes_LoadDeliveryNoteListByFacility_Result
                    {

                        CustomerName = Convert.ToString(row[nameof(DeliveryNotes_LoadDeliveryNotesListByFacility_Result.CustomerName)]),
                        DeliveryPointName = Convert.ToString(row[nameof(DeliveryNotes_LoadDeliveryNotesListByFacility_Result.DeliveryPointName)]),
                        DeliveryPointRequiresProof = row[nameof(DeliveryNotes_LoadDeliveryNotesListByFacility_Result.DeliveryPointRequiresProof)] == DBNull.Value ? false :  Convert.ToBoolean(row[nameof(DeliveryNotes_LoadDeliveryNotesListByFacility_Result.DeliveryPointRequiresProof)]),
                        ItemsCount = Convert.ToInt16(row[nameof(DeliveryNotes_LoadDeliveryNotesListByFacility_Result.ItemsCount)]),
                        EarliestItemExpiry = row[nameof(DeliveryNotes_LoadDeliveryNotesListByFacility_Result.EarliestItemExpiry)] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[nameof(DeliveryNotes_LoadDeliveryNotesListByFacility_Result.EarliestItemExpiry)]),
                        FastTrackItemsCount = Convert.ToInt16(row[nameof(DeliveryNotes_LoadDeliveryNotesListByFacility_Result.FastTrackItemsCount)]),

                        DeliveryNoteId = Convert.ToInt32(row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.DeliveryNoteId)]),
                        DeliveryPointId =  Convert.ToInt32(row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.DeliveryPointId)]),
                        FacilityId = Convert.ToInt32(row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.FacilityId)]),
                        PrintedUserId = Convert.ToInt32(row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.PrintedUserId)]),
                        Printed = Convert.ToDateTime(row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.Printed)]),
                        PrintedStatus = Convert.ToBoolean(row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.PrintedStatus)]),
                        ExternalId = Convert.ToInt32(row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.ExternalId)]),
                        PhysicalCopyCreated = row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.PhysicalCopyCreated)] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.PhysicalCopyCreated)]),
                        ExpectedDelivery = row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.ExpectedDelivery)] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.ExpectedDelivery)]),
                        IsTrolleyDeliveryNote =Convert.ToBoolean( row[nameof(DeliveryNotes_LoadDeliveryNoteListByFacility_Result.IsTrolleyDeliveryNote)]),
                    };
                }, StoredProcedureNames.DeliveryNotes_LoadDeliveryNotesListByFacility, CommandType.StoredProcedure, new SqlParameter[]
                {
                        new SqlParameter()
                        {
                            ParameterName = "@FacilityID", Value = facilityId, DbType = DbType.Int32
                        },
                        new SqlParameter()
                        {
                            ParameterName = "@Take", Value = take, DbType = DbType.Int32
                        }
                });
                return data.ToList();
            }
        }

        /// <summary>
        /// FaciltyHasOutstandingMFPTurnarounds operation
        /// </summary>
        public bool FaciltyHasOutstandingMFPTurnarounds(int processingFacilityId, int trolleyOwnerFacilityId)
        {
            {
                var dataManager = repository.DataManager;

                var data = dataManager.ExecuteQuery(StoredProcedureNames.TrolleyDispatch_MFPTurnaroundsForTrolley, CommandType.StoredProcedure, new SqlParameter[]
                {
                            new SqlParameter()
                            {
                                ParameterName = "@TrolleyFacilityID", Value = trolleyOwnerFacilityId, DbType = DbType.Int32
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@StationFacilityID", Value = processingFacilityId, DbType = DbType.Int32
                            }
                });

                if (data?.Tables != null && data.Tables.Count > 0)
                {
                    return (data.Tables[0].Rows?.Count ?? 0) > 0;
                }
                return false;
            }
        }
        /// <summary>
        /// Dispose operation
        /// </summary>
        public void Dispose()
        {

        }
    }
}
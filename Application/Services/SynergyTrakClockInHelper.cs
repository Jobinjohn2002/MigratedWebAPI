using SynergyApplicationFrameworkApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// SynergyTrakClockInHelper
    /// </summary>
    public class SynergyTrakClockInHelper
    {
        List<GetClockingActionsResultData> GetClockingActions(int? stationId, int userId, ClockingEventTypeIdentifier eventType)
        {
            List<GetClockingActionsResultData> actions = new List<GetClockingActionsResultData>();

            using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted}))
            {
                using (var repository = new PathwayRepository())
                {
                    if (stationId != null)
                    {
                        var dataManager = repository.DataManager;

                        var data = dataManager.ExecuteQuery("CICO_GetClockingActions", CommandType.StoredProcedure, new SqlParameter[]
                        {
                            new SqlParameter()
                            {
                                ParameterName = "@UserId", Value = userId, DbType = DbType.Int32
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@EndStationId", Value = stationId.Value, DbType = DbType.Int32
                            },
                            new SqlParameter()
                            {
                                ParameterName = "@ClockingEventTypeId", Value = (int) eventType, DbType = DbType.Int32
                            }
                        });

                        var outEvents = data.Tables[0];

                        foreach (DataRow dr in outEvents.Rows)
                        {
                            actions.Add(new GetClockingActionsResultData(dr, ClockingEventTypeIdentifier.ClockOut));
                        }

                        if (eventType == ClockingEventTypeIdentifier.ClockIn)
                        {
                            var inEvents = data.Tables[1];

                            foreach (DataRow dr in inEvents.Rows)
                            {
                                actions.Add(new GetClockingActionsResultData(dr, ClockingEventTypeIdentifier.ClockIn));
                            }
                        }
                    }
                    scope.Complete();
                }
            }
            return actions;
        }

        /// <summary>
        /// AddUserClockingEvent operation
        /// </summary>
        public ClockingEventReplyDataContract AddUserClockingEvent(DataContracts.ClientSettings.ClockingEventRequestDataContract request)
        {
            var dataContract = new ClockingEventReplyDataContract();
            List<GetClockingActionsResultData> actions = null;

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var userRepository = UserRepository.New(workUnit);
                User user = null;

                if (request.UserId > 0)
                {
                    user = userRepository.Get(request.UserId);
                }
                else
                {
                    if (!string.IsNullOrEmpty(request.UserExternalId))
                    {
                        user = userRepository.GetByExternalId(request.UserExternalId);

                        if (user != null)
                        {
                            request.UserId = user.UserId;
                        }
                        else
                        {
                            dataContract.ErrorCode = (int)ErrorCodes.InvalidUser;
                        }
                    }
                    else if (!string.IsNullOrEmpty(request.Username))
                    {
                        dataContract.ErrorCode = (int)ErrorCodes.InvalidUserNamePassword;

                        user = userRepository.Get(request.Username);
                        if (user != null)
                        {
                            if (user.Validate(request.Pwd))
                            {
                                request.UserId = user.UserId;
                                dataContract.ErrorCode = null;
                                if (!user.SoftLockOutPreventLogin(Data.Helpers.SystemSettings.GetPasswordLockoutRetryMins))
                                {
                                    user.ResetPasswordAttempts();
                                }
                            }
                            else
                            {
                                user.UpdatePasswordAttempts(Data.Helpers.TenancySettings.GetPasswordAttemptsLimit(user.TenancyId));
                                userRepository.Save();
                            }
                        }
                    }
                }

                if (!request.IsAutomatic && request.ClockingEventType == ClockingEventTypeIdentifier.ClockIn ||
                        request.ClockingEventType == ClockingEventTypeIdentifier.ClockOut)
                {
                    RecordLoginAudit(request.ClockingEventType, (ErrorCodes?)dataContract.ErrorCode, user?.UserId, user?.UserName ?? request.Username, workUnit);
                }

                if (dataContract.ErrorCode.HasValue)
                {
                    return dataContract;
                }

                if (user != null)
                {
                    dataContract.FirstName = user.FirstName;
                    dataContract.Surname = user.Surname;
                    dataContract.UserId = user.UserId;
                    dataContract.LastEventTime = GetLastClockInOutEvent(user.UserId);

                    var facilityRepository = FacilityRepository.New(workUnit);
                    Facility facility = facilityRepository.Get(request.FacilityId);

                    if (facility?.Owner?.TenancyId != user.TenancyId)
                    {
                        dataContract.Successful = false;
                        dataContract.ClockingEventType = ClockingEventTypeIdentifier.ClockIn;
                        dataContract.LocationId = request.LocationId;
                        dataContract.ErrorCode = (int)ErrorCodes.NoUserTenancyAccess;

                        return dataContract;
                    }

                    if (request.ClockingEventType != ClockingEventTypeIdentifier.ToggleState)
                    {
                        if ((request.LocationId == user.CurrentClockedInLocationId) &&
                            (request.ClockingEventType == ClockingEventTypeIdentifier.ClockIn) &&
                            (request.StationId.HasValue && request.StationId == user.CurrentClockedInStationId))
                        {
                            dataContract.Successful = false;
                            dataContract.ClockingEventType = ClockingEventTypeIdentifier.ClockIn;
                            dataContract.LocationId = request.LocationId;
                            return dataContract;
                        }

                        if (user.CurrentClockedInLocationId == null && request.ClockingEventType == ClockingEventTypeIdentifier.ClockOut)
                        {
                            dataContract.Successful = false;
                            dataContract.ClockingEventType = ClockingEventTypeIdentifier.ClockOut;
                            dataContract.LocationId = request.LocationId;
                            return dataContract;
                        }
                    }
                    else
                    {
                        request.ClockingEventType = user.CurrentClockedInLocationId == request.LocationId ? ClockingEventTypeIdentifier.ClockOut : ClockingEventTypeIdentifier.ClockIn;
                    }
                }
                else
                {
                    dataContract.ErrorCode = (int)ErrorCodes.InvalidUserNamePassword;
                    return dataContract;
                }
            }

            actions = GetClockingActions(request.StationId, request.UserId, request.ClockingEventType);

            if (actions.Any())
            {
                dataContract.Successful = true;
                dataContract.ClockingEventType = request.ClockingEventType;
                dataContract.LocationPath = actions.Last().FullPath;
                dataContract.LocationId = actions.Last().LocationId;
            }
            else if (!actions.Any())
            {
                dataContract.Successful = false;
                dataContract.ClockingEventType = request.ClockingEventType;
                dataContract.LocationPath = "";
            }

            foreach (var action in actions)
            {
                AddClockingEvent(request.UserId, action.StationId, action.FullPath, action.LocationId, action.ClockingTypeIdentifier, request.LocationId, request.UserId,
                    action.LocationId != request.LocationId, request.StationId != null ? request.StationId.Value : 0);
            }

            return dataContract;
        }

        private void RecordLoginAudit(ClockingEventTypeIdentifier clockingType, ErrorCodes? error, int? userId, string UserName, IUnitOfWork workUnit)
        {
            var loginAuditRepository = LoginAuditRepository.New(workUnit);
            loginAuditRepository.Add(LoginAuditFactory.CreateEntity(workUnit,
                appTypeId: (int)ApplicationType.Operative,
                iPAddress: IpAddressHelper.GetIPAddress(),
                loginDate: DateTime.UtcNow,
                userId: userId,
                userName: string.IsNullOrEmpty(UserName) ? null : UserName,
                loginAuditTypeId: (int)(error.HasValue ? LoginAuditTypeIdentifier.IncorrectUsernamePassword : LoginAuditTypeIdentifier.Success),
                source: clockingType == ClockingEventTypeIdentifier.ClockIn ? "Clock In Station" : "Clock Out Station"
            ));

            loginAuditRepository.Save();
        }

        private DateTime? GetLastClockInOutEvent(int userId)
        {
            {
                var userClockingEventRepository = UserClockingEventRepository.New(workUnit);

                var d = userClockingEventRepository.Repository.Find(uce => uce.UserId == userId).OrderByDescending(uce => uce.ClockingTime).FirstOrDefault();

                if (d != null)
                {
                    return DateTime.SpecifyKind(d.ClockingTime, DateTimeKind.Utc);
                }
            }

            return null;
        }

        private void AddClockingEvent(int userId, int? stationId, string locationPath, int locationId, ClockingEventTypeIdentifier eventType, int initiatedFromLocationId, int clockedOutByUserId, bool isAutomatic = false, int InitiatedFromStationId = 0)
        {
            using (IUnitOfWork workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var userClockingInEventRepository = UserClockingEventRepository.New(workUnit);

                var clockingInEvent = UserClockingEventFactory.CreateEntity(workUnit,
                    userId: userId,
                    clockingTime: DateTime.UtcNow,
                    stationId: stationId,
                    locationPath: locationPath,
                    locationId: locationId,
                    clockingEventTypeId: (int)eventType,
                    isAutomatic: isAutomatic,
                    initiatedFromLocationId: initiatedFromLocationId,
                    initiatedByUserId: clockedOutByUserId,
                    initiatedFromStationId: InitiatedFromStationId // 0 default is TrakStar System station
                );

                userClockingInEventRepository.Add(clockingInEvent);
                userClockingInEventRepository.Save();

                var userRepository = UserRepository.New(workUnit);
                var user = userRepository.Get(userId);

                if (eventType == ClockingEventTypeIdentifier.ClockOut)
                {
                    int? parentLocationId;
                    using (var transaction = new TransactionScope(TransactionScopeOption.RequiresNew, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }))
                    {
                        {
                            var context = repository.Container;
                            var parameters = new Dictionary<string, object>();
                            parameters.Add("LocationId", locationId);

                            var datacommand = DataCommandFactory.CreateCommand(context, CommandType.StoredProcedure, "CICO_GetLocationParentId", parameters);
                            var result = datacommand.ExecuteScalar();
                            parentLocationId = result == DBNull.Value ? null : (int?)result;
                        }

                        transaction.Complete();
                    }

                    user.CurrentClockedInLocationId = parentLocationId;
                    user.CurrentClockedInStationId = null;
                }
                else
                {
                    user.CurrentClockedInLocationId = locationId;
                    user.CurrentClockedInStationId = stationId;
                }

                userRepository.Save();
            }
        }

        /// <summary>
        /// ClockOutUsers operation
        /// </summary>
        public bool ClockOutUsers(List<int> userIds, int initiatedByUserId, int facilityId)
        {
            bool success = true;
            List<GetClockingActionsResultData> actions = null;

            {
                var userRepository = UserRepository.New(workUnit);
                var stationDataAdapter = DataAdapterFactory.GetStationDataAdapter(workUnit);
                var station = stationDataAdapter.ReadAdminStationByFacility(facilityId);

                try
                {
                    foreach (var userId in userIds)
                    {
                        using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                        {
                            User user = userRepository.Get(userId);

                            if (user != null)
                            {
                                if (user.CurrentClockedInLocationId == null)
                                {
                                }
                                else
                                {
                                    actions = GetClockOutToRootActions(userId);

                                    if (actions.Any())
                                    {
                                        foreach (var action in actions)
                                        {
                                            bool isAutomatic = action != actions.Last();
                                            AddClockingEvent(userId, action.StationId, action.FullPath, action.LocationId, action.ClockingTypeIdentifier, station.LocationId.Value, initiatedByUserId, isAutomatic, station.StationId);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                success = false;
                            }
                            scope.Complete();
                        }
                    }
                }
                catch (Exception)
                {
                    success = false;
                }
            }
            return success;
        }

        private List<GetClockingActionsResultData> GetClockOutToRootActions(int userId)
        {
            List<GetClockingActionsResultData> actions = new List<GetClockingActionsResultData>();

            {
                var dataManager = repository.DataManager;

                var data = dataManager.ExecuteQuery("CICO_GetClockingActions_ClockOutOfRoot", CommandType.StoredProcedure, new SqlParameter[]
                {
                        new SqlParameter()
                        {
                            ParameterName = "@UserId", Value = userId, DbType = DbType.Int32
                        }
                });

                var outEvents = data.Tables[0];

                foreach (DataRow dr in outEvents.Rows)
                {
                    actions.Add(new GetClockingActionsResultData(dr, ClockingEventTypeIdentifier.ClockOut));
                }

            }

            return actions;
        }
    }
}
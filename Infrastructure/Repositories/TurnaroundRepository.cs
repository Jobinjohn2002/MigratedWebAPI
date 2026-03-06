using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class TurnaroundRepository
    {
        /// <summary>
        /// Retrieves a turnaround by Id
        /// </summary>
        /// <param name="turnaroundId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// Get operation
        /// </summary>
        public Turnaround Get(int turnaroundId)
        {
            return Repository.Find(t => t.TurnaroundId == turnaroundId).FirstOrDefault();
        }

        /// <summary>
        /// Get operation
        /// </summary>
        public List<Turnaround> Get(List<int> turnaroundIds)
        {
            return Repository.Find(t => turnaroundIds.Contains(t.TurnaroundId)).ToList();
        }

        /// <summary>
        /// GetByIds operation
        /// </summary>
        public IQueryable<Turnaround> GetByIds(List<int> turnaroundIds)
        {
            return Repository.Find(t => turnaroundIds.Contains(t.TurnaroundId));
        }

        /// <summary>
        /// GetByExternalId operation
        /// </summary>
        public IQueryable<Turnaround> GetByExternalId(List<long> turnaroundExternalIds)
        {
            return Repository.Find(t => turnaroundExternalIds.Contains(t.ExternalId));
        }

        /// <summary>
        /// GetFromDeliveryNote operation
        /// </summary>
        public List<Turnaround> GetFromDeliveryNote(int deliveryNoteId)
        {
            return Repository.Find(t => t.DeliveryNoteId == deliveryNoteId).ToList();
        }

        /// <summary>
        /// Gets the tunraround by external id, and facility id.
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetTurnaroundByExternalIdAndFacilityId operation
        /// </summary>
        public Turnaround GetTurnaroundByExternalIdAndFacilityId(long turnaroundExternalId, short facilityId)
        {
            var mfpRepository = MultiFacilityProcessingRepository.New(Repository.UnitOfWork);
            var facilities = mfpRepository.GetPrimaryFacilities(facilityId);
            var turnaround = Repository.Find(t => t.ExternalId == turnaroundExternalId && t.TurnaroundFacility.Any(tf => facilities.Contains(tf.FacilityId))).Include("ContainerMaster.ItemType.ParentItemType").Include("DeliveryPoint.CustomerDefinition.CurrentCustomer").FirstOrDefault();

            if (turnaround != null)
            {
                var usingFacilityId = turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer?.FacilityId ?? turnaround.FacilityId;

                if (!facilities.Contains(usingFacilityId) && turnaround.TurnaroundFacility.All(tf => tf.FacilityId != facilityId))
                {
                    turnaround = null;
                }
            }

            return turnaround;
        }

        /// <summary>
        /// GetPreviousTurnaround operation
        /// </summary>
        public Turnaround GetPreviousTurnaround(int turnaroundId)
        {
            var containerInstanceId = Get(turnaroundId).ContainerInstanceId;

            return Repository.Find(t => t.ContainerInstanceId == containerInstanceId && t.CurrentTurnaroundEvent.EventTypeId != (int)TurnAroundEventTypeIdentifier.Archived)
                    .OrderByDescending(t => t.Created)
                    .Skip(1)
                    .FirstOrDefault();
        }

        /// <summary>
        /// Gets the turnaround by external id and user delivery point access.
        /// </summary>
        /// <param name="turnaroundExternalId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <summary>
        /// GetTurnaroundByExternalIdAndUserAccess operation
        /// </summary>
        public Turnaround GetTurnaroundByExternalIdAndUserAccess(long turnaroundExternalId, int userId)
        {
            var userDeliveryPointRepository = UserDeliveryPointRepository.New(Repository.UnitOfWork);
            var deliveryPoints = userDeliveryPointRepository.ReadDeliveryPointsByUserId(userId);
            var turnaround = Repository.Find(t => t.ExternalId == turnaroundExternalId).FirstOrDefault();

            if (turnaround != null && deliveryPoints.Any(dp => dp.DeliveryPointId == turnaround.DeliveryPointId))
            {
                return turnaround;
            }

            return null;
        }

        /// <summary>
        /// Gets all turnarounds by delivery point uid.
        /// </summary>
        /// <param name="deliveryPointId">The delivery point id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllTurnaroundsByDeliveryPointId operation
        /// </summary>
        public IQueryable<Turnaround> GetAllTurnaroundsByDeliveryPointId(int deliveryPointId)
        {
            return Repository.Find(t => t.DeliveryPoint.DeliveryPointId == deliveryPointId);
        }

        /// <summary>
        /// Gets all turnarounds by deliverynote id.
        /// </summary>
        /// <param name="deliveryNoteId">The deliverynote id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetAllTurnaroundsByDeliveryNoteId operation
        /// </summary>
        public IQueryable<Turnaround> GetAllTurnaroundsByDeliveryNoteId(int deliveryNoteId)
        {
            return Repository.Find(t => t.DeliveryNote.DeliveryNoteId == deliveryNoteId);
        }

        /// <summary>
        /// ReadProductionOverviewByCustomer operation
        /// </summary>
        public IList<Turnaround> ReadProductionOverviewByCustomer(short facilityId, short? alternateFacilityId, int productionEventTypeId, Synergy.Core.Data.DataFilter filter, int userId, string userTimeZone, UserCultureData userCultureData, bool useMFP, bool IncludeAlternateFacilityItems)
        {
            var parameters = new ProductionParamCollection
            {
                FacilityId = facilityId,
                AlternateFacilityId = alternateFacilityId,
                ProductionEventTypeId = productionEventTypeId,
                Filter = filter,
                useMFP = useMFP,
                IncludeAlternateFacilityItems = IncludeAlternateFacilityItems
            };

            var turnarounds = ReadTurnaroundsByFacilityAndCustomer(parameters, userId, userTimeZone, userCultureData).ToList();

            turnarounds = turnarounds.
                GroupBy(i => new
                {
                    ServiceRequirementText = i.ServiceRequirementDefinitionId,
                    CustomerText = i.CustomerText,
                    CustomerDefinitionId = i.CustomerDefinitionId,
                    i.FacilityName,
                    i.FacilityId,
                }).
                Select(i => new Turnaround(i.First())
                {
                    TurnaroundCount = i.Count(),
                    OverdueTurnaroundCount = i.Count(t => t.Expiry.Year != 1900 && (t.Expiry.Subtract(t.TurnaroundWH.Select(a => a.StartEventTime.GetValueOrDefault()).SingleOrDefault()).Minutes - t.Expiry.Subtract(DateTime.UtcNow).Minutes >= t.Expiry.Subtract(t.TurnaroundWH.Select(a => a.StartEventTime.GetValueOrDefault()).SingleOrDefault()).Minutes / 100 * 90) && t.Expiry < DateTime.UtcNow)
                }).
                OrderBy(i => i.CustomerDefinitionId).
                ThenBy(i => i.ServiceRequirementText).
                ToList();

            return turnarounds;
        }

        /// <summary>
        /// ReadTurnaroundsByFacilityAndCustomer operation
        /// </summary>
        public IList<Turnaround> ReadTurnaroundsByFacilityAndCustomer(ProductionParamCollection parameters, int userId, string userTimeZone, UserCultureData userCultureData)
        {
            IUnitOfWork unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork();
            var facilityRepository = new FacilityRepository(unitOfWork);
            var facility = facilityRepository.Get((short)parameters.FacilityId);
            if (parameters.Filter == null)
            {
                parameters.Filter = new Synergy.Core.Data.DataFilter
                {
                    SearchItems = new List<SearchItem>()
                };
            }

            var context = (OperativeModelContainer)Repository.UnitOfWork.Context;
            var isProductionOverView = default(bool);
            var lastProcessEventTypeIdsDataTable = new DataTable("EventTypeID");
            lastProcessEventTypeIdsDataTable.Columns.Add("EventTypeId");

            if (parameters.ProductionEventTypeId > 0)
            {
                if ((parameters.ProductionEventTypeId == (int)ProductionEventTypeIdentifier.MFPWash
                                                || parameters.ProductionEventTypeId == (int)ProductionEventTypeIdentifier.MFPWashIn))
                {
                    isProductionOverView = true;
                }
                else
                {
                    var lastProcessEventTypeIds = context.EventType.ToList().Where(j => j.ProductionEventTypeId(facility.WashRelease) == parameters.ProductionEventTypeId).Select(j => j.EventTypeId);
                    foreach (var eventTypeId in lastProcessEventTypeIds)
                    {
                        lastProcessEventTypeIdsDataTable.Rows.Add(eventTypeId);
                    }
                }
            }
            else if (parameters.ProductionEventTypeId == (int)ProductionEventTypeIdentifier.AllProductionEvents)
            {
                isProductionOverView = true;
            }

            if (parameters.UseEventContext)
            {
                parameters.ProductionEventTypeId = null;
            }

            using (var repository = new PathwayRepository())
            {
                var turnaroundList = repository.DataManager.ExecuteQuery<admapp_ReadTurnaroundsByFacilityAndCustomer_Result>((row, table, set) =>
                {
                    return new admapp_ReadTurnaroundsByFacilityAndCustomer_Result
                    {
                        TurnaroundId = Convert.ToInt32(row["TurnaroundId"]),
                        TotalRows = row["TotalRows"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["TotalRows"]),
                        TurnaroundExternalId = Convert.ToInt32(row["TurnaroundExternalId"]),
                        LastEventEventTypeText = row["LastEventEventTypeText"].ToString(),
                        LastEventTypeId = Convert.ToInt16(row["LastEventTypeId"]),
                        ServiceRequirementDefinitionId = Convert.ToInt32(row["ServiceRequirementDefinitionId"]),
                        DisplayOrder = Convert.ToInt16(row["DisplayOrder"]),
                        ProcessEvent = Convert.ToBoolean(row["ProcessEvent"]),
                        PriorityOrder = Convert.ToInt32(row["PriorityOrder"]),
                        ExpiredItemsCount = row["ExpiredItemsCount"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["ExpiredItemsCount"]),
                        NearExpiryItemsCount = row["NearExpiryItemsCount"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["NearExpiryItemsCount"]),
                        ContainerInstancePrimaryID = row["ContainerInstancePrimaryID"].ToString(),
                        Created = Convert.ToDateTime(row["Created"]),
                        Expiry = Convert.ToDateTime(row["Expiry"]),
                        ExpiryCountDown = row["ExpiryCountDown"].ToString(),
                        QuarantineReason = row["QuarantineReason"].ToString(),
                        ContainerMasterName = row["ContainerMasterName"].ToString(),
                        DeliveryPointName = row["DeliveryPointName"].ToString(),
                        CustomerName = row["CustomerName"].ToString(),
                        ServiceRequirementName = row["ServiceRequirementName"].ToString(),
                        IsFastTrack = row["IsFastTrack"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(row["IsFastTrack"]),
                        CustomerDefinitionId = Convert.ToInt32(row["CustomerDefinitionId"]),
                        RowNumber = row["RowNumber"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["RowNumber"]),
                        FacilityName = row["FacilityName"].ToString(),
                        FacilityId = Convert.ToInt16(row["FacilityId"]),
                        IsIdentifiable = Convert.ToBoolean(row["IsIdentifiable"]),
                    };
                },
                    (parameters.useMFP) ? "admapp_ReadTurnaroundsByFacilityAndCustomer_MFP" : "admapp_ReadTurnaroundsByFacilityAndCustomer",
                    CommandType.StoredProcedure,
                    new SqlParameter("@FacilityId", parameters.FacilityId),
                    new SqlParameter("@AlternateFacilityId", parameters.AlternateFacilityId),
                    new SqlParameter("@CustomerDefinitionId", parameters.CustomerDefinitionId),
                    parameters.useMFP ? new SqlParameter("@MFPProductionEventTypeId", parameters.ProductionEventTypeId) : new SqlParameter("@ProductionEventTypeId", lastProcessEventTypeIdsDataTable) { SqlDbType = SqlDbType.Structured },
                    !parameters.ProductionEventTypeId.HasValue ? new SqlParameter("@LastProcessEventTypeId", parameters.LastProcessEventTypeId) : new SqlParameter("@LastProcessEventTypeId", null),
                    new SqlParameter("@BaseItemTypeId", parameters.BaseItemTypeId),
                    new SqlParameter("@ServiceRequirementDefinitionId", parameters.ServiceRequirementDefinitionId),
                    new SqlParameter("@OverDue", parameters.OverDue ?? false),
                    new SqlParameter("@IsAscending", parameters.Filter.OrderByAscending),
                    new SqlParameter("@SortField", parameters.Filter.OrderBy ?? ""),
                    new SqlParameter("@PageSize", parameters.Filter.Take ?? 0),
                    new SqlParameter("@PageIndex", parameters.Filter.Skip),
                    new SqlParameter("@TurnaroundExternalId", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.TurnaroundExternalId.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@ContainerMasterBaseItemType", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.BaseItemTypeText.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@ContainerMasterItemType", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.ItemTypeText.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@ContainerInstancePrimaryId", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.ContainerInstancePrimaryId.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@ContainerMasterName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.ContainerMasterName.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@LastEventName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.LastEventName.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@LastEventTime", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.LastEventTime.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@Expiry", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.Expiry.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@ServiceRequirementName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.ServiceRequirementName.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@CustomerName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.CustomerName.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@DeliveryPointName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.DeliveryPointName.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@QuarantineReasonText", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.QuarantineReason.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@IsIdentifiable", (
                        parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.IsIdentifiable.ToString()) != null &&
                        !string.IsNullOrEmpty(parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.IsIdentifiable.ToString()).Value) ?
                        Convert.ToBoolean(parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.IsIdentifiable.ToString()).Value) :
                        (bool?)null)),
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@UserTimeZone", userTimeZone),
                    new SqlParameter("@IsProductionOverView", isProductionOverView),
                    new SqlParameter("@FacilityName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.FacilityName.ToString()) ?? new SearchItem()).Value),
                    CultureHelper.CreateUserCultureData(userCultureData),
                   new SqlParameter("@UseEventContext", parameters.UseEventContext),
                   new SqlParameter("@IncludeAlternateFacilityItems", parameters.IncludeAlternateFacilityItems ?? false)
                );

                if (turnaroundList != null && turnaroundList.Any())
                {
                    parameters.Filter.ItemCount = turnaroundList.First().TotalRows ?? default(int);
                    parameters.ExpiredItemsCount = turnaroundList.First().ExpiredItemsCount ?? default(int);
                    parameters.NearExpiryItemsCount = turnaroundList.First().NearExpiryItemsCount ?? default(int);
                }

                return turnaroundList.Select(t => new Turnaround
                {
                    ExternalId = t.TurnaroundExternalId,
                    TurnaroundId = t.TurnaroundId,
                    ContainerInstancePrimaryId = t.ContainerInstancePrimaryID,
                    ContainerMasterText = t.ContainerMasterName,
                    LastEventEventTypeText = t.LastEventEventTypeText,
                    LastProcessEventType = new EventType { EventTypeId = t.LastEventTypeId, Text = t.LastEventEventTypeText, ProcessEvent = t.ProcessEvent },
                    Created = t.Created,
                    LastEventCreated = t.Created,
                    Expiry = t.Expiry, // expiry countdown needs to be added
                    ServiceRequirementText = t.ServiceRequirementName,
                    CustomerText = t.CustomerName,
                    QuarantineReasonText = string.IsNullOrEmpty(t.QuarantineReason) ? string.Empty : t.QuarantineReason.ToLower() != QuarantineReasonIdentifier.Quarantine.ToString().ToLower() ? string.Format("{0} {1}", "", t.QuarantineReason) : t.QuarantineReason,
                    HighPriorityCount = t.PriorityOrder == 3 ? 1 : 0,
                    MediumPriorityCount = t.PriorityOrder == 2 ? 1 : 0,
                    Priority = (TurnaroundPriority)t.PriorityOrder,
                    IsFastTrack = t.IsFastTrack ?? false,
                    CustomerDefinitionId = t.CustomerDefinitionId,
                    ServiceRequirementDefinitionId = t.ServiceRequirementDefinitionId,
                    FacilityName = t.FacilityName,
                    FacilityId = t.FacilityId,
                    IsIdentifiable = t.IsIdentifiable
                }).ToList();
            }
        }

        /// <summary>
        /// Gets the production turnarounds by facility.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetProductionTurnaroundsByFacility operation
        /// </summary>
        public IQueryable<Turnaround> GetProductionTurnaroundsByFacility(short facilityId)
        {
            var list = new List<Turnaround>();
            IUnitOfWork unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork();
            var facilityRepository = FacilityRepository.New(unitOfWork);
            IQueryable<Turnaround> turnarounds =
                facilityRepository.GetDeliveryPointsByFacility(facilityId).SelectMany(dp => dp.Turnaround);
            var turnaroundEventRepository = TurnaroundEventRepository.New(unitOfWork);

            foreach (Turnaround turnaround in turnarounds)
            {
                var lastEvent = new TurnaroundEvent();
                try
                {
                    lastEvent =
                        turnaroundEventRepository.Repository.Find(te => te.TurnaroundId == turnaround.TurnaroundId).
                            OrderByDescending(te => te.Created).FirstOrDefault();
                }
                catch (Exception)
                {
                }
                if (null != lastEvent)
                {
                    switch ((TurnAroundEventTypeIdentifier)lastEvent.EventTypeId)
                    {
                        case TurnAroundEventTypeIdentifier.Wash:
                        case TurnAroundEventTypeIdentifier.TrayPrioritisation:
                        case TurnAroundEventTypeIdentifier.QualityAssurance:
                        case TurnAroundEventTypeIdentifier.IntoAutoclave:
                        case TurnAroundEventTypeIdentifier.OutofAutoclave:
                        case TurnAroundEventTypeIdentifier.Dispatch:
                        case TurnAroundEventTypeIdentifier.FailedQualityAssurance:
                        case TurnAroundEventTypeIdentifier.FailedWash:
                        case TurnAroundEventTypeIdentifier.IntoQuarantine:
                        case TurnAroundEventTypeIdentifier.OutOfQuarantine:
                        case TurnAroundEventTypeIdentifier.RemovedFromDeliveryNote:
                        case TurnAroundEventTypeIdentifier.WetPack:
                            list.Add(turnaround);
                            break;
                        default:
                            break;
                    }
                }
            }
            return list.AsQueryable();
        }

        /// <summary>
        /// Gets the type of the production turnarounds by facility and event.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetProductionTurnaroundsByFacilityAndEventType operation
        /// </summary>
        public IQueryable<Turnaround> GetProductionTurnaroundsByFacilityAndEventType(short facilityId, int eventType)
        {
            var facilityRepository = FacilityRepository.New(
                                                            UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
            IQueryable<Turnaround> turnarounds =
                facilityRepository.GetDeliveryPointsByFacility(facilityId).SelectMany(dp => dp.Turnaround);
            var turnaroundEventRepository = TurnaroundEventRepository.New(
                                                                          UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
            var list = (from turnaround in turnarounds
                        let lastEvent = turnaroundEventRepository.Repository.Find(te => te.TurnaroundId == turnaround.TurnaroundId).OrderByDescending(te => te.Created).FirstOrDefault()
                        where lastEvent.EventTypeId == eventType
                        select turnaround).ToList();
            return list.AsQueryable();
        }

        /// <summary>
        /// Gets the type of the production turnarounds by facility item type and event.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="itemtypeId">The itemtype id.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetProductionTurnaroundsByFacilityItemTypeAndEventType operation
        /// </summary>
        public IQueryable<Turnaround> GetProductionTurnaroundsByFacilityItemTypeAndEventType(short facilityId,
                                                                                             int itemtypeId,
                                                                                             int eventType)
        {
            var facilityRepository = FacilityRepository.New(
                                                            UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
            var turnarounds =
                facilityRepository.GetDeliveryPointsByFacility(facilityId).SelectMany(dp => dp.Turnaround).Where(
                    t =>
                    t.ContainerInstance.ContainerMasterDefinition.ContainerMasters.OrderByDescending(c => c.Revision).
                        FirstOrDefault().ItemTypeId == itemtypeId);
            var turnaroundEventRepository = TurnaroundEventRepository.New(
                                                                          UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
            var list = (from turnaround in turnarounds
                        let lastEvent = turnaroundEventRepository.Repository.Find(te => te.TurnaroundId == turnaround.TurnaroundId).OrderByDescending(te => te.Created).FirstOrDefault()
                        where lastEvent.EventTypeId == eventType
                        select turnaround).ToList();
            return list.AsQueryable();
        }

        /// <summary>
        /// Reads the turnarounds by status facility.
        /// </summary>
        /// <param name="turnaroudEventTypeId">The turnaroud event type id.</param>
        /// <param name="customerId">The customer id.</param>
        /// <param name="facilityId">The facility id.</param>
        /// <param name="itemTypeId">The item type id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadTurnaroundsByStatusFacility operation
        /// </summary>
        public IQueryable<Turnaround> ReadTurnaroundsByStatusFacility(int turnaroudEventTypeId, int customerId,
                                                                      short facilityId, int itemTypeId)
        {
            var customerRepository = CustomerRepository.New(
                                                            UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
            int customerDefinitionId = customerRepository.Get(customerId).CustomerDefinitionId;
            return
                Repository.Find(
                    t =>
                    t.LastEvent.EventTypeId == turnaroudEventTypeId && t.Facility.FacilityId == facilityId &&
                    t.DeliveryPoint.CustomerDefinitionId == customerDefinitionId &&
                    (t.ContainerMaster.ItemTypeId == itemTypeId ||
                     t.ContainerInstance.ContainerMasterDefinition.ContainerMasters.OrderByDescending(cm => cm.Revision)
                         .FirstOrDefault().ItemTypeId == itemTypeId));
        }

        /// <summary>
        /// Reads the unreleased carriages.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadUnreleasedCarriages operation
        /// </summary>
        public IQueryable<Turnaround> ReadUnreleasedCarriages(short facilityId)
        {
            return Repository.Find(t => t.TurnaroundWH.Any(a => a.FacilityId == facilityId &&
                (a.LastEventTypeId == (int)TurnAroundEventTypeIdentifier.CarriageCreated || a.LastEventTypeId == (int)TurnAroundEventTypeIdentifier.AcknowledgeNote) &&
                 (a.NextEventTypeId == (int)TurnAroundEventTypeIdentifier.Wash || a.NextEventTypeId == (int)TurnAroundEventTypeIdentifier.WashIn) && a.ContainerMasterBaseItemTypeId == (int)ItemTypeIdentifier.BaseCarriage));
        }

        /// <summary>
        /// Reads the unreleased carriages.
        /// </summary>
        /// <param name="facilityId">The facility id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadUnreleasedBatchTags operation
        /// </summary>
        public IQueryable<Turnaround> ReadUnreleasedBatchTags(short facilityId)
        {
            return Repository.Find(t => t.TurnaroundWH.Any(a => a.FacilityId == facilityId &&
                (a.LastEventTypeId == (int)TurnAroundEventTypeIdentifier.BatchTagCreated || a.LastEventTypeId == (int)TurnAroundEventTypeIdentifier.AcknowledgeNote || a.LastEventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromCarriage) &&
                 (a.NextEventTypeId == (int)TurnAroundEventTypeIdentifier.Wash || a.NextEventTypeId == (int)TurnAroundEventTypeIdentifier.WashIn) && a.ContainerMasterBaseItemTypeId == (int)ItemTypeIdentifier.BatchTag));
        }
        /// <summary>
        /// Reads the child turnarounds.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadChildTurnarounds operation
        /// </summary>
        public IQueryable<Turnaround> ReadChildTurnarounds(int turnaroundId)
        {
            return
                Repository.Find(t => t.ParentTurnaroundId == turnaroundId);
        }

        /// <summary>
        /// Reads the assigned to turnarounds.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadAssignedToTurnarounds operation
        /// </summary>
        public IQueryable<Turnaround> ReadAssignedToTurnarounds(int turnaroundId, DateTime startDate, DateTime endDate)
        {
            if (startDate > DateTime.MinValue && endDate > DateTime.MinValue)
            {
                return Repository.Find(t => t.TurnaroundAssignedsAsParent.Any(a => a.TurnaroundChildId == turnaroundId) && t.Created >= startDate && t.Created <= endDate);
            }
            else
            {
                return Repository.Find(t => t.TurnaroundAssignedsAsParent.Any(a => a.TurnaroundChildId == turnaroundId));
            }
        }

        /// <summary>
        /// Reads the assigned to turnarounds.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadAssignedTurnarounds operation
        /// </summary>
        public IQueryable<Turnaround> ReadAssignedTurnarounds(int turnaroundId, DateTime startDate, DateTime endDate)
        {
            if (startDate > DateTime.MinValue && endDate > DateTime.MinValue)
            {
                return Repository.Find(t => t.TurnaroundAssignedsAsChild.Any(a => a.TurnaroundParentId == turnaroundId) && t.Created >= startDate && t.Created <= endDate);
            }

            return Repository.Find(t => t.TurnaroundAssignedsAsChild.Any(a => a.TurnaroundParentId == turnaroundId));
        }

        /// <summary>
        /// Reads the turnaround details.
        /// </summary>
        /// <param name="turnaroundId">The turnaround id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadTurnaroundDetails operation
        /// </summary>
        public ITurnaroundDetail ReadTurnaroundDetails(int turnaroundId)
        {
            var turnaround = Repository.Find(t => t.TurnaroundId == turnaroundId).FirstOrDefault();
            var turnaroundDetailData = new TurnaroundDetailData();
            var deliveryPoint = turnaround.DeliveryPoint;

            if (turnaround.TurnaroundEvent != null)
            {
                var autoclaveBatch = turnaround.TurnaroundEvent.Where(te => te.EventTypeId == 6 && te.Batch != null).Select(b => b.Batch).Where(type => type.Machine.MachineTypeId == 1).OrderByDescending(i => i.Created).FirstOrDefault();
                if (autoclaveBatch != null)
                {
                    turnaroundDetailData.AutoclaveBatch = autoclaveBatch.BatchId;
                    turnaroundDetailData.AutoclaveName = autoclaveBatch.Machine.Text;
                    turnaroundDetailData.AutoclaveBatchExternalId = autoclaveBatch.ExternalId;
                    turnaroundDetailData.AutoClaveMachineId = autoclaveBatch.MachineId.Value;
                    turnaroundDetailData.AutoClaveProcessedFacility = autoclaveBatch.Machine.Facility.Text;
                }

                var washBatch = turnaround.TurnaroundEvent.Where(te => (te.EventTypeId == (int)TurnAroundEventTypeIdentifier.Wash || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.WashRelease || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.WashRequireRelease
                        || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.WashIn || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.ChangedBatch)
                        && te.Batch != null).OrderByDescending(i => i.TurnaroundEventId).Select(b => b.Batch).FirstOrDefault(type => type.Machine.MachineTypeId == (byte)MachineTypeIdentifier.Washer || type.Machine.MachineTypeId == (byte)MachineTypeIdentifier.Post1997Washer);

                if (washBatch != null)
                {
                    turnaroundDetailData.WasherBatch = washBatch.BatchId;
                    turnaroundDetailData.WasherName = washBatch.Machine.Text;
                    turnaroundDetailData.WasherBatchExternalId = washBatch.ExternalId;
                    turnaroundDetailData.MachineId = washBatch.MachineId.Value;
                    turnaroundDetailData.WasherMachineId = washBatch.MachineId.Value;
                    turnaroundDetailData.WasherProcessedFacility = washBatch.Machine.Facility.Text;
                }

                turnaroundDetailData.IsEndoscope = turnaround.ContainerMaster?.BaseItemType.ItemTypeId == (int)ItemTypeIdentifier.Endoscopy;

                var aerWashBatch = turnaround.TurnaroundEvent.Where(te =>
                        (te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AssignedToAer
                        || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AerStart
                        || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AerFailed
                        || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AerPassed
                        || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.ChangedBatch)
                        && te.Batch != null)
                    .OrderByDescending(i => i.Created)
                    .ThenByDescending(i => i.TurnaroundEventId).Select(b => b.Batch)
                    .FirstOrDefault(type => type.Machine.MachineTypeId == (byte)MachineTypeIdentifier.Aer);

                if (aerWashBatch != null)
                {
                    turnaroundDetailData.AerWasherBatch = aerWashBatch.BatchId;
                    turnaroundDetailData.AerWasherName = aerWashBatch.Machine.Text;
                    turnaroundDetailData.AerWasherBatchExternalId = aerWashBatch.ExternalId;
                    turnaroundDetailData.MachineId = aerWashBatch.MachineId.Value;
                    turnaroundDetailData.AerWasherMachineId = aerWashBatch.MachineId.Value;
                    turnaroundDetailData.AerWasherProcessedFacility = aerWashBatch.Machine.Facility.Text;
                }

                var lastProcessEvent = turnaround.TurnaroundEvent.Where(te => te.EventType.ProcessEvent).OrderByDescending(i => i.Created).ThenByDescending(i => i.TurnaroundEventId).FirstOrDefault();
                var workflowRepository = WorkflowRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
                var possibleEventTypes = workflowRepository.ReadNextEvents(lastProcessEvent.EventTypeId, turnaround.ContainerMaster.ItemTypeId, turnaround.FacilityId, turnaround.ContainerMasterId, turnaround.DeliveryPointId).ToList();
                turnaroundDetailData.CanQuarantine = possibleEventTypes.Any(et => et.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoQuarantine);
            }
            if (deliveryPoint != null)
            {
                turnaroundDetailData.DeliveryPointName = deliveryPoint.Text;
                turnaroundDetailData.DeliveryPointId = deliveryPoint.DeliveryPointId;
                var customer = deliveryPoint.CustomerDefinition.Customer.OrderByDescending(t => t.Revision).FirstOrDefault();
                if (customer != null)
                {
                    turnaroundDetailData.CustomerName = customer.Text;
                    turnaroundDetailData.CustomerId = customer.CustomerId;
                    turnaroundDetailData.CustomerFacilityName = customer.Facility.Text;
                }
            }

            turnaroundDetailData.TurnaroundId = turnaround.TurnaroundId;
            turnaroundDetailData.ExternalId = turnaround.ExternalId;
            turnaroundDetailData.ServiceRequirementId = turnaround.ServiceRequirementId;
            turnaroundDetailData.Expiry = turnaround.Expiry;

            if (turnaround.DeliveryNote != null)
            {
                turnaroundDetailData.DeliveryNoteExternalId = turnaround.DeliveryNote.ExternalId;
                turnaroundDetailData.DeliveryNoteId = turnaround.DeliveryNote.DeliveryNoteId;
            }

            turnaroundDetailData.MasterType = Core.Enums.MasterType.ContainerMaster;
            turnaroundDetailData.MasterId = turnaround.ContainerMaster.ContainerMasterId;
            turnaroundDetailData.ItemExternalId = turnaround.ContainerMaster.ExternalId;
            turnaroundDetailData.ItemName = turnaround.ContainerMaster.Text;
            turnaroundDetailData.ItemType = turnaround.ContainerMaster.ItemType.Text;

            if (turnaround.ContainerInstance != null)
            {
                turnaroundDetailData.ContainerInstanceId = turnaround.ContainerInstance.ContainerInstanceId;
                turnaroundDetailData.ContainerInstancePrimaryId = turnaround.ContainerInstance.PrimaryId;
                turnaroundDetailData.IsIdentifiable = turnaround.ContainerInstance.IsIdentifiable;
            }

            var orderLine = turnaround.OrderLine?.FirstOrDefault(ol => ol.TurnaroundId == turnaroundId);

            if (orderLine != null)
            {
                turnaroundDetailData.OrderId = orderLine.OrderId;
                turnaroundDetailData.OrderNumber = orderLine.Order.OrderNumber;
            }

            turnaroundDetailData.DisableTrolleyCustomerRestriction = turnaround.DisableTrolleyCustomerRestriction;
            turnaroundDetailData.ShowDisableTrolleyCustomerRestriction = turnaround.ContainerMaster.ItemType.IsReprocessableType() && IsFacilityUsingTrolleyDispatch(turnaround.FacilityId);
            turnaroundDetailData.CanDisableTrolleyCustomerRestriction = turnaround.CanDisableTrolleyCustomerRestriction();

            bool IsFacilityUsingTrolleyDispatch(short facilityId){
                var facilityRepository = FacilityRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
                return facilityRepository.ReadStationTypesByFacility(facilityId)
                    .Any(st => st.StationTypeId == (int)StationTypeIdentifier.TrolleyDispatch 
                            || st.StationTypeId == (int)StationTypeIdentifier.OOATrolleyDispatch);
            }

            return turnaroundDetailData;
        }

        /// <summary>
        /// Reads the turnaround tab details.
        /// </summary>
        /// <param name="turnaroundId">The turnaround uid.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadTurnaroundTabDetails operation
        /// </summary>
        public ITurnaroundTabDetail ReadTurnaroundTabDetails(int turnaroundId)
        {
            bool hasEndoscopyTurnaroundEnded = false;
            {
                hasEndoscopyTurnaroundEnded = repository.DataManager.ExecuteQuery((row, table, set) =>
                    {
                        return Convert.ToBoolean(row["HasEnded"]);
                    },
                  "dbo.Endoscopy_HasTurnaroundEnded",
                  CommandType.StoredProcedure,
                  new SqlParameter("TurnaroundID", turnaroundId)
                  ).FirstOrDefault();
            }

            var QueryableTurnaround = Repository.Find(t => t.TurnaroundId == turnaroundId);
            var turnaround = QueryableTurnaround.FirstOrDefault();

            var model = QueryableTurnaround.Select(i => new TurnaroundTabDetailData
            {
                    TurnaroundId = i.TurnaroundId,
                    ExternalId = i.ExternalId,
                    DeliveryPointId = i.DeliveryPoint.DeliveryPointId,
                    CustomerDefinitionId = i.DeliveryPoint.CustomerDefinitionId,
                    CustomerId = i.DeliveryPoint.CustomerDefinition.Customer.FirstOrDefault(customer => customer.CustomerStatusId == (byte)CustomerStatusTypeIdentifier.Active).CustomerId,
                    CustomerEmail = i.DeliveryPoint.CustomerDefinition.Customer.FirstOrDefault(customer => customer.CustomerStatusId == (byte)CustomerStatusTypeIdentifier.Active).Address.ContactEmail,
                    FacilityId = i.FacilityId,
                    IsTurnaroundInQuarantine = i.TurnaroundEvent.Where(T => T.EventType.ProcessEvent).OrderByDescending(j => j.Created).ThenByDescending(k => k.TurnaroundEventId).FirstOrDefault().EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoQuarantine,
                    ContainerInstanceId = i.ContainerInstanceId,
                    IsTurnaroundArchived = i.TurnaroundEvent.Any(j => j.EventTypeId == (short)TurnAroundEventTypeIdentifier.Archived),
                    LastEventName = i.TurnaroundEvent.OrderByDescending(j => j.Created).ThenByDescending(k => k.TurnaroundEventId).FirstOrDefault().EventType.Text,
                    LastEventTypeId = i.TurnaroundEvent.OrderByDescending(j => j.Created).ThenByDescending(k => k.TurnaroundEventId).FirstOrDefault().EventTypeId,
                    ContainerMasterId = i.ContainerMaster != null ? i.ContainerMasterId : (i.ContainerInstance != null ? i.ContainerInstance.ContainerMasterDefinition.ContainerMasters.OrderByDescending(j => j.Created).FirstOrDefault().ContainerMasterId : i.ContainerMaster.ContainerMasterDefinition.ContainerMasters.OrderByDescending(j => j.Created).FirstOrDefault().ContainerMasterId),
                    LatestContainerMasterId = i.ContainerInstance != null ? i.ContainerInstance.ContainerMasterDefinition.ContainerMasters.OrderByDescending(j => j.Created).FirstOrDefault().ContainerMasterId : i.ContainerMaster.ContainerMasterDefinition.ContainerMasters.OrderByDescending(j => j.Created).FirstOrDefault().ContainerMasterId,
                    ItemType = i.ContainerMaster.ContainerMasterDefinition.ContainerMasters.OrderByDescending(j => j.Created).FirstOrDefault().ItemType.Text,
                    ServiceRequirementId = i.ServiceRequirementId,
                    InvoiceLineId = i.InvoiceLineId,
                    DeliveryPointEmail = i.DeliveryPoint.Address.ContactEmail,
                    BaseType = i.ContainerMaster.ItemType.ParentItemType.Text,
                    CanSaveTurnaround = (!i.TurnaroundEvent.Any(j => j.EventTypeId == (short)TurnAroundEventTypeIdentifier.DeliveryNotePrint) && !hasEndoscopyTurnaroundEnded),
            }).FirstOrDefault();

            var lastProcessEvent = turnaround.TurnaroundEvent.Where(te => te.EventType.ProcessEvent).OrderByDescending(i => i.Created).ThenByDescending(i => i.TurnaroundEventId).FirstOrDefault();
            var workflowRepository = WorkflowRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
            var possibleEventTypes = workflowRepository.ReadNextEvents(lastProcessEvent.EventTypeId, turnaround.ContainerMaster.ItemTypeId, turnaround.FacilityId, turnaround.ContainerMasterId, turnaround.DeliveryPointId).ToList();
            model.CanQuarantine = possibleEventTypes.Any(et => et.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoQuarantine);

            return model;
        }

        /// <summary>
        /// Read turnarounds of the item given.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        /// <summary>
        /// GetTurnaroundsForAssignedTo operation
        /// </summary>
        public IQueryable<Turnaround> GetTurnaroundsForAssignedTo(int instanceId)
        {
            var turnarounds =
                Repository.Find(t => t.ContainerInstanceId == instanceId).OrderByDescending(t => t.TurnaroundId).Select(t => t.TurnaroundId).FirstOrDefault();
            var result = Repository.Find(i => i.ParentTurnaroundId == turnarounds);
            return result;
        }

        /// <summary>
        /// Read turnarounds of the item given.
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        /// <summary>
        /// GetTurnaroundsForAssigned operation
        /// </summary>
        public IQueryable<Turnaround> GetTurnaroundsForAssigned(int instanceId)
        {
            var turnaround =
                Repository.Find(t => t.ContainerInstanceId == instanceId).OrderByDescending(t => t.TurnaroundId).Select(t => t.TurnaroundId).FirstOrDefault();
            var result = Repository.Find(i => i.ChildTurnaround.Any(a => a.TurnaroundId == turnaround));
            return result;
        }

        /// <summary>
        /// Reads the turnaround for a given instance and date range
        /// </summary>
        /// <param name="instanceUid">The instanceUid</param>
        /// <param name="fromDate">The fromDate</param>
        /// <param name="toDate">The toDate</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetTurnaroundsByInstanceAndDate operation
        /// </summary>
        public IQueryable<Turnaround> GetTurnaroundsByInstanceAndDate(int instanceUid, DateTime fromDate, DateTime toDate)
        {

            return Repository.
               Find(turnaround =>
                   turnaround.LastEvent.Created >= fromDate &&
                   turnaround.LastEvent.Created <= toDate &&
                   turnaround.ContainerInstanceId == instanceUid).
               OrderBy(t => t.Expiry);
        }

        /// <summary>
        /// Reads the turnaround for a given instance and date range
        /// </summary>
        /// <param name="masterId">The instanceUid</param>
        /// <param name="fromDate">The fromDate</param>
        /// <param name="toDate">The toDate</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetTurnaroundsByMasterAndDate operation
        /// </summary>
        public IQueryable<Turnaround> GetTurnaroundsByMasterAndDate(int masterId, DateTime fromDate, DateTime toDate)
        {
            return Repository.
                Find(turnaround =>
                    turnaround.LastEvent.Created >= fromDate &&
                    turnaround.LastEvent.Created <= toDate &&
                    (
                        turnaround.ContainerMasterId == masterId ||
                        (
                            turnaround.ContainerInstance != null &&
                            turnaround.ContainerInstance.ContainerMasterDefinition.ContainerMasters.Any(i => i.ContainerMasterId == masterId)
                        ) ||
                        (
                            turnaround.ContainerMaster != null && turnaround.ContainerMaster.ContainerMasterDefinition.ContainerMasters.Any(i => i.ContainerMasterId == masterId)
                        )
                    )

                    ).
                OrderBy(t => t.Expiry);
        }

        /// <summary>
        /// Reads the workflow event for a given turnaround
        /// </summary>
        /// <param name="turnaroundId"></param>
        /// <returns></returns>
        /// <summary>
        /// GetWorkFlowByTurnaround operation
        /// </summary>
        public IQueryable<IWorkflow> GetWorkFlowByTurnaround(int turnaroundId)
        {
            var itemtypeId = Repository.Find(turnaround => turnaround.TurnaroundId == turnaroundId).Select(i => i.ContainerMaster).FirstOrDefault().ItemTypeId;
            var workFlowRepository = WorkflowRepository.New(Repository.UnitOfWork);
            return workFlowRepository.All().Where(workflow => workflow.ItemTypeId == itemtypeId);
        }

        /// <summary>
        /// GetLastProcessWorkFlow operation
        /// </summary>
        public Workflow GetLastProcessWorkFlow(IQueryable<TurnaroundEvent> turnaroundEvents, IQueryable<Workflow> workflows, int eventIndex)
        {
            var eventId = turnaroundEvents.OrderByDescending(a => a.Created).ThenByDescending(o => o.TurnaroundEventId).
                 Where(b => b.EventTypeId != (short)TurnAroundEventTypeIdentifier.IntoQuarantine
                     && b.EventTypeId != (short)TurnAroundEventTypeIdentifier.OutOfQuarantine && b.EventTypeId != (short)TurnAroundEventTypeIdentifier.AcknowledgeNote && b.EventType.ProcessEvent).Select(c => c.EventTypeId).FirstOrDefault();

            var eventsToExclude = new List<short>
            {
                (short)TurnAroundEventTypeIdentifier.IntoQuarantine,
                (short)TurnAroundEventTypeIdentifier.FailedWash,
                (short)TurnAroundEventTypeIdentifier.Archived
            };

            var lastworkflow = workflows.FirstOrDefault(T => T.FromEventTypeId == eventId && T.FromEventTypeId != (short)TurnAroundEventTypeIdentifier.IntoQuarantine && !eventsToExclude.Contains(T.ToEventTypeId));

            if (lastworkflow == null)
            {
                eventIndex = eventIndex + 1;
                if (eventIndex <= turnaroundEvents.Count())
                {
                    lastworkflow = GetLastProcessWorkFlow(turnaroundEvents, workflows, eventIndex);
                }
            }
            else
            {
                return lastworkflow;
            }

            return lastworkflow;
        }

        /// <summary>
        /// ReadTurnaroundsByBatch operation
        /// </summary>
        public IQueryable<ITurnaround> ReadTurnaroundsByBatch(int batchId)
        {
            var batchRepository = BatchRepository.New(Repository.UnitOfWork);
            return
                batchRepository.Repository.Find(batch => batch.BatchId == batchId).SelectMany(batch => batch.TurnaroundEvent).Where(
                    te => te.TurnaroundEventId == te.Turnaround.CurrentTurnaroundEvent.TurnaroundEventId)
                     .Select(te => te.Turnaround).OrderBy(t => t.Expiry);
        }

        /// <summary>
        /// ReadTurnaroundsByBatchUnfiltered operation
        /// </summary>
        public IQueryable<Turnaround> ReadTurnaroundsByBatchUnfiltered(int batchId)
        {
            var teRepo = TurnaroundEventRepository.New(Repository.UnitOfWork);
            var turnaroundEvents = teRepo.Repository.Find(te => te.BatchId == batchId);
            return turnaroundEvents.Select(te => te.Turnaround).Distinct();
        }

        /// <summary>
        /// ReadTurnaroundsForGraphByFacilityAndCustomer operation
        /// </summary>
        public IList<Turnaround> ReadTurnaroundsForGraphByFacilityAndCustomer(ProductionParamCollection parameters, int userId, string userTimeZone, UserCultureData userCultureData)
        {
            {
                IUnitOfWork unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork();
                var facilityRepository = new FacilityRepository(unitOfWork);
                var facility = facilityRepository.Get((short)parameters.FacilityId);
                var context = (OperativeModelContainer)Repository.UnitOfWork.Context;
                var isProductionOverView = default(bool);
                var lastProcessEventTypeIdsDataTable = new DataTable("EventTypeID");
                lastProcessEventTypeIdsDataTable.Columns.Add("EventTypeId");

                if (parameters.ProductionEventTypeId > 0)
                {
                    if (parameters.ProductionEventTypeId == (int)ProductionEventTypeIdentifier.MFPWash
                        || parameters.ProductionEventTypeId == (int)ProductionEventTypeIdentifier.MFPWashIn)
                    {
                        isProductionOverView = true;
                    }
                    else
                    {
                        var lastProcessEventTypeIds = context.EventType.ToList().Where(j => j.ProductionEventTypeId(facility.WashRelease) == parameters.ProductionEventTypeId).Select(j => j.EventTypeId);
                        foreach (var eventTypeId in lastProcessEventTypeIds)
                        {
                            lastProcessEventTypeIdsDataTable.Rows.Add(eventTypeId);
                        }
                    }

                }
                else if (parameters.ProductionEventTypeId == (int)ProductionEventTypeIdentifier.AllProductionEvents)
                {
                    isProductionOverView = true;
                }

                var turnaroundList = repository.DataManager.ExecuteQuery<admapp_ReadTurnaroundsForGraphByFacilityAndCustomer_Result>((row, table, set) =>
                {
                    return new admapp_ReadTurnaroundsForGraphByFacilityAndCustomer_Result
                    {
                        HighPriorityCount = Convert.ToInt32(row["HighPriorityCount"]),
                        LastEventEventTypeText = (row["LastEventEventTypeText"]).ToString(),
                        LastEventTypeId = Convert.ToInt16(row["LastEventTypeId"]),
                        MediumPriorityCount = Convert.ToInt32(row["MediumPriorityCount"]),
                        TurnaroundCount = Convert.ToInt32(row["TurnaroundCount"]),
                        EventDisplayOrder = Convert.ToInt16(row["EventDisplayOrder"])
                    };
                },
                    parameters.useMFP ? "admapp_ReadTurnaroundsForGraphByFacilityAndCustomer_MFP" : "admapp_ReadTurnaroundsForGraphByFacilityAndCustomer",
                    CommandType.StoredProcedure,
                    new SqlParameter("@FacilityId", parameters.FacilityId),
                    new SqlParameter("@AlternateFacilityId", parameters.AlternateFacilityId),
                    new SqlParameter("@FacilityName", parameters.FacilityName),
                    new SqlParameter("@CustomerDefinitionId", parameters.CustomerDefinitionId),
                    parameters.useMFP ? new SqlParameter("@MFPProductionEventTypeId", parameters.ProductionEventTypeId) : new SqlParameter("@ProductionEventTypeId", lastProcessEventTypeIdsDataTable) { SqlDbType = SqlDbType.Structured },
                    new SqlParameter("@LastProcessEventTypeId", parameters.LastProcessEventTypeId),
                    new SqlParameter("@BaseItemTypeId", parameters.BaseItemTypeId),
                    new SqlParameter("@ServiceRequirementDefinitionId", parameters.ServiceRequirementDefinitionId),
                    new SqlParameter("@OverDue", parameters.OverDue ?? false),
                    new SqlParameter("@TurnaroundExternalId", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.TurnaroundExternalId.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@ContainerInstancePrimaryId", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.ContainerInstancePrimaryId.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@ContainerMasterName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.ContainerMasterName.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@LastEventName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.LastEventName.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@LastEventTime", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.LastEventTime.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@Expiry", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.Expiry.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@ServiceRequirementName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.ServiceRequirementName.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@CustomerName", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.CustomerName.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@QuarantineReasonText", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.QuarantineReason.ToString()) ?? new SearchItem()).Value),
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@IsProductionOverView", isProductionOverView),
                    new SqlParameter("@UserTimeZone", userTimeZone),
                    new SqlParameter("@IsIdentifiable", (parameters.Filter.SearchItems.FirstOrDefault(i => i.PropertyAlias == PropertyAlias.IsIdentifiable.ToString()) ?? new SearchItem()).Value),
                    CultureHelper.CreateUserCultureData(userCultureData),
                    new SqlParameter("@IncludeAlternateFacilityItems", parameters.IncludeAlternateFacilityItems ?? false)
                    );

                return turnaroundList.Select(t => new Turnaround
                {
                    TurnaroundCount = t.TurnaroundCount ?? default(int),
                    LastEventEventTypeText = t.LastEventEventTypeText,
                    LastEventTypeId = t.LastEventTypeId,
                    HighPriorityCount = t.HighPriorityCount ?? default(int),
                    MediumPriorityCount = t.MediumPriorityCount ?? default(int),
                    EventDisplayOrder = t.EventDisplayOrder,
                }).ToList();
            }
        }

        /// <summary>
        /// GetTurnaroundUsingExternalId operation
        /// </summary>
        public ITurnaround GetTurnaroundUsingExternalId(string externalId, short facilityId)
        {
            long value;
            long.TryParse(externalId, out value);

            var mfpRepository = MultiFacilityProcessingRepository.New(Repository.UnitOfWork);
            var repository = DeliveryPointRepository.New(Repository.UnitOfWork);
            var facilities = mfpRepository.GetPrimaryFacilities(facilityId);
            var turnaround = Repository.Find(t => t.ExternalId == value && t.TurnaroundFacility.Any(tf => facilities.Contains(tf.FacilityId))).FirstOrDefault();

            if (turnaround.DeliveryPointId > 0)
            {
                turnaround.CustomerDefinitionId = repository.GetCustomerByDeliveryPoint(turnaround.DeliveryPointId).CustomerDefinitionId;
            }
            return turnaround;
        }
        /// <summary>
        /// Reads the number of turnarounds by event type and base type
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <returns></returns>
        /// <summary>
        /// ReadProductionOverviewByBaseItemType operation
        /// </summary>
        public IList<Turnaround> ReadProductionOverviewByBaseItemType(short? facilityId, string customerDefinitionId, UserCultureData userCultureData)
        {
            {
                var result = repository.DataManager.ExecuteQuery((row, table, set) =>
                {
                    return new Turnaround
                    {
                        AnyOverdue = Convert.ToInt32(row["AnyOverdue"]) == 1,
                        TurnaroundCount = row.Field<int?>("TurnaroundCount") ?? 0,
                        LastEventEventTypeText = Convert.ToString(row["LastEventEventTypeText"]),
                        ContainerMasterBaseItemType =
                            new ItemType
                            {
                                ItemTypeId = Convert.ToInt16(row["ContainerMasterBaseItemTypeId"]),
                                Text = Convert.ToString(row["ContainerMasterBaseItemTypeText"])
                            },
                        LastProcessEventType =
                            new EventType
                            {
                                EventTypeId = Convert.ToInt16(row["LastEventTypeId"]),
                                Text = Convert.ToString(row["LastEventEventTypeText"])
                            },
                        HighPriorityCount = row.Field<int?>("HighPriorityCount") ?? 0,
                        MediumPriorityCount = row.Field<int?>("MediumPriorityCount") ?? 0,
                        EventDisplayOrder = row.Field<int?>("EventDisplayOrder") ?? 0,
                        ProductionEventType = new ProductionEventType(Convert.ToInt16(row["ProductionEventTypeId"]), Convert.ToString(row["EventName"]), row.Field<int?>("EventDisplayOrder") ?? 0)
                    };
                },
                    "dbo.admapp_ReadProductionOverviewByBaseItemType",
                    CommandType.StoredProcedure,
                    new SqlParameter("FacilityId", facilityId),
                    new SqlParameter("CustomerDefinitionId", customerDefinitionId),
                    CultureHelper.CreateUserCultureData(userCultureData)
                    );

                return result.ToList();
            }
        }

        /// <summary>
        /// Reads the number of turnarounds by event type and service requirement
        /// </summary>
        /// <param name="facilityId"></param>
        /// <param name="customerDefinitionId"></param>
        /// <returns></returns>
        /// <summary>
        /// ReadProductionOverviewByServiceRequirement operation
        /// </summary>
        public IList<Turnaround> ReadProductionOverviewByServiceRequirement(int facilityId, int? customerDefinitionId)
        {
            var context = (OperativeModelContainer)Repository.UnitOfWork.Context;

            var turnarounds =
                context.admapp_ReadProductionOverviewByServiceRequirement(facilityId, customerDefinitionId).Select(
                    t => new Turnaround
                    {
                        TurnaroundCount = t.TurnaroundCount ?? 0,
                        LastEventEventTypeText = t.LastEventEventTypeText,
                        LastEventTypeId = t.LastEventTypeId,
                        ServiceRequirementText = t.ServiceRequirementText,
                        ServiceRequirementDefinitionId = t.ServiceRequirementDefinitionId,
                        CustomerText = t.CustomerText
                    }).ToList();
            return turnarounds;
        }

        /// <summary>
        /// ReadProductionOverviewByEventType operation
        /// </summary>
        public IList<Turnaround> ReadProductionOverviewByEventType(short facilityId, short? alternateFacilityId, bool washReleaseEnabled)
        {
            var context = (OperativeModelContainer)Repository.UnitOfWork.Context;

            var parameters = new Dictionary<string, object>
            {
                {"@CustomerDefinitionId", null},
                {"@FacilityId", facilityId},
                {"@ArchivedEventTypeId", (short) TurnAroundEventTypeIdentifier.Archived},
                {"@AlternativeFacilityId", facilityId == alternateFacilityId ? null : alternateFacilityId}
            };
            var datacommand = DataCommandFactory.CreateCommand(context, CommandType.StoredProcedure, "admapp_ReadProductionOverview", parameters);
            var result = datacommand.GetEntityList<admapp_ReadProductionOverview_Result>();

            var turnarounds = result.Select(t => new Turnaround()
            {
                AnyOverdue = t.AnyOverdue > 0,
                TurnaroundCount = t.TurnaroundCount ?? default(int),
                LastProcessEventType = new EventType { EventTypeId = t.EventTypeId, Text = t.EventType }
            }).ToList();

            var overview = ProductionEventType.
                Data.
                OrderBy(i => i.DisplayOrder).
                Select(i =>
                {
                    var turnaroundsByProductionEventType = turnarounds.Where(j => i.ProductionEventTypeId == j.LastProcessEventType.ProductionEventTypeId(washReleaseEnabled));

                    return new Turnaround
                    {
                        TurnaroundCount = turnaroundsByProductionEventType.Sum(j => j.TurnaroundCount),
                        AnyOverdue = turnaroundsByProductionEventType.Any(j => j.AnyOverdue),
                        ProductionEventType = i,
                    };
                });

            return overview.ToList();
        }

        /// <summary>
        /// CheckInstanceForCustomer operation
        /// </summary>
        public bool CheckInstanceForCustomer(int customerId, string turnaroundExternalId, bool forSameCustomer)
        {
            long tmpExternalId = long.Parse(turnaroundExternalId);

            if (forSameCustomer)
            {
                var cust = Repository.All().Where(t => t.ExternalId == tmpExternalId).OrderByDescending(i => i.Created).FirstOrDefault().ContainerInstance.ContainerMasterDefinition.CustomerDefinition.Customer.Where(i => i.CustomerId == customerId).FirstOrDefault();
                return cust != null;
            }
            else
            {
                var cust = Repository.All().Where(t => t.ExternalId == tmpExternalId).OrderByDescending(i => i.Created).FirstOrDefault().ContainerInstance.ContainerMasterDefinition.CustomerDefinition.Customer.Where(i => i.CustomerId != customerId).FirstOrDefault();
                return cust != null;
            }
        }

        /// <summary>
        /// Gets the tunraround by external id.
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetTurnaroundByExternalIdAndFacility operation
        /// </summary>
        public Turnaround GetTurnaroundByExternalIdAndFacility(long turnaroundExternalId, int facilityId)
        {
            return Repository.Find(t => t.ExternalId == turnaroundExternalId && t.FacilityId == facilityId).FirstOrDefault();
        }

        /// <summary>
        /// Gets the tunraround by external id.
        /// </summary>
        /// <param name="turnaroundExternalId">The turnaround external id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetTurnaroundByExternalIdAndFacility operation
        /// </summary>
        public Turnaround GetTurnaroundByExternalIdAndFacility(long turnaroundExternalId)
        {
            return Repository.Find(t => t.ExternalId == turnaroundExternalId).FirstOrDefault();
        }

        /// <summary>
        /// TurnaroundCompleted operation
        /// </summary>
        public bool TurnaroundCompleted(int turnaroundId, int userId, int facilityId, short abandonReasonId)
        {
            {
                bool saveChanges = false;
                var turnaround = repository.Container.Turnaround
                    .Include("TurnaroundEvent")
                    .Include("OrderLine")
                    .Include("ContainerInstance")
                    .FirstOrDefault(x => x.TurnaroundId == turnaroundId);

                if (turnaround == null)
                {
                    return false;
                }
                if (turnaround.TurnaroundEvent.Any(x =>
                    x.EventTypeId == (int)TurnAroundEventTypeIdentifier.Archived ||
                    x.EventTypeId == (int)TurnAroundEventTypeIdentifier.TurnaroundEndedEarly))
                {
                    return false;
                }
                if (turnaround.OrderLine.Any())
                {
                    turnaround.OrderLine.ToList().ForEach(ol => ol.OrderLineStatusId = (int)OrderLineStatusIdentifier.Ordered);
                    turnaround.OrderLine.FirstOrDefault().Order.OrderStatusId = (int)OrderStatusIdentifier.InProcess;

                    turnaround.OrderLine.Clear();
                    saveChanges = true;
                }
                if (turnaround.ContainerInstance?.CurrentLocationId != null)
                {
                    turnaround.ContainerInstance.CurrentLocationId = null;
                    saveChanges = true;
                }
                if (turnaround.ContainerInstance?.QuarantineReason != null)
                {
                    turnaround.ContainerInstance.QuarantineReason = null;
                    saveChanges = true;
                }
                if (turnaround.ParentTurnaroundId != null)
                {
                    turnaround.ParentTurnaroundId = null;
                    saveChanges = true;
                }
                if (saveChanges)
                {
                    repository.Container.SaveChanges();
                }
                var context = repository.Container;
                var parameters = new Dictionary<string, object>();
                parameters.Add("@TurnaroundId", turnaroundId);
                parameters.Add("@FacilityId", facilityId);
                parameters.Add("@UserId", userId);
                parameters.Add("@AbandonReasonId", (int)abandonReasonId);
                var datacommand = DataCommandFactory.CreateCommand(context, CommandType.StoredProcedure, "admapp_TurnaroundCompleted", parameters);
                datacommand.ExecuteNonQuery();
            }

            return true;
        }
        /// <summary>
        /// Retrieves a turnaround by Id
        /// </summary>
        /// <param name="turnaroundId"></param>
        /// <param name="facilityId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetTurnaroundByFacility operation
        /// </summary>
        public Turnaround GetTurnaroundByFacility(int turnaroundId, int facilityId)
        {
            return Repository.Find(t => t.TurnaroundId == turnaroundId && (t.FacilityId == facilityId || t.Facility.MultiFacilityProcessing.SelectMany(i => i.MultiFacilityProcessHandShake).Any(f => f.RequestingFacilityId == facilityId))).FirstOrDefault();
        }

        /// <summary>
        /// Ensure TurnaroundFacility table is populated with Primary and/or processing facilities.
        /// </summary>
        /// <param name="turnaround">The turnaround object to process.</param>
        /// <returns></returns>
        /// <summary>
        /// AddFacilityToturnaround operation
        /// </summary>
        public bool AddFacilityToturnaround(ITurnaround turnaround)
        {
            if (turnaround != null)
            {
                var turnaroundFacilityRepository = TurnaroundFacilityRepository.New(Repository.UnitOfWork);

                TurnaroundFacility tf;
                var changesMade = false;

                var primaryFacilityId = ((Turnaround)turnaround).ContainerMaster.ContainerMasterDefinition.CustomerDefinition.CurrentCustomer.FacilityId;
                if (!turnaroundFacilityRepository.Any(turnaround.TurnaroundId, turnaround.FacilityId))
                {
                    tf = new TurnaroundFacility
                    {
                        TurnaroundId = turnaround.TurnaroundId,
                        FacilityId = turnaround.FacilityId
                    };

                    turnaroundFacilityRepository.Add(tf);
                    changesMade = true;
                }
                if (turnaround.FacilityId != primaryFacilityId && !turnaroundFacilityRepository.Any(turnaround.TurnaroundId, primaryFacilityId))
                {
                    tf = new TurnaroundFacility
                    {
                        TurnaroundId = turnaround.TurnaroundId,
                        FacilityId = primaryFacilityId
                    };

                    turnaroundFacilityRepository.Add(tf);
                    changesMade = true;
                }

                if (changesMade)
                {
                    turnaroundFacilityRepository.Save();
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Ensure TurnaroundFacility table is populated with Primary and/or processing facilities.
        /// </summary>
        /// <param name="turnaroundId">The id of the turnaround to process.</param>
        /// <returns></returns>
        /// <summary>
        /// AddFacilityToTurnaround operation
        /// </summary>
        public bool AddFacilityToTurnaround(int turnaroundId)
        {
            var turnaround = Repository.Find(t => t.TurnaroundId == turnaroundId)
                .Include("ContainerMaster.ContainerMasterDefinition.CustomerDefinition.CurrentCustomer")
                .FirstOrDefault();

            return AddFacilityToturnaround(turnaround);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchTerm"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <summary>
        /// SearchTurnarounds operation
        /// </summary>
        public List<Turnaround> SearchTurnarounds(string searchTerm, int userId)
        {
            {
                var turnarounds = repository.DataManager.ExecuteQuery<Turnaround>((row, table, set) =>
                {
                    return new Turnaround
                    {
                        TurnaroundId = Convert.ToInt32(row["TurnaroundId"]),
                        ExternalId = (long)(row["ExternalID"]),
                        ContainerMasterText = row["Name"].ToString()
                    };
                },

                "dbo.[SAF_Omnisearch_Customer_Turnarounds]",
                CommandType.StoredProcedure,
                new SqlParameter("@UserId", userId),
                new SqlParameter("@searchText", searchTerm)

                );

                var v = turnarounds.Take(5);

                return v.ToList();
            }
        }
    }
}

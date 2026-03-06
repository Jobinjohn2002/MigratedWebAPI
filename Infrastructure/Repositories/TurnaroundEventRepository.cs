using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Infrastructure.Repositories
{
    public partial class TurnaroundEventRepository
    {
        /// <summary>
        /// Get operation
        /// </summary>
        public TurnaroundEvent Get(int id)
        {
            return Repository.Find(te => te.TurnaroundEventId == id).FirstOrDefault();
        }

        /// <summary>
        /// GetAllTurnaroundEventsByTurnaroundId operation
        /// </summary>
        public IQueryable<TurnaroundEvent> GetAllTurnaroundEventsByTurnaroundId(int turnaroundId)
        {
            return Repository.Find(te => te.Turnaround.TurnaroundId == turnaroundId);
        }

        /// <summary>
        /// GetTurnaroundEventsWithStorageDetailsByTurnaroundId operation
        /// </summary>
        public IQueryable<ITurnaroundEventList> GetTurnaroundEventsWithStorageDetailsByTurnaroundId(int turnaroundId)
        {
            var turnEventlist = Repository.Find(te => te.Turnaround.TurnaroundId == turnaroundId);

            var turnaroundEventdata = turnEventlist.AsEnumerable().Select(turnaroundEvent => new TurnaroundEventListData
            {
                TurnaroundEventId = turnaroundEvent.TurnaroundEventId,
                BatchId = turnaroundEvent.BatchId,
                CreatedUserId = turnaroundEvent.User.UserId,
                TurnaroundEventTypeId = turnaroundEvent.EventTypeId,
                TurnaroundEventType = (turnaroundEvent.StoragePoint != null && turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoPigeonHoleStock)
                    ? $"{turnaroundEvent.EventType.Text.ToString()}  ( {turnaroundEvent.StoragePoint.Text.ToString()} )"
                    : turnaroundEvent.EventType.Text.ToString(),
                Created = turnaroundEvent.Created,
                CreatedUser = $"{turnaroundEvent.User.FirstName} {turnaroundEvent.User.Surname}"
            }).ToList();

            return turnaroundEventdata.AsQueryable();
        }

        /// <summary>
        /// GetTurnaroundEventsListByTurnaroundId operation
        /// </summary>
        public IQueryable<ITurnaroundEventList> GetTurnaroundEventsListByTurnaroundId(int turnaroundId, int userId, UserCultureData userCultureData)
        {
            var unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork();
            var turnEventlist = Repository.Find(te => te.TurnaroundId == turnaroundId).ToList();

            var repo = TranslationRepository.New(unitOfWork);

            var eventType = repo.All().GetTranslation(userCultureData, "entities", "dbo.EventType");

            AdditionalInfo addInfo;
            var turnaroundEventdataList = turnEventlist.Select((x) => {
                addInfo = GetAdditionalInformation(x, userCultureData.Culture, userId);
                return new TurnaroundEventListData
                {
                    AdditionalInfo = addInfo.Text,
                    AdditionalInfoExtended = addInfo.ExtendedText,
                    AdditionalInfoFields = new Dictionary<string, string>(addInfo.Fields),
                    Created = x.Created,
                    CreatedUser = $"{x.User.FirstName} {x.User.Surname}",
                    CreatedUserId = x.User.UserId,
                    TurnaroundEventTypeId = x.EventTypeId,
                    TurnaroundEventType = x.EventType?.Text,
                    TurnaroundEventId = x.TurnaroundEventId,
                    BatchId = x.BatchId,
                    ComplianceReason = (x.PinRequestReasonId == null) ? String.Empty : x.PinRequestReason.Text,
                    TurnaroundEnded = x.Workflow?.IsEnd ?? false,
                    IsProcessEvent = x.EventType.ProcessEvent,
                    FacilityName = x.Station.Facility.Text,
                    FacilityId = x.Station.Facility.FacilityId
                };
            }).ToList(); 
            turnaroundEventdataList.OrderByDescending(a => a.TurnaroundEventId)
                .Where(a => a.TurnaroundEventTypeId == (short)TurnAroundEventTypeIdentifier.AddedToTrolley).Skip(1).ToList()
                .ForEach(a => a.AdditionalInfo = string.Empty);

            var turnaroundWhRepository = TurnaroundWHRepository.New(unitOfWork);
            var turnaroundWh = turnaroundWhRepository.GetByTurnaround(turnaroundId);

            foreach (var turnaroundEvent in turnaroundEventdataList)
            {
                turnaroundEvent.NextEventTypeId = turnaroundWh?.NextEventTypeId;
            }

            return turnaroundEventdataList.AsQueryable();
        }

        /// <summary>
        /// GetOnlyTurnaroundEventsListByTurnaroundId operation
        /// </summary>
        public IQueryable<TurnaroundEvent> GetOnlyTurnaroundEventsListByTurnaroundId(int turnaroundId)
        {
            return Repository.Find(te => te.TurnaroundId == turnaroundId);
        }

        /// <summary>
        /// GetAllProcessEventByTurnaroundId operation
        /// </summary>
        public IQueryable<TurnaroundEvent> GetAllProcessEventByTurnaroundId(int turnaroundId)
        {
            return Repository.Find(te => te.Turnaround.TurnaroundId == turnaroundId && te.EventType.ProcessEvent).OrderByDescending(te => te.Created);
        }

        /// <summary>
        /// Reads the turnaround for a given facility and date range
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="fromDate">The fromDate</param>
        /// <param name="toDate">The toDate</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetTurnaroundsByDateRange operation
        /// </summary>
        public IQueryable<Turnaround> GetTurnaroundsByDateRange(int userId, DateTime fromDate, DateTime toDate)
        {
            return Repository.
                Find(turnaroundEvent =>
                    turnaroundEvent.Created >= fromDate &&
                    turnaroundEvent.Created <= toDate &&
                    turnaroundEvent.User.UserId == userId).
                Select(turnaround => turnaround.Turnaround).
                Distinct().
                OrderBy(t => t.Expiry);
        }

        /// <summary>
        /// Reads the turnaround event batch
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// GetTurnaroundEventWithBatch operation
        /// </summary>
        public TurnaroundEvent GetTurnaroundEventWithBatch(int batchId)
        {
            var batchevent = Repository.Find(turnaroundEvent => turnaroundEvent.BatchId == batchId).FirstOrDefault();

            if (batchevent != null)
            {
                var allTurnaroundEvents =
                    Repository.Find(
                        turnaroundEvent =>
                        turnaroundEvent.TurnaroundId == batchevent.TurnaroundId && turnaroundEvent.BatchId == batchId).
                        OrderByDescending(
                            o => o.Created).FirstOrDefault();

                if (allTurnaroundEvents != null)
                {
                    return allTurnaroundEvents;
                }
            }

            return null;
        }

        /// <summary>
        /// Reads the turnaround events by batch.
        /// </summary>
        /// <param name="batchId">The batch id.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        /// <summary>
        /// ReadTurnaroundEventsByBatch operation
        /// </summary>
        public IQueryable<TurnaroundEvent> ReadTurnaroundEventsByBatch(int batchId)
        {
            var allresults = Repository.Find(b => b.BatchId == batchId).Select(i => i.Turnaround).Distinct().SelectMany(i => i.TurnaroundEvent).OrderBy(i => i.TurnaroundEventId);
            var turnarounds = allresults.Select(te => te.TurnaroundId).Distinct();
            var finalResults = new List<TurnaroundEvent>();

            foreach (var t in turnarounds)
            {
                var turnaroundEventId = allresults.Where(b => b.BatchId == batchId && b.TurnaroundId == t).Select(i => i.TurnaroundEventId).FirstOrDefault();
                var nextTurnaroundEventId = allresults.Where(b => b.BatchId != null && b.BatchId != batchId && b.TurnaroundId == t && b.TurnaroundEventId > turnaroundEventId).Select(i => i.TurnaroundEventId).FirstOrDefault();
                var tempresults = nextTurnaroundEventId > 0 ? allresults.Where(i => i.TurnaroundId == t &&
                    i.TurnaroundEventId >= turnaroundEventId && i.TurnaroundEventId < nextTurnaroundEventId).ToList()
                    : allresults.Where(i => i.TurnaroundId == t && i.TurnaroundEventId >= turnaroundEventId).ToList();
                finalResults.AddRange(tempresults);
            }
            return finalResults.AsQueryable();
        }

        /// <summary>
        /// to do : needs to be fine tuned.
        /// </summary>
        /// <param name="existingevents"></param>
        /// <returns></returns>
        /// <summary>
        /// GetDefectTurnaroundEventList operation
        /// </summary>
        public List<GenericKeyValue> GetDefectTurnaroundEventList(List<int> existingevents)
        {
            var genericList = new List<GenericKeyValue>();
            foreach (var existingevent in existingevents)
            {
                var item = Repository.Find(T => T.TurnaroundEventId == existingevent).Select(i => new GenericKeyValue
                {
                    Id = i.TurnaroundEventId,
                    Name = i.EventType.Text
                }).FirstOrDefault();
                if (item != null)
                    genericList.Add(item);
            }
            return genericList;
        }

        /// <summary>
        /// ReadLastTurnaroundEventsByFacility operation
        /// </summary>
        public IQueryable<ITurnaroundEventList> ReadLastTurnaroundEventsByFacility(int facilityId)
        {

            return Repository.Find(T => T.Turnaround.FacilityId == facilityId)
                .GroupBy(i => i.TurnaroundId).SelectMany(c => c.OrderByDescending(r => r.TurnaroundEventId).Take(1)).
                Select(turnaroundEvent => new TurnaroundEventListData

                {
                    Expiry = turnaroundEvent.Turnaround.Expiry,
                    TurnaroundEventTypeId = turnaroundEvent.EventTypeId,
                    ProcessEvent = turnaroundEvent.EventType.ProcessEvent,
                    Created = turnaroundEvent.Created,
                }).AsQueryable();
        }

        /// <summary>
        /// Get TurnarounEvent By TurnaroundId.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <summary>
        /// GetTurnarounEventByTurnaroundId operation
        /// </summary>
        public TurnaroundEvent GetTurnarounEventByTurnaroundId(int id)
        {
            return Repository.Find(te => te.TurnaroundId == id && te.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoAutoclave)
                .OrderByDescending(o => o.Created).FirstOrDefault();
        }

        /// <summary>
        /// Returns translated Additional information for Turnaround events
        /// </summary>
        /// <param name="turnaroundEvent"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <summary>
        /// GetAdditionalInformation operation
        /// </summary>
        public AdditionalInfo GetAdditionalInformation(TurnaroundEvent turnaroundEvent, string culture, int userId)
        {
            var info = new AdditionalInfo();
            const string sectionGroup = "EventType_AdditionalInfo";
            const string section = "labels";

            if (turnaroundEvent.Batch != null && turnaroundEvent.EventType.ProcessEvent)
            {
                switch (turnaroundEvent.EventTypeId)
                {
                    case (int)TurnAroundEventTypeIdentifier.PreAerDeconTaskFailure:
                        info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Failed_Task", culture: culture),
                            TranslatorManager.GetText("entities", "dbo.DecontaminationTask", turnaroundEvent.Batch.BatchDecontaminationTask.First().DecontaminationTask.Text, culture: culture));

                        info.ExtendedText = string.Format("| " + TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Failed_Task_Reason", culture: culture),
                                                                 TranslatorManager.GetText("entities", "dbo.FailureType", turnaroundEvent.Batch.FailedBatch.First().FailureType.Text, culture: culture));

                        var failedTaskAdditionalInfo = turnaroundEvent.Batch.FailedBatch.First().Text;
                        if (!string.IsNullOrEmpty(failedTaskAdditionalInfo))
                        {
                            info.ExtendedText += string.Format(" | " + TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Failed_Task_Info", culture: culture), failedTaskAdditionalInfo);
                        }
                        break;

                    case (int)TurnAroundEventTypeIdentifier.PreAerDeconTaskSuccess:
                        info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Passed_Task", culture: culture), turnaroundEvent.Batch.BatchDecontaminationTask.First().DecontaminationTask.Text);
                        break;

                    case (short)TurnAroundEventTypeIdentifier.AssignedToAer:
                    case (short)TurnAroundEventTypeIdentifier.AerStart:
                    case (short)TurnAroundEventTypeIdentifier.AerPassed:
                    case (short)TurnAroundEventTypeIdentifier.AerFailed:
                        info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_AER_Details", false, culture), turnaroundEvent.Batch.Machine?.Text, turnaroundEvent.Batch.ExternalId);

                        if (turnaroundEvent.EventTypeId == (short)TurnAroundEventTypeIdentifier.AerFailed && turnaroundEvent.Batch.FailedBatch?.FirstOrDefault()?.FailureType?.Text != null)
                        {
                            info.ExtendedText = "| " + $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_FailureReason", culture: culture).Replace("{0}", TranslatorManager.GetText("entities", "dbo.FailureType", turnaroundEvent.Batch.FailedBatch.FirstOrDefault().FailureType.Text, false, culture))}";

                            var failureAdditionalInfo = turnaroundEvent.Batch.FailedBatch.First().Text;
                            if (!string.IsNullOrEmpty(failureAdditionalInfo))
                            {
                                info.ExtendedText += string.Format(" | " + TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Failed_Task_Info", culture: culture), failureAdditionalInfo);
                            }
                        }
                        break;
                    default:
                        info.Text = string.Format("{0}{1}{2}{3}", turnaroundEvent.Batch.Machine?.Text, ":", turnaroundEvent.Batch.ExternalId,
                              turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoAutoclave && turnaroundEvent.Batch?.BiologicalIndicatorTest != null && turnaroundEvent.Batch.BiologicalIndicatorTest.Any()
                              ? string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_BIAdded", false, culture), turnaroundEvent.Batch.BiologicalIndicatorTest.FirstOrDefault().TestBiologicalIndicatorLotNumber)
                              : string.Empty);
                        if(turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoAutoclave)
                        {
                            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                            {
                                var userRepo = new UserRepository(workUnit);
                                var user = userRepo.Get(userId);
                                string translationName = "";
                                DateTime batchDate = new DateTime();
                                bool dateFound = false;

                                var batchStatus = turnaroundEvent.Batch.BatchStatusId;

                                if (batchStatus == (int)BatchStatusIdentifier.Passed && turnaroundEvent.Batch.DateChecked.HasValue)
                                {
                                    dateFound = true;
                                    translationName = "AdditionalInfo_Batch_Passed";
                                    batchDate = turnaroundEvent.Batch.DateChecked.Value;
                                }

                                else if (batchStatus == (int)BatchStatusIdentifier.InProgress && turnaroundEvent.Batch.Started.HasValue)
                                {
                                    dateFound = true;
                                    translationName = "AdditionalInfo_Batch_Started";
                                    batchDate = turnaroundEvent.Batch.Started.Value;                                 
                                }

                                else if (batchStatus == (int)BatchStatusIdentifier.Failed && turnaroundEvent.Batch.Failed.HasValue)
                                {
                                    dateFound = true;
                                    translationName = "AdditionalInfo_Batch_Failed";
                                    batchDate = turnaroundEvent.Batch.Failed.Value;                                 
                                }
                                if (dateFound)
                                {
                                    var datetimeFormatRepository = new DateTimeFormatRepository(workUnit);
                                    var formatRepository = new FormatRepository(workUnit);
                                    var formats = datetimeFormatRepository.Get(user.DateTimeFormatId);
                                    var shortDateFormat = formatRepository.Get(formats.ShortDateFormatId).Text;
                                    var shortTimeFormat = formatRepository.Get(formats.ShortTimeFormatId).Text;
                                    batchDate = TimeZoneConverter.ToLocalTime(batchDate, user.TimeZone.Text);
                                    string dateString = DateTimeConversionHelper.PreferedDateTimeFormat(batchDate, shortDateFormat);
                                    dateString += " " + DateTimeConversionHelper.PreferedDateTimeFormat(batchDate, shortTimeFormat);

                                    info.ExtendedText = string.Format(TranslatorManager.GetText(sectionGroup, section, translationName, culture: culture), dateString);
                                }
                            }
                        }
                        break;
                }

                return info;
            }
            
            var trolleyEvents = new[]
            {
                (short)TurnAroundEventTypeIdentifier.LoadTrolleyEPOC,
                (short)TurnAroundEventTypeIdentifier.LoadTrolleyEPOD
            };
            if (Array.IndexOf(trolleyEvents, turnaroundEvent.EventTypeId) >= 0)
            {
                var externalId = GetExternalId(turnaroundEvent, (TurnAroundEventTypeIdentifier)turnaroundEvent.EventTypeId);

                info.Text = !string.IsNullOrEmpty(externalId)
                    ? TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Trolley", false, culture) + externalId : string.Empty;

                return info;
            }
            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.AddedToTrolley)
            {

                info.Text = string.Empty;

                var lastAddToTrolleyEventForThisTrayTurnaround = turnaroundEvent.Turnaround.TurnaroundEvent
                                                                     .OrderByDescending(te => te.TurnaroundEventId)
                                                                     .FirstOrDefault(te => te.EventTypeId == (short)TurnAroundEventTypeIdentifier.AddedToTrolley);
                if (lastAddToTrolleyEventForThisTrayTurnaround.TurnaroundEventId == turnaroundEvent.TurnaroundEventId)
                {//this add to trolley event is the most recent add to trolley event, so it's trolley is the most recent turnaroundassigned parent trolley
                    var mostRecentTA = turnaroundEvent.Turnaround.TurnaroundAssignedsAsChild.OrderByDescending(ta => ta.TurnaroundAssignedId).FirstOrDefault();
                    if (mostRecentTA != null)
                    {
                        info.Text = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Trolley", false, culture) + mostRecentTA.ParentTurnaround.ContainerInstance.PrimaryId;
                    }
                }

                return info;

            }
            if (turnaroundEvent.Location != null && turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoPigeonHoleStock)
            {
                info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Location", false, culture), turnaroundEvent.Location.Text);
                return info;
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoQuarantine && turnaroundEvent.QuarantineReason != null)
            {
                info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_QuarantineReason", false, culture), TranslatorManager.GetText("entities", "dbo.QuarantineReason", turnaroundEvent.QuarantineReason.Text, false, culture));
                return info;
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.TurnaroundEndedEarly && turnaroundEvent.AbandonReason != null)
            {
                info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_AbandonReason", false, culture), TranslatorManager.GetText("entities", "dbo.AbandonReason", turnaroundEvent.AbandonReason.Text, false, culture));
                return info;
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.FailPacking && turnaroundEvent.TurnaroundEventFailureType != null && turnaroundEvent.TurnaroundEventFailureType.Count > 0)
            {
                info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_FailureReason", false, culture), TranslatorManager.GetText("entities", "dbo.FailureType", turnaroundEvent.TurnaroundEventFailureType.FirstOrDefault().FailureType.Text, false, culture));
                return info;
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.AcknowledgeNote && turnaroundEvent.QuarantineReasonId != null)
            {
                info.Text = TranslatorManager.GetText("entities", "dbo.QuarantineReason", turnaroundEvent.QuarantineReason.Text, false, culture);
                return info;
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromOrder && turnaroundEvent.Location != null)
            {
                info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Location", false, culture), turnaroundEvent.Location.Text);
                return info;
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.ChangedBatch && turnaroundEvent.Batch != null)
            {
                info.Text = $"{turnaroundEvent.Batch.Machine.Text}:{turnaroundEvent.Batch.ExternalId}";
                return info;
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.AddedToOrder)
            {
                var latestAddedToOrderTurnaroundEvent = GetAllTurnaroundEventsByTurnaroundId(turnaroundEvent.TurnaroundId)
                    .Where(e => e.EventTypeId == (int)TurnAroundEventTypeIdentifier.AddedToOrder)
                    .OrderByDescending(e => e.Created)
                    .FirstOrDefault();

                if (latestAddedToOrderTurnaroundEvent != null &&
                    latestAddedToOrderTurnaroundEvent.TurnaroundEventId == turnaroundEvent.TurnaroundEventId)
                {
                    var orderNumber = GetMostRecentOrderNumber(turnaroundEvent.TurnaroundId);
                    if (!string.IsNullOrEmpty(orderNumber))
                    {
                        info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_OrderNumber", false, culture), orderNumber);
                        return info;
                    }
                }
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.OrderShipped)
            {
                var latestOrderShippedTurnaroundEvent = GetAllTurnaroundEventsByTurnaroundId(turnaroundEvent.TurnaroundId)
                    .Where(e => e.EventTypeId == (int)TurnAroundEventTypeIdentifier.OrderShipped)
                    .OrderByDescending(e => e.Created)
                    .FirstOrDefault();

                var latestAddedToOrderTurnaroundEvent = GetAllTurnaroundEventsByTurnaroundId(turnaroundEvent.TurnaroundId)
                    .Where(e => e.EventTypeId == (int)TurnAroundEventTypeIdentifier.AddedToOrder)
                    .OrderByDescending(e => e.Created)
                    .FirstOrDefault();

                if (latestOrderShippedTurnaroundEvent != null &&
                    latestOrderShippedTurnaroundEvent.TurnaroundEventId == turnaroundEvent.TurnaroundEventId &&
                    latestAddedToOrderTurnaroundEvent != null &&
                    latestAddedToOrderTurnaroundEvent.Created <= latestOrderShippedTurnaroundEvent.Created)
                {
                    var orderNumber = GetMostRecentOrderNumber(turnaroundEvent.TurnaroundId);
                    if (!string.IsNullOrEmpty(orderNumber))
                    {
                        info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_OrderNumber", false, culture), orderNumber);
                        return info;
                    }
                }
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.Reprint)
            {
                {
                    var repo = TurnaroundEventReprintRepository.New(workUnit);

                    var turnaroundEventReprint = repo.All().FirstOrDefault(x => x.TurnaroundEventId == turnaroundEvent.TurnaroundEventId);

                    if (turnaroundEventReprint == null)
                    {
                        return info;
                    }

                    info.Text = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint", culture: culture);

                    switch ((PrintContentTypeIdentifier)turnaroundEventReprint.PrintHistory.PrintContentTypeId)
                    {
                        case PrintContentTypeIdentifier.SystemPrint:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_SystemPrint", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.TrayList:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_TrayList", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.TrayListFrontSheet:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_TrayListFrontSheet", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.QALabel:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_QALabel", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.DecontaminationCertificate:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_DecontaminationCertificate", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.DeliveryNote:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_DeliveryNote", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.InboundList:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_InboundList", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.IntoQuarantine:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_IntoQuarantine", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.AuditException:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_AuditException", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.AERPassed:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_AERPassed", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.VacuumPackedWet:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_VacuumPackedWet", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.VacuumPackedDry:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_VacuumPackedDry", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.FacilityTransferOutbound:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_FacilityTransferOutbound", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.SystemPrintTest:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_SystemPrintTest", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.IntoAutoclaveBatchReport:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_IntoAutoclaveBatchReport", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.OutOfAutoclaveBatchReport:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_OutOfAutoclaveBatchReport", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.PackingFailedTraylist:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_PackingFailedTraylist", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.OrderManifest:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_OrderManifest", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.TransferNote:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_TransferNote", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.DirtyInstrumentTraylist:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_DirtyInstrumentTraylist", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.WashReleaseDeliveryPointSummary:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_WashReleaseDeliveryPointSummary", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.WasherBatchReport:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_WasherBatchReport", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.WashInBatchReport:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_WashInBatchReport", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.WashReleaseBatchReport:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_WashReleaseBatchReport", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.PackList:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_PackList", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.FailedDecontamination:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_FailedDecontamination", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.OutOfAERPassedLabel:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_OutOfAERPassedLabel", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.RemovedFromDryingCabWetLabel:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_RemovedFromDryingCabWetLabel", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.RemovedFromDryingCabDryLabel:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_RemovedFromDryingCabDryLabel", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.VacuumPackedWetLabel:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_VacuumPackedWetLabel", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.VacuumPackedDryLabel:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_VacuumPackedDryLabel", culture: culture)}";
                            break;
                        case PrintContentTypeIdentifier.SystemPrintLabel:
                            info.Text = $"{info.Text}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Reprint_SystemPrintLabel", culture: culture)}";
                            break;

                    }
                }
                return info;
            }

            if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances ||
                turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.WeighedUsingPostWashTolerances)
            {
                {
                    var repo = TurnaroundEventWeightRepository.New(workUnit);

                    var turnaroundEventWeight =
                        repo.All().FirstOrDefault(w => w.TurnaroundEventId == turnaroundEvent.TurnaroundEventId);

                    if (turnaroundEventWeight == null)
                    {
                        return info;
                    }

                    var statusName = string.Empty;

                    switch ((WeightStatus)turnaroundEventWeight.WeightStatusId)
                    {
                        case WeightStatus.Passed:
                            statusName = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Passed", culture: culture);
                            break;
                        case WeightStatus.Failed:
                            statusName = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Failed", culture: culture);
                            break;
                        case WeightStatus.Accepted:
                            statusName = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Accepted", culture: culture);
                            break;
                        case WeightStatus.Cancelled:
                            statusName = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Cancelled", culture: culture);
                            break;
                    }

                    info.Text = turnaroundEventWeight.WeightStatusId != (int)WeightStatus.Cancelled
                        ? $"{turnaroundEventWeight.WeightKg:##0.000}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Kg", culture: culture)} - {statusName}"
                        : statusName;

                    if (turnaroundEvent.FailureTypeId != null)
                    {
                        info.ExtendedText += ": " + $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_WeighingFailureReason", culture: culture) }" + " : " + $"{ TranslatorManager.GetText("entities", "dbo.FailureType", turnaroundEvent.FailureType.Text, false, culture)}";
                    }

                    if (turnaroundEventWeight.WeightStatusId == (int)WeightStatus.Accepted)
                    {
                        TurnaroundEvent prevTe;

                        if (turnaroundEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances)
                        {
                            prevTe =
                                turnaroundEvent.Turnaround.TurnaroundEvent.Where(
                                    a =>
                                        a.EventTypeId ==
                                        (int)TurnAroundEventTypeIdentifier.WeighedUsingPreWashTolerances &&
                                        a.TurnaroundEventId < turnaroundEventWeight.TurnaroundEventId)
                                    .OrderByDescending(b => b.TurnaroundEventId)
                                    .FirstOrDefault();
                        }
                        else
                        {
                            prevTe =
                                turnaroundEvent.Turnaround.TurnaroundEvent.Where(
                                    a =>
                                        a.EventTypeId ==
                                        (int)TurnAroundEventTypeIdentifier.WeighedUsingPostWashTolerances &&
                                        a.TurnaroundEventId < turnaroundEventWeight.TurnaroundEventId)
                                    .OrderByDescending(b => b.TurnaroundEventId)
                                    .FirstOrDefault();
                        }

                        var oldRefWeight = 0M;

                        var tew = prevTe?.TurnaroundEventWeight.FirstOrDefault();

                        if (tew != null)
                        {
                            oldRefWeight = tew.ReferenceWeightKg;
                        }

                        if (turnaroundEvent.FailureTypeId == null)
                        {
                            info.Fields = new Dictionary<string, string>
                            {
                                {
                                    $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_OldRefWeight", culture: culture) }", oldRefWeight > 0M
                                        ? $"{oldRefWeight:##0.000}{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Kg", culture: culture) }"
                                        : $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_UnknownWeight", culture: culture) }"
                                },
                                {$"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_NewRefWeight", culture: culture) }", $"{turnaroundEventWeight.WeightKg:##0.000}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Kg", culture: culture)}" }
                            };
                        }
                        else
                        {
                            info.Fields = new Dictionary<string, string>
                            {
                                {
                                    $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_OldRefWeight", culture: culture) }", oldRefWeight > 0M
                                        ? $"{oldRefWeight:##0.000}{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Kg", culture: culture) }"
                                        : $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_UnknownWeight", culture: culture) }"
                                },
                                {$"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_NewRefWeight", culture: culture) }", $"{turnaroundEventWeight.WeightKg:##0.000}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Kg", culture: culture)}" },
                                { $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_WeighingFailureReason", culture: culture) }", $"{ TranslatorManager.GetText("entities", "dbo.FailureType", turnaroundEvent.FailureType.Text, false, culture)}" }
                            };
                        }
                    }
                    else if (turnaroundEventWeight.WeightStatusId != (int)WeightStatus.Cancelled)
                    {
                        if (turnaroundEvent.FailureTypeId == null)
                        {
                            info.Fields = new Dictionary<string, string>
                            {
                                {$"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_ActualWeight", culture: culture) }", $"{turnaroundEventWeight.WeightKg:##0.000}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Kg", culture: culture)}"},
                                {
                                    $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_RefWeight", culture: culture) }", turnaroundEventWeight.ReferenceWeightKg > 0M
                                        ? $"{turnaroundEventWeight.ReferenceWeightKg:##0.000}{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Kg", culture: culture) }"
                                        : $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_UnknownWeight", culture: culture) }"
                                },
                                {$"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Tolerance", culture: culture) }", $"{(int)Math.Floor(turnaroundEventWeight.ToleranceKg*1000M)}{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_g", culture: culture) }" },
                                {
                                    $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_WeighingResult", culture: culture) }", turnaroundEventWeight.WeightStatusId == (int) WeightStatus.Passed
                                    ? TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Passed", culture: culture)
                                    : TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Failed", culture: culture)
                                }
                            };

                        }
                        else
                        {

                            var latestTurnaroundEventCancelledList = GetAllTurnaroundEventsByTurnaroundId(turnaroundEvent.TurnaroundId)
                                .Where(e => e.EventTypeId == (int)turnaroundEvent.EventTypeId && turnaroundEvent.Created > e.Created)
                                .OrderByDescending(e => e.Created).ToList();

                            string firstName = "";
                            string surName = "";
                            foreach (var latestTurnaroundEventCancelled in latestTurnaroundEventCancelledList)
                            {

                                var cancelTurnaroundEventUser = latestTurnaroundEventCancelled.TurnaroundEventWeight.Where(a => a.WeightStatusId == (int)WeightStatus.Cancelled);
                                if (cancelTurnaroundEventUser.Count() > 0)
                                {
                                    firstName = cancelTurnaroundEventUser.ToList()[0].TurnaroundEvent.User.FirstName;
                                    surName = cancelTurnaroundEventUser.ToList()[0].TurnaroundEvent.User.Surname;
                                    break;
                                }

                            }

                            info.Fields = new Dictionary<string, string>
                            {
                                {$"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_ActualWeight", culture: culture) }", $"{turnaroundEventWeight.WeightKg:##0.000}{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Kg", culture: culture)}"},
                                {
                                    $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_RefWeight", culture: culture) }", turnaroundEventWeight.ReferenceWeightKg > 0M
                                        ? $"{turnaroundEventWeight.ReferenceWeightKg:##0.000}{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Kg", culture: culture) }"
                                        : $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_UnknownWeight", culture: culture) }"
                                },
                                {$"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Tolerance", culture: culture) }", $"{(int)Math.Floor(turnaroundEventWeight.ToleranceKg*1000M)}{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_g", culture: culture) }" },
                                {
                                    $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_WeighingResult", culture: culture) }", turnaroundEventWeight.WeightStatusId == (int) WeightStatus.Passed
                                    ? TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Passed", culture: culture)
                                    : TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_Failed", culture: culture)
                                },
                            { $"{ TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_WeighingFailureReason", culture: culture) }", $"{ TranslatorManager.GetText("entities", "dbo.FailureType", turnaroundEvent.FailureType.Text, false, culture)}" },

                            };

                            if (turnaroundEventWeight.WeightStatusId == (int)WeightStatus.Passed)
                            {
                                info.Fields.Add($"{TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_WeighingFailureReasonUser", culture: culture) }", firstName + " " + surName);
                            }

                        }
                    }

                    return info;
                }
            }

            if (turnaroundEvent.SingleInstrumentAudit.Any())
            {
                {
                    var repo = SingleInstrumentAuditRepository.New(workUnit);

                    var audit = repo.All().FirstOrDefault(a => a.EndedTurnaroundEventId == turnaroundEvent.TurnaroundEventId);
                    var auditResult = "AdditionalInfo_Audit_" + audit.AuditResultType.Text;

                    info.Text = TranslatorManager.GetText(sectionGroup, section, auditResult, culture: culture);

                    info.Fields = new Dictionary<string, string>
                    {
                        {"SingleInstrumentAuditId", audit.SingleInstrumentAuditId.ToString()},
                        {"SingleInstrumentExternalAuditId", audit.SingleInstrumentExternalAuditId.ToString()}
                    };
                }

                return info;
            }

            if (turnaroundEvent.EventTypeId == (short)TurnAroundEventTypeIdentifier.IntoDryingCabinet)
            {
                if (turnaroundEvent.Location != null && turnaroundEvent.Location.Leaf != null)
                {
                    var dryingCabinetName = turnaroundEvent.Location.Leaf.Tree.Machine.FirstOrDefault()?.Text;
                    var locationName = turnaroundEvent.Location.Leaf.Tree.Machine.FirstOrDefault()?.Location.FirstOrDefault()?.Text;

                    info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_DryingCabinet_Details", false, culture), locationName, dryingCabinetName);
                }
            }

            if (turnaroundEvent.EventTypeId == (short)TurnAroundEventTypeIdentifier.FailedWash)
            {
                {
                    var repo = FailedWashRepository.New(workUnit);
                    var failedWash = repo.GetFailedWashByTurnaroundEventId(turnaroundEvent.TurnaroundEventId);

                    if (failedWash != null)
                    {
                        info.Text = string.Format(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_FailedWash_Details", false, culture), failedWash.FailedWashInstrument.Sum(a => a.Quantity));
                        if (!string.IsNullOrWhiteSpace(failedWash.Notes))
                        {
                            var additionalNotesText = Environment.NewLine + failedWash.Notes + Environment.NewLine;
                            var additionalNotesLabel = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_FailedWash_AdditionalNotes", false, culture);
                            info.Fields.Add(additionalNotesLabel, additionalNotesText);
                        }
                        if (failedWash.FailedWashInstrument.Count > 0)
                        {
                            var instrumentsText = new StringBuilder("");
                            foreach (var instrument in failedWash.FailedWashInstrument)
                            {
                                instrumentsText.AppendLine();
                                instrumentsText.AppendLine(instrument.ItemMaster.Text);

                                if (!string.IsNullOrWhiteSpace(instrument.ItemMaster.ManufacturersReference))
                                {
                                    var manufacturerReferenceLabel = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_FailedWash_ManufacturerReference", false, culture);
                                    instrumentsText.AppendLine($"{manufacturerReferenceLabel}: {instrument.ItemMaster.ManufacturersReference}");
                                }
                                else if (!string.IsNullOrWhiteSpace(instrument.ItemMaster.ExternalId))
                                {
                                    var externalIDLabel = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_FailedWash_ExternalID", false, culture);
                                    instrumentsText.AppendLine($"{externalIDLabel}: {instrument.ItemMaster.ExternalId}");
                                }

                                var reasonLabel = TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_FailedWash_Quantity", false, culture);
                                instrumentsText.AppendLine($"{reasonLabel}: {instrument.Quantity}");
                            }

                            info.Fields.Add(TranslatorManager.GetText(sectionGroup, section, "AdditionalInfo_FailedWash_Instruments", false, culture), instrumentsText.ToString());
                        }
                    }
                }
            }

            return info;
        }

        private static string GetMostRecentOrderNumber(int turnaroundId)
        {
            var orderLineRepo = OrderLineRepository.New(
                UnitOfWorkFactory.CreateOperativeEFUnitOfWork());

            var order = orderLineRepo.GetMostRecentOrderLineByTurnaroundId(turnaroundId)?.Order;

            return order?.OrderNumber ?? string.Empty;
        }

        private string GetExternalId(TurnaroundEvent turnaroundEvent, TurnAroundEventTypeIdentifier eventType)
        {
            var externalId = string.Empty;
            var assigned = turnaroundEvent.Turnaround.TurnaroundAssignedsAsChild.Where(t => t.TurnaroundChildId == turnaroundEvent.Turnaround.TurnaroundId);
            foreach (var last in assigned
                .Select(a => a.ParentTurnaround.TurnaroundEvent.LastOrDefault(e => e.EventTypeId == (short)eventType))
                .Where(last => last != null))
            {
                externalId = last.Turnaround.ContainerInstance.PrimaryId;
                break;
            }

            if (string.IsNullOrEmpty(externalId) && turnaroundEvent.Turnaround.ParentTurnaround != null)
            {
                externalId = turnaroundEvent.Turnaround.ParentTurnaround.ContainerInstance.PrimaryId;
            }

            return externalId;
        }
    }

    /// <summary>
    /// AdditionalInfo
    /// </summary>
    public class AdditionalInfo
    {
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets ExtendedText
        /// </summary>
        public string ExtendedText { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets Fields
        /// </summary>
        public Dictionary<string, string> Fields { get; set; } = new Dictionary<string, string>();
    }
}

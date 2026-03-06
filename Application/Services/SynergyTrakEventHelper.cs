using SynergyApplicationFrameworkApi.Application.DTOs.Printing;
using System;
using System.Collections.Generic;
using System.Linq;
using ReportTypeIdentifier = Synergy.LabelPrinting.Enums.ReportTypeIdentifier;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public partial class SynergyTrakHelperMk3
    {
        /// <summary>
        /// CreateTurnaroundAssigned operation
        /// </summary>
        public void CreateTurnaroundAssigned(int turnaroundId, int parentTurnaroundId)
        {
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var turnaroundAssignedRepository = new TurnaroundAssignedRepository(workUnit);
                var turnaroundAssigned = TurnaroundAssignedFactory.CreateEntity(workUnit,
                    turnaroundParentId: parentTurnaroundId,
                    turnaroundChildId: turnaroundId
                );

                var taAlreadyExists = turnaroundAssignedRepository.Repository.Find(ta => ta.TurnaroundParentId == parentTurnaroundId && ta.TurnaroundChildId == turnaroundId).FirstOrDefault();

                if (taAlreadyExists == null)
                {
                    turnaroundAssignedRepository.Add(turnaroundAssigned);
                    workUnit.Save();
                }
            }
        }

        private void CheckAutomaticCollection(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (!scanDC.ParentTurnaroundId.HasValue) return;

            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var parentTurnaround = turnaroundRepository.Get(scanDC.ParentTurnaroundId.Value);

                if (parentTurnaround?.ContainerMaster.BaseItemType.ItemTypeId != (int)ItemTypeIdentifier.Trolley) return;

                if (scanDC.TurnaroundEvents.Any(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.LoadTrolleyEPOC))
                {
                    scanDC.IsRemoveFromParent = true;

                    if (!scanDC.TurnaroundEvents.Any(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AutomaticCollection
                                                       || te.EventTypeId == (int)TurnAroundEventTypeIdentifier.Collected))
                    {
                        ApplyEvent(TurnAroundEventTypeIdentifier.AutomaticCollection, scanDC, scanDetails, true);
                    }

                }
            }
        }

        private static void SetInstanceQuaratineReasons(int? containerInstanceId, short? eventTypeId, short? quarantineReasonId)
        {
            if (containerInstanceId.HasValue)
            {
                {
                    var containerRepository = ContainerInstanceRepository.New(
                        workUnit);

                    var instance = containerRepository.Get(containerInstanceId.Value);

                    if (instance != null)
                    {
                        instance.QuarantineEventTypeId = eventTypeId;
                        instance.QuarantineReasonId = quarantineReasonId;

                        containerRepository.Save();
                    }
                }
            }
        }

        private bool CreateDeliveryNotePrintData(int deliveryNoteId, int userId, DeliveryNotePrintDataContract dataContract, bool isReprint)
        {
            if (dataContract != null)
            {
                {
                    var userRepository = UserRepository.New(workUnit);
                    var user = userRepository.Get(userId);

                    var deliveryNoteRepository = DeliveryNoteRepository.New(workUnit);
                    var deliveryNote = deliveryNoteRepository.Get(deliveryNoteId);

                    var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                    var deliveryPoint = deliveryPointRepository.Get(deliveryNote.DeliveryPointId);
                    var deliveryPointCustomer = deliveryPointRepository.GetCustomerByDeliveryPoint(deliveryNote.DeliveryPointId);

                    var tenancyId = deliveryPointCustomer.Facility.Owner.TenancyId;
                    var facilityId = deliveryPointCustomer.FacilityId;
                    var customerDefinitionId = deliveryPointCustomer.CustomerDefinitionId;

                    var list = new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("S", user.SystemId.ToString()),
                        new Tuple<string, string>("DeliveryNoteId", deliveryNoteId.ToString())
                    };

                    var reportName = Reporting.GenerateDeliveryNotePdf(dataContract, tenancyId, facilityId, customerDefinitionId, ReportTypeIdentifier.DeliveryNote, list.ToArray());
                    var turnarounds = deliveryNote.Turnaround.Select(x => x.TurnaroundId).ToList();

                    var printHistoryHelper = new PrintHistoryHelper();
                    if (!isReprint)
                    {
                        var printHistory = printHistoryHelper.CreatePrintHistory(user.UserId, PrintContentTypeIdentifier.DeliveryNote, turnarounds, null, new List<int> { deliveryNote.DeliveryNoteId }, null, null);
                        var pdfData = new PDFContent
                        {
                            Bytes = dataContract.ReportData
                        };

                        var content = printHistoryHelper.CreatePrintHistoryContent(printHistory.Id, PrintHistoryPrinterType.LaserPrinter, pdfData);
                    }

                    if (deliveryPoint.CreatePhysicalDeliveryNote || isReprint)
                    {
                        if (dataContract.IsNetworkPrinting)
                        {
                            for (var i = 0; i < dataContract.NumberOfCopies; i++)
                            {
                                Printing.PrintUtility.ProcessPrint(dataContract.ReportData, dataContract.PrinterName, reportName);
                            }
                            dataContract.ReportData = null;
                            dataContract.NumberOfCopies = 0;
                        }
                    }
                    else
                    {
                        dataContract.ReportData = null;
                        dataContract.NumberOfCopies = 0;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Prints a pick list for an order.
        /// </summary>
        /// <param name="printDataContract">The data required to do the printing.</param>
        /// <returns>The data to be printed (for local printing).</returns>
        public byte[] CreatePickListPrintData(OrderPickListPrintDataContract printDataContract)
        {
            if (printDataContract != null)
            {
                {
                    var userRepository = UserRepository.New(workUnit);
                    var user = userRepository.Get(printDataContract.UserId);

                    var list = new List<Tuple<string, string>>
                    {
                        new Tuple<string, string>("S", user.SystemId.ToString()),
                        new Tuple<string, string>("OrderID", printDataContract.OrderId.ToString())
                    };

                    return Reporting.CreatePDFReport(ReportTypeIdentifier.PrintedPickList.ToString(), list.ToArray(), printDataContract.PrinterName, printDataContract.IsNetworkPrinting);
                }
            }

            return null;
        }

        /// <summary>
        /// RemoveFromBatchTag operation
        /// </summary>
        public void RemoveFromBatchTag(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                var turnaroundEventRepository = TurnaroundEventRepository.New(workUnit);
                var turnaroundEvents = turnaroundEventRepository.GetAllTurnaroundEventsByTurnaroundId(scanDC.ParentTurnaroundId.Value).ToList();

                if (turnaroundEvents.Count(c => c.EventTypeId == (int)TurnAroundEventTypeIdentifier.AssignedToCarriage) >
                    turnaroundEvents.Count(c => c.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromCarriage))
                {
                    ApplyEvent(TurnAroundEventTypeIdentifier.RemovedFromCarriage, scanDC, scanDetails);
                }

                var applyEventDetails = ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.UnassignedFromBatchTag, true);
                if (scanDC.OverrideTurnaroundEventFacility)
                {
                    var lastEvent = turnaroundEventRepository.Get(scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).First(te => te.IsProcessEvent).TurnaroundEventId);
                    applyEventDetails.LocationId = lastEvent.LocationId;
                }

                ApplyEvent(applyEventDetails, scanDC, scanDetails);
            }
        }

        /// <summary>
        /// RemoveFromAutoclaveBatch operation
        /// </summary>
        public void RemoveFromAutoclaveBatch(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            using (var repository = new PathwayRepository())
            {
                var turnaround = repository.Container.Turnaround.FirstOrDefault(x => x.TurnaroundId == scanDetails.TurnaroundId);
                if (turnaround != null)
                {
                    var newEventTime = DateTime.UtcNow;
                    var processEvents = turnaround.TurnaroundEvent
                        .OrderByDescending(x => x.Created)
                        .ThenByDescending(x => x.TurnaroundEventId)
                        .Where(x => x.EventType.ProcessEvent);

                    var lastProcessEvent = processEvents.FirstOrDefault();
                    var priorEvent = processEvents.Skip(1).FirstOrDefault();

                    if (lastProcessEvent != null && lastProcessEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.IntoAutoclave)
                    {
                        lastProcessEvent.EventTypeId = (int)TurnAroundEventTypeIdentifier.IntoAutoclaveAddedInError;
                        lastProcessEvent.WorkflowId = null;
                        lastProcessEvent.CreatedUserId = scanDetails.UserId;
                        lastProcessEvent.StationId = scanDetails.StationId.Value;
                        lastProcessEvent.Created = newEventTime;
                        lastProcessEvent.BatchId = null; //Just remove the batchId and delete any record that this happened...
                        var turnaroundWH = turnaround.TurnaroundWH.FirstOrDefault();
                        if (turnaroundWH != null && turnaroundWH.LastEventId == lastProcessEvent.TurnaroundEventId)
                        {
                            turnaroundWH.LastEventTypeId = priorEvent.EventTypeId;
                            turnaroundWH.LastEventName = priorEvent.EventType.Text;
                            turnaroundWH.LastEventTime = newEventTime;
                            turnaroundWH.LastEventId = priorEvent.TurnaroundEventId;

                            var workflowDC = new ScanAssetDataContract
                            {
                                LastProcessEventTypeId = (TurnAroundEventTypeIdentifier)priorEvent.EventTypeId,
                                Asset = new AssetDetailsDataContract
                                {
                                    ItemTypeId = turnaround.ContainerMaster.ItemTypeId,
                                    ContainerMasterId = turnaround.ContainerMasterId
                                },
                                FacilityId = scanDetails.FacilityId,
                                DeliveryPtId = turnaround.DeliveryPointId
                            };
                            GetNextEventViaWorkflow(workflowDC);
                            if (workflowDC.NextEventId != 0)
                            {
                                turnaroundWH.NextEventTypeId = (short)workflowDC.NextEventId;
                            }
                        }
                        var currentTAE = turnaround.CurrentTurnaroundEvent;
                        if (currentTAE != null)
                        {
                            currentTAE.TurnaroundEventId = priorEvent.TurnaroundEventId;
                            currentTAE.EventTypeId = priorEvent.EventTypeId;
                        }

                        repository.Container.SaveChanges();
                    }
                    else
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.TurnaroundUnableToRemoveFromAutoclaveBatch;
                    }
                }
                else
                {
                    scanDC.ErrorCode = (int)ErrorCodes.TurnaroundUnableToRemoveFromAutoclaveBatch;
                }
            }
        }

        /// <summary>
        /// Archive operation
        /// </summary>
        public void Archive(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDC.TurnaroundId.HasValue)
            {
                {
                    var turnaroundRepository = TurnaroundRepository.New(workUnit);
                    var turnaround = turnaroundRepository.Get(scanDC.TurnaroundId.Value);

                    if (turnaround != null)
                    {
                        turnaround.ParentTurnaroundId = null;
                        turnaround.DeliveryNoteId = null;
                        turnaroundRepository.Save();
                    }

                    SetInstanceQuaratineReasons(scanDC.Asset.ContainerInstanceId, null, null);
                }
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.Archived, RemoveFromParent = true }, scanDC, scanDetails);
                scanDC.IsTurnaroundLive = false;
            }
        }

        /// <summary>
        /// NetworkPrintStationBadge operation
        /// </summary>
        public bool NetworkPrintStationBadge(DynamicRequest<StationDataContract> request)
        {
            if (request.StationId == null)
                return false;

            if (request.Value == null)
                return false;

            var printer = GetBarcodePrinterForStation(request.StationId.Value);

            if (string.IsNullOrEmpty(printer))
                return false;
            using (var stationLabel = new StationLabel(printer, new StationLabelData(request.Value.Name, request.Value.Logon)))
            {
                try
                {
                    stationLabel.Print();
                }
                catch (Exception ex)
                {
                    Log.Exception(ex, "NetworkPrintStationBadge");

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// NetworkPrintUserBadge operation
        /// </summary>
        public bool NetworkPrintUserBadge(DynamicRequest<UserInfo> request)
        {
            if (request.StationId == null)
                return false;

            if (request.Value == null)
                return false;

            var printer = GetBarcodePrinterForStation(request.StationId.Value);

            if (string.IsNullOrEmpty(printer))
                return false;

            using (var userLabel = new UserTag(printer, new UserTagData(request.Value.Firstname, request.Value.Surname, request.Value.ExternalId)))
            {
                try
                {
                    userLabel.Print();
                }
                catch (Exception ex)
                {
                    Log.Exception(ex, "NetworkPrintUserBadge");

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// NetworkPrintLocationBadge operation
        /// </summary>
        public bool NetworkPrintLocationBadge(DynamicRequest<LocationDataContract> request)
        {
            if (request.StationId == null)
                return false;

            if (request.Value == null)
                return false;

            var printer = GetBarcodePrinterForStation(request.StationId.Value);

            if (string.IsNullOrEmpty(printer))
                return false;

            using (var locationLabel = new LocationLabel(printer, request.Value.Text, request.Value.ExternalId, request.Value.LocationCode))
            {
                try
                {
                    locationLabel.Print();
                }
                catch (Exception ex)
                {
                    Log.Exception(ex, "NetworkPrintLocationBadge");

                    return false;
                }
            }

            return true;
        }

        private static string GetBarcodePrinterForStation(int stationId)
        {
            using (var unitOfWork = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var printerRepo = StationPrinterRepository.New(unitOfWork);

                var barcodePrinter = printerRepo.GetByStationAndType(stationId, (int)Synergy.LabelPrinting.Enums.PrinterTypeIdentifier.PTouch);

                return barcodePrinter?.Printer?.Text;
            }
        }

        /// <summary>
        /// ValidateWorkFlowStep operation
        /// </summary>
        public bool ValidateWorkFlowStep(ScanAssetDataContract scanDC, int eventType)
        {
            return IsWorkflowStepValid(scanDC, (TurnAroundEventTypeIdentifier)eventType, _preWorkflowEventId);
        }

        /// <summary>
        /// DeliveryNotePrint operation
        /// </summary>
        public void DeliveryNotePrint(ScanAssetDataContract scanDC, ScanDetails scanDetails, bool requiresProof, bool isEndTurnaround = false, bool isAutomaticEvent = false)
        {
            DeliveryNoteScanDetails dnScanDetails = scanDetails as DeliveryNoteScanDetails;

            List<ApplyTurnaroundEventDetails> eventsToApply = new List<ApplyTurnaroundEventDetails>
            {
                new ApplyTurnaroundEventDetails()
                {
                    EventType = TurnAroundEventTypeIdentifier.DeliveryNotePrint,
                    DeliveryNoteId = dnScanDetails?.DeliveryNoteId,
                    RemoveFromParent = false,
                    ParentTurnaroundId = scanDetails.ParentTurnaroundId,
                    LocationId = null,
                    BatchId = null,
                    IsEndTurnaround = isEndTurnaround,
                    IsAutomaticEvent = isAutomaticEvent,
                    UseDeliveryNoteIdFromScanDc = true
                }
            };

            if (requiresProof)
            {
                eventsToApply.Add(new ApplyTurnaroundEventDetails()
                {
                    EventType = TurnAroundEventTypeIdentifier.LoadTrolleyEPOD,
                    DeliveryNoteId = dnScanDetails?.DeliveryNoteId,
                    RemoveFromParent = false,
                    ParentTurnaroundId = scanDetails.ParentTurnaroundId,
                    LocationId = null,
                    BatchId = null,
                    IsAutomaticEvent = isAutomaticEvent
                });
            }

            ApplyEvent(eventsToApply, _synergyTrakData.ScanDcList, scanDetails);

            foreach (var scanItem in _synergyTrakData.ScanDcList.Where(a => a.TurnaroundId.HasValue))
            {
                MLDLoanerSwitcherooHelper.DeliveryNotePrintCleanup(scanItem.TurnaroundId.Value, scanDetails.UserId);
            }
        }

        /// <summary>
        /// AbandonTurnaround operation
        /// </summary>
        public void AbandonTurnaround(ScanAssetDataContract scanDC, ScanDetails scanDetails, Turnaround turnaround)
        {
            try
            {
                {
                    {
                        bool saveChanges = false;
                        if (turnaround.OrderLine.Any())
                        {
                            turnaround.OrderLine.ToList().ForEach(ol => ol.OrderLineStatusId = (int)OrderLineStatusIdentifier.Ordered);
                            turnaround.OrderLine.FirstOrDefault().Order.OrderStatusId = (int)OrderStatusIdentifier.InProcess;

                            turnaround.OrderLine.Clear();
                            saveChanges = true;
                        }
                        if (turnaround.ContainerInstance != null && turnaround.ContainerInstance.CurrentLocationId != null)
                        {
                            turnaround.ContainerInstance.CurrentLocationId = null;
                            saveChanges = true;
                        }
                        if (turnaround.ParentTurnaroundId != null)
                        {
                            turnaround.ParentTurnaroundId = null;
                            saveChanges = true;
                        }
                        if (saveChanges)
                            repository.Container.SaveChanges();
                        var context = repository.Container;
                        var parameters = new Dictionary<string, object>
                    {
                        {"@TurnaroundId", turnaround.TurnaroundId},
                        {"@FacilityId", _synergyTrakData.FacilityId},
                        {"@UserId", _synergyTrakData.UserId},
                        {"@AbandonReasonId", (int) AbandonReasonIdentifier.AutoAbandonNonCom}
                    };

                        var datacommand = DataCommandFactory.CreateCommand(context, CommandType.StoredProcedure, "admapp_TurnaroundCompleted", parameters);
                        datacommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                scanDC.ErrorCode = (int)ErrorCodes.ApplyTurnaroundEventError;
                throw;
            }
        }

        /// <summary>
        /// EndTurnaround operation
        /// </summary>
        public void EndTurnaround(ScanAssetDataContract scanDC, ScanDetails scanDetails, Turnaround turnaround)
        {
            try
            {
                {
                    bool saveChanges = false;
                    if (turnaround.OrderLine.Any())
                    {
                        turnaround.OrderLine.ToList().ForEach(ol => ol.OrderLineStatusId = (int)OrderLineStatusIdentifier.Ordered);
                        turnaround.OrderLine.FirstOrDefault().Order.OrderStatusId = (int)OrderStatusIdentifier.InProcess;

                        turnaround.OrderLine.Clear();
                        saveChanges = true;
                    }
                    if (turnaround.ContainerInstance != null && turnaround.ContainerInstance.CurrentLocationId != null)
                    {
                        turnaround.ContainerInstance.CurrentLocationId = null;
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

                    if (!_isLastEventAnEndEvent)
                    {
                        var dispatchEvent = turnaround.TurnaroundEvent.Any(e => e.EventTypeId == (int)TurnAroundEventTypeIdentifier.Dispatch);

                        var deliveryNotePrintEvent = turnaround.TurnaroundEvent.Any(e => e.EventTypeId == (int)TurnAroundEventTypeIdentifier.DeliveryNotePrint);

                        bool canApplyEventToItem = scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Tray ||
                                                   scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Endoscopy ||
                                                   scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.LoanTray ||
                                                   scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Supplementary ||
                                                   scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Extra;

                        if (!dispatchEvent && !deliveryNotePrintEvent && canApplyEventToItem)
                        {
                            var turnevents = new DispatchEvents(CreateTurnaroundEventData(scanDC, scanDetails, _synergyTrakData.EventTypeId));
                            turnevents.Dispatch(scanDC, scanDetails, true, false);

                            turnaround.DeliveryNoteId = scanDC.DeliveryNoteId;
                        }

                        if (!deliveryNotePrintEvent && canApplyEventToItem)
                        {
                            if (_synergyTrakData.ScanDcList.Count == 0)
                            {
                                _synergyTrakData.ScanDcList.Add(scanDC);
                            }

                            DeliveryNotePrint(scanDC, scanDetails, false, true, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                scanDC.ErrorCode = (int)ErrorCodes.ApplyTurnaroundEventError;
                throw;
            }
        }
        /// <summary>
        /// RemoveFromTransferNote operation
        /// </summary>
        public void RemoveFromTransferNote(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                {
                    var parentAndChildren = new List<ScanAssetDataContract>();
                    var grandChildren = new List<ScanAssetDataContract>();

                    foreach (var item in _synergyTrakData.ScanDcList)
                    {
                        if (item.TurnaroundId == scanDC.TurnaroundId || item.ParentTurnaroundId == scanDC.TurnaroundId)
                        {
                            parentAndChildren.Add(item);
                        }
                        else
                        {
                            grandChildren.Add(item);
                        }
                    }

                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemovedFromTransferNote, RemoveFromParent = true },
                        parentAndChildren,
                        scanDetails);

                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemovedFromTransferNote },
                        grandChildren,
                        scanDetails);
                }
                else
                {
                    ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemovedFromTransferNote, true),
                        scanDC,
                        scanDetails);
                    ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemovedFromTransferNote),
                        _synergyTrakData.ScanDcList.Where(dc => dc.TurnaroundId != scanDC.TurnaroundId).ToList(),
                        scanDetails);
                }
                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                {
                    var transferNote = repository.Container.TransferNote.FirstOrDefault(tn => tn.TransportTurnaroundId == scanDC.TurnaroundId && tn.DispatchTransferNoteEventId == null && tn.CancelledEventId == null);
                    if (transferNote != null)
                    {
                        transferNote.CancelledEventId = scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromTransferNote)?.TurnaroundEventId;
                    }
                }
                if (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Trolley && scanDetails.TransferNoteLineId.HasValue)
                {
                    var transferNoteLine = repository.Container.TransferNoteLine.First(tnl => tnl.TransferNoteLineId == scanDetails.TransferNoteLineId && tnl.RemovedFromTransferNoteEventId == null);
                    transferNoteLine.RemovedFromTransferNoteEventId = scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromTransferNote)?.TurnaroundEventId;
                }
                foreach (var dc in _synergyTrakData.ScanDcList.Where(dc => dc.TurnaroundId != scanDC.TurnaroundId))
                {
                    var line = repository.Container.TransferNoteLine.First(tnl => tnl.TurnaroundId == dc.TurnaroundId && tnl.TransferNoteId == scanDetails.TransferNoteId && tnl.RemovedFromTransferNoteEventId == null);
                    line.RemovedFromTransferNoteEventId = dc.TurnaroundEvents.OrderByDescending(te => te.Created).FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromTransferNote)?.TurnaroundEventId;
                }

                repository.Container.SaveChanges();
                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley && _synergyTrakData.ScanDcList.Any(dc => dc.RouteToEventTypeId.HasValue))
                {
                    foreach (var dc in _synergyTrakData.ScanDcList.Where(x => x.TurnaroundId != scanDC.TurnaroundId && x.RouteToEventTypeId.HasValue))
                    {
                        ApplyEvent(ApplyTurnaroundEventDetails.Create(dc.RouteToEventTypeId.Value), dc, scanDetails);
                    }
                    _synergyTrakData.ScanDcList.RemoveAll(x => x.TurnaroundId != scanDC.TurnaroundId);
                }
                else if (scanDetails.RouteToEventTypeId.HasValue)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = (TurnAroundEventTypeIdentifier)scanDetails.RouteToEventTypeId.Value }, scanDetails);
                }

                scanDC.TransferNote = TransferNoteHelper.GetTransferNote(new TransferNoteRequestDataContract() { TransferNoteId = scanDetails.TransferNoteId.GetValueOrDefault() });
            }
        }

        private bool DecontaminationComplete(ScanAssetDataContract scannedItem)
        {
            bool deconComplete = false;
            var lastEvent = scannedItem.TurnaroundEvents.OrderByDescending(o => o.Created)
                .FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.DeconStart ||
                    te.EventTypeId == (int)TurnAroundEventTypeIdentifier.DeconEnd ||
                    te.EventTypeId == (int)TurnAroundEventTypeIdentifier.DeconCancel ||
                    te.EventTypeId == (int)TurnAroundEventTypeIdentifier.Archived
                );
            if (lastEvent != null && lastEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.DeconEnd)
            {
                deconComplete = true;
            }

            return deconComplete;
        }

        /// <summary>
        /// AreAllLoanSetDispatched operation
        /// </summary>
        public List<DeliveryNoteTurnaroundDataContract> AreAllLoanSetDispatched(DeliveryNote deliveryNote, List<Turnaround> turnarounds, DeliveryNotePrintDataContract dc)
        {
            var invalidTurnarounds = new List<DeliveryNoteTurnaroundDataContract>();
            var processedLoanSets = new List<LoanSet>();

            {
                foreach (var turnaround in turnarounds.Where(t => t.ContainerInstance != null && t.ContainerInstance.LoanSetContents.Any(l => l.InstanceId == t.ContainerInstanceId && l.LoanSet.LoanStatusId != (int)LoanSetStatusTypeIdentifier.Cancelled && l.LoanSet.LoanStatusId != (int)LoanSetStatusTypeIdentifier.Archived)))
                {
                    var loanSetContent = repository.Container.LoanSetContents.FirstOrDefault(i => i.InstanceId == turnaround.ContainerInstanceId &&
                        (i.LoanSet.LoanStatusId != (int)LoanSetStatusTypeIdentifier.Cancelled && i.LoanSet.LoanStatusId != (int)LoanSetStatusTypeIdentifier.Archived));

                    if (loanSetContent != null)
                    {
                        var loanSet = repository.Container.LoanSet.SingleOrDefault(i => i.LoanSetId == loanSetContent.LoanSetId);

                        if (loanSet != null)
                        {
                            if (!processedLoanSets.Contains(loanSet))
                            {
                                processedLoanSets.Add(loanSet);

                                var loanSetContents = loanSet.LoanSetContents;
                                var externalId = loanSet.ExternalId;

                                foreach (var contents in loanSetContents)
                                {
                                    var lastTurnaround = repository.Container.Turnaround.Where(t => t.ContainerInstanceId == contents.InstanceId)
                                            .OrderByDescending(o => o.Created)
                                            .FirstOrDefault();

                                    var lastProcessEvent = lastTurnaround?.TurnaroundEvent.Where(te => te.EventType.ProcessEvent).OrderByDescending(o => o.Created).ThenByDescending(or => or.TurnaroundEventId).FirstOrDefault();

                                    if (lastProcessEvent != null && !lastProcessEvent.Workflow.IsEnd)
                                    {
                                        if (!lastTurnaround.DeliveryNoteId.HasValue || lastTurnaround.DeliveryNoteId != deliveryNote.DeliveryNoteId)
                                        {
                                            invalidTurnarounds.Add(new DeliveryNoteTurnaroundDataContract
                                            {
                                                TurnaroundId = lastTurnaround.TurnaroundId,
                                                TurnaroundExternalId = lastTurnaround.ExternalId,
                                                InstancePrimaryId = lastTurnaround.ContainerInstance != null ? lastTurnaround.ContainerInstance.PrimaryId : string.Empty,
                                                Name = lastTurnaround.ContainerMaster.Text,
                                                ExternalId = externalId,
                                                LastEventName = lastProcessEvent.EventType.Text
                                            });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return invalidTurnarounds;
        }

        /// <summary>
        /// AreAllLoanSetDispatched operation
        /// </summary>
        public List<DeliveryNoteTurnaroundDataContract> AreAllLoanSetDispatched(List<long> turnaroundExternalIds, int trolleyturnaroundId)
        {
            var invalidTurnarounds = new List<DeliveryNoteTurnaroundDataContract>();
            var processedLoanSets = new List<LoanSet>();

            {
                var turnaroundRepository = TurnaroundRepository.New(unitOfWork);
                var turnarounds = turnaroundRepository.GetByExternalId(turnaroundExternalIds);

                foreach (var turnaround in turnarounds.Where(t => t.ContainerInstance != null && t.ContainerInstance.LoanSetContents.Any(l => l.InstanceId == t.ContainerInstanceId && l.LoanSet.LoanStatusId != (int)LoanSetStatusTypeIdentifier.Cancelled && l.LoanSet.LoanStatusId != (int)LoanSetStatusTypeIdentifier.Archived)))
                {
                    var loanSetContent = repository.Container.LoanSetContents.FirstOrDefault(i => i.InstanceId == turnaround.ContainerInstanceId && (i.LoanSet.LoanStatusId != (int)LoanSetStatusTypeIdentifier.Cancelled && i.LoanSet.LoanStatusId != (int)LoanSetStatusTypeIdentifier.Archived));

                    if (loanSetContent != null)
                    {
                        var loanSet = repository.Container.LoanSet.SingleOrDefault(i => i.LoanSetId == loanSetContent.LoanSetId);

                        if (loanSet != null)
                        {
                            if (!processedLoanSets.Contains(loanSet))
                            {
                                processedLoanSets.Add(loanSet);

                                var loanSetContents = loanSet.LoanSetContents;
                                var externalId = loanSet.ExternalId;

                                foreach (var contents in loanSetContents)
                                {
                                    var lastTurnaround = repository.Container.Turnaround.Where(t => t.ContainerInstanceId == contents.InstanceId)
                                            .OrderByDescending(o => o.Created)
                                            .FirstOrDefault();

                                    var lastProcessEvent = lastTurnaround?.TurnaroundEvent.Where(te => te.EventType.ProcessEvent).OrderByDescending(o => o.Created).ThenByDescending(or => or.TurnaroundEventId).FirstOrDefault();

                                    if (lastProcessEvent != null && !lastProcessEvent.Workflow.IsEnd)
                                    {
                                        if (!lastTurnaround.ParentTurnaroundId.HasValue || lastTurnaround.ParentTurnaroundId != trolleyturnaroundId)
                                        {
                                            invalidTurnarounds.Add(new DeliveryNoteTurnaroundDataContract
                                            {
                                                TurnaroundId = lastTurnaround.TurnaroundId,
                                                TurnaroundExternalId = lastTurnaround.ExternalId,
                                                InstancePrimaryId = lastTurnaround.ContainerInstance != null ? lastTurnaround.ContainerInstance.PrimaryId : string.Empty,
                                                Name = lastTurnaround.ContainerMaster.Text,
                                                ExternalId = externalId,
                                                LastEventName = lastProcessEvent.EventType.Text
                                            });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return invalidTurnarounds;
        }

        /// <summary>
        /// UpdateOrderStatus operation
        /// </summary>
        public void UpdateOrderStatus(Turnaround turnaround, int userId, bool requiresProof = false)
        {
            List<int> orderIds = new List<int>();

            {
                {
                    var orderLine = turnaround.OrderLine.FirstOrDefault(ol => ol.OrderLineStatusId == (int)OrderIdentifier.Picked);

                    if (orderLine != null)
                    {
                        if (!orderIds.Contains(orderLine.OrderId))
                        {
                            orderIds.Add(orderLine.OrderId);

                            var order = repository.Container.Order.FirstOrDefault(o => o.OrderId == orderLine.OrderId);

                            if (order != null)
                            {
                                order.OrderStatusId = (int)OrderIdentifier.Dispatched;

                                var statusHistoryDispatched = OrderStatusHistoryFactory.CreateEntity(workUnit,
                                    orderId: orderLine.OrderId,
                                    orderStatusId: (int)OrderIdentifier.Dispatched,
                                    createdDate: DateTime.UtcNow,
                                    userId: userId
                                );

                                repository.Container.OrderStatusHistory.AddObject(statusHistoryDispatched);

                                if (!requiresProof)
                                {
                                    order.OrderStatusId = (int)OrderIdentifier.Dispatched;

                                    var orderStatusHistoryNew = OrderStatusHistoryFactory.CreateEntity(workUnit,
                                        orderId: orderLine.OrderId,
                                        orderStatusId: (int)OrderIdentifier.Delivered,
                                        createdDate: DateTime.UtcNow,
                                        userId: userId
                                    );

                                    repository.Container.OrderStatusHistory.AddObject(orderStatusHistoryNew);
                                }

                                repository.Container.SaveChanges();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// UpdateOrderLineStatus operation
        /// </summary>
        public void UpdateOrderLineStatus(Turnaround turnaround)
        {
            {
                var orderLine = turnaround.OrderLine.FirstOrDefault();

                if (orderLine != null)
                {
                    var orderLines = repository.Container.OrderLine.Where(ol => ol.OrderId == orderLine.OrderId);

                    foreach (OrderLine ol in orderLines.Where(ol => ol.OrderLineStatusId == (int)OrderIdentifier.Picked))
                    {
                        ol.OrderLineStatusId = (int)OrderLineStatusIdentifier.Delivered;
                    }

                    repository.Container.SaveChanges();
                }
            }
        }

        /// <summary>
        /// GetStationLocations operation
        /// </summary>
        public List<StationDataContract> GetStationLocations(int facilityId)
        {
            using (var repo = new PathwayRepository())
            {
                var stations = repo.Container.Station
                    .Where(s => s.FacilityId == facilityId && s.Archived == null)
                    .Select(s => new StationDataContract
                    {
                        Id = s.StationId,
                        Name = s.Text,
                        Type = s.StationType.Text,
                        DisplayOrder = s.StationType.DisplayOrder,
                        Logon = s.NTLogon,
                        Location = s.Location.Text,
                        LocationCode = s.Location.LocationCode,
                        Culture = s.Culture
                    })
                    .OrderBy(s => s.DisplayOrder)
                    .ThenBy(s => s.Name)
                    .ToList();

                return stations;
            }
        }

        /// <summary>
        /// GetStationLocationTrees operation
        /// </summary>
        public LocationsDataContract GetStationLocationTrees(int facilityId)
        {
            var dataContract = new LocationsDataContract();

            using (IUnitOfWork operativeWorkUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var locationRepository = LocationRepository.New(operativeWorkUnit);

                var validLocationTypes = new List<LocationTypeIdentifier>
                {
                    LocationTypeIdentifier.General,
                    LocationTypeIdentifier.Stock,
                    LocationTypeIdentifier.EndoscopeStockLocation,
                    LocationTypeIdentifier.EndoscopeGeneralLocation
                };

                var allNodes = locationRepository.Repository.Find(i => i.Archived == null)
                    .Where(l => l.Leaf.Tree.Owner.Facility.Any(f => f.FacilityId == facilityId)
                                && validLocationTypes.Contains((LocationTypeIdentifier)l.LocationTypeId)
                           ).ToList();

                dataContract.Locations = allNodes
                    .Select(i => new LocationDataContract()
                    {
                        TreeId = i.Leaf.TreeId,
                        Lft = i.Leaf.Lft,
                        Rgt = i.Leaf.Rgt,
                        LeafId = i.LeafId,
                        Description = i.Description,
                        ExternalId = i.ExternalId,
                        IsMandatoryForClockingProcess = i.IsMandatoryForClockingProcess,
                        LocationId = i.LocationId,
                        Text = i.Text,
                        TreeText = (i.Leaf.Tree.LocationTree.FirstOrDefault() == null) ? null : i.Leaf.Tree.LocationTree.FirstOrDefault().TreeCode + " - " + i.Leaf.Tree.Text,
                        IsStockLocation = (LocationTypeIdentifier)i.LocationTypeId == LocationTypeIdentifier.Stock,
                        LocationCode = i.LocationCode,
                        LocationTypeId = i.LocationTypeId,
                        MaximumCapacity = i.MaximumCapacity,
                        IsUsagePoint = i.IsUsagePoint
                    }).ToList();

                return dataContract;
            }
        }

        /// <summary>
        /// GetDeliveryPointCustomerLocationTrees operation
        /// </summary>
        public LocationsDataContract GetDeliveryPointCustomerLocationTrees(int userId)
        {
            var dataContract = new LocationsDataContract();

            {
                var locationRepository = LocationRepository.New(operativeWorkUnit);
                var userDeliveryPointRepository = UserDeliveryPointRepository.New(operativeWorkUnit);

                var owners = userDeliveryPointRepository.Repository.Find(i => i.UserId == userId)
                    .Select(x => x.DeliveryPoint.CustomerDefinition.OwnerId);

                var storagePointLocations = userDeliveryPointRepository.Repository.Find(i => i.UserId == userId)
                    .SelectMany(x => x.DeliveryPoint.CustomerDefinition.StoragePoint.Where(s => s.Archived == null)).Distinct()
                    .Select(l => l.Location);

                var deliveryPointLocations = locationRepository.Repository.Find(i => i.Archived == null).Where
                    (l => owners.Contains(l.Leaf.Tree.Owner.OwnerId));

                var allNodes = deliveryPointLocations.Union(storagePointLocations);

                var finalNodes = allNodes
                    .Select(i => new LocationDataContract()
                    {
                        TreeId = i.Leaf.TreeId,
                        Lft = i.Leaf.Lft,
                        Rgt = i.Leaf.Rgt,
                        LeafId = i.LeafId,
                        Description = i.Description,
                        ExternalId = i.ExternalId,
                        IsMandatoryForClockingProcess = i.IsMandatoryForClockingProcess,
                        LocationId = i.LocationId,
                        Text = i.Text,
                        TreeText = (i.Leaf.Tree.LocationTree.FirstOrDefault() == null) ? null : i.Leaf.Tree.LocationTree.FirstOrDefault().TreeCode + " - " + i.Leaf.Tree.Text,
                        IsStockLocation = (LocationTypeIdentifier)i.LocationTypeId == LocationTypeIdentifier.Stock,
                        LocationCode = i.LocationCode,
                        LocationTypeId = i.LocationTypeId,
                        MaximumCapacity = i.MaximumCapacity,
                        IsUsagePoint = i.IsUsagePoint
                    }).ToList();

                dataContract.Locations = finalNodes;

                return dataContract;
            }
        }

        private List<CompletedPartWashReplyDataContract> CompletedPartWashes(ScanAssetDataContract scanDC)
        {
            var completedPartWashes = new List<CompletedPartWashReplyDataContract>();

            if (scanDC.TurnaroundId.HasValue)
            {
                if (scanDC.TurnaroundEvents != null)
                {
                    var startPoint = scanDC.TurnaroundEvents.OrderByDescending(o => o.Created).FirstOrDefault(te =>
                        te.EventTypeId == (int)TurnAroundEventTypeIdentifier.DeconStart ||
                        te.EventTypeId == (int)TurnAroundEventTypeIdentifier.DeconCancel);

                    List<TurnaroundEventDataContract> partWashEvents = null;

                    if (startPoint != null)
                    {
                        partWashEvents = scanDC.TurnaroundEvents.OrderByDescending(o => o.Created).Where(te =>
                            te.EventTypeId == (int)TurnAroundEventTypeIdentifier.PartWash &&
                            te.Created > startPoint.Created).ToList();
                    }
                    else
                    {
                        partWashEvents = scanDC.TurnaroundEvents.OrderByDescending(o => o.Created)
                            .Where(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.PartWash)
                            .ToList();
                    }

                    if (partWashEvents.Any())
                    {
                        foreach (var partWash in partWashEvents)
                        {
                            var batchId = partWash.BatchId;
                            var machineId = partWash.MachineId;

                            {
                                var machine = repository.Container.Machine.FirstOrDefault(m => m.MachineId == machineId);
                                if (machine != null)
                                {
                                    var batch = from b in repository.Container.Batch.Where(b => b.BatchId == batchId)
                                                join u in repository.Container.User on b.CreatedUserId equals u.UserId
                                                select new CompletedPartWashReplyDataContract
                                                {
                                                    MachineTypeId = machine.MachineType.MachineTypeId,
                                                    MachineTypeName = machine.MachineType.Text,
                                                    DateOfBatch = b.Created,
                                                    UserFullname = u.FirstName + " " + u.Surname,
                                                    MachineId = machineId,
                                                    MachineName = machine.Text,
                                                    DeconTaskId = machine.MachineType.DecontaminationTaskId,
                                                    BatchId = batchId
                                                };

                                    var batchDetails = batch.FirstOrDefault();

                                    if (batchDetails != null)
                                    {
                                        batchDetails.DateOfBatch = DateTime.SpecifyKind(batchDetails.DateOfBatch, DateTimeKind.Utc);
                                        completedPartWashes.Add(batchDetails);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return completedPartWashes;
        }

        /// <summary>
        /// GetReportsAndNotification operation
        /// </summary>
        public void GetReportsAndNotification(List<ScanAssetDataContract> listOfDataContracts, BaseReplyDataContract replyContract)
        {
            replyContract.Reports = new List<ReportDataContract>();

            foreach (var dc in listOfDataContracts.OrderBy(x=>x.TurnaroundId))
            {
                if (dc.Reports != null && dc.Reports.Count > 0)
                {
                    foreach (var report in dc.Reports)
                    {
                        replyContract.Reports.Add(report);
                    }
                }

                if (replyContract.NotificationTypesFired == null)
                {
                    replyContract.NotificationTypesFired = dc.NotificationTypesFired;
                }
            }
        }
    }
}

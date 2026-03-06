using System.Collections.Generic;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs.Scan;
using System;
using SynergyApplicationFrameworkApi.Application.Services.TurnaroundProcessing;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public sealed class TrolleyDispatchHelper
    {
        private readonly ITrolleyDatabaseHelper _trolleyDatabaseHelper;
        private readonly ISynergyTrakHelper _synergyTrakHelper;
        private readonly IOOATrolleyDispatchHelper _ooaTrolleyDispatchHelper;
        private readonly ILog _log;

        public TrolleyDispatchHelper(ITrolleyDatabaseHelper trolleyDatabaseHelper, ISynergyTrakHelper synergyTrakHelper, ILog log, IOOATrolleyDispatchHelper ooaTrolleyDispatchHelper)
        {
            _log = log;
            _trolleyDatabaseHelper = trolleyDatabaseHelper;
            _synergyTrakHelper = synergyTrakHelper;
            _ooaTrolleyDispatchHelper = ooaTrolleyDispatchHelper;
        }

        /// <summary>
        /// GetTrolleyContents operation
        /// </summary>
        public TrolleyDispatchTrolleyDataContract GetTrolleyContents(ScanDetails scanDetails, bool validateTrolleyWorkflow)
        {
            _log.Info("Get Trolley Contents START");

            var dataContract = CreateReturnDataContract(scanDetails);
            var trolleyExternalId = scanDetails is TrolleyDispatchScanTurnaroundScanDetails ? ((TrolleyDispatchScanTurnaroundScanDetails)scanDetails).TrolleyExternalId : scanDetails.ExternalId;
            var unFilteredTrolleys = GetTrolleySummary(trolleyExternalId, scanDetails.FacilityId).ToList();
            var trolleys =unFilteredTrolleys.Where(x=>x.IsOwner || x.CanProcessForMFPCustomer);
            TrolleyDispatch_GetTrolleySummary_Result trolley = null;
            if (trolleys.Count() > 1)
            {
                dataContract.ErrorCode = (int)ErrorCodes.DuplicateExternalId;
                Scanning.FailedScan.Add(trolleyExternalId, (short)Enums.ScanType.Trolley, scanDetails.UserId, scanDetails.StationId ?? 0, scanDetails.StationLocationId, (short)TurnAroundEventTypeIdentifier.TrolleyStarted, DateTime.UtcNow);
                return dataContract;
            }
            if (trolleys.Count() == 0)
            {
                var MFPInProcessTrolley = unFilteredTrolleys.FirstOrDefault();
                if (MFPInProcessTrolley != null)
                {
                    if (_trolleyDatabaseHelper.FaciltyHasOutstandingMFPTurnarounds(scanDetails.FacilityId, MFPInProcessTrolley.OwnerFacilityId))
                        trolley = MFPInProcessTrolley;
                }
            }
            else
            {
                trolley = trolleys.FirstOrDefault();
            }
            _log.Info("GetTrolleySummary END");
            if (trolley == null)
            {
                dataContract.ErrorCode = (int)ErrorCodes.NotATrolley;
                Scanning.FailedScan.Add(scanDetails.ExternalId, (short)Enums.ScanType.Trolley, scanDetails.UserId, scanDetails.StationId ?? 0, scanDetails.StationLocationId, null, DateTime.UtcNow);
                return dataContract;
            }
            else
            {
                dataContract.LastEventAppliedId = (int)trolley.LastEventTypeId;
            }
            if (validateTrolleyWorkflow)
            {
                ///or the trolley processing facility does not match the current facility
                if ((trolley.LastEventTypeId != (short)TurnAroundEventTypeIdentifier.TrolleyStarted && trolley.LastEventTypeId != (short)TurnAroundEventTypeIdentifier.LoadTrolleyEPOD && trolley.LastEventTypeId != (short)TurnAroundEventTypeIdentifier.TrolleyDispatched) || (trolley.ProcessingFacilityId != scanDetails.FacilityId && trolley.OwnerFacilityId != scanDetails.FacilityId))
                {
                    _synergyTrakHelper.SynergyTrakData.FacilityId = scanDetails.FacilityId;
                    ScanAssetDataContract scanDC = new ScanAssetDataContract
                    {
                        FacilityId = scanDetails.FacilityId,
                        UserId = scanDetails.UserId,
                        TurnaroundExternalId = (long)trolley.TrolleyTurnaroundExternalID,
                        LastProcessEventTypeId = (TurnAroundEventTypeIdentifier)trolley.LastEventTypeId,
                        Asset = new AssetDetailsDataContract
                        {
                            ItemTypeId = trolley.ItemTypeId,
                            ContainerMasterId = trolley.TrolleyContainerMasterId
                        }
                    };

                    _synergyTrakHelper.SynergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.TrolleyStarted;
                    _synergyTrakHelper.SynergyTrakData.StationId = scanDetails.StationId;
                    _synergyTrakHelper.SynergyTrakData.StationTypeId = scanDetails.StationTypeId;
                    _synergyTrakHelper.SynergyTrakData.UserId = scanDetails.UserId;
                    if (!_synergyTrakHelper.ValidateWorkFlowStep(scanDC, (int)TurnAroundEventTypeIdentifier.TrolleyStarted))
                    {
                        using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                        {
                            var containerRepository = ContainerInstanceRepository.New(workUnit);
                            var containerInstance = containerRepository.GetContainerInstanceByExternalOrAlternateId(scanDetails.ExternalId);
                            bool canStartNewTurnaround = false;
                            if (containerInstance?.CurrentTurnaround == null)
                                canStartNewTurnaround = true;
                            else
                                canStartNewTurnaround = containerInstance.CurrentTurnaround.CurrentTurnaroundEvent.TurnaroundEvent.Workflow.IsEnd;
                            if (!canStartNewTurnaround)
                            {
                                dataContract.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                                dataContract.TurnaroundExternalId = trolley.TrolleyTurnaroundExternalID.Value;
                                dataContract.NextEvent = trolley.NextEvent;
                                dataContract.LastProcessEventTypeId = (TurnAroundEventTypeIdentifier)(trolley.LastEventTypeId);
                                dataContract.EventTypeId = TurnAroundEventTypeIdentifier.TrolleyStarted;
                                dataContract.TurnaroundId = trolley.TurnaroundId;
                                dataContract.Asset = new AssetDetailsDataContract
                                {
                                    ContainerInstancePrimaryId = scanDetails.ExternalId
                                };
                                TurnaroundProcessing.DeniedTurnaroundEvent.Log(dataContract);
                                return dataContract;
                            }
                        }
                    }
                }
            }
            dataContract.Name = trolley.TrolleyName;
            dataContract.ContainerInstancelId = trolley.TrolleyInstanceId;
            dataContract.InstancePrimaryId = trolley.TrolleyInstancePrimaryId;
            dataContract.Contents = new List<TrolleyDispatchContainerDataContract>();
            if (trolley.HasTurnaroundEnded != true || trolley.LastEventTypeId == (int) TurnAroundEventTypeIdentifier.TrolleyDispatched)
            {
                dataContract.TurnaroundExternalId = (int)trolley.TrolleyTurnaroundExternalID;

                var dataModel = _trolleyDatabaseHelper.GetTrolleyContents(trolley.TrolleyInstanceId);
                if (dataModel != null)
                {
                    dataContract.Contents.AddRange(ConvertTrolleyContentsDataModelToDataContractModel(dataModel));
                }
                using (var workUnit = InstanceFactory.GetInstance<IUnitOfWork>())
                {
                    var containerRepository = ContainerInstanceRepository.New(workUnit);
                    var trolleyContainer = containerRepository.Get(trolley.TrolleyInstanceId);

                    dataContract.SuggestedTurnarounds = GetSuggestedTurnarounds(scanDetails.FacilityId, trolleyContainer, scanDetails.StationTypeId == (int)StationTypeIdentifier.OOATrolleyDispatch);
                }
               
            }
            else
                dataContract.SuggestedTurnarounds = GetSuggestedTurnarounds(scanDetails.FacilityId, null, null, scanDetails.StationTypeId == (int)StationTypeIdentifier.OOATrolleyDispatch);

            _log.Info("Get Trolley Contents END");
            return dataContract;
        }

        private IEnumerable<TrolleyDispatchContainerDataContract> ConvertTrolleyContentsDataModelToDataContractModel(IEnumerable<TrolleyDispatch_GetTrolleyContents_Result> model)
        {
            return model.Select(X => ConvertTrolleyContentsDataModelToDataContractModel(X));
        }

        /// <summary>
        /// ConvertTrolleyContentsDataModelToDataContractModel operation
        /// </summary>
        public TrolleyDispatchContainerDataContract ConvertTrolleyContentsDataModelToDataContractModel(TrolleyDispatch_GetTrolleyContents_Result trolleyItem)
        {
            return new TrolleyDispatchContainerDataContract
            {
                CustomerId = trolleyItem.CustomerId ?? 0,
                CustomerName = trolleyItem.CustomerName,
                DeliveryPointId = trolleyItem.DeliveryPointId ?? 0,
                DeliveryPointName = trolleyItem.DeliveryPointName,
                ExpiryDate = trolleyItem.ExpiryDate != null ? DateTime.SpecifyKind(trolleyItem.ExpiryDate.Value, DateTimeKind.Utc) : trolleyItem.ExpiryDate,
                InstancePrimaryId = trolleyItem.ContainerInstancePrimaryId,
                InstanceId = trolleyItem.ContainerInstanceId,
                IsFastTrack = trolleyItem.IsFastTrack,
                IsSupplementary = trolleyItem.IsSupplementary,
                IsExtra = trolleyItem.IsExtra,
                IsTray = trolleyItem.IsTray,
                Name = trolleyItem.Name,
                ServiceRequirement = trolleyItem.ServiceRequirement,
                TurnaroundExternalId = (long)trolleyItem.TurnaroundExternalId,
                LastEventDateTime = DateTime.SpecifyKind(trolleyItem.LastEventDateTime, DateTimeKind.Utc),
                LastEventType = (TurnAroundEventTypeIdentifier)trolleyItem.LastEventTypeId,
                ItemType = trolleyItem.ItemType,
                IsExpiringSoon = trolleyItem.IsExpiringSoon,
                DeliveryPointRestrictedForTrolleys = trolleyItem.RestrictedForTrolleys
            };
        }

        /// <summary>
        /// GetDispatchHubSummary operation
        /// </summary>
        public TrolleyDispatchHubSummaryDataContract GetDispatchHubSummary(int facilityId)
        {
            var dataContract = new TrolleyDispatchHubSummaryDataContract();
            var dataModel = _trolleyDatabaseHelper.GetTrolleyHubSummary(facilityId);
            if (dataModel != null)
            {
                _log.Info("Read trollies with incomplete LoanSets START");
                var trolleysWithIncompleteLoanSets = _trolleyDatabaseHelper.GetTrolleysWithIncompleteLoanSets(facilityId);
                var turnaroundRepository = TurnaroundRepository.New(UnitOfWorkFactory.CreateOperativeEFUnitOfWork());
                var trolleyTurnaroundsWithIncompleteLoanSets = turnaroundRepository.Get(trolleysWithIncompleteLoanSets);
                _log.Info("Read trollies with incomplete LoanSets END");

                List<TrolleyDispatchTrolleySummaryDataContract> trolleys = new List<TrolleyDispatchTrolleySummaryDataContract>(dataModel.Count);
                foreach (var item in dataModel)
                {
                    var trolley = trolleys.SingleOrDefault(x => x.ContainerInstanceId == item.ContainerInstanceId);
                    if (trolley == null)
                    {
                        var rowToCheckExpiry = dataModel.OrderBy(a => a.Expiry).Where(a => a.ContainerInstanceId == item.ContainerInstanceId && a.Expiry != DateTime.Parse("01/01/1900 12:00:00 AM")).FirstOrDefault();
                        var expiryDate = DateTime.SpecifyKind(rowToCheckExpiry?.Expiry.GetValueOrDefault() ?? DateTime.Now.AddDays(7), DateTimeKind.Utc);

                        trolleys.Add(new TrolleyDispatchTrolleySummaryDataContract
                        {
                            ContainerInstanceId = item.ContainerInstanceId,
                            CustomerId = item.CustomerId ?? 0,
                            CustomerName = item.CustomerName,
                            ContainerInstancePrimaryId = item.ContainerInstancePrimaryId,
                            DeliveryPoints = new string[] { item.DeliveryPointName }.ToList(),
                            TotalItemCount = dataModel.Count(a => a.ContainerInstanceId == item.ContainerInstanceId),
                            FastTrackCount = dataModel.Count(a => a.ContainerInstanceId == item.ContainerInstanceId && a.IsFastTrack),
                            OverdueCount = dataModel.Count(a => a.ContainerInstanceId == item.ContainerInstanceId && a.IsOverdue),
                            ExpiringSoonCount = dataModel.Count(a => a.ContainerInstanceId == item.ContainerInstanceId && a.IsExpiringSoon),
                            ExpiryDate = expiryDate,
                            ServiceRequirementText = dataModel.OrderBy(a => a.Expiry).Where(a => a.ContainerInstanceId == item.ContainerInstanceId && a.IsFastTrack).Select(a => a.ServiceRequirementName).FirstOrDefault(),
                            HasIncompleteLoanSet = trolleyTurnaroundsWithIncompleteLoanSets.Any(t => t.ContainerInstanceId == item.ContainerInstanceId)
                            
                        });
                    }
                    else
                    {
                        if (!trolley.DeliveryPoints.Contains(item.DeliveryPointName))
                            trolley.DeliveryPoints.Add(item.DeliveryPointName);
                    }
                }
                dataContract.Trolleys = trolleys;
            }
            return dataContract;
        }

        /// <summary>
        /// GetTrolleySummary operation
        /// </summary>
        public IList<TrolleyDispatch_GetTrolleySummary_Result> GetTrolleySummary(string externalId, int facilityId)
        {
            _log.Info("GetTrolleySummary START");
            return _trolleyDatabaseHelper.GetTrolleySummary(externalId, facilityId);
        }

        /// <summary>
        /// DispatchTrolley operation
        /// </summary>
        public TrolleyDispatchDeliveryNoteDataContract DispatchTrolley(DeliveryNoteScanDetails scanDetails)
        {
            _log.Info("Dispatch Trolley BEGIN");
            var dataContract = new TrolleyDispatchDeliveryNoteDataContract();
            var trolleys = GetTrolleySummary(scanDetails.ExternalId, scanDetails.FacilityId);

            if (trolleys.Count() > 1)
            {
                dataContract.ErrorCode = (int)ErrorCodes.DuplicateExternalId;
                return dataContract;
            }
            var trolley = trolleys.FirstOrDefault();
            if (trolley == null)
            {
                dataContract.ErrorCode = (int)ErrorCodes.NotATrolley;
                return dataContract;
            }

            var contents = _trolleyDatabaseHelper.GetTrolleyContents(trolley.TrolleyInstanceId);
            if (contents == null || contents.Count() == 0)
            {
                dataContract.ErrorCode = (int)ErrorCodes.ErrorPrintingDeliveryNote;
                return dataContract;
            }
            scanDetails.Events = new List<ScanEventDataContract>
            {
                new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.TrolleyDispatched}
            };
            _synergyTrakHelper.SynergyTrakData.FacilityId = scanDetails.FacilityId;
            ScanAssetDataContract scanDC = new ScanAssetDataContract
            {
                FacilityId = scanDetails.FacilityId,
                UserId = scanDetails.UserId,
                TurnaroundExternalId = (long)trolley.TrolleyTurnaroundExternalID,
                LastProcessEventTypeId = (TurnAroundEventTypeIdentifier)trolley.LastEventTypeId,
                Asset = new AssetDetailsDataContract
                {
                    ItemTypeId = trolley.ItemTypeId,
                    ContainerMasterId = trolley.TrolleyContainerMasterId
                }
            };

            if (!_synergyTrakHelper.ValidateWorkFlowStep(scanDC, (int)TurnAroundEventTypeIdentifier.TrolleyDispatched))
            {
                dataContract.ErrorCode = (int)ErrorCodes.Unknown;
                return dataContract;
            }

            if (!scanDetails.ForcePrint)
            {
                dataContract.Turnarounds = _synergyTrakHelper.AreAllLoanSetDispatched(contents.Where(t => t.LastEventTypeId != (int)TurnAroundEventTypeIdentifier.DeliveryNotePrint && t.TurnaroundExternalId.HasValue).Select(t => t.TurnaroundExternalId.Value).ToList(), trolley.TurnaroundId.Value);

                if (dataContract.Turnarounds?.Any() == true)
                {
                    dataContract.ErrorCode = (int)ErrorCodes.DeliveryNoteMissingFromLoanset;
                    return dataContract;
                }
            }
            dataContract.TrolleyContainerInstanceId = trolley.TrolleyInstanceId;
            if (!dataContract.ErrorCode.HasValue)
                dataContract.DeliveryNoteIds = _trolleyDatabaseHelper.AssignTrolleyContentsToDeliveryNote(trolley.TrolleyInstanceId, scanDetails.FacilityId, scanDetails.UserId, (int)scanDetails.StationId, scanDetails.StationTypeId, scanDetails.PinReason).ToList();

            _log.Info("Dispatch Trolley END");
            return dataContract;
        }

        /// <summary>
        /// DispatchTrolleys operation
        /// </summary>
        public TrolleyDispatchDeliveryNoteBatchDataContract DispatchTrolleys(DeliveryNoteBatchScanDetails scanDetails)
        {
            _log.Info("Dispatch Trolleys BEGIN");
            var dataContract = new TrolleyDispatchDeliveryNoteBatchDataContract();
            {
                var containerInstanceRepository = ContainerInstanceRepository.New(workUnit);

                _log.Info("Load Instances START");
                var trolleys = containerInstanceRepository.GetMultiple(scanDetails.TrolleyContainerInstanceIds);
                _log.Info("Load Instances END");

                scanDetails.Events = new List<ScanEventDataContract>
                {
                    new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.TrolleyDispatched}
                };

                _synergyTrakHelper.SynergyTrakData.FacilityId = scanDetails.FacilityId;

                var scanDcList = new List<ScanAssetDataContract>();

                _log.Info("Validate workflow BEGIN");
                foreach (var trolley in trolleys)
                {
                    var scanDC = new ScanAssetDataContract
                    {
                        FacilityId = scanDetails.FacilityId,
                        UserId = scanDetails.UserId,
                        TurnaroundExternalId = (long)trolley.CurrentTurnaround?.ExternalId,
                        LastProcessEventTypeId = (TurnAroundEventTypeIdentifier)trolley.CurrentTurnaround.CurrentTurnaroundEvent.EventTypeId,
                        Asset = new AssetDetailsDataContract
                        {
                            ContainerInstancePrimaryId = trolley.PrimaryId,
                            ItemTypeId = trolley.ContainerMasterDefinition.ContainerMaster.ItemTypeId,
                            ContainerInstanceId = trolley.ContainerInstanceId,
                            ContainerMasterId = trolley.ContainerMasterDefinition.ContainerMaster.ContainerMasterId,
                            ContainerMasterName = trolley.ContainerMasterDefinition.ContainerMaster.Text
                        }
                    };

                    if (!_synergyTrakHelper.ValidateWorkFlowStep(scanDC, (int)TurnAroundEventTypeIdentifier.TrolleyDispatched)) //DB HIT 3
                    {
                        scanDC.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                    }

                    scanDcList.Add(scanDC);
                }
                _log.Info("Validate workflow END");

                var instanceIds = scanDcList.Where(dc => dc.ErrorCode == null).Select(dc => dc.Asset.ContainerInstanceId.Value).ToList();

                _log.Info("Assign to Trolley & Dispatch START");
                var results = _trolleyDatabaseHelper.AssignTrolleyContentsToDeliveryNote_Bulk(instanceIds, scanDetails.FacilityId, scanDetails.UserId, (int)scanDetails.StationId, scanDetails.StationTypeId, scanDetails.PinReason).ToList();
                _log.Info("Assign to Trolley & Dispatch END");

                dataContract.TrolleyDeliveryNotes = (from result in results
                                                     select new TrolleyDeliveryNotesDataContract
                                                     {
                                                         TrolleyContainerInstanceId = result.TrolleyContainerInstanceId,
                                                         DeliveryNoteIds = result.DeliveryNoteIds,
                                                         Asset = scanDcList.FirstOrDefault(dc => dc.Asset.ContainerInstanceId == result.TrolleyContainerInstanceId).Asset
                                                     }).ToList();

                dataContract.TrolleyDeliveryNotes.AddRange(
                    from dc in scanDcList
                    where dc.ErrorCode.HasValue && dc.Asset?.ContainerInstanceId != null
                    select new TrolleyDeliveryNotesDataContract
                    {
                        ErrorCode = dc.ErrorCode,
                        DeliveryNoteIds = new List<int>(),
                        Asset = dc.Asset
                    });

                _log.Info("Dispatch Trolleys END");
                return dataContract;
            }
        }

        /// <summary>
        /// ValidateTurnaroundCanBeProcessedOntoTrolley operation
        /// </summary>
        public TrolleyDispatchTrolleyDataContract ValidateTurnaroundCanBeProcessedOntoTrolley(ContainerInstance trolley, TrolleyDispatchTrolleyDataContract dataContract, TrolleyDispatchScanTurnaroundScanDetails scanDetails, long trayTurnaroundExternalId, out int deliveryPointId, out int facilityId)
        {
            _log.Info("ValidateTurnaroundCanBeProcessedOntoTrolley START");
            deliveryPointId = 0;
            facilityId = 0;

            {
                var turnaroundRepository = TurnaroundRepository.New(workUnit);
                var turnaround = turnaroundRepository.GetByExternalId(new List<long> { trayTurnaroundExternalId }).FirstOrDefault();
                if (turnaround == null)
                {
                    dataContract.ErrorCode = (int)ErrorCodes.InvalidItem;
                    dataContract.TurnaroundExternalId = scanDetails.TurnaroundExternalId ?? 0;
                    Scanning.FailedScan.Add(scanDetails.TurnaroundExternalId.ToString(), (short)Enums.ScanType.Turnaround, scanDetails.UserId, scanDetails.StationId ?? 0, scanDetails.StationLocationId, (short)TurnAroundEventTypeIdentifier.AddedToTrolley, DateTime.UtcNow);
                    return dataContract;
                }
                var unvalidatedTrolleys = _trolleyDatabaseHelper.GetTrolleySummary(scanDetails.TrolleyExternalId, scanDetails.FacilityId);
                bool isMFPStillInProcessTrolley = false;
                var trolleyDetails = unvalidatedTrolleys.Where(x => x.IsOwner || x.CanProcessForMFPCustomer).ToList();
                if (trolleyDetails.Count() == 0 && _trolleyDatabaseHelper.FaciltyHasOutstandingMFPTurnarounds(scanDetails.FacilityId, trolley.FacilityId))
                {
                    trolleyDetails = unvalidatedTrolleys.ToList();
                    isMFPStillInProcessTrolley = true;
                }
                
                TrolleyDispatch_GetTrolleySummary_Result trolleyInfo = null;
                if (scanDetails.FacilityId != turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.FacilityId)
                {
                    var turnaorundValidTrolleys = _trolleyDatabaseHelper.GetTrolleySummary(scanDetails.TrolleyExternalId, turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.FacilityId).Where(x => x.IsOwner || (x.CanProcessForMFPCustomer && x.CanProcessForAnyCustomerFacility)).Select(x => x.TrolleyInstanceId).ToList();
        
                    if (!trolleyDetails.Any(x => turnaorundValidTrolleys.Contains(x.TrolleyInstanceId)))
                    {
                        dataContract.TurnaroundExternalId = scanDetails.TurnaroundExternalId ?? 0;
                        dataContract.ErrorCode = (int)ErrorCodes.TurnaroundAndTrolleyFacilityMismatch;
                        return dataContract;
                    }
                }

                if (trolleyDetails.Count != 1)
                {
                    if (trolleyDetails.Count > 1)
                        dataContract.ErrorCode = (int)ErrorCodes.DuplicateExternalId;
                    else
                    {
                        dataContract.ErrorCode = (int)ErrorCodes.InvalidItem;
                    }
                    if (dataContract.ErrorCode.HasValue)
                    {
                        Scanning.FailedScan.Add(scanDetails.TurnaroundExternalId.ToString(), (short)Enums.ScanType.Turnaround, scanDetails.UserId, scanDetails.StationId ?? 0, scanDetails.StationLocationId, (short)TurnAroundEventTypeIdentifier.AddedToTrolley, DateTime.UtcNow);
                        dataContract.TurnaroundExternalId = scanDetails.TurnaroundExternalId ?? 0;
                        return dataContract;
                    }
                }
                else
                {
                    trolleyInfo = trolleyDetails.FirstOrDefault();
                }

                if(trolleyInfo == null)
                {
                    dataContract.ErrorCode = (int)ErrorCodes.InvalidItem;
                    Scanning.FailedScan.Add(scanDetails.TurnaroundExternalId.ToString(), (short)Enums.ScanType.Turnaround, scanDetails.UserId, scanDetails.StationId ?? 0, scanDetails.StationLocationId, (short)TurnAroundEventTypeIdentifier.AddedToTrolley, DateTime.UtcNow);
                    dataContract.TurnaroundExternalId = scanDetails.TurnaroundExternalId ?? 0;
                    return dataContract;
                }

                var turnaroundCustomerIsRelevant = true;
                TurnAroundEventTypeIdentifier lastEvent = (TurnAroundEventTypeIdentifier)(turnaround.LastEvent?.EventTypeId ?? (int)TurnAroundEventTypeIdentifier.Unknown);
                var deliveryPoint = turnaround?.DeliveryPoint;
                var IsStock = deliveryPoint?.StockLocation ?? false;

                if (   lastEvent == TurnAroundEventTypeIdentifier.IntoStock
                    || lastEvent == TurnAroundEventTypeIdentifier.OutOfStock
                    || (lastEvent == TurnAroundEventTypeIdentifier.IntoAutoclave && IsStock)
                    || (lastEvent == TurnAroundEventTypeIdentifier.OutofAutoclave && IsStock)
                    || (lastEvent == TurnAroundEventTypeIdentifier.QualityAssurance && IsStock)

                   )
                {// in these cases the customer will be reassigned to trolley customer anyway
                    turnaroundCustomerIsRelevant = false;
                }

                                                
                if (IsStock && !(scanDetails.IsDispatchingStock ?? false))
                {
                    dataContract.ErrorCode = (int)ErrorCodes.InvalidRequest;
                    dataContract.IsStockLocation = true;
                    dataContract.TurnaroundExternalId = scanDetails.TurnaroundExternalId ?? 0;
                    return dataContract;
                }

                if (((trolleyInfo.IsOwner || trolleyInfo.CanProcessForMFPCustomer || isMFPStillInProcessTrolley) && !trolleyInfo.CanProcessForAnyCustomerFacility) && turnaroundCustomerIsRelevant)
                {
                    if(turnaround.DeliveryPoint.CustomerDefinition.CurrentCustomer.FacilityId != trolleyInfo.OwnerFacilityId)
                    {
                        dataContract.ErrorCode = (int)ErrorCodes.TurnaroundAndTrolleyFacilityMismatch;
                        Scanning.FailedScan.Add(scanDetails.TurnaroundExternalId.ToString(), (short)Enums.ScanType.Turnaround, scanDetails.UserId, scanDetails.StationId ?? 0, scanDetails.StationLocationId, (short)TurnAroundEventTypeIdentifier.AddedToTrolley, DateTime.UtcNow);
                        dataContract.TurnaroundExternalId = scanDetails.TurnaroundExternalId ?? 0;
                        return dataContract;
                    }
                }

                

                deliveryPointId = turnaround.DeliveryPointId;
                facilityId = deliveryPoint?.CustomerDefinition?.CurrentCustomer?.FacilityId ?? 0;
                if (turnaround.DisableTrolleyCustomerRestriction && (trolley.CurrentTurnaround == null
                                                                 || !trolley.CurrentTurnaround.ChildTurnaround.Any()
                                                                 || (scanDetails.StartNewTrolleyTurnaround.HasValue && scanDetails.StartNewTrolleyTurnaround.Value)))
                {
                    dataContract.ErrorCode = (int)ErrorCodes.TrolleyDispatchUnrestrictedItemFirst;
                    return dataContract;
                }
           
                Func<Turnaround,bool> notGhost = t => !t.DisableTrolleyCustomerRestriction ;
                if (((!trolley?.CurrentTurnaround?.CurrentTurnaroundEvent?.TurnaroundEvent?.Workflow?.IsEnd ?? false) || scanDetails.StartNewTrolleyTurnaround == false )&& turnaroundCustomerIsRelevant)
                {

                    if ( (trolley.CurrentTurnaround.ChildTurnaround.Where(notGhost).Any(ct => ct.DeliveryPoint.CustomerDefinitionId != turnaround?.DeliveryPoint?.CustomerDefinitionId))//if it doesnt match
                        && (!turnaround?.DisableTrolleyCustomerRestriction ?? false) // and we're not ignoring that it doesnt match
                       )
                    {
                        dataContract.ErrorCode = (int)ErrorCodes.TurnaroundForDifferentCustomer;
                        dataContract.TurnaroundExternalId = scanDetails.TurnaroundExternalId ?? 0;
                        return dataContract;
                    }

                    if (!turnaround.DisableTrolleyCustomerRestriction && (turnaround.DeliveryPoint.RestrictedForTrolleys //if this tray is restricted deliverypoint and we havn't disabled the restriction
                               || trolley.CurrentTurnaround.ChildTurnaround.Where(notGhost).Any(ct => ct.DeliveryPoint.RestrictedForTrolleys))    // or if the trolleys other trays have a restricted deliverypoint
                        && !trolley.CurrentTurnaround.ChildTurnaround.Where(notGhost).Any(ct => ct.DeliveryPoint.DeliveryPointId == turnaround.DeliveryPoint.DeliveryPointId)) //and the delivery points dont all match then error
                    {
                        var customerRepository = CustomerRepository.New(workUnit);
                        var customer = customerRepository.GetActiveOneByDefinitionId(trolley.CurrentTurnaround.ChildTurnaround.Where(notGhost).First().DeliveryPoint.CustomerDefinitionId);
                        var deliveryPointRepository = DeliveryPointRepository.New(workUnit);
                        var trolleyDeliveryPoint = deliveryPointRepository.Get(trolley.CurrentTurnaround.ChildTurnaround.Where(notGhost).Where(ct => ct.DeliveryPoint.RestrictedForTrolleys).FirstOrDefault()?.DeliveryPointId ?? trolley.CurrentTurnaround.ChildTurnaround.First().DeliveryPointId);
                        var turnaroundDeliveryPoint = deliveryPointRepository.Get(turnaround.DeliveryPoint.DeliveryPointId);
          
                        dataContract.CustomerName = customer?.Text;
                        dataContract.Contents = new List<TrolleyDispatchContainerDataContract> { new TrolleyDispatchContainerDataContract { CustomerName = customer.Text, DeliveryPointName = trolley.DeliveryPoint.Text } };
                        dataContract.DeliveryPtName = turnaroundDeliveryPoint?.Text;
                        dataContract.Contents.First().DeliveryPointName = trolleyDeliveryPoint?.Text;

                        if (turnaround.DeliveryPoint.RestrictedForTrolleys && !turnaround.DisableTrolleyCustomerRestriction)
                            dataContract.ErrorCode = (int)ErrorCodes.RestrictedDeliveryPointForTurnarounds;                      
                        else
                            dataContract.ErrorCode = (int)ErrorCodes.RestrictedDeliveryPointForTrolleys;

                        dataContract.TurnaroundExternalId = scanDetails.TurnaroundExternalId ?? 0;
                        return dataContract;
                    }
                }

                if (scanDetails.RemoveFromPreviousTrolley && turnaround?.ParentTurnaround != null)
                {
                    var result = RemoveTurnaroundFromTrolley(new TrolleyDispatchScanTurnaroundScanDetails()
                    {
                        UserId = scanDetails.UserId,
                        FacilityId = scanDetails.FacilityId,
                        StationId = scanDetails.StationId ?? 0,
                        StationLocationId = scanDetails.StationLocationId,
                        TurnaroundExternalId = scanDetails.TurnaroundExternalId,
                        TrolleyExternalId = turnaround.ParentTurnaround.ContainerInstance.PrimaryId,
                        StationTypeId = scanDetails.StationTypeId,
                        IgnoreNotesWarningsAndDecon = scanDetails.IgnoreNotesWarningsAndDecon
                    });
                    dataContract.ErrorCode = result.ErrorCode;
                }
                else if (turnaround.ParentTurnaround?.ContainerMaster?.BaseItemType?.ItemTypeId == (int)ItemTypeIdentifier.Trolley
                         && turnaround.ParentTurnaround?.ContainerInstanceId != trolley.ContainerInstanceId)
                {
                    var cteRepository = new CurrentTurnaroundEventRepository(workUnit);
                    var lastProcessEvent = cteRepository.GetLastProcessEventByTurnaroundId(turnaround.TurnaroundId);
                    if (lastProcessEvent.EventTypeId == (int)TurnAroundEventTypeIdentifier.AddedToTrolley)
                    {
                        dataContract.ErrorCode = (int)ErrorCodes.TurnaroundAlreadyAssignedToTrolley;
                        dataContract.TurnaroundExternalId = scanDetails.TurnaroundExternalId ?? 0;
                        return dataContract;
                    }
                }

                _log.Info("ValidateTurnaroundCanBeProcessedOntoTrolley END");
                return dataContract;
            }
        }

        /// <summary>
        /// GetSuggestedTurnarounds operation
        /// </summary>
        public List<TrolleyDispatchContainerDataContract> GetSuggestedTurnarounds(int facilityId, int? customerId, int? deliveryPointId, bool isOutOfAutoclave)
        {
            if (customerId == null && deliveryPointId == null)
                return new List<TrolleyDispatchContainerDataContract>();

            List<int> nonSterileEventTypesToInclude = new List<int> { (int)TurnAroundEventTypeIdentifier.QualityAssurance, (int) TurnAroundEventTypeIdentifier.RemovedFromTrolley,(int)TurnAroundEventTypeIdentifier.RemovedFromDeliveryNote, (int) TurnAroundEventTypeIdentifier.RerouteToDispatch, (int) TurnAroundEventTypeIdentifier.PrintDecontaminationCertificate };
            List<int> sterileEventTypesToInclude = new List<int> { isOutOfAutoclave ? (int)TurnAroundEventTypeIdentifier.IntoAutoclave : (int)TurnAroundEventTypeIdentifier.OutofAutoclave, (int)TurnAroundEventTypeIdentifier.RemovedFromTrolley, (int)TurnAroundEventTypeIdentifier.RemovedFromDeliveryNote, (int)TurnAroundEventTypeIdentifier.RerouteToDispatch, (int)TurnAroundEventTypeIdentifier.PrintDecontaminationCertificate };
            return _trolleyDatabaseHelper.GetSuggestedTurnarounds(facilityId, nonSterileEventTypesToInclude, sterileEventTypesToInclude, customerId, deliveryPointId)
                .Select(x => ConvertSuggestedTurnaroundsDataModelToDataContractModel(x)).ToList();

        }

        /// <summary>
        /// GetSuggestedTurnarounds operation
        /// </summary>
        public List<TrolleyDispatchContainerDataContract> GetSuggestedTurnarounds(int facilityId, ContainerInstance trolley, bool isOutOfAutoclave)
        {
            int? trolleyCustomerRestriction = null;
            if (trolley?.CurrentTurnaround?.ChildTurnaround.Count > 0)
            {
                var trolleyFirstTray = trolley.CurrentTurnaround.ChildTurnaround.FirstOrDefault(x => !x.DisableTrolleyCustomerRestriction);
                if(trolleyFirstTray != null)
                {
                    trolleyCustomerRestriction = trolleyFirstTray.DeliveryPoint.CustomerDefinitionId;
                }
                if (trolley.CurrentTurnaround.ChildTurnaround.Any(ct => ct.DeliveryPoint.RestrictedForTrolleys))
                {
                    List<TrolleyDispatchContainerDataContract> results = new List<TrolleyDispatchContainerDataContract>();
                    foreach(var deliveryPointId in trolley.CurrentTurnaround.ChildTurnaround.Select(x=>x.DeliveryPointId).Distinct())
                    {
                        results.AddRange(GetSuggestedTurnarounds(facilityId, trolleyCustomerRestriction, deliveryPointId, isOutOfAutoclave));
                    }
                    return results;
                }      
            }
            return GetSuggestedTurnarounds(facilityId, trolleyCustomerRestriction, null, isOutOfAutoclave);
        }

        /// <summary>
        /// StartTrolley operation
        /// </summary>
        public TrolleyDispatchTrolleyDataContract StartTrolley(ContainerInstance trolley, TrolleyDispatchTrolleyDataContract dataContract, TrolleyDispatchScanTurnaroundScanDetails scanDetails, int facilityId, int deliveryPointId, ref int? trolleyTurnaroundId)
        {
            _synergyTrakHelper.SynergyTrakData.FacilityId = scanDetails.FacilityId;
            var lastEventTypeId = trolley?.CurrentTurnaround?.CurrentTurnaroundEvent?.EventTypeId ?? 0;
            ScanAssetDataContract scanDC = new ScanAssetDataContract
            {
                FacilityId = scanDetails.FacilityId,
                UserId = scanDetails.UserId,
                TurnaroundExternalId = trolley.CurrentTurnaround?.ExternalId ?? default(long),
                LastProcessEventTypeId = (TurnAroundEventTypeIdentifier?)lastEventTypeId,
                Asset = new AssetDetailsDataContract
                {
                    ItemTypeId = trolley.ActiveContainerMaster.ItemTypeId,
                    ContainerMasterId = trolley.ActiveContainerMaster.ContainerMasterId
                }
            };

            _synergyTrakHelper.SynergyTrakData.EventTypeId = TurnAroundEventTypeIdentifier.TrolleyStarted;
            _synergyTrakHelper.SynergyTrakData.StationId = scanDetails.StationId;
            _synergyTrakHelper.SynergyTrakData.StationTypeId = scanDetails.StationTypeId;
            _synergyTrakHelper.SynergyTrakData.UserId = scanDetails.UserId;

            {
                if (scanDetails.StartNewTrolleyTurnaround == true || !_synergyTrakHelper.ValidateWorkFlowStep(scanDC, (int)TurnAroundEventTypeIdentifier.TrolleyStarted))
                {
                    bool canStartNewTurnaround = false;
                    if (trolley.CurrentTurnaround == null)
                        canStartNewTurnaround = true;
                    else //may have to check the last process event (as shown above)
                        canStartNewTurnaround = trolley.CurrentTurnaround.CurrentTurnaroundEvent.TurnaroundEvent.Workflow.IsEnd;
                    if (canStartNewTurnaround)
                    {
                        scanDetails.ApplyEvent = true;

                        scanDC.LastProcessEventTypeId = (TurnAroundEventTypeIdentifier?)lastEventTypeId;
                        _synergyTrakHelper.CreateNewTurnaround(scanDC, scanDetails, trolley);
                        if (scanDC.ErrorCode != null)
                        {
                            dataContract.ErrorCode = scanDC.ErrorCode;
                        }
                        if (scanDC.TurnaroundId != null)
                            dataContract.TurnaroundId = scanDC.TurnaroundId;
                    }
                    else
                    {
                        dataContract.ErrorCode = (int)ErrorCodes.InvalidNextEvent;
                    }
                }

                else
                {
                    scanDC.TurnaroundId = trolley.CurrentTurnaround?.TurnaroundId;
                    scanDC.DeliveryPtId = deliveryPointId;
                    scanDC.TurnaroundEvents = new List<DataContracts.TurnaroundEventDataContract>();
                    dataContract.TurnaroundId = trolley.CurrentTurnaround?.TurnaroundId;
                    using (var applyEvent = InstanceFactory.GetInstance<IApplyEvent>())
                    {
                        applyEvent.Setup(_synergyTrakHelper.SynergyTrakData);
                        applyEvent.ApplyEvents(new List<TurnaroundProcessing.Models.ApplyTurnaroundEventDetails> { new TurnaroundProcessing.Models.ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.TrolleyStarted } },
                        new List<ScanAssetDataContract> { scanDC }, scanDetails, true);
                    }
                    if (scanDC.ErrorCode.HasValue)
                        dataContract.ErrorCode = scanDC.ErrorCode;
                }
            }

            if (dataContract.ErrorCode.HasValue)
            {
                dataContract.LocationId = scanDetails.StationLocationId;
                dataContract.TurnaroundExternalId = trolley.CurrentTurnaround?.ExternalId ?? default(long);
                dataContract.LastProcessEventTypeId = (TurnAroundEventTypeIdentifier?)lastEventTypeId;
                dataContract.EventTypeId = TurnAroundEventTypeIdentifier.TrolleyStarted;
                dataContract.TurnaroundId = trolley.CurrentTurnaround?.TurnaroundId;
                dataContract.Asset = new AssetDetailsDataContract
                {
                    ContainerInstancePrimaryId = scanDetails.ExternalId
                };
                TurnaroundProcessing.DeniedTurnaroundEvent.Log(dataContract);
                return dataContract;
            }
            trolleyTurnaroundId = dataContract.TurnaroundId;
            return dataContract;
        }

        /// <summary>
        /// AddTurnaroundToTrolley operation
        /// </summary>
        public TrolleyDispatchTrolleyDataContract AddTurnaroundToTrolley(ContainerInstance trolley, TrolleyDispatchScanTurnaroundScanDetails scanDetails, int facilityId, int deliveryPointId, bool isOutOfAutoclave, Turnaround turnaround)
        {
            _log.Info("Add Turnaround to Trolley START");
            var ignoreNotes = scanDetails.IgnoreNotesWarningsAndDecon;
            var dataContract = CreateReturnDataContract(scanDetails);

            var trayTurnaroundExternalId = scanDetails.TurnaroundExternalId;

            if (dataContract.ErrorCode != null)
                return dataContract;

            int? trolleyTurnaroundId = null;

            var trolleyLastEventTypeId = trolley.CurrentTurnaround?.CurrentTurnaroundEvent?.EventTypeId ?? 0;

            if (trolleyLastEventTypeId == (short)TurnAroundEventTypeIdentifier.TrolleyDispatched && scanDetails.StartNewTrolleyTurnaround == null)
            {
                dataContract.ErrorCode = (int)ErrorCodes.UserConfirmationRequiredStartNewTrolleyTurnaround;
                return dataContract;
            }

            if (trolleyLastEventTypeId != (int)TurnAroundEventTypeIdentifier.TrolleyStarted)
            {
                scanDetails.ApplyEvent = false;
                scanDetails.ParentTurnaroundId = trolley.CurrentTurnaround?.TurnaroundId;
                scanDetails.Events = new List<ScanEventDataContract>();
                if (isOutOfAutoclave)
                {
                    scanDetails.Events.Add(new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.OutofAutoclave });
                }                    
                else
                {
                    scanDetails.Events.Add(new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.AddedToTrolley });
                }
                                    
                _synergyTrakHelper.Scan(scanDetails, dataContract);
                if (dataContract.ErrorCode.HasValue)
                {
                    return dataContract;
                }
                if ((dataContract.ContainerMasterNotes?.Any() == true || dataContract.TransientNotes?.Any() == true || dataContract.TurnaroundNotes?.Any() == true) && !ignoreNotes)
                {
                    return dataContract;
                }
                dataContract = StartTrolley(trolley, dataContract, scanDetails, facilityId, deliveryPointId, ref trolleyTurnaroundId);
                if (dataContract.ErrorCode != null)
                    return dataContract;             
            }
            if (!trolleyTurnaroundId.HasValue)
            {
                trolleyTurnaroundId = trolley?.CurrentTurnaround?.TurnaroundId;
            }

            if (trolleyTurnaroundId.HasValue)
            {
                scanDetails.ApplyEvent = true;
                scanDetails.ParentTurnaroundId = trolleyTurnaroundId;
                scanDetails.ExternalId = null;
                scanDetails.IgnoreNotesWarningsAndDecon = ignoreNotes;
                scanDetails.TurnaroundExternalId = trayTurnaroundExternalId;
                scanDetails.Events = new List<ScanEventDataContract>();
                var reports = dataContract.Reports;
                _synergyTrakHelper.SynergyTrakData.StationLocationId = scanDetails.StationLocationId;
                if (isOutOfAutoclave)
                {                          
                    dataContract = _ooaTrolleyDispatchHelper.PassItemOutOfAutoclave(dataContract, scanDetails, turnaround, _synergyTrakHelper);
                    reports = dataContract.Reports;
                    if (dataContract.ErrorCode.HasValue)
                    {
                        return dataContract;
                    }
                }

                scanDetails.Events = new List<ScanEventDataContract>();                                       
                scanDetails.Events.Add(new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.AddedToTrolley });
                _synergyTrakHelper.Scan(scanDetails, dataContract);
                dataContract.Reports = reports;
                if (dataContract.ErrorCode.HasValue)
                {
                    return dataContract;
                }

            }

            _log.Info("Add Turnaround to Trolley END");
            return dataContract;
        }

        /// <summary>
        /// RemoveTurnaroundFromTrolley operation
        /// </summary>
        public TrolleyDispatchTrolleyDataContract RemoveTurnaroundFromTrolley(TrolleyDispatchScanTurnaroundScanDetails scanDetails)
        {
            var dataContract = CreateReturnDataContract(scanDetails);

            var trolleyExternalId = scanDetails.TrolleyExternalId;
            var trayTurnaroundExternalId = scanDetails.TurnaroundExternalId;
            var trolleys = GetTrolleySummary(trolleyExternalId, scanDetails.FacilityId);
            if(trolleys.Count() > 1)
            {
                dataContract.ErrorCode = (int)ErrorCodes.DuplicateExternalId;
                return dataContract;
            }
            var trolley = trolleys.FirstOrDefault();
            if (trolley == null)
            {
                dataContract.ErrorCode = (int)ErrorCodes.NotATrolley;
                return dataContract;
            }
            var trolleyContents = _trolleyDatabaseHelper.GetTrolleyContents(trolley.TrolleyInstanceId);
            var tray = trolleyContents?.FirstOrDefault(tc => tc.TurnaroundExternalId == trayTurnaroundExternalId);
            if (trolleyContents == null || tray == null)
            {
                dataContract.ErrorCode = (int)ErrorCodes.TurnaroundNotOnTrolley;
                Scanning.FailedScan.Add(trayTurnaroundExternalId.ToString(), (short)Enums.ScanType.Turnaround, scanDetails.UserId, scanDetails.StationId ?? 0, scanDetails.StationLocationId, (short)TurnAroundEventTypeIdentifier.RemovedFromTrolley, DateTime.UtcNow);
                return dataContract;
            }
            if (trolleyContents.Any(x => x.DisableTrolleyCustomerRestriction)
                && trolleyContents.Where(x => !x.DisableTrolleyCustomerRestriction).Count() == 1
                && !tray.DisableTrolleyCustomerRestriction)
            {
                dataContract.ErrorCode = (int)ErrorCodes.TrolleyDispatchUnrestrictedItemLeft;
                Scanning.FailedScan.Add(trayTurnaroundExternalId.ToString(), (short)Enums.ScanType.Turnaround, scanDetails.UserId, scanDetails.StationId ?? 0, scanDetails.StationLocationId, (short)TurnAroundEventTypeIdentifier.RemovedFromTrolley, DateTime.UtcNow);
                return dataContract;
            }
            scanDetails.ExternalId = null;
            scanDetails.TurnaroundExternalId = trayTurnaroundExternalId;
            scanDetails.Events = new List<ScanEventDataContract>
            {
                new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.RemovedFromTrolley }
            };
            _synergyTrakHelper.Scan(scanDetails, dataContract);

            if (dataContract.ErrorCode.HasValue)
            {
                return dataContract;
            }
            if (trolleyContents.Count <= 1)
            {
                _synergyTrakHelper.SynergyTrakData?.ScanDcList?.Clear();

                scanDetails.TurnaroundExternalId = null;
                scanDetails.ExternalId = trolleyExternalId;
                scanDetails.Events = new List<ScanEventDataContract>
                {
                    new ScanEventDataContract { EventType = (int)TurnAroundEventTypeIdentifier.TrolleyStopped }
                };
                _synergyTrakHelper.Scan(scanDetails, dataContract);
                if (dataContract.ErrorCode.HasValue)
                {
                    return dataContract;
                }
            }

            scanDetails.ExternalId = trolleyExternalId;
            scanDetails.TurnaroundExternalId = null;
            return dataContract;
        }

        private TrolleyDispatchTrolleyDataContract CreateReturnDataContract(ScanDetails scanDetails)
        {
            return new TrolleyDispatchTrolleyDataContract
            {
                UserId = scanDetails.UserId,
                StationId = scanDetails.StationId ?? 0,
                LocationId = scanDetails.StationLocationId,
                ScannedString = scanDetails.TurnaroundExternalId.ToString()
            };
        }

      

        private TrolleyDispatchContainerDataContract ConvertSuggestedTurnaroundsDataModelToDataContractModel(TrolleyDispatch_GetSuggestedTurnarounds_Result turnaround)
        {
            return new TrolleyDispatchContainerDataContract
            {
                DeliveryPointId = turnaround.DeliveryPointId,
                DeliveryPointName = turnaround.DeliveryPointName,
                Name = turnaround.ContainerMasterName,
                TurnaroundExternalId = turnaround.TurnaroundExternalId,
                ServiceRequirement = turnaround.ServiceRequirementName,
                IsFastTrack = turnaround.IsFastTrack ?? false,
                ExpiryDate = turnaround.Expiry,
                IsExtra = turnaround.IsExtra,
                IsTray = turnaround.IsTray,
                IsSupplementary = turnaround.IsSupplementary,
                BatchExternalId = turnaround.BatchExternalID,
                BatchPassedDateTime = !turnaround.BatchPassedDateTime.HasValue ? (DateTime?)null : DateTime.SpecifyKind(turnaround.BatchPassedDateTime.Value, DateTimeKind.Utc)
            };
        }

        /// <summary>
        /// Dispose operation
        /// </summary>
        public void Dispose()
        {
            _trolleyDatabaseHelper.Dispose();
        }
    }
}
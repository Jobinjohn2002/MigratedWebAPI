using SynergyApplicationFrameworkApi.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    /// <summary>
    /// WashEvents
    /// </summary>
    public class WashEvents : BasicTurnaroundEvents
    {
        public WashEvents(SynergyTrakData data) : base(data)
        {
        }

        /// <summary>
        /// Process scanning at WashRelease
        /// </summary>
        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.WashRelease)]
        /// <summary>
        /// WashRelease operation
        /// </summary>
        public void WashRelease(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            using (UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var children = new List<ScanAssetDataContract>();
                var notChildren = new List<ScanAssetDataContract>();
                var auditFailed = new List<ScanAssetDataContract>();
                scanDC.QuarantinedItems = new List<AutomaticQuarantinedItem>();

                var deconAuditImmediateQuarantineEnabled = FacilitySettings.GetDeconAuditImmediateQuarantine((short)scanDC.FacilityId);

                foreach (var item in _data.ScanDcList)
                {
                    if (item.ParentTurnaroundId == scanDC.TurnaroundId)
                    {
                        children.Add(item);
                        if (_data.EventTypeId != TurnAroundEventTypeIdentifier.PartWash)
                        {
                            var quarantinedItem = CheckDefectsForAutomaticQuarantine(item, scanDetails);
                            if (quarantinedItem != null)
                            {
                                scanDC.QuarantinedItems.Add(quarantinedItem);
                            }
                        }
                    }
                    else
                    {
                        notChildren.Add(item);
                    }

                    if (!deconAuditImmediateQuarantineEnabled && Auditing.HasFailedDeconAudit(item))
                    {
                        auditFailed.Add(item);
                    }
                }
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, RemoveFromParent = true, BatchId = scanDC.BatchId }, children, scanDetails);
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, BatchId = scanDC.BatchId }, notChildren, scanDetails);

                if (!deconAuditImmediateQuarantineEnabled && auditFailed.Any())
                {
                    var ate = new Auditing(_data);
                    ate.AuditQuarantine(auditFailed, scanDetails, _data.EventTypeId);
                }

                CheckItemAndChildrenForAutomaticQuarantine(scanDC, scanDetails, notChildren);
                foreach (var child in children)
                {
                    if (child.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag)
                    {
                        foreach (var grandchild in child.ChildItems)
                        {
                            GetChildNotificationsAndReports(scanDC, grandchild);
                        }
                    }
                    else
                    {
                        GetChildNotificationsAndReports(scanDC, child);
                    }
                }
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.WashIn)]
        /// <summary>
        /// WashIn operation
        /// </summary>
        public void WashIn(ScanAssetDataContract scanDC, ScanDetailsBatchRequestDataContract scanDetails)
        {
            CreateBatchRequestDataContract request = new CreateBatchRequestDataContract()
            {
                UserId = scanDetails.UserId,
                NTLogon = scanDetails.NTLogon,
                StationId = scanDetails.StationId,
                FacilityId = scanDetails.FacilityId,
                PrimaryFacilityId = scanDetails.PrimaryFacilityId,
                BatchName = scanDetails.BatchName,
                MachineId = scanDetails.MachineId.GetValueOrDefault(),
            };

            BatchHelper batchHelper = new BatchHelper();
            var batchCreatedDc = batchHelper.Create(request, (scanDetails.MachineTypeId == (int)MachineTypeIdentifier.Washer || scanDetails.MachineTypeId == (int)MachineTypeIdentifier.Post1997Washer));

            if (batchCreatedDc != null)
            {
                if (batchCreatedDc.ErrorCode == null)
                {
                    scanDetails.BatchId = batchCreatedDc.BatchId;
                    scanDC.BatchId = batchCreatedDc.BatchId;
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, BatchId = scanDetails.BatchId }, scanDetails);
                    batchHelper.SetBatchInProgress(batchCreatedDc.BatchId);
                }
                else
                {
                    scanDC.ErrorCode = batchCreatedDc.ErrorCode;
                }
            }
            else
            {
                scanDC.ErrorCode = (int)ErrorCodes.CreateBatchError;
            }

            if (scanDC.Defects.Count > 0 && !scanDetails.FulfillsDeconTask)
            {
                var quarantine = new Quarantine(_data);
                quarantine.PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ServiceReportRaised);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.Wash)]
        /// <summary>
        /// Wash operation
        /// </summary>
        public void Wash(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDetails is ScanDetailsBatchRequestDataContract)
            {
                WashIn(scanDC, scanDetails as ScanDetailsBatchRequestDataContract);
            }
            else
            {
                WashIt(scanDC, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.PartWash)]
        /// <summary>
        /// PartWash operation
        /// </summary>
        public void PartWash(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDetails is ScanDetailsBatchRequestDataContract)
            {
                WashIn(scanDC, scanDetails as ScanDetailsBatchRequestDataContract);
            }
            else
            {
                WashIt(scanDC, scanDetails);
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FailedWash)]
        /// <summary>
        /// FailedWash operation
        /// </summary>
        public void FailedWash(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDetails.ApplyToBatch && scanDC.BatchId.HasValue)
            {
                scanDetails.ApplyToBatch = false;
                scanDetails.BatchId = scanDC.BatchId;
                var result = BatchScan(scanDetails);
                scanDC.ErrorCode = result.ErrorCode;
                scanDC.RequiresKeepBatchTogetherConfirmation = result.RequiresKeepBatchTogetherConfirmation;
                scanDC.ChildBatchTagCount = result.ChildBatchTagCount;
            }
            else
            {
                if (_data.IsRemoveFromParent || scanDC.IsRemoveFromParent)
                {
                    ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemoveFromBatchTag, true), scanDetails);
                }
                ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.FailedWash, true), scanDC, scanDetails);
                var allDescendents = _data.ScanDcList.Where(s => s != scanDC).ToList();

                if (scanDC.IsBatchScan && scanDC.ChildItems != null && scanDC.ChildItems.Any())
                {
                    allDescendents = scanDC.ChildItems;
                }

                if (allDescendents != null && allDescendents.Any())
                {
                    if (scanDetails.IsKeepFailedBatchTogether != null && ((scanDC.Asset != null) && (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag) && !scanDetails.IsKeepFailedBatchTogether.Value))
                    {
                        ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.RemoveFromBatchTag, true), allDescendents, scanDetails);
                    }

                    ApplyEvent(ApplyTurnaroundEventDetails.Create(TurnAroundEventTypeIdentifier.FailedWash), allDescendents, scanDetails);
                }
            }
        }

        private void WashIt(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if ((scanDC.IsDeconEndRequired || (scanDC.Asset.DecontaminationTasks != null && scanDC.Asset.DecontaminationTasks.Count > 0)) &&
                (_data.EventTypeId == TurnAroundEventTypeIdentifier.PartWash) && (scanDetails.MachineId != null))
            {
                if (scanDetails.BatchId == null)
                {
                    var batch = new CreateBatchRequestDataContract
                    {
                        MachineId = scanDetails.MachineId.Value,
                        IsStartBatch = true,
                        UserId = _data.UserId
                    };

                    BatchHelper batchHelper = new BatchHelper();
                    var batchDc = batchHelper.Create(batch);

                    if (batchDc != null)
                    {
                        scanDC.BatchId = batchDc.BatchId;
                        if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag)
                        {
                            _data.ScanDcList.ForEach(dc => dc.BatchId = batchDc.BatchId);
                        }
                    }
                }
                if (scanDC.TurnaroundId != null && (scanDetails.BatchId != null || scanDC.BatchId != null) && scanDetails.FulfillsDeconTask)
                {
                    var bh = new BatchHelper();

                    if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag && scanDC.HasChildren && scanDC.ChildItems.All(c => c.TurnaroundId.HasValue))
                    {
                        foreach (var child in scanDC.ChildItems)
                        {
                            var batchId = scanDetails.BatchId.HasValue ? scanDetails.BatchId : scanDC.BatchId;
                            bh.UpdateBatchDecontaminationTasks(batchId.Value, child.TurnaroundId.Value, scanDetails.MachineId.Value, _data.UserId);
                        }
                    }
                    else if (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BatchTag && scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.BaseCarriage)
                    {
                        var batchId = scanDetails.BatchId.HasValue ? scanDetails.BatchId : scanDC.BatchId;
                        bh.UpdateBatchDecontaminationTasks(batchId.Value, scanDC.TurnaroundId.Value, scanDetails.MachineId.Value, _data.UserId);
                    }
                }
            }
            if (scanDC.IsDeconEndRequired && _data.EventTypeId == TurnAroundEventTypeIdentifier.Wash)
            {
                if (scanDC.LastProcessEventTypeId != TurnAroundEventTypeIdentifier.DeconEnd)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.DeconEnd, CanSetTurnaroundExpiryTime = false }, scanDC, scanDetails);
                }

                scanDC.IsDeconEndRequired = false;
            }
            if (_data.IsRemoveFromParent && _data.EventTypeId == TurnAroundEventTypeIdentifier.Wash && scanDC.IsParentABatchTag)
            {
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemoveFromBatchTag, RemoveFromParent = true }, scanDC, scanDetails);
            }

            if (_data.IsRemoveFromParent && _data.EventTypeId == TurnAroundEventTypeIdentifier.Wash && scanDC.IsParentACarriage)
            {
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.RemovedFromCarriage, RemoveFromParent = true }, scanDC, scanDetails);
            }
            CheckAutomaticCollection(scanDC, scanDetails);

            var children = new List<ScanAssetDataContract>();
            var notChildren = new List<ScanAssetDataContract>();

            if ((scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BaseCarriage) || (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Carriage))
            {
                foreach (var item in _data.ScanDcList)
                {
                    if (item.ParentTurnaroundId == scanDC.TurnaroundId)
                    {
                        children.Add(item);
                        if (_data.EventTypeId != TurnAroundEventTypeIdentifier.PartWash)
                        {
                            var quarantinedItem = CheckDefectsForAutomaticQuarantine(item, scanDetails);
                            if (quarantinedItem != null)
                            {
                                scanDC.QuarantinedItems.Add(quarantinedItem);
                            }
                        }
                    }
                    else
                    {
                        notChildren.Add(item);
                    }
                }
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, RemoveFromParent = true, BatchId = scanDC.BatchId }, children, scanDetails);
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, BatchId = scanDC.BatchId }, notChildren, scanDetails);
            }
            else if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag)
            {
                children = _data.ScanDcList.Where(s => s.TurnaroundId != scanDC.TurnaroundId).ToList();

                foreach (var item in children)
                {
                    if (_data.EventTypeId != TurnAroundEventTypeIdentifier.PartWash)
                    {
                        var quarantinedItem = CheckDefectsForAutomaticQuarantine(item, scanDetails);
                        if (quarantinedItem != null)
                        {
                            scanDC.QuarantinedItems.Add(quarantinedItem);
                        }
                    }
                }
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, RemoveFromParent = true, BatchId = scanDC.BatchId }, scanDC, scanDetails);
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = _data.EventTypeId, BatchId = scanDC.BatchId, ParentTurnaroundId = scanDC.TurnaroundId }, children, scanDetails);
            }
            else
            {
                var list = new List<ApplyTurnaroundEventDetails>
                {
                    new ApplyTurnaroundEventDetails
                    {
                        LocationId = scanDetails.StationLocationId,
                        RetrospectiveProcessStationTypeId = scanDetails.RetrospectiveProcessStationTypeId,
                        EventType = _data.EventTypeId,
                        RemoveFromParent = true,
                        BatchId = scanDC.BatchId
                    }
                };
                ApplyEvent(list, scanDetails);

                if (_data.EventTypeId != TurnAroundEventTypeIdentifier.PartWash)
                {
                    var quarantinedItem = CheckDefectsForAutomaticQuarantine(scanDC, scanDetails);

                    if (quarantinedItem != null)
                    {
                        scanDC.QuarantinedItems.Add(quarantinedItem);
                    }
                }
            }

            if (scanDC.Defects.Count > 0 && !scanDetails.FulfillsDeconTask)
            {
                var quarantine = new Quarantine(_data);
                quarantine.PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ServiceReportRaised);
            }

            CheckItemAndChildrenForAutomaticQuarantine(scanDC, scanDetails, notChildren);

            if (_data.EventTypeId != TurnAroundEventTypeIdentifier.PartWash && !FacilitySettings.GetDeconAuditImmediateQuarantine((short)scanDC.FacilityId))
            {
                var auditFailed = new List<ScanAssetDataContract>();

                foreach (var item in _data.ScanDcList)
                {
                    if (Auditing.HasFailedDeconAudit(item))
                    {
                        auditFailed.Add(item);
                    }
                }

                if (auditFailed.Any())
                {
                    var ate = new Auditing(_data);
                    ate.AuditQuarantine(auditFailed, scanDetails, _data.EventTypeId);
                    if (auditFailed.Count != 1 && !auditFailed.First().Equals(scanDC))
                    {
                        var neh = new NotificationEngineHelper();
                        neh.GetReportsAndNotification(auditFailed, scanDC);
                    }
                }
            }
        }

        private void CheckItemAndChildrenForAutomaticQuarantine(ScanAssetDataContract rootDC, ScanDetails scanDetails, List<ScanAssetDataContract> itemsToExclude = null)
        {
            if (rootDC.QuarantinedItems == null)
            {
                rootDC.QuarantinedItems = new List<AutomaticQuarantinedItem>();
            }

            if (_data.EventTypeId == TurnAroundEventTypeIdentifier.PartWash)
            {
                return;
            }

            if ((rootDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BaseCarriage) || (rootDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Carriage))
            {
                var itemsToCheck = itemsToExclude != null ? _data.ScanDcList.Except(itemsToExclude) : _data.ScanDcList;

                foreach (var item in itemsToCheck)
                {
                    if (item.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag)
                    {
                        foreach (var child in item.ChildItems)
                        {
                            CheckDefectsForAutomaticQuarantine(rootDC, child, scanDetails);
                        }
                    }
                    else
                    {
                        CheckDefectsForAutomaticQuarantine(rootDC, item, scanDetails);
                    }
                }
            }
            else if (rootDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.BatchTag)
            {
                foreach (var child in rootDC.ChildItems)
                {
                    CheckDefectsForAutomaticQuarantine(rootDC, child, scanDetails);
                }
            }
            else
            {
                CheckDefectsForAutomaticQuarantine(rootDC, rootDC, scanDetails);
            }
        }

        private void CheckDefectsForAutomaticQuarantine(ScanAssetDataContract rootDC, ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var quarantinedItem = new AutomaticQuarantinedItem()
            {
                ContainerMasterName = scanDC.Asset.ContainerMasterName,
                PrimaryId = scanDC.Asset.ContainerInstancePrimaryId,
                Defects = new List<DefectDataContract>(),
                CustomerDefects = new List<CustomerDefectDataContract>()
            };

            var previousQuarantineReason = _data.QuarantineReasonId;

            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var customerDefectRepository = CustomerDefectRepository.New(workUnit);
                var defectRepository = DefectRepository.New(workUnit);

                var customerDefects = customerDefectRepository.ReadOpenCustomerDefectsWithAutomaticQuarantineByTurnaroundId(scanDC.TurnaroundId.Value);
                var defects = defectRepository.ReadOpenDefectsWithAutomaticQuarantineByTurnaroundId(scanDC.TurnaroundId.Value);

                if (!customerDefects.Any() && !defects.Any())
                {
                    return;
                }

                if (customerDefects.Any())
                {
                    var quarantine = new Quarantine(_data);
                    quarantine.PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.CSRRaised);

                    quarantinedItem.CustomerDefects.AddRange(customerDefects.ToList().Select(cd => CreateCustomerDefectDataContract(cd)));
                }

                if (defects.Any())
                {
                    var quarantine = new Quarantine(_data);
                    quarantine.PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ServiceReportRaised);

                    quarantinedItem.Defects.AddRange(defects.ToList().Select(d => CreateDefectDataContract(d)));
                }

                customerDefects.ForEach(cd => cd.QuarantineAfterWash = false);
                defects.ForEach(d => d.QuarantineAfterWash = false);

                customerDefectRepository.Save();
                defectRepository.Save();
            }

            rootDC.QuarantinedItems.Add(quarantinedItem);

            _data.QuarantineReasonId = previousQuarantineReason;
        }

        private CustomerDefectDataContract CreateCustomerDefectDataContract(CustomerDefect customerDefect)
        {
            var customerDefectDC = new CustomerDefectDataContract
            {
                ExternalId = customerDefect.ExternalId,
                DefectReasons = new List<CustomerDefectReasonDataContract>()
            };

            foreach (var reason in customerDefect.CustomerDefectReasons)
            {
                var reasonDC = new CustomerDefectReasonDataContract
                {
                    Text = reason.Text,
                    CustomerDefectReasonId = reason.CustomerDefectReasonId,
                    CausesIntoQuarantine = reason.CausesIntoQuarantine,
                    DisplayOrder = reason.DisplayOrder
                };

                customerDefectDC.DefectReasons.Add(reasonDC);
            }

            return customerDefectDC;
        }

        private DefectDataContract CreateDefectDataContract(Defect defect)
        {
            var defectDC = new DefectDataContract
            {
                ExternalId = defect.ExternalId,
                DefectClassificationId = defect.DefectClassificationId
            };

            return defectDC;
        }

        private AutomaticQuarantinedItem CheckDefectsForAutomaticQuarantine(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            var quarantinedItem = new AutomaticQuarantinedItem()
            {
                ContainerMasterName = scanDC.Asset.ContainerMasterName,
                PrimaryId = scanDC.Asset.ContainerInstancePrimaryId,
                Defects = new List<DefectDataContract>(),
                CustomerDefects = new List<CustomerDefectDataContract>()
            };

            {
                var customerDefectRepository = CustomerDefectRepository.New(workUnit);
                var defectRepository = DefectRepository.New(workUnit);

                var customerDefects = customerDefectRepository.ReadOpenCustomerDefectsWithAutomaticQuarantineByTurnaroundId(scanDC.TurnaroundId.Value);
                var defects = defectRepository.ReadOpenDefectsWithAutomaticQuarantineByTurnaroundId(scanDC.TurnaroundId.Value);

                if (!customerDefects.Any() && !defects.Any())
                {
                    return null;
                }

                if (customerDefects.Any())
                {
                    var quarantine = new Quarantine(_data);
                    quarantine.PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.CSRRaised);

                    quarantinedItem.CustomerDefects.AddRange(customerDefects.ToList().Select(cd => CreateCustomerDefectDataContract(cd)));
                }

                if (defects.Any())
                {
                    var quarantine = new Quarantine(_data);
                    quarantine.PutIntoQuarantine(scanDC, scanDetails, (short)QuarantineReasonIdentifier.ServiceReportRaised);

                    quarantinedItem.Defects.AddRange(defects.ToList().Select(d => CreateDefectDataContract(d)));
                }

                customerDefects.ForEach(cd => cd.QuarantineAfterWash = false);
                defects.ForEach(d => d.QuarantineAfterWash = false);

                customerDefectRepository.Save();
                defectRepository.Save();
            }

            return quarantinedItem;
        }

        private ScanAssetDataContract BatchScan(ScanDetails scanDetails)
        {
            var dataContract = new ScanAssetDataContract();
            var start = DateTime.UtcNow;

            if (scanDetails != null)
            {
                if (scanDetails.Events.First().EventType == (int)TurnAroundEventTypeIdentifier.FailedWash)
                {
                    _data.Instance.BatchScanEx(scanDetails, dataContract);
                }
                else
                {
                    _data.Instance.BatchScan(scanDetails, dataContract);
                }
            }

            dataContract.OperationDurationMs = (long)(DateTime.UtcNow - start).TotalMilliseconds;

            return dataContract;
        }

        private void GetChildNotificationsAndReports(ScanAssetDataContract rootDC, ScanAssetDataContract scanDC)
        {
            if (rootDC.NotificationTypesFired == null)
            {
                rootDC.NotificationTypesFired = scanDC.NotificationTypesFired;
            }
            else
            {
                rootDC.NotificationTypesFired.AddRange(scanDC.NotificationTypesFired);
            }

            if (rootDC.Reports == null)
            {
                rootDC.Reports = scanDC.Reports;
            }
            else
            {
                rootDC.Reports.AddRange(scanDC.Reports);
            }
        }
    }
}
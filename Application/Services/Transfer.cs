using SynergyApplicationFrameworkApi.Application.DTOs.Transfer;
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
    /// Transfer
    /// </summary>
    public class Transfer : BasicTurnaroundEvents
    {
        public Transfer(SynergyTrakData data) : base(data)
        {

        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.AddedToTransferNote)]
        /// <summary>
        /// AddToTransferNote operation
        /// </summary>
        public void AddToTransferNote(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            Log.Info("AddToTN: START");
            if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley && scanDetails.DestinationFacilityId.HasValue && scanDetails.RouteToEventTypeId.HasValue && scanDetails.TransferNoteId == null)
            {
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AddedToTransferNote, ParentTurnaroundId = scanDetails.ParentTurnaroundId }, scanDC, scanDetails);

                if ((scanDC.ChildItems != null) && (scanDC.ChildItems.Count > 0))
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AddedToTransferNote }, _data.ScanDcList.Where(s => s.ParentTurnaroundId == scanDC.TurnaroundId).ToList(), scanDetails);
                }

                Log.Info("AddToTN: Events Applied");
                Log.Info("AddToTN: Create new TN");
                using (var repository = new PathwayRepository())
                {
                    using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
                    {
                        var fromOwnerId = repository.Container.Facility.First(f => f.FacilityId == scanDetails.FacilityId).OwnerId;
                        var toOwnerId = repository.Container.Facility.First(f => f.FacilityId == scanDetails.DestinationFacilityId).OwnerId;

                        var transferNote = TransferNoteFactory.CreateEntity(workUnit,
                                fromOwnerId: fromOwnerId,
                                toOwnerId: toOwnerId,
                                routeToEventTypeId: scanDetails.RouteToEventTypeId.Value,
                                transportTurnaroundId: scanDC.TurnaroundId.GetValueOrDefault(),
                                dispatchTransferNoteEventId: null
                            );

                        repository.Container.TransferNote.AddObject(transferNote);
                        repository.Container.SaveChanges();

                        scanDC.TransferNote = GetTransferNote(new TransferNoteRequestDataContract { TransferNoteId = transferNote.TransferNoteId });
                    }
                }
            }
            else if (scanDetails.TransferNoteId.HasValue && scanDC.TurnaroundId.HasValue)
            {
                Log.Info("AddToTN: Create TransferNoteLine START");
                ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AddedToTransferNote, ParentTurnaroundId = scanDetails.ParentTurnaroundId }, scanDC, scanDetails);

                if ((scanDC.ChildItems != null) && (scanDC.ChildItems.Count > 0))
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.AddedToTransferNote }, _data.ScanDcList.Where(s => s.ParentTurnaroundId == scanDC.TurnaroundId).ToList(), scanDetails);
                }

                {
                    {
                        if (_data.ScanDcList != null)
                        {
                            Log.Info($"AddToTN: TransferNoteLines to create: {_data.ScanDcList.Count}");
                        }

                        foreach (var dc in _data.ScanDcList)
                        {
                            var transferNoteLine = TransferNoteLineFactory.CreateEntity(workUnit,
                                    transferNoteId: scanDetails.TransferNoteId.Value,
                                    turnaroundId: dc.TurnaroundId.GetValueOrDefault(),
                                    beforeTransferProcessEventId: dc.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).First(te => te.IsProcessEvent && te.EventTypeId != (int)TurnAroundEventTypeIdentifier.AddedToTransferNote && te.EventTypeId != (int)TurnAroundEventTypeIdentifier.RemoveFromBatchTag).TurnaroundEventId,
                                    addToTransferNoteEventId: dc.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).First(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.AddedToTransferNote).TurnaroundEventId,
                                    dispatchTransferNoteEventId: null,
                                    removedFromTransferNoteEventId: null
                                );

                            repository.Container.TransferNoteLine.AddObject(transferNoteLine);
                        }
                        repository.Container.SaveChanges();

                        Log.Info("AddToTN: Finished Creating TransferNoteLines");

                        var transferNoteRequest = new TransferNoteRequestDataContract { TransferNoteId = scanDetails.TransferNoteId.Value };
                        scanDC.TransferNote = GetTransferNote(transferNoteRequest);

                        Log.Info("AddToTN: Create Turnaround Assigned");
                        if (scanDC.TurnaroundId.HasValue && scanDetails.ParentTurnaroundId.HasValue)
                        {
                            var turnaroundAr = TurnaroundAssignedRepository.New(workUnit);
                            var taAlreadyExists = turnaroundAr.Repository.Find(ta => (ta.TurnaroundParentId == scanDetails.ParentTurnaroundId.Value) &&
                                                                                        (ta.TurnaroundChildId == scanDC.TurnaroundId.Value)).FirstOrDefault();
                            if (taAlreadyExists == null)
                            {
                                turnaroundAr.Add(TurnaroundAssignedFactory.CreateEntity(workUnit,
                                    turnaroundParentId: scanDetails.ParentTurnaroundId.GetValueOrDefault(),
                                    turnaroundChildId: scanDC.TurnaroundId.Value
                                ));
                                turnaroundAr.Save();
                            }
                        }
                    }
                }
            }
            else
            {
                scanDC.ErrorCode = (int)ErrorCodes.Unknown;

                var tnHasValue = scanDetails.TransferNoteId.HasValue;
                var turnaroundHasValue = scanDC.TurnaroundId.HasValue;

                Log.Info($"AddToTN: No TransferNoteLine Created, TransferNote has value: {tnHasValue}, Turnaround Has Value: {turnaroundHasValue}");
            }

            Log.Info("AddToTN: END");
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FacilityTransferOutbound)]
        /// <summary>
        /// DispatchTransferNote operation
        /// </summary>
        public void DispatchTransferNote(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            if (scanDetails.RouteToEventTypeId.HasValue)
            {
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.FacilityTransferOutbound }, _data.ScanDcList.Where(dc => dc.TurnaroundId == scanDC.TurnaroundId).ToList(), scanDetails);
                    ApplyEvent(new List<ApplyTurnaroundEventDetails>()
                    {
                        new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.FacilityTransferOutbound },
                        new ApplyTurnaroundEventDetails { EventType = (TurnAroundEventTypeIdentifier)scanDetails.RouteToEventTypeId.Value }
                    }, _data.ScanDcList.Where(dc => dc.TurnaroundId != scanDC.TurnaroundId).ToList(), scanDetails);
                    var transferNote = repository.Container.TransferNote.First(tn => tn.TransferNoteId == scanDetails.TransferNoteId);
                    transferNote.DispatchTransferNoteEventId = scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).First(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.FacilityTransferOutbound).TurnaroundEventId;

                    foreach (var dc in _data.ScanDcList.Where(dc => dc.TurnaroundId != scanDC.TurnaroundId))
                    {
                        var line = repository.Container.TransferNoteLine.First(tnl => tnl.TurnaroundId == dc.TurnaroundId && tnl.TransferNoteId == scanDetails.TransferNoteId && tnl.RemovedFromTransferNoteEventId == null && tnl.DispatchTransferNoteEventId == null);
                        line.DispatchTransferNoteEventId = dc.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).First(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.FacilityTransferOutbound).TurnaroundEventId; ;
                    }
                    repository.Container.SaveChanges();
                    scanDC.TransferNote = GetTransferNote(new TransferNoteRequestDataContract() { TransferNoteId = scanDetails.TransferNoteId.GetValueOrDefault() });
                }
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.FacilityTransferInbound)]
        /// <summary>
        /// FacilityTransferInbound operation
        /// </summary>
        public void FacilityTransferInbound(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            {
                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                {
                    var parentAndChildren = new List<ScanAssetDataContract>();
                    var grandChildren = new List<ScanAssetDataContract>();

                    foreach (var item in _data.ScanDcList)
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
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.FacilityTransferInbound, RemoveFromParent = true },
                        parentAndChildren,
                        scanDetails);
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.FacilityTransferInbound },
                        grandChildren,
                        scanDetails);
                    var transferNote = repository.Container.TransferNote.First(tn => tn.TransferNoteId == scanDC.TransferNote.Id);
                    transferNote.InboundEventId = scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).First(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.FacilityTransferInbound).TurnaroundEventId;
                    foreach (var dc in _data.ScanDcList.Where(dc => dc.TurnaroundId != scanDC.TurnaroundId))
                    {
                        var line = repository.Container.TransferNoteLine.First(tnl => tnl.TurnaroundId == dc.TurnaroundId && tnl.TransferNoteId == scanDC.TransferNote.Id && tnl.RemovedFromTransferNoteEventId == null && tnl.InboundEventId == null);
                        line.InboundEventId = dc.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).First(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.FacilityTransferInbound).TurnaroundEventId; ;
                    }
                }
                else
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.FacilityTransferInbound, RemoveFromParent = true },
                        scanDC,
                        scanDetails);
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = TurnAroundEventTypeIdentifier.FacilityTransferInbound },
                        _data.ScanDcList.Where(dc => dc.TurnaroundId != scanDC.TurnaroundId).ToList(),
                        scanDetails);
                    foreach (var dc in _data.ScanDcList)
                    {
                        var line = repository.Container.TransferNoteLine.First(tnl => tnl.TurnaroundId == dc.TurnaroundId && tnl.TransferNoteId == scanDC.TransferNote.Id && tnl.RemovedFromTransferNoteEventId == null && tnl.InboundEventId == null);
                        line.InboundEventId = dc.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).First(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.FacilityTransferInbound).TurnaroundEventId; ;
                    }
                }

                repository.Container.SaveChanges();
            }
        }

        [ProcessTurnaroundEvent(TurnAroundEventTypeIdentifier.RemovedFromTransferNote)]
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

                    foreach (var item in _data.ScanDcList)
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
                        _data.ScanDcList.Where(dc => dc.TurnaroundId != scanDC.TurnaroundId).ToList(),
                        scanDetails);
                }
                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley)
                {
                    var transferNote = repository.Container.TransferNote.FirstOrDefault(tn => tn.TransportTurnaroundId == scanDC.TurnaroundId && tn.DispatchTransferNoteEventId == null && tn.CancelledEventId == null);
                    if (transferNote != null)
                    {
                        transferNote.CancelledEventId = scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromTransferNote)?.TurnaroundEventId;
                    }
                }
                if (scanDC.Asset.BaseItemTypeId != (int)ItemTypeIdentifier.Trolley && scanDetails.TransferNoteLineId.HasValue)
                {
                    var transferNoteLine = repository.Container.TransferNoteLine.First(tnl => tnl.TransferNoteLineId == scanDetails.TransferNoteLineId && tnl.RemovedFromTransferNoteEventId == null);
                    transferNoteLine.RemovedFromTransferNoteEventId = scanDC.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromTransferNote)?.TurnaroundEventId;
                }
                foreach (var dc in _data.ScanDcList.Where(dc => dc.TurnaroundId != scanDC.TurnaroundId))
                {
                    var line = repository.Container.TransferNoteLine.First(tnl => tnl.TurnaroundId == dc.TurnaroundId && tnl.TransferNoteId == scanDetails.TransferNoteId && tnl.RemovedFromTransferNoteEventId == null);
                    line.RemovedFromTransferNoteEventId = dc.TurnaroundEvents.OrderByDescending(te => te.Created).ThenByDescending(te => te.TurnaroundEventId).FirstOrDefault(te => te.EventTypeId == (int)TurnAroundEventTypeIdentifier.RemovedFromTransferNote)?.TurnaroundEventId;
                }

                repository.Container.SaveChanges();
                if (scanDC.Asset.BaseItemTypeId == (int)ItemTypeIdentifier.Trolley && _data.ScanDcList.Any(dc => dc.RouteToEventTypeId.HasValue))
                {
                    foreach (var dc in _data.ScanDcList.Where(x => x.TurnaroundId != scanDC.TurnaroundId && x.RouteToEventTypeId.HasValue))
                    {
                        ApplyEvent(ApplyTurnaroundEventDetails.Create(dc.RouteToEventTypeId.Value), dc, scanDetails);
                    }
                    _data.ScanDcList.RemoveAll(x => x.TurnaroundId != scanDC.TurnaroundId);
                }
                else if (scanDetails.RouteToEventTypeId.HasValue)
                {
                    ApplyEvent(new ApplyTurnaroundEventDetails { EventType = (TurnAroundEventTypeIdentifier)scanDetails.RouteToEventTypeId.Value }, scanDetails);
                }

                scanDC.TransferNote = GetTransferNote(new TransferNoteRequestDataContract() { TransferNoteId = scanDetails.TransferNoteId.GetValueOrDefault() });
            }
        }

        private TransferNoteDataContract GetTransferNote(TransferNoteRequestDataContract request)
        {
            {
                var noExpiry = new DateTime(1900, 1, 1, 0, 0, 0);

                var qry =
                    from tr in repository.Container.TransferNote
                    join f in repository.Container.Facility on tr.ToOwnerId equals f.OwnerId
                    join sf in repository.Container.Facility on tr.FromOwnerId equals sf.OwnerId
                    where tr.TransferNoteId == request.TransferNoteId
                    select new TransferNoteDataContract
                    {
                        Id = tr.TransferNoteId,
                        ExternalId = tr.ExternalId,
                        Transport = new TurnaroundInfo
                        {
                            ContainerInstance = new ContainerInstanceInfo
                            {
                                PrimaryId = tr.Turnaround.ContainerInstance.PrimaryId,
                                Id = tr.Turnaround.ContainerInstance.ContainerInstanceId,
                                Name = tr.Turnaround.ContainerMaster.Text,
                                ItemTypeId = tr.Turnaround.ContainerMaster.ItemType.ParentItemTypeId ?? tr.Turnaround.ContainerMaster.ItemType.ItemTypeId
                            },
                            Expiry = noExpiry,
                            ExternalId = tr.Turnaround.ExternalId,
                            Id = tr.Turnaround.TurnaroundId,
                            ParentId = tr.Turnaround.ParentTurnaroundId
                        },
                        Lines = tr.TransferNoteLine.Where(n => n.RemovedFromTransferNoteEventId == null).Select(l => new TransferNoteLineInfo
                        {
                            Id = l.TransferNoteLineId,
                            Turnaround = new TurnaroundInfo
                            {
                                ContainerInstance = new ContainerInstanceInfo
                                {
                                    PrimaryId = l.Turnaround.ContainerInstance == null ? string.Empty : l.Turnaround.ContainerInstance.PrimaryId,
                                    Id = l.Turnaround.ContainerInstance == null ? default(int) : l.Turnaround.ContainerInstance.ContainerInstanceId,
                                    Name = l.Turnaround.ContainerMaster.Text,
                                    ItemTypeId = l.Turnaround.ContainerMaster.ItemType.ParentItemTypeId ?? l.Turnaround.ContainerMaster.ItemType.ItemTypeId
                                },
                                Expiry = l.Turnaround.Expiry,
                                ExternalId = l.Turnaround.ExternalId,
                                Id = l.TurnaroundId,
                                ParentId = l.Turnaround.ParentTurnaroundId
                            }
                        }),
                        DestinationFacility = new FacilityInfo
                        {
                            Id = f.FacilityId,
                            Name = f.Text
                        },
                        DestinationEventType = new EventTypeInfo
                        {
                            Id = tr.RouteToEventTypeId,
                            Name = tr.EventType.Text
                        },
                        SendingFacility = new FacilityInfo
                        {
                            Id = sf.FacilityId,
                            Name = sf.Text
                        },
                    };

                var transferNote = qry.FirstOrDefault();

                if (transferNote != null)
                {
                    transferNote.Transport.Expiry =
                        transferNote
                        .Lines
                        .Where(l => l.Turnaround.Expiry != noExpiry)
                        .Select(l => l.Turnaround.Expiry).DefaultIfEmpty(noExpiry).Min();
                }

                return transferNote;
            }
        }

    }
}
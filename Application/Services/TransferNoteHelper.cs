using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using SynergyApplicationFrameworkApi.Application.DTOs.ContainerInstanceIdentifiers;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.Services
{
    public static class TransferNoteHelper
    {
        /// <summary>
        /// GetTransferRules operation
        /// </summary>
        public static TransferRulesDataContract GetTransferRules(BaseRequestDataContract request)
        {
            return LoadTransferRules(request.FacilityId);
        }

        /// <summary>
        /// LoadTransferRules operation
        /// </summary>
        public static TransferRulesDataContract LoadTransferRules(short senderFacilityId, short? recipientFacilityId = null)
        {
            const string proc = "dbo.TransferNote_GetTransferRules";

            DataSet data;

            using (var repository = new PathwayRepository())
            {
                data = repository
                    .DataManager
                    .ExecuteQuery(
                        proc,
                        CommandType.StoredProcedure,
                        new SqlParameter { ParameterName = "SendingFacilityId", Value = senderFacilityId },
                        new SqlParameter { ParameterName = "RecipientFacilityId", Value = recipientFacilityId, SqlDbType = SqlDbType.SmallInt });
            }

            return BuildTransferRules(senderFacilityId, data);
        }

        /// <summary>
        /// BuildTransferRules operation
        /// </summary>
        public static TransferRulesDataContract BuildTransferRules(short facilityId, DataSet data)
        {
            if (facilityId == 0)
                throw new ArgumentException(@"Facility Id must be specified", "facilityId");

            if (data == null || data.Tables.Count != 2)
                throw new Exception("Expected data format is 2 tables, the first containing unrestricted reroute events and the second container MFP rules with restrictions");

            var unrestrictedEvents = BuildUnrestrictedTransferRules(data.Tables[0]);

            var rules = BuildTransferRules(data.Tables[1], unrestrictedEvents);

            return rules;
        }

        /// <summary>
        /// BuildUnrestrictedTransferRules operation
        /// </summary>
        public static List<TurnAroundEventTypeIdentifier> BuildUnrestrictedTransferRules(DataTable table)
        {
            if (table == null)
                throw new ArgumentException(@"Unrestricted transfer rules table cannot be null");

            return (
                from DataRow dr in table.Rows
                select (TurnAroundEventTypeIdentifier)Convert.ToInt16(dr["EventTypeId"])
            ).ToList();
        }

        /// <summary>
        /// BuildTransferRules operation
        /// </summary>
        public static TransferRulesDataContract BuildTransferRules(DataTable table, List<TurnAroundEventTypeIdentifier> unrestrictedEvents)
        {
            var rules = new TransferRulesDataContract
            {
                Destinations = new List<TransferDestination>()
            };

            foreach (DataRow dr in table.Rows)
            {
                var destinationFacilityId = Convert.ToInt16(dr["RecipientFacilityId"]);
                var destinationFacilityName = "" + dr["RecipientFacilityName"];
                var owningFacilityId = Convert.ToInt16(dr["OwningFacilityId"]);
                var owningFacilityName = "" + dr["OwningFacilityName"];
                var senderType = (RelationshipType)Convert.ToByte(dr["SenderType"]);
                var hasRestrictions = dr["FromEventTypeId"] != DBNull.Value && dr["ToEventTypeId"] != DBNull.Value;
                var fromEvent = hasRestrictions ? (TurnAroundEventTypeIdentifier?)Convert.ToInt16(dr["FromEventTypeId"]) : null;
                var toEvent = hasRestrictions ? (TurnAroundEventTypeIdentifier?)Convert.ToInt16(dr["ToEventTypeId"]) : null;

                var destinationFacility = rules.Destinations.SingleOrDefault(d => d.Facility.Id == destinationFacilityId);

                if (destinationFacility == null)
                {
                    destinationFacility = new TransferDestination
                    {
                        Facility = new FacilityInfo
                        {
                            Id = destinationFacilityId,
                            Name = destinationFacilityName
                        },
                        DestinationEvents = new List<DestinationEvent>(),
                        RelationshipToSender = senderType
                    };

                    rules.Destinations.Add(destinationFacility);
                }

                if (hasRestrictions)
                {
                    var destinationEvent = BuildDestinationEvent(destinationFacility, toEvent.Value);

                    var facilityRestriction = BuildFacilityRestriction(destinationEvent, owningFacilityId, owningFacilityName);

                    if (!facilityRestriction.FromEvents.Contains(fromEvent.Value))
                        facilityRestriction.FromEvents.Add(fromEvent.Value);
                }
                else
                {
                    unrestrictedEvents.ForEach(ev =>
                    {
                        var destinationEvent = BuildDestinationEvent(destinationFacility, ev);

                        BuildFacilityRestriction(destinationEvent, owningFacilityId, owningFacilityName);
                    });
                }
            }

            return rules;
        }

        /// <summary>
        /// BuildFacilityRestriction operation
        /// </summary>
        public static FacilityRestriction BuildFacilityRestriction(DestinationEvent destinationEvent, short owningFacilityId, string owningFacilityName)
        {
            var facilityRestriction = destinationEvent.Restrictions.SingleOrDefault(d => d.OwningFacility.Id == owningFacilityId);

            if (facilityRestriction == null)
            {
                facilityRestriction = new FacilityRestriction
                {
                    OwningFacility = new FacilityInfo
                    {
                        Id = owningFacilityId,
                        Name = owningFacilityName
                    },
                    FromEvents = new List<TurnAroundEventTypeIdentifier>()
                };

                destinationEvent.Restrictions.Add(facilityRestriction);
            }
            return facilityRestriction;
        }

        /// <summary>
        /// BuildDestinationEvent operation
        /// </summary>
        public static DestinationEvent BuildDestinationEvent(TransferDestination destinationFacility, TurnAroundEventTypeIdentifier toEvent)
        {
            var destinationEvent = destinationFacility.DestinationEvents.SingleOrDefault(d => d.EventType == toEvent);

            if (destinationEvent == null)
            {
                destinationEvent = new DestinationEvent
                {
                    EventType = toEvent,
                    Restrictions = new List<FacilityRestriction>()
                };

                destinationFacility.DestinationEvents.Add(destinationEvent);
            }
            return destinationEvent;
        }

        /// <summary>
        /// GetTransferNote operation
        /// </summary>
        public static TransferNoteDataContract GetTransferNote(TransferNoteRequestDataContract request)
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
                                ItemTypeId = tr.Turnaround.ContainerMaster.ItemType.ParentItemTypeId ?? tr.Turnaround.ContainerMaster.ItemType.ItemTypeId,
                                ContainerInstanceIdentifiers = ConvertIdentifiersToDataContracts(tr.Turnaround.ContainerInstance.ContainerInstanceIdentifier)
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

        private static List<ContainerInstanceIdentifierDataContract> ConvertIdentifiersToDataContracts(IEnumerable<ContainerInstanceIdentifier> identifiers)
        {
            var dataContracts = new List<ContainerInstanceIdentifierDataContract>();

            foreach (var identifier in identifiers)
            {
                var identifierDC = new ContainerInstanceIdentifierDataContract
                {
                    ContainerInstanceIdentifierId = identifier.ContainerInstanceIdentifierId,
                    ContainerInstanceIdentifierType = new ContainerInstanceIdentifierTypeDataContract
                    {
                        ContainerInstanceIdentifierTypeId = identifier.ContainerInstanceIdentifierType.ContainerInstanceIdentifierTypeId,
                        IsEditable = identifier.ContainerInstanceIdentifierType.IsEditable,
                        IsUnique = identifier.ContainerInstanceIdentifierType.IsUnique,
                        Text = identifier.ContainerInstanceIdentifierType.Text
                    },
                    IsPrimary = identifier.IsPrimary,
                    Value = identifier.Value
                };

                dataContracts.Add(identifierDC);
            }

            return dataContracts;
        }

        /// <summary>
        /// GetTransferNotes operation
        /// </summary>
        public static TransferNotePriorityListDataContract GetTransferNotes(BaseRequestDataContract request)
        {
            const string proc = "dbo.Operative_TransferStation_PriorityList";

            DataSet data;

            {
                data = repository.DataManager.ExecuteQuery(proc, CommandType.StoredProcedure, new SqlParameter { ParameterName = "FacilityId", Value = request.FacilityId });
            }

            return BuildTransferNotePriorityList(data);
        }

        /// <summary>
        /// BuildTransferNotePriorityList operation
        /// </summary>
        public static TransferNotePriorityListDataContract BuildTransferNotePriorityList(DataSet data)
        {
            if (data == null)
                throw new ArgumentNullException("data", @"DataSet cannot be null");

            if (data.Tables.Count != 1)
                throw new ArgumentException(@"DataSet should contain 1 table", "data");

            var priority = new TransferNotePriorityListDataContract
            {
                Items = new List<TransferNotePriorityItem>()
            };

            foreach (DataRow dr in data.Tables[0].Rows)
            {
                var item = new TransferNotePriorityItem
                {
                    TransferNote = new TransferNoteInfo
                    {
                        Id = Convert.ToInt16(dr["TransferNoteId"]),
                        ExternalId = "" + dr["ExternalId"]
                    },
                    Destination = new FacilityInfo
                    {
                        Id = Convert.ToInt16(dr["FacilityId"]),
                        Name = "" + dr["FacilityName"]
                    },
                    DestinationEvent = (TurnAroundEventTypeIdentifier)Convert.ToInt16(dr["DestinationEvent"]),
                    Transport = new ContainerInstanceInfo
                    {
                        PrimaryId = "" + dr["TransportExternalId"],
                        Id = Convert.ToInt32(dr["TransportId"]),
                        Name = "" + dr["TransportName"]
                    },
                    Expiry = dr["Expiry"] == DBNull.Value ? new DateTime(1900, 1, 1) : Convert.ToDateTime(dr["Expiry"]),
                    ItemCount = dr["ItemCount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ItemCount"])
                };

                priority.Items.Add(item);
            }
            foreach(DataRow dr in data.Tables[1].Rows)
            {
                var item = priority.Items.First(i => i.TransferNote.Id == Convert.ToInt16(dr["TransferNoteId"]));

                if (item.Transport != null)
                {
                    if (item.Transport.ContainerInstanceIdentifiers == null)
                    {
                        item.Transport.ContainerInstanceIdentifiers = new List<ContainerInstanceIdentifierDataContract>();
                    }

                    item.Transport.ContainerInstanceIdentifiers.Add(new ContainerInstanceIdentifierDataContract
                    {
                        Value = dr["Value"].ToString(),
                        IsPrimary = Convert.ToBoolean(dr["IsPrimary"]),
                        ContainerInstanceIdentifierType = new ContainerInstanceIdentifierTypeDataContract
                        {
                            ContainerInstanceIdentifierTypeId = Convert.ToInt16(dr["ContainerInstanceIdentifierTypeId"]),
                            Text = dr["Text"].ToString()
                        }
                    });
                }
            }

            return priority;
        }

        /// <summary>
        /// AddToTransferNoteValidation operation
        /// </summary>
        public static ValidateTransferResult AddToTransferNoteValidation(ScanAssetDataContract scanDC, ScanDetails scanDetails)
        {
            ValidateTransferResult isValid;
            using (var workUnit = UnitOfWorkFactory.CreateOperativeEFUnitOfWork())
            {
                var transferNoteLineRepository = TransferNoteLineRepository.New(workUnit);
                isValid = transferNoteLineRepository.IsValidTransferProcess(scanDetails, scanDC);
            }

            return isValid;
        }
    }
}
using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ItemMaster
    {
        /// <summary>
        /// Gets or sets UpdateContainerMasterNotes
        /// </summary>
        public bool UpdateContainerMasterNotes { get; set; }
        /// <summary>
        /// Gets or sets UpdateWarnings
        /// </summary>
        public bool UpdateWarnings { get; set; }

        public ItemType BaseItemType
        {
            get { return (ItemType.ParentItemType ?? ItemType); }
        }

        public ItemType ChildItemType
        {
            get { return (ItemType.ParentItemType == null ? null : ItemType); }
        }

        /// <summary>
        /// Gets or sets ItemInstance
        /// </summary>
        public IItemInstance ItemInstance { get; set; }

        /// <summary>
        /// Gets or sets Position
        /// </summary>
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets UserItemAudit
        /// </summary>
        public UserItemAudit UserItemAudit { get; set; }

        public int? OwnerId { get; set; }

        public IList<byte> ContainerMasterNoteStationTypeIds
        {
            get
            {
                return ContainerMasterNote.SelectMany(cmn => cmn.ContainerMasterNoteStationType.Select(cmnst => cmnst.StationType)).Select(st => st.StationTypeId).ToList();
            }
        }

        /// <summary>
        /// Initialises the 1st revision
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <summary>
        /// CreateFirstRevision operation
        /// </summary>
        public static ItemMaster CreateFirstRevision(ItemMasterDefinition masterDefinition, int userId)
        {
            return new ItemMaster()
            {
                ItemMasterDefinition = masterDefinition,
                CreatedUserId = userId,
                ItemStatusId = (int)ItemStatusTypeIdentifier.Active,
                Revision = 1,
                Created = DateTime.UtcNow,
                FinanceId = string.Empty,
            };
        }

        /// <summary>
        /// Initialises the 1st revision
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <summary>
        /// CreateFirstRevision operation
        /// </summary>
        public static ItemMaster CreateFirstRevision(int userId)
        {
            return new ItemMaster()
            {
                ItemMasterDefinition = new ItemMasterDefinition(),
                CreatedUserId = userId,
                ItemStatusId = (int)ItemStatusTypeIdentifier.Active,
                Revision = 1,
                Created = DateTime.UtcNow,
                FinanceId = string.Empty,
            };
        }

        /// <summary>
        /// Create a new revision from this
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <summary>
        /// CreateNewRevision operation
        /// </summary>
        public ItemMaster CreateNewRevision(int userId)
        {
            ItemStatusId = (int)ItemStatusTypeIdentifier.Retired;
            var newRevision = new ItemMaster()
            {
                ItemMasterId = ItemMasterId,
                BatchCycleId = BatchCycleId,
                CategoryId = CategoryId,
                ComplexityId = ComplexityId,
                CreatedUserId = userId,
                ItemMasterDefinitionId = ItemMasterDefinitionId,
                ItemStatusId = (int)ItemStatusTypeIdentifier.Active,
                ItemTypeId = ItemTypeId,
                SpecialityId = SpecialityId,
                ExternalId = ExternalId,
                Text = Text,
                Revision = (short)(Revision + 1),
                Created = DateTime.UtcNow,
                ManufacturersReference = ManufacturersReference,
                ComponentPartCount = ComponentPartCount,
                Trackable = Trackable,
                IndependentQualityAssuranceCheck = IndependentQualityAssuranceCheck,
                FinanceId = FinanceId,
                PinRequestReasonId = PinRequestReasonId,
                BiologicalIndicatorEnabled = BiologicalIndicatorEnabled,
                OwnerId = OwnerId,
                LabourLevelId = LabourLevelId, 
                ManufacturerId = ManufacturerId
            };

            //// alias
            foreach (var note in ContainerMasterNote)
            {
                var newNote = new ContainerMasterNote()
                {
                    ContainerMasterNoteId = note.ContainerMasterNoteId,
                    ContainerMasterNoteTypeId = note.ContainerMasterNoteTypeId,
                    ContainerMasterId = note.ContainerMasterId,
                    Text = note.Text,
                    ItemMasterId = note.ItemMasterId,
                };
                newRevision.ContainerMasterNote.Add(newNote);
                foreach (var stationType in note.ContainerMasterNoteStationType)
                {
                    newNote.ContainerMasterNoteStationType.Add(stationType);
                }
            }
            foreach (var price in ItemMasterPrice)
            {
                var newPrice = new ItemMasterPrice()
                {
                    ItemMasterPriceId = price.ItemMasterPriceId,
                    ItemMasterId = price.ItemMasterId,
                    CustomerDefinitionId = price.CustomerDefinitionId,
                    BasePrice = price.BasePrice,
                };
                newRevision.ItemMasterPrice.Add(newPrice);
            }
            foreach (var warning in Warning)
            {
                var newWarning = new Warning()
                {
                    WarningId = warning.WarningId,
                    ContainerMasterId = warning.ContainerMasterId,
                    ItemMasterId = warning.ItemMasterId,
                    Text = warning.Text,
                    MaximumTurnarounds = warning.MaximumTurnarounds,
                    MaximumDays = warning.MaximumDays,
                    TurnaroundLeadIn = warning.TurnaroundLeadIn,
                    WarningOnly = warning.WarningOnly,
                    Created = warning.Created,
                };
                newRevision.Warning.Add(newWarning);
            }

            return newRevision;
        }

        /// <summary>
        /// Populates a revision with data from the provided item
        /// </summary>
        /// <param name="item"></param>
        /// <param name="stationTypes"></param>
        /// <summary>
        /// PopulateRevision operation
        /// </summary>
        public void PopulateRevision(ItemMaster item, IList<StationType> stationTypes)
        {
            BatchCycleId = item.BatchCycleId;
            CategoryId = item.CategoryId;
            ComplexityId = item.ComplexityId;
            ItemTypeId = item.ItemTypeId;
            SpecialityId = item.SpecialityId;
            ExternalId = item.ExternalId;
            Text = item.Text;
            ManufacturersReference = item.ManufacturersReference;
            ComponentPartCount = item.ComponentPartCount;
            IndependentQualityAssuranceCheck = item.IndependentQualityAssuranceCheck;
            ManufacturerId = item.ManufacturerId;
            BiologicalIndicatorEnabled = item.BiologicalIndicatorEnabled;
            OwnerId = item.OwnerId;
            LabourLevelId = item.LabourLevelId;
            if (item.UpdateContainerMasterNotes)
            {
                ContainerMasterNote.Clear();
                foreach (var note in item.ContainerMasterNote)
                {
                    var newNote = new ContainerMasterNote()
                    {
                        ContainerMasterNoteTypeId = note.ContainerMasterNoteTypeId,
                        Text = note.Text
                    };
                    ContainerMasterNote.Add(newNote);

                    foreach (var containerMasterNoteStationType in note.ContainerMasterNoteStationType)
                    {
                        newNote.ContainerMasterNoteStationType.Add(containerMasterNoteStationType);
                    }
                }
            }
            if (item.UpdateWarnings)
            {
                Warning.Clear();
                foreach (var warning in item.Warning)
                {
                    Warning.Add(new Warning()
                    {
                        Text = warning.Text,
                        MaximumTurnarounds = warning.MaximumTurnarounds,
                        MaximumDays = warning.MaximumDays,
                        TurnaroundLeadIn = warning.TurnaroundLeadIn,
                        WarningOnly = warning.WarningOnly,
                        Created = DateTime.UtcNow,
                        LeadInDays = warning.LeadInDays,
                        CreatedUserId = warning.CreatedUserId,
                        Name = warning.Name
                    });
                }
            }
        }

        /// <summary>
        /// Sets the price for the provided customer
        /// </summary>
        /// <param name="value"></param>
        /// <param name="customerDefinitionId"></param>
        /// <returns></returns>
        /// <summary>
        /// SetItemMasterPriceForCustomer operation
        /// </summary>
        public ItemMasterPrice SetItemMasterPriceForCustomer(decimal value, int customerDefinitionId)
        {
            if (!ItemMasterPrice.Any(imp => imp.CustomerDefinitionId == customerDefinitionId))
            {
                ItemMasterPrice.Add(new ItemMasterPrice()
                {
                    CustomerDefinitionId = customerDefinitionId
                });
            }

            var price = ItemMasterPrice.Single(imp => imp.CustomerDefinitionId == customerDefinitionId);
            price.BasePrice = value;
            return price;
        }

        /// <summary>
        /// GenerateExternalId operation
        /// </summary>
        public static string GenerateExternalId(int itemMasterDefinitionId, ItemType baseItemType)
        { 
            return string.Format("{0}{1}{2}", SystemSettings.PortalPrefix,
                    BaseTypeIdentifier.GetIdentifier(baseItemType != null ? baseItemType.Text : ""),
                    itemMasterDefinitionId.ToString().PadLeft(7, '0'));
            
        }
    }
}
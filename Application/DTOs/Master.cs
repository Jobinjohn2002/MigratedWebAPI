using SynergyApplicationFrameworkApi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// A composite of the ContainerMaster and ItemMaster entities
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// Master
    /// </summary>
    public class Master
    {
        /// <summary>
        /// Gets or sets the container master.
        /// </summary>
        /// <value>The container master.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public ContainerMaster ContainerMaster { get; set; }
        /// <summary>
        /// Gets or sets the item master.
        /// </summary>
        /// <value>The item master.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public ItemMaster ItemMaster { get; set; }

        /// <summary>
        /// Gets or sets the master id.
        /// </summary>
        /// <value>The master id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterId
        /// </summary>
        public int MasterId { get; set; }

        /// <summary>
        /// Gets or sets the Archived.
        /// </summary>
        /// <value>The Archived.</value>
        /// <remarks></remarks>
        public DateTime? Archived { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [requires second check].
        /// </summary>
        /// <value><c>true</c> if [requires second check]; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IndependentQualityAssuranceCheck
        /// </summary>
        public bool IndependentQualityAssuranceCheck { get; set; }
        /// <summary>
        /// Gets or Sets if the customer is setup for tray charges
        /// </summary>
        /// <summary>
        /// Gets or sets IsTrayChangeChargeable
        /// </summary>
        public bool IsTrayChangeChargeable { get; set; }
        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        /// <value>The revision.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Revision
        /// </summary>
        public int Revision { get; set; }
        /// <summary>
        /// Gets or sets the speciality id.
        /// </summary>
        /// <value>The speciality id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets SpecialityId
        /// </summary>
        public short SpecialityId { get; set; }
        /// <summary>
        /// Gets or sets the category id.
        /// </summary>
        /// <value>The category id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CategoryId
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// Gets or sets the created user id.
        /// </summary>
        /// <value>The created user id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets the item type id.
        /// </summary>
        /// <value>The item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets the complexity id.
        /// </summary>
        /// <value>The complexity id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ComplexityId
        /// </summary>
        public short ComplexityId { get; set; }
        /// <summary>
        /// Gets or sets the item status id.
        /// </summary>
        /// <value>The item status id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemStatusId
        /// </summary>
        public short ItemStatusId { get; set; }
        /// <summary>
        /// Gets or sets the definition id.
        /// </summary>
        /// <value>The definition id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefinitionId
        /// </summary>
        public int DefinitionId { get; set; }
        /// <summary>
        /// Gets or sets the manufacturers reference.
        /// </summary>
        /// <value>The manufacturers reference.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ManufacturersReference
        /// </summary>
        public string ManufacturersReference { get; set; }
        /// <summary>
        /// Gets or sets Manufacturer
        /// </summary>
        public ManufacturerDataContract Manufacturer { get; set; }
        /// <summary>
        /// Gets or sets the number of labels.
        /// </summary>
        /// <value>The number of labels.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets NumberOfLabels
        /// </summary>
        public byte NumberOfLabels { get; set; }
        /// <summary>
        /// Gets or sets the legacy internal id.
        /// </summary>
        /// <value>The legacy internal id.</value>
        /// <remarks></remarks>
        public int? LegacyInternalId { get; set; }
        /// <summary>
        /// Gets or sets the legacy external id.
        /// </summary>
        /// <value>The legacy external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets LegacyExternalId
        /// </summary>
        public string LegacyExternalId { get; set; }
        /// <summary>
        /// Gets or sets the external id.
        /// </summary>
        /// <value>The external id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ExternalId
        /// </summary>
        public string ExternalId { get; set; }
        /// <summary>
        /// Gets or sets the batch cycle uid.
        /// </summary>
        /// <value>The batch cycle uid.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets BatchCycleId
        /// </summary>
        public int BatchCycleId { get; set; }
        /// <summary>
        /// Gets or sets the component part count.
        /// </summary>
        /// <value>The component part count.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ComponentPartCount
        /// </summary>
        public short ComponentPartCount { get; set; }

        /// <summary>
        /// Gets or sets the component part count.
        /// </summary>
        /// <value>The component part count.</value>
        /// <remarks></remarks>
        public int? ComponentQuntity { get; set; }

        /// <summary>
        /// Gets or sets the printer type id.
        /// </summary>
        /// <value>The printer type id.</value>
        /// <remarks></remarks>
        public byte? PrinterTypeId { get; set; }

        /// <summary>
        /// Gets or sets the component part count.
        /// </summary>
        /// <value>The component part count.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MachineType
        /// </summary>
        public byte MachineType { get; set; }

        /// <summary>
        /// Gets or sets the Customer Definition Id
        /// </summary>
        /// <value>The Customer Definition Id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }

        /// <summary>
        /// Gets or sets the Customer 
        /// </summary>
        /// <value>The Customer .</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the Gtin
        /// </summary>
        /// <value>The Gtin.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Gtin
        /// </summary>
        public string Gtin { get; set; }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        /// <value>The Total.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Total
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        /// <value>The Total.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }

        /// <summary>
        /// get or sets the base item type Is
        /// </summary>
        /// <summary>
        /// Gets or sets BaseItemTypeId
        /// </summary>
        public short BaseItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        /// <value>The Total.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ChildItemTypeName
        /// </summary>
        public string ChildItemTypeName { get; set; }

        /// <summary>
        /// Gets or sets the Facility Name
        /// </summary>
        /// <value>Facility.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        /// <value>The Total.</value>
        /// <remarks></remarks>
        public int? ComplianceReasonId { get; set; }

        /// <summary>
        /// Gets or sets the Biological Indicator Enabled
        /// </summary>
        /// <value>The Biological Indicator Enabled.</value>
        /// <remarks></remarks>
        public bool BiologicalIndicatorEnabled
        {
            get
            {
                return Property(i => i.BiologicalIndicatorEnabled, i => i.BiologicalIndicatorEnabled).GetValueOrDefault();
            }
        }

        /// <summary>
        /// Gets or sets the Total
        /// </summary>
        /// <value>The Total.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ProcessingBatchCycles
        /// </summary>
        public IEnumerable<BatchCycle> ProcessingBatchCycles { get; set; }

        /// <summary>
        /// Decontamination Tasks
        /// </summary>
        /// <summary>
        /// Gets or sets ProcessingDecontaminationTasks
        /// </summary>
        public IEnumerable<DecontaminationTask> ProcessingDecontaminationTasks { get; set; }

        /// <summary>
        /// Gets or Sets the Labour Level
        /// </summary>
        /// <summary>
        /// Gets or sets LabourLevelId
        /// </summary>
        public int LabourLevelId { get; set; }

        public int? CoolingTime { get; set; }

        /// <summary>
        /// Gets or sets QualityId
        /// </summary>
        public short QualityId { get; set; }
        /// <summary>
        /// Gets or sets QualityTypeId
        /// </summary>
        public short QualityTypeId { get; set; }
        /// <summary>
        /// Gets or sets DefinitionTypeId
        /// </summary>
        public short DefinitionTypeId { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        /// <remarks></remarks>
        public Master()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Master"/> class.
        /// </summary>
        /// <param name="containerMaster">The container master.</param>
        /// <remarks></remarks>
        public Master(ContainerMaster containerMaster)
        {
            ContainerMaster = containerMaster;
            ItemMaster = null;
            MasterId = containerMaster.ContainerMasterId;
            Name = containerMaster.Text;
            CreatedDate = containerMaster.Created;
            IndependentQualityAssuranceCheck = containerMaster.IndependentQualityAssuranceCheck;
            Revision = containerMaster.Revision;
            SpecialityId = containerMaster.SpecialityId;
            CategoryId = containerMaster.CategoryId;
            CreatedUserId = containerMaster.CreatedUserId;
            ItemTypeId = containerMaster.ItemTypeId;
            ComplexityId = containerMaster.ComplexityId;
            ItemStatusId = containerMaster.ItemStatusId;
            DefinitionId = containerMaster.ContainerMasterDefinitionId;
            ManufacturersReference = containerMaster.ManufacturersReference;
            NumberOfLabels = containerMaster.NumberOfLabels;
            LegacyInternalId = containerMaster.LegacyId;
            ExternalId = containerMaster.ExternalId;
            BatchCycleId = containerMaster.ChargableBatchCycleId;
            ComponentPartCount = default(short);
            PrinterTypeId = 0;//containerMaster.PrinterTypeId;
            MachineType = containerMaster.MachineTypeId;
            Gtin = containerMaster.Gtin;
            ProcessingBatchCycles = containerMaster.ProcessingBatchCycles;
            ProcessingDecontaminationTasks = containerMaster.ProcessingDecontaminationTasks;
            LabourLevelId = containerMaster.LabourLevelId;
            CoolingTime = containerMaster.CoolingTime;
            QualityId = containerMaster.ContainerMasterDefinition?.ContainerMasterQualityId ?? default(short);
            QualityTypeId = containerMaster.ContainerMasterDefinition?.Quality.QualityTypeId?? default(short);
            DefinitionTypeId = containerMaster.ContainerMasterDefinition?.ContainerMasterDefinitionTypeId ?? default(short);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Master"/> class.
        /// </summary>
        /// <param name="itemMaster">The item master.</param>
        /// <remarks></remarks>
        public Master(ItemMaster itemMaster)
        {
            ContainerMaster = null;
            ItemMaster = itemMaster;
            MasterId = itemMaster.ItemMasterId;
            Name = itemMaster.Text;
            CreatedDate = itemMaster.Created;
            IndependentQualityAssuranceCheck = itemMaster.IndependentQualityAssuranceCheck;
            Revision = itemMaster.Revision;
            SpecialityId = itemMaster.SpecialityId;
            CategoryId = itemMaster.CategoryId;
            CreatedUserId = itemMaster.CreatedUserId;
            ItemTypeId = itemMaster.ItemTypeId;
            ComplexityId = itemMaster.ComplexityId;
            ItemStatusId = itemMaster.ItemStatusId;
            DefinitionId = itemMaster.ItemMasterDefinitionId;
            ManufacturersReference = itemMaster.ManufacturersReference;
            NumberOfLabels = default(byte);
            LegacyInternalId = itemMaster.LegacyId;
            ExternalId = itemMaster.ExternalId;
            BatchCycleId = itemMaster.BatchCycleId;
            ComponentPartCount = itemMaster.ComponentPartCount;
            MachineType = default(byte);
            Gtin = null;
            ProcessingBatchCycles = itemMaster.ProcessingBatchCycles;
            ProcessingDecontaminationTasks = itemMaster.ProcessingDecontaminationTasks;
            LabourLevelId = itemMaster.LabourLevelId;
            QualityId = itemMaster.ItemMasterDefinition?.ItemMasterQualityId ?? default(short);
            QualityTypeId = itemMaster.ItemMasterDefinition?.Quality.QualityTypeId ?? default(short);
            DefinitionTypeId = itemMaster.ItemMasterDefinition?.ItemMasterDefinitionTypeId ?? default(short);
        }

        /// <summary>
        /// Properties the specified container property.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="containerProperty">The container property.</param>
        /// <param name="itemProperty">The item property.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        protected TProperty Property<TProperty>(Func<ContainerMaster, TProperty> containerProperty, Func<ItemMaster, TProperty> itemProperty)
        {
            if (ContainerMaster != null)
            {
                return containerProperty.Invoke(ContainerMaster);
            }
            if (ItemMaster != null)
            {
                return itemProperty.Invoke(ItemMaster);
            }
            return default(TProperty);
        }

        /// <summary>
        /// Gets the type of the master.
        /// </summary>
        /// <remarks></remarks>
        public MasterType MasterType
        {
            get
            {
                return Property(i => MasterType.ContainerMaster, i => MasterType.ItemMaster);
            }
        }

        /// <summary>
        /// Gets the warnings.
        /// </summary>
        /// <remarks></remarks>
        public ICollection<Warning> Warnings
        {
            get
            {
                return Property(i => i.Warnings, i => i.Warning);
            }
        }

        /// <summary>
        /// Gets the type of the item.
        /// </summary>
        /// <remarks></remarks>
        public ItemType ItemType
        {
            get
            {
                return Property(i => i.ItemType, i => i.ItemType);
            }
        }

        /// <summary>
        /// Gets the type of the base item.
        /// </summary>
        /// <remarks></remarks>
        public ItemType BaseItemType
        {
            get
            {
                return Property(i => i.BaseItemType, i => i.BaseItemType);
            }
        }

        /// <summary>
        /// Gets the type of the child item.
        /// </summary>
        /// <remarks></remarks>
        public ItemType ChildItemType
        {
            get
            {
                return Property(i => i.ChildItemType, i => i.ChildItemType);
            }
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <remarks></remarks>
        public User User
        {
            get
            {
                return Property(i => i.User, i => i.User);
            }
        }

        /// <summary>
        /// Gets the item status.
        /// </summary>
        /// <remarks></remarks>
        public ItemStatus ItemStatus
        {
            get
            {
                return Property(i => i.ItemStatus, i => i.ItemStatus);
            }
        }

        #region DB functions

        /// <summary>
        /// Gets the parse container exp.
        /// </summary>
        /// <remarks></remarks>
        public static Expression<Func<ContainerMaster, Master>> ParseContainerExp
        {
            get
            {
                return i => new Master
                                {
                                    ContainerMaster = i,
                                    ItemMaster = null,
                                    MasterId = i.ContainerMasterId,
                                    Name = i.Text,
                                    CreatedDate = i.Created,
                                    IndependentQualityAssuranceCheck = i.IndependentQualityAssuranceCheck,
                                    Revision = i.Revision,
                                    SpecialityId = i.SpecialityId,
                                    CategoryId = i.CategoryId,
                                    CreatedUserId = i.CreatedUserId,
                                    ItemTypeId = i.ItemTypeId,
                                    ComplexityId = i.ComplexityId,
                                    ItemStatusId = i.ItemStatusId,
                                    DefinitionId = i.ContainerMasterDefinitionId,
                                    ManufacturersReference = i.ManufacturersReference,
                                    NumberOfLabels = i.NumberOfLabels,
                                    LegacyInternalId = i.LegacyId,
                                    ExternalId = i.ExternalId,
                                    BatchCycleId = i.ChargableBatchCycleId,
                                    PrinterTypeId = i.PrinterTypeId,
                                    ComponentPartCount = default(short),
                                    MachineType = i.MachineTypeId,
                                    Gtin = i.Gtin,
                                    ComplianceReasonId = i.PinRequestReasonId,
                                    Archived=i.Archived,
                                    ProcessingBatchCycles = i.ProcessingBatchCycles ,
                                    ProcessingDecontaminationTasks = i.ProcessingDecontaminationTasks,
                                    LabourLevelId = i.LabourLevelId,
                                    CoolingTime = i.CoolingTime,
                                    QualityId = i.ContainerMasterDefinition != null ? i.ContainerMasterDefinition.ContainerMasterQualityId : default(short),
                                    QualityTypeId = i.ContainerMasterDefinition != null ? i.ContainerMasterDefinition.Quality.QualityTypeId: default(short),
                };
            }
        }

        /// <summary>
        /// Gets the parse item exp.
        /// </summary>
        /// <remarks></remarks>
        public static Expression<Func<ItemMaster, Master>> ParseItemExp
        {
            get
            {
                return i => new Master
                                {
                                    ContainerMaster = null,
                                    ItemMaster = i,
                                    MasterId = i.ItemMasterId,
                                    Name = i.Text,
                                    CreatedDate = i.Created,
                                    IndependentQualityAssuranceCheck = i.IndependentQualityAssuranceCheck,
                                    Revision = i.Revision,
                                    SpecialityId = i.SpecialityId,
                                    CategoryId = i.CategoryId,
                                    CreatedUserId = i.CreatedUserId,
                                    ItemTypeId = i.ItemTypeId,
                                    ComplexityId = i.ComplexityId,
                                    ItemStatusId = i.ItemStatusId,
                                    DefinitionId = i.ItemMasterDefinitionId,
                                    ManufacturersReference = i.ManufacturersReference,
                                    NumberOfLabels = default(byte),
                                    LegacyInternalId = i.LegacyId,
                                    ExternalId = i.ExternalId,
                                    BatchCycleId = i.BatchCycleId,
                                    PrinterTypeId = default(byte),
                                    ComponentPartCount = i.ComponentPartCount,
                                    MachineType = default(byte),
                                    Gtin = null,
                                    ComplianceReasonId = i.PinRequestReasonId,
                                    Archived = null,
                                    ProcessingBatchCycles = i.ProcessingBatchCycles,
                                    ProcessingDecontaminationTasks = i.ProcessingDecontaminationTasks,
                                    LabourLevelId = i.LabourLevelId,
                                    QualityId = i.ItemMasterDefinition != null ? i.ItemMasterDefinition.ItemMasterQualityId : default(short),
                                    QualityTypeId = i.ItemMasterDefinition != null ? i.ItemMasterDefinition.Quality.QualityTypeId : default(short),
                                    DefinitionTypeId = i.ItemMasterDefinition != null ? i.ItemMasterDefinition.ItemMasterDefinitionTypeId : default(short),
                };
            }
        }

        #endregion
    }
}

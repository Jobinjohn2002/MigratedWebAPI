using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    /// <summary>
    /// MasterData
    /// </summary>
    public class MasterData
    {
        /// <summary>
        /// Gets or sets the type of the master.
        /// </summary>
        /// <value>The type of the master.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MasterType
        /// </summary>
        public MasterType MasterType { get; set; }

        /// <summary>
        /// Gets or sets the index id.
        /// </summary>
        /// <value>The index id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IndexId
        /// </summary>
        public int IndexId { get; set; }

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
        /// Gets or sets the definition id.
        /// </summary>
        /// <value>The definition id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets DefinitionId
        /// </summary>
        public int DefinitionId { get; set; }
        /// <summary>
        /// Gets or sets MasterDefinitionType
        /// </summary>
        public short MasterDefinitionType { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Text
        /// </summary>
        public string Text { get; set; }

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
        /// Gets or sets the item type id.
        /// </summary>
        /// <value>The item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public short ItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the base item type id.
        /// </summary>
        /// <value>The base item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets BaseItemTypeId
        /// </summary>
        public int BaseItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the base item type.
        /// </summary>
        /// <value>The name of the base item type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets BaseItemTypeName
        /// </summary>
        public string BaseItemTypeName { get; set; }

        /// <summary>
        /// Gets or sets the child item type id.
        /// </summary>
        /// <value>The child item type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ChildItemTypeId
        /// </summary>
        public int ChildItemTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the child item type.
        /// </summary>
        /// <value>The name of the child item type.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ChildItemTypeName
        /// </summary>
        public string ChildItemTypeName { get; set; }

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
        /// Gets or sets the complexity id.
        /// </summary>
        /// <value>The complexity id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ComplexityId
        /// </summary>
        public short ComplexityId { get; set; }

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
        /// Gets or sets the speciality id.
        /// </summary>
        /// <value>The speciality id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets SpecialityId
        /// </summary>
        public short SpecialityId { get; set; }

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
        /// Gets or sets the number of labels.
        /// </summary>
        /// <value>The number of labels.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets NumberOfLabels
        /// </summary>
        public byte NumberOfLabels { get; set; }

        /// <summary>
        /// Gets or sets the component part count.
        /// </summary>
        /// <value>The component part count.</value>
        /// <remarks></remarks>
        public short? ComponentPartCount { get; set; }

        /// <summary>
        /// Gets or sets the component part count.
        /// </summary>
        /// <value>The component part count.</value>
        /// <remarks></remarks>
        public int? ComponentQuntity { get; set; }

        /// <summary>
        /// Gets or sets the manufacture ref.
        /// </summary>
        /// <value>The manufacture ref.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ManufacturersReference
        /// </summary>
        public string ManufacturersReference { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets the created user username.
        /// </summary>
        /// <value>The created user username.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CreatedUserUsername
        /// </summary>
        public string CreatedUserUsername { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the status id.
        /// </summary>
        /// <value>The status id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets StatusId
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        /// <remarks></remarks>
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or sets the containercontentnoteid
        /// </summary>
        public int? ContainerContentNoteId { get; set; }

        /// <summary>
        /// Gets or sets the container content note.
        /// </summary>
        /// <summary>
        /// Gets or sets ContainerContentNote
        /// </summary>
        public string ContainerContentNote { get; set; }

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
        /// Gets or sets the printer type id.
        /// </summary>
        /// <value>The printer type id.</value>
        /// <remarks></remarks>
        public byte? PrinterTypeId { get; set; }

        /// <summary>
        /// Gets or sets the machine type id.
        /// </summary>
        /// <value>The machine type id.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public byte MachineTypeId { get; set; }

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
        /// Gets or sets the Customer Name
        /// </summary>
        /// <value>The Customer.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the Customer Gtin
        /// </summary>
        /// <value>The Customer Gtin.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Gtin
        /// </summary>
        public string Gtin { get; set; }

        /// <summary>
        /// Gets or sets the Customer Total
        /// </summary>
        /// <value>The Customer Total.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets Total
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// Gets or sets the Compliance Reason
        /// </summary>
        /// <value>The Compliance Reason</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets ComplianceReason
        /// </summary>
        public string ComplianceReason { get; set; }

        /// <summary>
        /// Gets or sets isRetired prop
        /// </summary>
        /// <value>The IsRetired Prop</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets IsRetired
        /// </summary>
        public bool IsRetired { get; set; }

        /// <summary>
        /// Gets or Sets if the customer is setup for tray charges
        /// </summary>
        /// <summary>
        /// Gets or sets IsTrayChangeChargeable
        /// </summary>
        public bool IsTrayChangeChargeable { get; set; }
        /// <summary>
        /// Gets or sets ContainerContentId
        /// </summary>
        public int ContainerContentId { get; set; }

        /// <summary>
        /// Gets or sets the Biological Indicator Enabled
        /// </summary>
        /// <value>The Biological Indicator Enabled.</value>
        /// <remarks></remarks>
        /// <summary>
        /// Gets or sets BiologicalIndicatorEnabled
        /// </summary>
        public bool BiologicalIndicatorEnabled { get; set; }
        /// <summary>
        /// Gets or sets ItemCount
        /// </summary>
        public int ItemCount { get; set; }
        /// <summary>
        /// Gets or sets ProcessingBatchCycleIds
        /// </summary>
        public IEnumerable<int> ProcessingBatchCycleIds { get; set; }
        /// <summary>
        /// Gets or sets ProcessingDecontaminationTaskIds
        /// </summary>
        public IEnumerable<int> ProcessingDecontaminationTaskIds { get; set; }
        /// <summary>
        /// Gets or sets FacilityName
        /// </summary>
        public string FacilityName { get; set; }
        /// <summary>
        /// Gets or sets LabourLevelId
        /// </summary>
        public int LabourLevelId { get; set; }
        /// <summary>
        /// Gets or sets Manufacturer
        /// </summary>
        public ManufacturerDataContract Manufacturer { get; set; }
        public int? CoolingTime { get; set; }
        /// <summary>
        /// Gets or sets QualityId
        /// </summary>
        public short QualityId { get; set; }
        public int? ContainerMasterBlueprintId { get; set; }
    }
}
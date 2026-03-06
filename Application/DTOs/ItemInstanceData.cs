using System;
using System.Collections.Generic;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    public sealed partial class ItemInstanceData
    {

        public ItemInstanceData()
        {

        }

        /// <summary>
        /// Create operation
        /// </summary>
        public static ItemInstanceData Create(IItemInstance genericObj,bool wasLastAuditException) => new ItemInstanceData(genericObj) { LastAuditException = wasLastAuditException };
        /// <summary>
        /// Gets or sets LastIndividualInstrumentTrackEvent
        /// </summary>
        public IndividualInstrumentTrackingEventData LastIndividualInstrumentTrackEvent { get; set; }
        /// <summary>
        /// Gets or sets SaveComponentAction
        /// </summary>
        public SaveComponentAction SaveComponentAction { get; set; }
        /// <summary>
        /// Gets or sets SaveComponentState
        /// </summary>
        public SaveComponentState SaveComponentState { get; set; }
        /// <summary>
        /// Gets or sets ArchivedReasonText
        /// </summary>
        public string ArchivedReasonText { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets ActiveItemMasterText
        /// </summary>
        public string ActiveItemMasterText { get; set; }
        /// <summary>
        /// Gets or sets ItemId
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterExternalId
        /// </summary>
        public string ItemMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets ItemMasterId
        /// </summary>
        public int ItemMasterId { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserName
        /// </summary>
        public string CreatedUserName { get; set; }
        /// <summary>
        /// Gets or sets CreatedUserId
        /// </summary>
        public int CreatedUserId { get; set; }
        /// <summary>
        /// Gets or sets CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets IsItemPacked
        /// </summary>
        public bool IsItemPacked { get; set; }
        /// <summary>
        /// Gets or sets Identifiers
        /// </summary>
        public List<ItemInstanceIdentifierData> Identifiers { get; set; }
        /// <summary>
        /// Gets or sets ItemInstanceValue
        /// </summary>
        public string ItemInstanceValue { get; set; }
        /// <summary>
        /// Gets or sets ContainerName
        /// </summary>
        public string ContainerName { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ItemStatusText
        /// </summary>
        public string ItemStatusText { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundId
        /// </summary>
        public int TurnaroundId { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundExternalId
        /// </summary>
        public long TurnaroundExternalId { get; set; }
        /// <summary>
        /// Gets or sets CustomerFacilityId
        /// </summary>
        public short CustomerFacilityId { get; set; }
        /// <summary>
        /// Gets or sets LastAuditException
        /// </summary>
        public bool LastAuditException { get; set; }
    }
}

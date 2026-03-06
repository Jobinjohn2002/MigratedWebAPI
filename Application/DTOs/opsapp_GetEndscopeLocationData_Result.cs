using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    
    public partial class opsapp_GetEndscopeLocationData_Result
    {
        /// <summary>
        /// Gets or sets ContainerMasterText
        /// </summary>
        public string ContainerMasterText { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        public Nullable<System.DateTime> ContainerMasterArchived { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterItemTypeId
        /// </summary>
        public short ContainerMasterItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets TrackIndividualInstruments
        /// </summary>
        public bool TrackIndividualInstruments { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterMachineTypeId
        /// </summary>
        public byte ContainerMasterMachineTypeId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeParentItemTypeId
        /// </summary>
        public Nullable<short> ItemTypeParentItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeText
        /// </summary>
        public string ItemTypeText { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceId
        /// </summary>
        public int ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceFacilityId
        /// </summary>
        public short ContainerInstanceFacilityId { get; set; }
        public System.DateTime ContainerInstanceCreated { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundWarningCount
        /// </summary>
        public int TurnaroundWarningCount { get; set; }
        public Nullable<System.DateTime> ContainerInstanceArchived { get; set; }
        /// <summary>
        /// Gets or sets Linear1dBarcodeId
        /// </summary>
        public Nullable<short> Linear1dBarcodeId { get; set; }
        /// <summary>
        /// Gets or sets Datamatrix2dBarcodeId
        /// </summary>
        public Nullable<short> Datamatrix2dBarcodeId { get; set; }
        /// <summary>
        /// Gets or sets IsIdentifiable
        /// </summary>
        public bool IsIdentifiable { get; set; }
        /// <summary>
        /// Gets or sets CurrentLocationId
        /// </summary>
        public Nullable<int> CurrentLocationId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointId
        /// </summary>
        public int DeliveryPointId { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointText
        /// </summary>
        public string DeliveryPointText { get; set; }
        public Nullable<System.DateTime> CurrentTurnaroundSterileExpiryDate { get; set; }
        /// <summary>
        /// Gets or sets CurrentTurnaroundEventEventTypeId
        /// </summary>
        public short CurrentTurnaroundEventEventTypeId { get; set; }
        public System.DateTime TunraroundEventCreated { get; set; }
    }
}

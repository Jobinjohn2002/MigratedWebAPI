using System;
using System.Collections.Generic;
//using SynergyApplicationFrameworkApi.Application.DTOs.ContainerInstanceIdentifiers;
using SynergyApplicationFrameworkApi.Application.DTOs;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Pathway;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// AssetDetailsDataContract
    /// </summary>
    public class AssetDetailsDataContract : BaseReplyDataContract
    {
        public int? ContainerInstanceId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstancePrimaryId
        /// </summary>
        public string ContainerInstancePrimaryId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterId
        /// </summary>
        public int ContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionId
        /// </summary>
        public int ContainerMasterDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterName
        /// </summary>
        public string ContainerMasterName { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterExternalId
        /// </summary>
        public string ContainerMasterExternalId { get; set; }
        /// <summary>
        /// Gets or sets CustomerName
        /// </summary>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets CustomerId
        /// </summary>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        public bool? CustomerOnStop { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeText
        /// </summary>
        public string ItemTypeText { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets MachineTypeId
        /// </summary>
        public int MachineTypeId { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeId
        /// </summary>
        public int BaseItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeText
        /// </summary>
        public string BaseItemTypeText { get; set; }
        /// <summary>
        /// Gets or sets TrackIndividualInstruments
        /// </summary>
        public bool TrackIndividualInstruments { get; set; }
        /// <summary>
        /// Gets or sets IsLoanSetExpired
        /// </summary>
        public bool IsLoanSetExpired { get; set; }
        /// <summary>
        /// Gets or sets IsContainerMasterArchived
        /// </summary>
        public bool IsContainerMasterArchived { get; set; }
        /// <summary>
        /// Gets or sets IsContainerInstanceArchived
        /// </summary>
        public bool IsContainerInstanceArchived { get; set; }
        /// <summary>
        /// Gets or sets TurnaroundWarningCount
        /// </summary>
        public int TurnaroundWarningCount { get; set; }
        public int? Linear1DBarcodeId { get; set; }
        public int? Datamatrix2DBarcodeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceCreated
        /// </summary>
        public DateTime ContainerInstanceCreated { get; set; }
        public int? FacilityId { get; set; }
        /// <summary>
        /// Gets or sets IsNonSterile
        /// </summary>
        public bool IsNonSterile { get; set; }
        /// <summary>
        /// Gets or sets DecontaminationTasks
        /// </summary>
        public List<DecontaminationTaskDataContract> DecontaminationTasks { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDeliveryPoints
        /// </summary>
        public List<DeliveryPointDataContract> ContainerMasterDeliveryPoints { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceDeliveryPoint
        /// </summary>
        public DeliveryPointDataContract ContainerInstanceDeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirements
        /// </summary>
        public List<ServiceRequirementDataContract> ServiceRequirements { get; set; }
        /// <summary>
        /// Gets or sets IsIdentifiable
        /// </summary>
        public bool IsIdentifiable { get; set; }
        /// <summary>
        /// Gets or sets TransferNoteReRouteEventTypeList
        /// </summary>
        public List<EventTypeListDataContract> TransferNoteReRouteEventTypeList { get; set; }
        /// <summary>
        /// Gets or sets MoreThanOneReRouteEvent
        /// </summary>
        public bool MoreThanOneReRouteEvent { get; set; }
        public DateTime? LastLabelPrinted { get; set; }
        /// <summary>
        /// Gets or sets WeighingRequired
        /// </summary>
        public bool WeighingRequired { get; set; }
        public decimal? PreWashRefWeightKg { get; set; }
        public decimal? PostWashRefWeightKg { get; set; }
        /// <summary>
        /// Gets or sets WeighingRequiredForPreWash
        /// </summary>
        public bool WeighingRequiredForPreWash { get; set; }
        /// <summary>
        /// Gets or sets WeighingRequiredForPostWash
        /// </summary>
        public bool WeighingRequiredForPostWash { get; set; }
        /// <summary>
        /// Gets or sets InstrumentsToWeigh
        /// </summary>
        public int InstrumentsToWeigh { get; set; }
        /// <summary>
        /// Gets or sets HasBeenPreWashWeighed
        /// </summary>
        public bool HasBeenPreWashWeighed { get; set; }
        /// <summary>
        /// Gets or sets HasBeenPostWashWeighed
        /// </summary>
        public bool HasBeenPostWashWeighed { get; set; }
        /// <summary>
        /// Gets or sets HasIdentifiedItems
        /// </summary>
        public bool HasIdentifiedItems { get; set; }
        /// <summary>
        /// Gets or sets ContainerAuditRules
        /// </summary>
        public List<AuditRuleContract> ContainerAuditRules { get; set; }
        /// <summary>
        /// Gets or sets LastWeighingEventWasCancelledPreWash
        /// </summary>
        public bool LastWeighingEventWasCancelledPreWash { get; set; }
        /// <summary>
        /// Gets or sets LastWeighingEventWasCancelledPostWash
        /// </summary>
        public bool LastWeighingEventWasCancelledPostWash { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterProcessingBatchCycles
        /// </summary>
        public BatchCyclesDataContract ContainerMasterProcessingBatchCycles { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceIdentifiers
        /// </summary>
        public List<ContainerInstanceIdentifierDataContract> ContainerInstanceIdentifiers { get; set; }
        public Pathway.Enums.QualityIdentifier? Quality { get; set; }
        public Pathway.Enums.QualityTypeIdentifier? QualityType { get; set; }
        public int? BlueprintContainerMasterId { get; set; }
        /// <summary>
        /// Gets or sets AutomaticEventDetails
        /// </summary>
        public List<AutomaticEventDetailsDataContract> AutomaticEventDetails { get; set; }
    }
}
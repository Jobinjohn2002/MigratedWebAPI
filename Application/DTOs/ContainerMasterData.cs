using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    public partial class ContainerMasterData
    {
        /// <summary>
        /// Gets or sets CustomerDefinitionId
        /// </summary>
        public int CustomerDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterDefinitionTypeId
        /// </summary>
        public short ContainerMasterDefinitionTypeId { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterQualityId
        /// </summary>
        public short ContainerMasterQualityId { get; set; }
        /// <summary>
        /// Gets or sets CalculatedPriceCategoryExternalId
        /// </summary>
        public string CalculatedPriceCategoryExternalId { get; set; }
        public int? ManualPriceCategoryDefinitionId { get; set; }
        /// <summary>
        /// Gets or sets BaseReprocessingPrice
        /// </summary>
        public decimal BaseReprocessingPrice { get; set; }
        public decimal? ManualReprocessingPrice { get; set; }
        /// <summary>
        /// Gets or sets BaseSingleUsePrice
        /// </summary>
        public decimal BaseSingleUsePrice { get; set; }
        public decimal? ManualSingleUsePrice { get; set; }
        /// <summary>
        /// Gets or sets ReprocessingIndexation
        /// </summary>
        public decimal ReprocessingIndexation { get; set; }
        /// <summary>
        /// Gets or sets SingleUseIndexation
        /// </summary>
        public decimal SingleUseIndexation { get; set; }
        /// <summary>
        /// Gets or sets CostingModel
        /// </summary>
        public CostingModelData CostingModel { get; set; }
        /// <summary>
        /// Gets or sets ContainerContents
        /// </summary>
        public IList<ContainerContentData> ContainerContents { get; set; }
        /// <summary>
        /// Gets or sets ContainerComponents
        /// </summary>
        public IList<ComponentData> ContainerComponents { get; set; }
        /// <summary>
        /// Gets or sets ContainerComponentNotes
        /// </summary>
        public IList<ComponentNoteData> ContainerComponentNotes { get; set; }
        /// <summary>
        /// Gets or sets ContainerMasterNotes
        /// </summary>
        public IList<ContainerMasterNoteData> ContainerMasterNotes { get; set; }
        /// <summary>
        /// Gets or sets Warnings
        /// </summary>
        public IList<WarningData> Warnings { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoints
        /// </summary>
        public IList<DeliveryPointData> DeliveryPoints { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPointIDs
        /// </summary>
        public IList<int> DeliveryPointIDs { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeText
        /// </summary>
        public string ItemTypeText  { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeId
        /// </summary>
        public int BaseItemTypeId  { get; set; }
        /// <summary>
        /// Gets or sets BaseItemTypeText
        /// </summary>
        public string BaseItemTypeText  { get; set; }
        /// <summary>
        /// Gets or sets FinancialComponentCount
        /// </summary>
        public int FinancialComponentCount { get; set; }
        public int? PriceCategoryId { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryText
        /// </summary>
        public string PriceCategoryText { get; set; }
        public int? PriceCategoryGroupId { get; set; }
        /// <summary>
        /// Gets or sets PriceCategoryGroupText
        /// </summary>
        public string PriceCategoryGroupText { get; set; }
        /// <summary>
        /// Gets or sets IndexedPriceCategoryCharge
        /// </summary>
        public decimal IndexedPriceCategoryCharge { get; set; }
        /// <summary>
        /// Gets or sets IndexedSingleUseItemCharge
        /// </summary>
        public decimal IndexedSingleUseItemCharge { get; set; }
        /// <summary>
        /// Gets or sets IndexedAdjustment
        /// </summary>
        public decimal IndexedAdjustment { get; set; }
        /// <summary>
        /// Gets or sets IndexedTotalCharge
        /// </summary>
        public decimal IndexedTotalCharge { get; set; }
        /// <summary>
        /// Gets or sets TotalNumOfContainerInstances
        /// </summary>
        public int TotalNumOfContainerInstances { get; set; }
        /// <summary>
        /// Gets or sets NumOfContainerInstancesByDeliveryPoint
        /// </summary>
        public int NumOfContainerInstancesByDeliveryPoint { get; set; }
        /// <summary>
        /// Gets or sets IsTrayChangeChargeable
        /// </summary>
        public bool IsTrayChangeChargeable { get; set; }
        
        public ContainerMasterData()
        {
        }
        /// <summary>
        /// Gets or sets IsUpdatedWarnings
        /// </summary>
        public bool IsUpdatedWarnings { get; set; }
        /// <summary>
        /// Gets or sets ProcessingBatchCycleIds
        /// </summary>
        public List<int> ProcessingBatchCycleIds { get; set; }
        /// <summary>
        /// Gets or sets DecontaminationTaskIds
        /// </summary>
        public List<int> DecontaminationTaskIds { get; set; } 
    }
}

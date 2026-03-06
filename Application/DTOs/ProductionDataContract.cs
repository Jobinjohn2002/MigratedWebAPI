using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// 
    /// </summary>
    /// <summary>
    /// ProductionDataContract
    /// </summary>
    public class ProductionDataContract
    {    
        /// <summary>
        /// item count
        /// </summary>
        /// <summary>
        /// Gets or sets ItemCount
        /// </summary>
        public int ItemCount { get; set; }

        /// <summary>
        /// Turnaround data's
        /// </summary>
        /// <summary>
        /// Gets or sets TurnaroundDatas
        /// </summary>
        public IList<BasicTurnaroundData> TurnaroundDatas { get; set; }

        /// <summary>
        /// Expired item count
        /// </summary>
        /// <summary>
        /// Gets or sets ExpiredItemsCount
        /// </summary>
        public int ExpiredItemsCount { get; set; }

        /// <summary>
        /// NearExpiry item count
        /// </summary>
        /// <summary>
        /// Gets or sets NearExpiryItemsCount
        /// </summary>
        public int NearExpiryItemsCount { get; set; }
    }
    /// <summary>
    /// ProductionDataItem
    /// </summary>
    public class ProductionDataItem
    {
        /// <summary>
        /// Gets or sets BaseItemType
        /// </summary>
        public string BaseItemType { get; set; }
        public int? BaseItemTypeID { get; set; }
        /// <summary>
        /// Gets or sets ContainerInstanceExternalID
        /// </summary>
        public string ContainerInstanceExternalID { get; set; }
        public int? ContainerInstanceID { get; set; }
        /// <summary>
        /// Gets or sets ContainerMaster
        /// </summary>
        public string ContainerMaster { get; set; }
        public int? CustomerDefinitionID { get; set; }
        /// <summary>
        /// Gets or sets Customer
        /// </summary>
        public string Customer { get; set; }
        public int? DeliveryPointID { get; set; }
        /// <summary>
        /// Gets or sets DeliveryPoint
        /// </summary>
        public string DeliveryPoint { get; set; }
        public int? EventTypeID { get; set; }
        public byte? EventTypeCategoryId { get; set; }
        /// <summary>
        /// Gets or sets EventType
        /// </summary>
        public string EventType { get; set; }
        /// <summary>
        /// Gets or sets Expired
        /// </summary>
        public bool Expired { get; set; }
        public DateTime? ExpiresOn { get; set; }
        public DateTime? LastStatusChangeOn { get; set; }
        public bool? IsIdentifiable { get; set; }
        /// <summary>
        /// Gets or sets IsQuarantined
        /// </summary>
        public bool IsQuarantined { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public bool IsFastTrack { get; set; }
        /// <summary>
        /// Gets or sets QuarantineReason
        /// </summary>
        public string QuarantineReason { get; set; }
        /// <summary>
        /// Gets or sets ServiceRequirement
        /// </summary>
        public string ServiceRequirement { get; set; }
        public int? FirstServiceRequirementId { get; set; }
        /// <summary>
        /// Gets or sets SubItemType
        /// </summary>
        public string SubItemType { get; set; }
        public int? SubItemTypeID { get; set; }
        public long? TurnaroundExternalID { get; set; }
        public int? TurnaroundID { get; set; }
        public int? TurnaroundWHID { get; set; }
        /// <summary>
        /// Gets or sets MachineName
        /// </summary>
        public string MachineName { get; set; }
        /// <summary>
        /// Gets or sets MachineType
        /// </summary>
        public string MachineType { get; set; }
        public int? InstrumentCount { get; set; }
        public int? ItemExceptionCount { get; set; }
        public double? Priority { get; set; }
        public DateTime? SterileExpiryDate { get; set; }
        /// <summary>
        /// Gets or sets SterileExpired
        /// </summary>
        public bool SterileExpired { get; set; }
        public int? ContractualEndEvent { get; set; }
    }
    /// <summary>
    /// ExtendedProductionDataItem
    /// </summary>
    public class ExtendedProductionDataItem : ProductionDataItem
    {
        public int? BaseItemTypeCount { get; set; }
        public int? BaseItemTypeExpiredCount { get; set; }
        public int? CustomerCount { get; set; }
        public int? CustomerExpiredCount { get; set; }
        public int? DeliveryPointCount { get; set; }
        public int? DeliveryPointExpiredCount { get; set; }
        public int? EventTypeCount { get; set; }
        public int? EventTypeExpiredCount { get; set; }
        public int? SubItemTypeCount { get; set; }
        public int? SubItemTypeExpiredCount { get; set; }
        public int? ServiceRequirementTypeCount { get; set; }
        public int? ServiceRequirementExpiredCount { get; set; }
        
    }
    /// <summary>
    /// ProductionDataCategoryGroup
    /// </summary>
    public class ProductionDataCategoryGroup
    {
        public ProductionDataCategoryGroup(string name)
        {
            this.Categories = new Dictionary<string, DataContracts.ProductionDataCategory>();
            this.Name = name;
        }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Categories
        /// </summary>
        public Dictionary<string, ProductionDataCategory> Categories { get; set; }
    }
    /// <summary>
    /// ProductionDataCategory
    /// </summary>
    public class ProductionDataCategory
    {
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Gets or sets ExpiredCount
        /// </summary>
        public int ExpiredCount { get; set; }
        /// <summary>
        /// Gets or sets ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Gets or sets Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets ParentID
        /// </summary>
        public int ParentID { get; set; }
        /// <summary>
        /// Gets or sets InstrumentCount
        /// </summary>
        public int InstrumentCount { get; set; }
        /// <summary>
        /// Gets or sets IsFastTrack
        /// </summary>
        public bool IsFastTrack { get; set; } = false;
    }
    [Serializable]
    [KnownType(typeof(ProductionDataCategoryGroup))]
    [KnownType(typeof(ProductionDataCategory))]
    [KnownType(typeof(ProductionDataItem))]
    [KnownType(typeof(ExtendedProductionDataItem))]
    /// <summary>
    /// ProductionData
    /// </summary>
    public class ProductionData
    {
        public ProductionData()
        {
            this.Groups = new Dictionary<string, DataContracts.ProductionDataCategoryGroup>();
            this.Items = new List<ProductionDataItem>();
        }
        /// <summary>
        /// Gets or sets Groups
        /// </summary>
        public Dictionary<string, ProductionDataCategoryGroup> Groups { get; set; }
        /// <summary>
        /// Gets or sets Items
        /// </summary>
        public List<ProductionDataItem> Items { get; set; }

        /// <summary>
        /// GetGroup operation
        /// </summary>
        public ProductionDataCategoryGroup GetGroup(string name)
        {
            ProductionDataCategoryGroup group = null;

            if (Groups != null)
            {
                group = (Groups.ContainsKey(name)) ? Groups[name] : this.Groups[name] = new ProductionDataCategoryGroup(name);
            }

            return group;
        }
    }
}

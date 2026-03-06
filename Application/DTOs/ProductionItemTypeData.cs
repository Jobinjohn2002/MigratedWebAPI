using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ProductionItemTypeData
    /// </summary>
    public class ProductionItemTypeData
    {
        public ProductionItemTypeData(int itemTypeId,string itemTypeName,int count)
        {
            ItemTypeId = itemTypeId;
            ItemTypeName = itemTypeName;
            Count = count;
        }
        /// <summary>
        /// Gets or sets ItemTypeId
        /// </summary>
        public int ItemTypeId { get; set; }
        /// <summary>
        /// Gets or sets ItemTypeName
        /// </summary>
        public string ItemTypeName { get; set; }
        /// <summary>
        /// Gets or sets Count
        /// </summary>
        public int Count { get; set; }
        public IList<ProductionStationData> ProductionStations{ get;set;}
    }
}

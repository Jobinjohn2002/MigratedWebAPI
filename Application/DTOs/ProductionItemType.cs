using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    /// <summary>
    /// ProductionItemType
    /// </summary>
    public class ProductionItemType
    {
        public ProductionItemType(int itemTypeId,string itemTypeName,int count,IList<IProductionStation> productionStations)
        {
            ItemTypeId = itemTypeId;
            ItemTypeName = itemTypeName;
            Count = count;
            ProductionStations = productionStations;
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

        /// <summary>
        /// Gets or sets ProductionStations
        /// </summary>
        public IList<IProductionStation> ProductionStations { get; set; }
    }
}

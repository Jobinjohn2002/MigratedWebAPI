using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SynergyApplicationFrameworkApi.Application.DTOs
{
    [Serializable]
    /// <summary>
    /// ContainerSpecificationData
    /// </summary>
    public class ContainerSpecificationData : DataContractBase, IContainerSpecificationData
    {
        /// <summary>
        /// Gets or sets ItemMaster
        /// </summary>
        public ItemMasterData ItemMaster { get; set; }
        /// <summary>
        /// Gets or sets BaseItemType
        /// </summary>
        public ItemTypeData BaseItemType { get; set; }
        /// <summary>
        /// Gets or sets ChildItemType
        /// </summary>
        public ItemTypeData ChildItemType { get; set; }
        /// <summary>
        /// Gets or sets ContainerContent
        /// </summary>
        public ContainerContentData ContainerContent { get; set; }
        /// <summary>
        /// Gets or sets ItemInstances
        /// </summary>
        public List<ItemInstanceData> ItemInstances { get; set; }
        /// <summary>
        /// Gets or sets ItemExceptions
        /// </summary>
        public List<ItemExceptionGroupedData> ItemExceptions { get; set; }
        /// <summary>
        /// Gets or sets EntityKeyValue
        /// </summary>
        public string EntityKeyValue { get; set; }
    }
}
